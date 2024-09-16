using System.Windows.Controls;

namespace QD_Checklists.Views.Components {
    public partial class EditableField : UserControl {
        public EditableField() {
            InitializeComponent();
        }

        // Dependency Property for Label
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(EditableField), new PropertyMetadata(string.Empty));

        public string Label {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Dependency Property for Value
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(EditableField), new PropertyMetadata(string.Empty));

        public string Value {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        // Dependency Property to control the visibility of the asterisk
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(EditableField), new PropertyMetadata(false));

        public bool IsRequired {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }
    }
}
