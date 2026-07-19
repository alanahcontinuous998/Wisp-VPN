namespace WispVpn.Core.Networking;

/// <summary>
/// In-memory представление конфигурации туннеля в формате WireGuard ([Interface] / [Peer]).
/// См. пример без реальных ключей в /configs/sample.conf.
/// </summary>
public sealed class WireGuardConfig
{
    public string? PrivateKey { get; set; }
    public string? Address { get; set; }
    public string? Dns { get; set; }

    public string? PeerPublicKey { get; set; }
    public string? Endpoint { get; set; }
    public string? AllowedIPs { get; set; }
    public int PersistentKeepalive { get; set; } = 25;
}
