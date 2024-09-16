using QD_Checklists.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace QD_Checklists.Views.Pages {
    /// <summary>
    /// Interaction logic for ChecklistListPage.xaml
    /// </summary>
    public partial class ChecklistListPage : INavigableView<ChecklistListViewModel> {
        public ChecklistListViewModel ViewModel { get; }

        public ChecklistListPage(ChecklistListViewModel viewModel) {
            Loaded += ChecklistListPage_Loaded; // Subscribe to the Loaded event
            
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
        private void ChecklistListPage_Loaded(object sender, System.Windows.RoutedEventArgs e) {
            if (ViewModel != null) {
               ViewModel.FetchChecklists();
            }
        }
    }
}
