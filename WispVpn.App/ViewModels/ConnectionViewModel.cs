using WispVpn.Core.Models;
using WispVpn.Core.Networking;
using WispVpn.Core.Servers;
using WispVpn.Core.Tunnel;

namespace WispVpn.App.ViewModels;

public sealed class ConnectionViewModel : ViewModelBase
{
    private readonly ITunnelService _tunnelService;
    private readonly IServerCatalogService _serverCatalog;

    private ServerProfile? _selectedServer;
    private ConnectionState _state;
    private string _statusMessage = "Отключено";

    public ConnectionViewModel(ITunnelService tunnelService, IServerCatalogService serverCatalog)
    {
        _tunnelService = tunnelService;
        _serverCatalog = serverCatalog;
        _tunnelService.StateChanged += (_, state) => State = state;

        ConnectCommand = new RelayCommand(ConnectOrDisconnectAsync);
        _ = LoadDefaultServerAsync();
    }

    public ServerProfile? SelectedServer
    {
        get => _selectedServer;
        set => SetField(ref _selectedServer, value);
    }

    public ConnectionState State
    {
        get => _state;
        private set => SetField(ref _state, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        private set => SetField(ref _statusMessage, value);
    }

    public RelayCommand ConnectCommand { get; }

    private async Task LoadDefaultServerAsync()
    {
        var servers = await _serverCatalog.GetServersAsync();
        SelectedServer = servers.FirstOrDefault();
    }

    private async Task ConnectOrDisconnectAsync()
    {
        if (State == ConnectionState.Connected)
        {
            await _tunnelService.DisconnectAsync();
            StatusMessage = "Отключено";
            return;
        }

        if (SelectedServer is null)
        {
            StatusMessage = "Выберите сервер";
            return;
        }

        try
        {
            // TODO: подставлять реальный конфиг, полученный для SelectedServer, а не пустой.
            await _tunnelService.ConnectAsync(new WireGuardConfig());
            StatusMessage = "Подключено";
        }
        catch (NotImplementedException)
        {
            StatusMessage = "Подключение ещё не реализовано (см. ROADMAP.md)";
        }
    }
}
