using QD_Checklists.ViewModels.Pages;
using System.Windows.Navigation;
using Wpf.Ui.Controls;
using MessageBox = System.Windows.MessageBox;

namespace QD_Checklists.Views.Pages {
    /// <summary>  
    /// Interaction logic for AddChecklistPage.xaml  
    /// </summary>  
    public partial class ChecklistAddPage : INavigableView<ChecklistAddViewModel> {

        public ChecklistAddViewModel ViewModel { get; set; }

        public ChecklistAddPage(ChecklistAddViewModel viewModel) {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
