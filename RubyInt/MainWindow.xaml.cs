using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using IronRuby;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using Microsoft.Win32;
using RubyInt.Windows;

namespace RubyInt
{
    public partial class MainWindow
    {
        public EventHandler CodeChangedEvent;

        public readonly string ColorStyle;

        public readonly ScriptScope Scope;

        private readonly ScriptEngine _engine;

        private readonly MemoryStream _ms = new MemoryStream();
        private readonly MemoryStream _er = new MemoryStream();

        private RichTextBox _currentOutputTextBox;

        private int _lastBit = 1;

        public MainWindow()
        {
            InitializeComponent();

            if(!File.Exists(Settings.DataDirectory + "style.txt"))
                File.WriteAllText(Settings.DataDirectory + "style.txt", @"light");

            try
            {
                ColorStyle = File.ReadAllText(Settings.DataDirectory + "style.txt").Trim().ToLower();

                if (!File.Exists(Settings.StyleDirectory + ColorStyle + ".xshd"))
                    ColorStyle = "RubyLight";

                var isDark = ColorStyle.ToLower().Contains("dark");

                ThemeManager.ChangeAppStyle(Application.Current,
                    (isDark) ? ThemeManager.Accents.ToArray()[0] : ThemeManager.Accents.ToArray()[2],
                    (isDark) ? ThemeManager.AppThemes.ToArray()[1] : ThemeManager.AppThemes.ToArray()[0]);
                
                var reader = XmlReader.Create(Settings.StyleDirectory + ColorStyle + ".xshd");

                Settings.EditorHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                Settings.EditorForeground = (isDark)
                    ? new SolidColorBrush(Color.FromRgb(255, 255, 255))
                    : new SolidColorBrush(Color.FromRgb(0, 0, 0));
                
                _currentOutputTextBox = Results;

                _engine = Ruby.CreateEngine();
                Scope = Ruby.CreateRuntime().CreateScope();

                Scope.SetVariable("pi", Math.PI);
                Scope.SetVariable("e", Math.E);
                Scope.SetVariable("_", new Extension());

                var source = _engine.CreateScriptSourceFromString("require 'RubyInt.exe'\nrequire 'Mathos.dll'\nrequire '" + Settings.DataDirectory + "Std.rb'", SourceCodeKind.Statements);
                
                source.Execute(Scope);
            }
            catch(Exception e)
            {
                DoError("Startup Error", "An error occured while initializing Ruby: " + e.Message);
            }

            EditorTabControl.Items.Add(new TabItem { Content = new EditorTab { MainWindow = this }, Header = "Untitled" });

            //_dataView = new DataViewWindow(this);
            //_dataView.Show();
            //_dataView.UpdateData(_engine);            
        }

        private static string ReadFromStream(Stream ms, int start = 0)
        {
            var length = (int)ms.Length;
            var bytes = new Byte[length];

            ms.Seek(start, SeekOrigin.Begin);
            ms.Read(bytes, start, (int)ms.Length - start);

            return Encoding.GetEncoding("utf-8").GetString(bytes, start, (int)ms.Length - start);
        }

        private void Results_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var originalMargin = EditorTabControl.Margin;

            Results.Visibility = Visibility.Hidden;
            EditorTabControl.Margin = new Thickness(0, 0, 0, 0);

            var outWindow = new ResultsWindow();

            _currentOutputTextBox = outWindow.OutputTextBox;

            outWindow.Show();

            outWindow.Closed += (o, args) =>
            {
                Results.Visibility = Visibility.Visible;
                EditorTabControl.Margin = originalMargin;

                _currentOutputTextBox = Results;
            };
        }

        private async void DoError(string title, string msg)
        {
            await this.ShowMessageAsync(title, title + ": " + msg);
        }

