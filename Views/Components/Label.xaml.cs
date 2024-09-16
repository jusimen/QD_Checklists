using System.Windows.Controls;

namespace QD_Checklists.Views.Components
{
    /// <summary>
    /// Interaction logic for Label.xaml
    /// </summary>
    public partial class Label : UserControl
    {
        public Label()
        {
            InitializeComponent();
        }

        // Dependency Property for Value
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(Label), new PropertyMetadata(string.Empty));

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}
