using System.Windows.Controls;
using WispVpn.App.ViewModels;

namespace WispVpn.App.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
        DataContext = new SettingsViewModel();
    }
}
