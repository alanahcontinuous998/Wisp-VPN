namespace WispVpn.Core.Networking;

/// <summary>
/// Простой парсер текстового формата WireGuard-конфига (секции [Interface] / [Peer]).
/// Не выполняет валидацию криптографических значений — только разбор текста в структуру.
/// </summary>
public static class WireGuardConfigParser
{
    public static WireGuardConfig Parse(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        var config = new WireGuardConfig();
        var section = string.Empty;

        foreach (var rawLine in text.Split('\n'))
        {
            var line = rawLine.Trim().TrimEnd('\r');

            if (line.Length == 0 || line.StartsWith('#'))
            {
                continue;
            }

            if (line.StartsWith('[') && line.EndsWith(']'))
            {
                section = line[1..^1].Trim().ToLowerInvariant();
                continue;
            }

            var separatorIndex = line.IndexOf('=');
            if (separatorIndex < 0)
            {
                continue;
            }

            var key = line[..separatorIndex].Trim().ToLowerInvariant();
            var value = line[(separatorIndex + 1)..].Trim();

            ApplyKeyValue(config, section, key, value);
        }

        return config;
    }

    private static void ApplyKeyValue(WireGuardConfig config, string section, string key, string value)
    {
        switch (section)
        {
            case "interface":
                switch (key)
                {
                    case "privatekey": config.PrivateKey = value; break;
                    case "address": config.Address = value; break;
                    case "dns": config.Dns = value; break;
                }
                break;

            case "peer":
                switch (key)
                {
                    case "publickey": config.PeerPublicKey = value; break;
                    case "endpoint": config.Endpoint = value; break;
                    case "allowedips": config.AllowedIPs = value; break;
                    case "persistentkeepalive":
                        if (int.TryParse(value, out var keepalive))
                        {
                            config.PersistentKeepalive = keepalive;
                        }
                        break;
                }
                break;
        }
    }
}
