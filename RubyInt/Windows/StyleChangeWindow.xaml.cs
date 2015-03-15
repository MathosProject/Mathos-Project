using System;
using System.IO;
using System.Windows;

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

            File.WriteAllText(Environment.CurrentDirectory + "/style.txt", style.Substring(style.IndexOf(':') + 1));
            System.Windows.Forms.Application.Restart();
            Application.Current.Shutdown(0);
        }
    }
}
