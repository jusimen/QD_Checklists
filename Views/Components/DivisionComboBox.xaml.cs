using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.ViewModels;
using System.Windows.Controls;

namespace QD_Checklists.Views.Components {
    /// <summary>
    /// Interaction logic for DivisionComboBox.xaml
    /// </summary>
    public partial class DivisionComboBox : UserControl {

        public DivisionComboBoxViewModel ViewModel { get; set; }

        public DivisionComboBox() {
            InitializeComponent();
            ViewModel = new DivisionComboBoxViewModel(App.GetService<IAppDbContextFactory>());
            DataContext = ViewModel;
        }

        // Dependency Property for Label
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(DivisionComboBox), new PropertyMetadata(string.Empty));

        public string Label {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Dependency Property to control the visibility of the asterisk
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(DivisionComboBox), new PropertyMetadata(false));

        public bool IsRequired {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        // Dependency Property for the selected Division
        public static readonly DependencyProperty SelectedDivisionProperty =
            DependencyProperty.Register("SelectedDivision", typeof(Division), typeof(DivisionComboBox), new PropertyMetadata(null, OnSelectedDivisionChanged));

        public Division SelectedDivision {
            get => (Division)GetValue(SelectedDivisionProperty);
            set => SetValue(SelectedDivisionProperty, value);
        }

        // Optional: Handle any changes if needed when SelectedDivision changes
        private static void OnSelectedDivisionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            // Logic to execute when the SelectedDivision changes, if needed
        }
    }
}
