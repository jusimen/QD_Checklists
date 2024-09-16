using QD_Checklists.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace QD_Checklists.Views.Pages {
    public partial class DashboardPage : INavigableView<DashboardViewModel> {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel) {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
