using System;
using System.Windows;

namespace MathInterpreter
{
    public partial class SettingsWindow
    {
        public static SettingsWindow Instance;

        public SettingsWindow()
        {
            InitializeComponent();
        }

        public static void Open()
        {
            if (Instance != null)
                return;

            Instance = new SettingsWindow();
            Instance.ShowDialog();
        }

        private void SettingsWindow_OnClosed(object sender, EventArgs e)
        {
            Instance = null;
        }

        private void SaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            int editorFontSize;

            if (!int.TryParse(EditorFontSize.Text, out editorFontSize))
            {
                MessageBox.Show(this, "Invalid editor font size given.", "Settings Error", MessageBoxButton.OK);

                return;
            }

            Properties.Settings.Default.EditorFontSize = editorFontSize;

            Properties.Settings.Default.Save();
            
            System.Windows.Forms.Application.Restart();
            Application.Current.Shutdown();
        }
    }
}
