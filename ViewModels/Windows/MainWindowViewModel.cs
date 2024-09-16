using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace QD_Checklists.ViewModels.Windows {
    public partial class MainWindowViewModel : ObservableObject {
        [ObservableProperty]
        private string _applicationTitle = "Quadrante - Desk";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            // Checklists
            new NavigationViewItem() {
                Content = "Checklists",
                Icon = new SymbolIcon { Symbol = SymbolRegular.TaskListLtr24 },
                TargetPageType = typeof(Views.Pages.ChecklistListPage),
            },

            // Templates
            new NavigationViewItem() {
                Content = "Templates",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Apps24 },
                TargetPageType = typeof(Views.Pages.DashboardPage),
            },

            // Pastas
            new NavigationViewItem() {
                Content = "Pastas",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Folder24 },
                TargetPageType = typeof(Views.Pages.DashboardPage),
            },

            // Utilizadores
            new NavigationViewItem() {
                Content = "Utilzadores",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Person24 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}
