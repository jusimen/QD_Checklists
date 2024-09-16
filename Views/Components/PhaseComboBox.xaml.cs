using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.ViewModels;
using System.Windows.Controls;

namespace QD_Checklists.Views.Components {
    /// <summary>
    /// Interaction logic for PhaseComboBox.xaml
    /// </summary>
    public partial class PhaseComboBox : UserControl {

        public PhaseComboBoxViewModel ViewModel { get; set; }

        public PhaseComboBox() {
            ViewModel = new PhaseComboBoxViewModel(App.GetService<IAppDbContextFactory>());
            DataContext = ViewModel;

            InitializeComponent();
        }

        // Dependency Property for Label
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(PhaseComboBox), new PropertyMetadata(string.Empty));

        public string Label {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Dependency Property to control the visibility of the asterisk
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(PhaseComboBox), new PropertyMetadata(false));

        public bool IsRequired {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        // Dependency Property for the selected Phase
        public static readonly DependencyProperty SelectedPhaseProperty =
            DependencyProperty.Register("SelectedPhase", typeof(Phase), typeof(PhaseComboBox), new PropertyMetadata(null, OnSelectedPhaseChanged));

        public Phase SelectedPhase {
            get => (Phase)GetValue(SelectedPhaseProperty);
            set => SetValue(SelectedPhaseProperty, value);
        }

        // Optional: Handle any changes if needed when SelectedPhase changes
        private static void OnSelectedPhaseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            // Logic to execute when the SelectedPhase changes, if needed
        }
    }
}
