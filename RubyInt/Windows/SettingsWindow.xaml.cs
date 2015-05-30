using System.Windows.Forms;

namespace RubyInt.Windows
{
    public partial class SettingsWindow
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            showLineNumbers.IsChecked = Properties.Settings.Default.LineNumbers;
        }

        private void applyButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var lineNumbers = showLineNumbers.IsChecked;
            Properties.Settings.Default.LineNumbers = (lineNumbers == null) ? false : (bool)lineNumbers;

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            Application.Restart();
            System.Windows.Application.Current.Shutdown(0);
        }
    }
}
