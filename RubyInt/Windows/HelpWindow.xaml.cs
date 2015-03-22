using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

/*
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }
*/

        private void browserWin_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //var a = e.Uri.PathAndQuery;
            var a = e.Uri.Segments.Last();

            if (!a.Contains(".mcli.txt"))
                return;
            
            var sr = new StreamReader(e.Uri.LocalPath);

            var mainWindow = (MainWindow)Application.Current.Windows[0];

            if (mainWindow != null)
            {
                mainWindow.EditorTabControl.Items.Add(new TabItem
                {
                    Content = new EditorTab { MainWindow = MainWindow, TextEditor = {Text = sr.ReadToEnd()}},
                    Header = Path.GetFileNameWithoutExtension(e.Uri.LocalPath).Replace(".mcli", "")
                });
            }

            sr.Close();

            //foreach (var window in App.Current.Windows)
            //{
            //    if(typeof(window) == MainWindow)
            //    mn.TextEditor.Text = "bye";
            //}
            ////m.ShowDialog();
            //browserWin.GoBack();


            //CodeChange = "hello";

            //ControlID.TextData = "helloo";
                
            //= m;
            //MainWindow.TextEditor.Text = "";
        }

        private void browserWin_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var a = BrowserWin.Source.Segments.Last();

            if (a.Contains(".mcli.txt"))
                BrowserWin.GoBack();

            //if(browserWin
            var window = Application.Current.Windows[0];

            if (window != null)
                window.Focus();
        }
    }
}
