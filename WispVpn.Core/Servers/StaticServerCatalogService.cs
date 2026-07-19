using WispVpn.Core.Models;

namespace WispVpn.Core.Servers;

/// <summary>
/// Временный источник списка серверов на основе статического набора данных.
/// Будет заменён на загрузку актуального списка, когда появится backend (см. docs/ROADMAP.md).
/// </summary>
public sealed class StaticServerCatalogService : IServerCatalogService
{
    private static readonly IReadOnlyList<ServerProfile> Servers = new[]
    {
        new ServerProfile("ams-1", "Amsterdam #1", "🇳🇱", "ams1.example.invalid", 51820),
        new ServerProfile("fra-2", "Frankfurt #2", "🇩🇪", "fra2.example.invalid", 51820),
        new ServerProfile("hel-1", "Helsinki #1", "🇫🇮", "hel1.example.invalid", 51820),
        new ServerProfile("waw-1", "Warsaw #1", "🇵🇱", "waw1.example.invalid", 51820),
    };

    public Task<IReadOnlyList<ServerProfile>> GetServersAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Servers);
    }
}
