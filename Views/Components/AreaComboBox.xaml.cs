using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.ViewModels;
using System.Windows.Controls;

namespace QD_Checklists.Views.Components {
    /// <summary>
    /// Interaction logic for AreaComboBox.xaml
    /// </summary>
    public partial class AreaComboBox : UserControl {
        public AreaComboBoxViewModel ViewModel { get; set; }

        public AreaComboBox() {
            ViewModel = new AreaComboBoxViewModel(App.GetService<IAppDbContextFactory>());
            DataContext = ViewModel;

            InitializeComponent();
        }

        // Dependency Property for Label
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(AreaComboBox), new PropertyMetadata(string.Empty));

        public string Label {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Dependency Property to control the visibility of the asterisk
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(AreaComboBox), new PropertyMetadata(false));

        public bool IsRequired {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        // Dependency Property for the selected Area
        public static readonly DependencyProperty SelectedAreaProperty =
            DependencyProperty.Register("SelectedArea", typeof(Area), typeof(AreaComboBox), new PropertyMetadata(null, OnSelectedAreaChanged));

        public Area SelectedArea {
            get => (Area)GetValue(SelectedAreaProperty);
            set => SetValue(SelectedAreaProperty, value);
        }

        // Optional: Handle any changes if needed when SelectedArea changes
        private static void OnSelectedAreaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            //View Model
            if(d is AreaComboBox areaComboBox) {
                areaComboBox.ViewModel.OnAreaSelected(areaComboBox.SelectedArea);
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBox? comboBox = sender as ComboBox;
            if (comboBox != null) {
                SelectedArea = (Area)comboBox.SelectedItem;
            }
        }
    }
}
