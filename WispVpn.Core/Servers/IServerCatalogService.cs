using WispVpn.Core.Models;

namespace WispVpn.Core.Servers;

public interface IServerCatalogService
{
    Task<IReadOnlyList<ServerProfile>> GetServersAsync(CancellationToken cancellationToken = default);
}
