using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.Win32;
using RubyInt.Editor;
using RubyInt.Windows;

namespace RubyInt
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Settings.Initialize();
            NewFileClick(sender, e);
        }

        private void ButtonContextClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
                return;

            button.ContextMenu.IsEnabled = true;
            button.ContextMenu.PlacementTarget = button;
            button.ContextMenu.Placement = PlacementMode.Bottom;
            button.ContextMenu.IsOpen = true;
        }

        #region File

        private void NewFileClick(object sender, RoutedEventArgs e)
        {
            EditorPane.Children.Add(new EditorDocument());
        }

        private void OpenFileClick(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "Ruby File (*.rb)|*.rb|Any File (*.*)|*.*",
                CheckFileExists = true,
                RestoreDirectory = true
            };

            if (openDialog.ShowDialog() == true && openDialog.FileName.Trim().Length > 0)
                EditorPane.Children.Add(new EditorDocument(openDialog.FileName));
        }

        private void SaveFileClick(object sender, RoutedEventArgs e)
        {
            var editor = EditorPane.SelectedContent as EditorDocument;

            if (editor == null)
                return;

            editor.Save();
        }

        private void SaveFileAsClick(object sender, RoutedEventArgs e)
        {
            var editor = EditorPane.SelectedContent as EditorDocument;

            if (editor == null)
                return;
            
            editor.SaveAs();
        }

        private void QuitClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        private void RunClick(object sender, RoutedEventArgs e)
        {
            var editor = EditorPane.SelectedContent as EditorDocument;

            if (editor == null)
                return;

            Results.Text = editor.Run();
        }

        #region Help
        
        private void DocumentationClick(object sender, RoutedEventArgs e)
        {
            new DocumentationWindow().Show();
        }

        private void AboutClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@"Mathos Project was launched Jun 21, 2012, and is currently under active development. The project is based on contributions by users world wide, and is therefore entirely free to use unlimited amount of times, without any restrictions. You can also contribute in any ways!

We are currently taking a part in the Microsoft BizSpark programme, and we would like to extend a very special thanks to Microsoft BizSpark program for providing us with development tools, and other benefits of the programme! You can find out more about Microsoft BizSpark at http://bizspark.com/!",
                "About", MessageBoxButton.OK);
        }

        #endregion
    }
}
