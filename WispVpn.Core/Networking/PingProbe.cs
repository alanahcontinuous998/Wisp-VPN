using System.Net.NetworkInformation;

namespace WispVpn.Core.Networking;

/// <summary>
/// Измеряет приблизительную задержку до хоста (используется для отображения "ms" у сервера в списке).
/// </summary>
public static class PingProbe
{
    public static async Task<long?> MeasureRoundtripAsync(string host, int timeoutMs = 1500)
    {
        try
        {
            using var ping = new Ping();
            var reply = await ping.SendPingAsync(host, timeoutMs);
            return reply.Status == IPStatus.Success ? reply.RoundtripTime : null;
        }
        catch (PingException)
        {
            return null;
        }
    }
}
