using System.Windows.Controls;
using WispVpn.App.ViewModels;
using WispVpn.Core.Servers;
using WispVpn.Core.Tunnel;

namespace WispVpn.App.Views;

public partial class ConnectionView : UserControl
{
    public ConnectionView()
    {
        InitializeComponent();

        // TODO: заменить на внедрение зависимостей через общий composition root,
        // когда сервисов станет больше одного экрана.
        DataContext = new ConnectionViewModel(new WireGuardTunnelService(), new StaticServerCatalogService());
    }
}