        public void Compile()
        {
            _engine.Runtime.IO.SetOutput(_ms, Encoding.Unicode);
            _engine.Runtime.IO.SetErrorOutput(_er, Encoding.Unicode);

            try
            {
                var source = _engine.CreateScriptSourceFromString(Settings.GetCurrentEditor(EditorTabControl).TextEditor.Text, SourceCodeKind.Statements);

                source.Execute(Scope);
            }
            catch(Exception e)
            {
                DoError("Interpreter Error", e.Message);
            }

            var content = ReadFromStream(_ms, _lastBit - 1);

            _lastBit = Convert.ToInt32(_ms.Length) + 1;

            //_dataView.UpdateData(_engine); CAUSES AN ERROR because the window is currently deactivated.

            _currentOutputTextBox.Document.Blocks.Clear();
            _currentOutputTextBox.Document.Blocks.Add(new Paragraph(new Run(content)));
        }

        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            Compile();
        }

        private void New_Executed(object sender, RoutedEventArgs e)
        {
            EditorTabControl.Items.Add(new TabItem { Content = new EditorTab { MainWindow = this }, Header = "Untitled" });
        }

        private void Save_Executed(object sender, RoutedEventArgs e)
        {
            var current = Settings.GetCurrentEditor(EditorTabControl);
            var tab = EditorTabControl.SelectedItem as TabItem;

            if(current.FirstSave)
            {
                var saveFile = new SaveFileDialog
                {
                    Filter = "IronRuby File (*.rb)|*.rb",
                    CheckPathExists = true
                };

                var showDialog = saveFile.ShowDialog();
                
                if (showDialog != null && ((bool)showDialog && saveFile.FileName.Length > 0))
                {
                    current.FirstSave = false;
                    current.Saved = true;
                    current.Filepath = saveFile.FileName;

                    File.WriteAllText(saveFile.FileName, current.TextEditor.Text);
                }
            }

            if (tab != null && tab.Header.ToString().EndsWith("*"))
                tab.Header = tab.Header.ToString().Substring(0, tab.Header.ToString().Length - 1);
            if(current.Filepath != "")
                File.WriteAllText(current.Filepath, current.TextEditor.Text);
        }

        private void SaveAs_Executed(object sender, RoutedEventArgs e)
        {
            var current = Settings.GetCurrentEditor(EditorTabControl);
            var tab = EditorTabControl.SelectedItem as TabItem;
            var saveFile = new SaveFileDialog
            {
                Filter = "IronRuby Source File (*.rb)|*.rb",
                CheckPathExists = true
            };

            var showDialog = saveFile.ShowDialog();

            if (showDialog == null || (!(bool) showDialog || saveFile.FileName.Length <= 0))
                return;

            current.FirstSave = false;
            current.Saved = true;
            current.Filepath = saveFile.FileName;

            if (tab != null && tab.Header.ToString().EndsWith("*"))
                tab.Header = tab.Header.ToString().Substring(0, tab.Header.ToString().Length - 1);

            File.WriteAllText(saveFile.FileName, current.TextEditor.Text);
        }

        private void Open_Executed(object sender, RoutedEventArgs e)
        {
            var current = new EditorTab();
            var tab = new TabItem();
            var openFile = new OpenFileDialog
            {
                Filter = "IronRuby Source File (*.rb)|*.rb",
                CheckFileExists = true
            };

            var showDialog = openFile.ShowDialog();

            if (showDialog == null || (!(bool) showDialog || openFile.FileName.Length <= 0))
                return;

            current.FirstSave = false;
            current.Saved = true;
            current.Filepath = openFile.FileName;
            current.MainWindow = this;
            current.TextEditor.Text = File.ReadAllText(openFile.FileName);

            tab.Header = Path.GetFileNameWithoutExtension(openFile.FileName);
            tab.Content = current;

            EditorTabControl.Items.Add(tab);

            var old = EditorTabControl.SelectedItem as TabItem;

            if (old == null || (old.Header.ToString() != "Untitled" && old.Header.ToString() != "Untitled*"))
                return;

            var oldEditor = old.GetChildObjects().ElementAt(0) as EditorTab;

            if(oldEditor != null && oldEditor.TextEditor.Text.Trim() == "")
                EditorTabControl.Items.RemoveAt(EditorTabControl.SelectedIndex);
        }

        private void Style_Click(object sender, RoutedEventArgs e)
        {
            new StyleChangeWindow().Show();
        }

        private async void About_Executed(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("About",
@"Mathos Project was launched Jun 21, 2012, and is currently under active development. The project is based on contributions by users world wide, and is therefore entirely free to use unlimited amount of times, without any restrictions. You can also contribute in any ways!

We are currently taking a part in the Microsoft BizSpark programme, and we would like to extend a very special thanks to Microsoft BizSpark program for providing us with development tools, and other benefits of the programme! You can find out more about Microsoft BizSpark at http://bizspark.com/!");
        }

        private void Help_Executed(object sender, RoutedEventArgs e)
        {

            // TODO: figure out how to make an event listener to detect changes to frm.CodeChange;


            //System.Diagnostics.Process.Start("http://mathosproject.com/product/mcli/");

            var frm = new HelpWindow {MainWindow = this};
            frm.Show();
            
            //this.AddToEventRoute(TextEditor.TextChanged, utedEventArgs());

            //
            
            //TextEditor.Text = frm.CodeChange;
            //TextEditor.Text = ControlID.TextData;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (EditorTabControl.SelectedItem == null)
                return;

            EditorTabControl.Items.RemoveAt(EditorTabControl.SelectedIndex);
        }
    }
}
