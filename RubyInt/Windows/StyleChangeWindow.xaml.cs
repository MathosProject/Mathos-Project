using System.IO;
using System.Windows;
using Application = System.Windows.Forms.Application;

namespace RubyInt.Windows
{
    public partial class StyleChangeWindow
    {
        public StyleChangeWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var style = StyleBox.SelectedItem.ToString().Trim().ToLower();

            File.WriteAllText(Settings.DataDirectory + "style.txt", style.Substring(style.IndexOf(':') + 1));
            Application.Restart();
            System.Windows.Application.Current.Shutdown(0);
        }
    }
}
