using System.Collections.ObjectModel;
using WispVpn.Core.Models;
using WispVpn.Core.Networking;
using WispVpn.Core.Servers;

namespace WispVpn.App.ViewModels;

public sealed class ServerListViewModel : ViewModelBase
{
    private readonly IServerCatalogService _serverCatalog;

    public ServerListViewModel(IServerCatalogService serverCatalog)
    {
        _serverCatalog = serverCatalog;
        _ = LoadAsync();
    }

    public ObservableCollection<ServerRowViewModel> Servers { get; } = new();

    private async Task LoadAsync()
    {
        var servers = await _serverCatalog.GetServersAsync();

        foreach (var server in servers)
        {
            var row = new ServerRowViewModel(server);
            Servers.Add(row);

            var latency = await PingProbe.MeasureRoundtripAsync(server.Host);
            row.LatencyMs = latency;
        }
    }
}

public sealed class ServerRowViewModel : ViewModelBase
{
    private long? _latencyMs;

    public ServerRowViewModel(ServerProfile server)
    {
        Server = server;
    }

    public ServerProfile Server { get; }

    public long? LatencyMs
    {
        get => _latencyMs;
        set => SetField(ref _latencyMs, value);
    }
}
