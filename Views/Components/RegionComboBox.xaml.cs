using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.ViewModels;
using System.Windows.Controls;

namespace QD_Checklists.Views.Components {
    /// <summary>
    /// Interaction logic for RegionComboBox.xaml
    /// </summary>
    public partial class RegionComboBox : UserControl {

        public RegionComboBoxViewModel ViewModel { get; set; }
        public RegionComboBox() {
            ViewModel = new RegionComboBoxViewModel(App.GetService<IAppDbContextFactory>());
            DataContext = ViewModel;

            InitializeComponent();
        }

        // Dependency Property for Label
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(RegionComboBox), new PropertyMetadata(string.Empty));

        public string Label {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Dependency Property to control the visibility of the asterisk
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(RegionComboBox), new PropertyMetadata(false));

        public bool IsRequired {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        // Dependency Property for the selected Region
        public static readonly DependencyProperty SelectedRegionProperty =
            DependencyProperty.Register("SelectedRegion", typeof(Region), typeof(RegionComboBox), new PropertyMetadata(null, OnSelectedRegionChanged));

        public Region SelectedRegion {
            get => (Region)GetValue(SelectedRegionProperty);
            set => SetValue(SelectedRegionProperty, value);
        }

        // Optional: Handle any changes if needed when SelectedRegion changes
        private static void OnSelectedRegionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            // Logic to execute when the SelectedRegion changes, if needed
        }
    }
}
