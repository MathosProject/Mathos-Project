using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RubyInt.Windows
{
    public partial class HelpWindow
    {
        public MainWindow MainWindow;

        public string CodeChange { get; set; }

        private readonly string _helpPath = Environment.CurrentDirectory + "/Help/";

        public HelpWindow()
        {
            InitializeComponent();
            
            foreach(var line in File.ReadAllLines(_helpPath + "list.txt"))
                LstPages.Items.Add(line);

            BrowserWin.Source = new Uri(_helpPath + "Welcome.html");
        }

        private void lstPages_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var filePath = (string)LstPages.SelectedItem;

            BrowserWin.Source = new Uri(_helpPath + filePath + ".html");
        }

        private void browserWin_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            var a = e.Uri.Segments.Last();

            if (!a.Contains(".mcli.txt"))
                return;
            
            var sr = new StreamReader(e.Uri.LocalPath);

            var mainWindow = (MainWindow)Application.Current.Windows[0];

            if (mainWindow != null)
            {
                Settings.AddEditorToPane(mainWindow.EditorPane,
                    new EditorTab {MainWindow = MainWindow, TextEditor = {Text = sr.ReadToEnd()}},
                    Path.GetFileNameWithoutExtension(e.Uri.LocalPath).Replace(".mcli", ""));
            }

            sr.Close();
        }

        private void browserWin_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var a = BrowserWin.Source.Segments.Last();

            if (a.Contains(".mcli.txt"))
                BrowserWin.GoBack();
            
            var window = Application.Current.Windows[0];

            if (window != null)
                window.Focus();
        }
    }
}
