using System;
using System.Windows;

namespace MathInterpreter
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ResultsWindow.Open();
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            if (ResultsWindow.Instance != null)
                ResultsWindow.Instance.Close();
            if(SettingsWindow.Instance != null)
                SettingsWindow.Instance.Close();
        }

        private void NewFile_OnClick(object sender, RoutedEventArgs e)
        {
            TabControl.Items.Add(new MathTab());
        }

        private void OpenFile_OnClick(object sender, RoutedEventArgs e)
        {
            var tab = MathTab.Open();

            if (tab == null)
                return;

            TabControl.Items.Add(tab);
        }

        private void SaveFile_OnClick(object sender, RoutedEventArgs e)
        {
            (TabControl.SelectedItem as MathTab)?.Save();
        }

        private void SaveFileAs_OnClick(object sender, RoutedEventArgs e)
        {
            (TabControl.SelectedItem as MathTab)?.SaveAs();
        }

        private void CloseTab_OnClick(object sender, RoutedEventArgs e)
        {
            var tabIndex = TabControl.SelectedIndex;

            if (tabIndex == -1)
                return;

            TabControl.Items.RemoveAt(tabIndex);
        }

        private void Quit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ResultsWindow_OnClick(object sender, RoutedEventArgs e)
        {
            ResultsWindow.Open();
        }
        
        private void Run_OnClick(object sender, RoutedEventArgs e)
        {
            (TabControl.SelectedItem as MathTab)?.Run();
        }

        private void Settings_OnClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow.Open();
        }
    }
}
