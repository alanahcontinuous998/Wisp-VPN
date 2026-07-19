using WispVpn.Core.Models;
using WispVpn.Core.Networking;

namespace WispVpn.Core.Tunnel;

/// <summary>
/// Реализация <see cref="ITunnelService"/> поверх WireGuard.
/// </summary>
/// <remarks>
/// НЕ РЕАЛИЗОВАНО. Управление состоянием подключения (<see cref="State"/>, события)
/// уже работает, но само поднятие туннеля — нет.
/// План (см. docs/ARCHITECTURE.md, docs/ROADMAP.md v0.2):
///  - установка/настройка сетевого адаптера (WireGuardNT / wintun);
///  - запуск и мониторинг процесса туннеля;
///  - применение <see cref="WireGuardConfig"/> к адаптеру.
/// </remarks>
public sealed class WireGuardTunnelService : ITunnelService
{
    private ConnectionState _state = ConnectionState.Disconnected;

    public ConnectionState State
    {
        get => _state;
        private set
        {
            if (_state == value)
            {
                return;
            }

            _state = value;
            StateChanged?.Invoke(this, value);
        }
    }

    public event EventHandler<ConnectionState>? StateChanged;

    public Task ConnectAsync(WireGuardConfig config, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(config);

        State = ConnectionState.Connecting;
        try
        {
            throw new NotImplementedException(
                "Поднятие WireGuard-туннеля ещё не реализовано. См. docs/ROADMAP.md, v0.2.");
        }
        catch
        {
            State = ConnectionState.Error;
            throw;
        }
    }

    public Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        State = ConnectionState.Disconnecting;
        // TODO: остановить процесс/адаптер туннеля, когда появится реализация ConnectAsync.
        State = ConnectionState.Disconnected;
        return Task.CompletedTask;
    }
}
