using System.Windows.Controls;
using WispVpn.App.ViewModels;
using WispVpn.Core.Servers;

namespace WispVpn.App.Views;

public partial class ServerListView : UserControl
{
    public ServerListView()
    {
        InitializeComponent();
        DataContext = new ServerListViewModel(new StaticServerCatalogService());
    }
}
