using WispVpn.Core.Models;
using WispVpn.Core.Networking;

namespace WispVpn.Core.Tunnel;

public interface ITunnelService
{
    ConnectionState State { get; }

    event EventHandler<ConnectionState>? StateChanged;

    Task ConnectAsync(WireGuardConfig config, CancellationToken cancellationToken = default);

    Task DisconnectAsync(CancellationToken cancellationToken = default);
}
