using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.ViewModels;
using System.Windows.Controls;

namespace QD_Checklists.Views.Components {
    /// <summary>
    /// Interaction logic for TypologyComboBox.xaml
    /// </summary>
    public partial class TypologyComboBox : UserControl {
        public TypologyComboBoxViewModel ViewModel { get; set; }

        public TypologyComboBox() {
            ViewModel = new TypologyComboBoxViewModel(App.GetService<IAppDbContextFactory>());
            DataContext = ViewModel;
            
            InitializeComponent();
        }

        // Dependency Property for Label
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(TypologyComboBox), new PropertyMetadata(string.Empty));

        public string Label {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Dependency Property to control the visibility of the asterisk
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(TypologyComboBox), new PropertyMetadata(false));

        public bool IsRequired {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        // Dependency Property for the selected Typology
        public static readonly DependencyProperty SelectedTypologyProperty =
            DependencyProperty.Register("SelectedTypology", typeof(Typology), typeof(TypologyComboBox), new PropertyMetadata(null, OnSelectedTypologyChanged));

        public Typology SelectedTypology {
            get => (Typology)GetValue(SelectedTypologyProperty);
            set => SetValue(SelectedTypologyProperty, value);
        }

        // Optional: Handle any changes if needed when SelectedTypology changes
        private static void OnSelectedTypologyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            // Logic to execute when the SelectedTypology changes, if needed
        }
    }
}
