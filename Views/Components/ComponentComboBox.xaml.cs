using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.ViewModels;
using System.Windows.Controls;

namespace QD_Checklists.Views.Components {
    /// <summary>
    /// Interaction logic for ComponentComboBox.xaml
    /// </summary>
    public partial class ComponentComboBox : UserControl {

        public ComponentComboBoxViewModel ViewModel { get; set; }

        public ComponentComboBox() {
            ViewModel = new ComponentComboBoxViewModel(App.GetService<IAppDbContextFactory>());
            DataContext = ViewModel;

            InitializeComponent();
        }

        // Dependency Property for Label
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(ComponentComboBox), new PropertyMetadata(string.Empty));

        public string Label {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Dependency Property to control the visibility of the asterisk
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(ComponentComboBox), new PropertyMetadata(false));

        public bool IsRequired {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        // Dependency Property for the selected Component
        public static readonly DependencyProperty SelectedComponentProperty =
            DependencyProperty.Register("SelectedComponent", typeof(Component), typeof(ComponentComboBox), new PropertyMetadata(null, OnSelectedComponentChanged));

        public Component SelectedComponent {
            get => (Component)GetValue(SelectedComponentProperty);
            set => SetValue(SelectedComponentProperty, value);
        }

        // Optional: Handle any changes if needed when SelectedComponent changes
        private static void OnSelectedComponentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            // Logic to execute when the SelectedComponent changes, if needed
        }
    }
}
