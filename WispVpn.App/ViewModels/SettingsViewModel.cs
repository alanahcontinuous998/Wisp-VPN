namespace WispVpn.App.ViewModels;

/// <summary>
/// Настройки приложения. Пока хранятся только в памяти — сохранение на диск
/// (реестр/файл конфигурации) ещё не реализовано, см. docs/ROADMAP.md.
/// </summary>
public sealed class SettingsViewModel : ViewModelBase
{
    private bool _killSwitchEnabled = true;
    private bool _launchAtStartup = true;
    private bool _autoSelectServer;
    private bool _notificationsEnabled;

    public bool KillSwitchEnabled
    {
        get => _killSwitchEnabled;
        set => SetField(ref _killSwitchEnabled, value);
    }

    public bool LaunchAtStartup
    {
        get => _launchAtStartup;
        set => SetField(ref _launchAtStartup, value);
    }

    public bool AutoSelectServer
    {
        get => _autoSelectServer;
        set => SetField(ref _autoSelectServer, value);
    }

    public bool NotificationsEnabled
    {
        get => _notificationsEnabled;
        set => SetField(ref _notificationsEnabled, value);
    }
}
