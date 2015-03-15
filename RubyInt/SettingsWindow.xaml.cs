using System.Windows;
using System.Windows.Media.Media3D;

namespace RubyInt
{
    public partial class SettingsWindow
    {
        private readonly MainWindow _editorWindow;

        public SettingsWindow(MainWindow editorWindow)
        {
            InitializeComponent();

            _editorWindow = editorWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You need to restart the application for the new style to take effect.");

            _editorWindow.ColorStyle = "light";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You need to restart the application for the new style to take effect.");

            _editorWindow.ColorStyle = "dark";
        }
    }
}
