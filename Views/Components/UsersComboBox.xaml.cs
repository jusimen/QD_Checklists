using QD_Checklists.DbContexts;
using QD_Checklists.Models;
using QD_Checklists.ViewModels;
using System.Windows.Controls;

namespace QD_Checklists.Views.Components {
    /// <summary>
    /// Interaction logic for UsersComboBox.xaml
    /// </summary>
    public partial class UsersComboBox : UserControl {

        public UserComboBoxViewModel ViewModel { get; set; }

        public UsersComboBox() {
            ViewModel = new UserComboBoxViewModel(App.GetService<IAppDbContextFactory>());
            DataContext = ViewModel;
            
            InitializeComponent();
        }

        // Dependency Property for Label
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(UsersComboBox), new PropertyMetadata(string.Empty));

        public string Label {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Dependency Property to control the visibility of the asterisk
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(UsersComboBox), new PropertyMetadata(false));

        public bool IsRequired {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        // Dependency Property for the selected User
        public static readonly DependencyProperty SelectedUserProperty =
            DependencyProperty.Register("SelectedUser", typeof(User), typeof(UsersComboBox), new PropertyMetadata(null, OnSelectedUserChanged));

        public User SelectedUser {
            get => (User)GetValue(SelectedUserProperty);
            set => SetValue(SelectedUserProperty, value);
        }

        // Optional: Handle any changes if needed when SelectedUser changes
        private static void OnSelectedUserChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            // Logic to execute when the SelectedUser changes, if needed
        }
    }
}
