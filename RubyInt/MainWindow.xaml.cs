using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using IronRuby;
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using RubyInt.Windows;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace RubyInt
{
    public partial class MainWindow
    {
        public EventHandler CodeChangedEvent;
        
        public ScriptScope Scope;

        private ScriptEngine _engine;

        private readonly MemoryStream _ms = new MemoryStream();
        private readonly MemoryStream _er = new MemoryStream();
        
        private int _lastBit = 1;

        public MainWindow()
        {
            InitializeComponent();
            
            try
            {
                var style = Properties.Settings.Default.ColorStyle;

                if (style == "")
                {
                    style =
                        Properties.Settings.Default.ColorStyle =
                            File.ReadAllText(Settings.DataDirectory + "style.txt").Trim().ToLower();
                }

                if (!File.Exists(style))
                {
                    MessageBox.Show("Could not find current style: " + style, "Style Missing", MessageBoxButton.OK,
                        MessageBoxImage.Error);

                    style = Settings.StyleDirectory + "RubyLight.xshd";
                }

                var ext = Path.GetFileNameWithoutExtension(style);
                var isDark = (ext != null) && ext.ToLower().Contains("dark");

                ThemeManager.ChangeAppStyle(Application.Current,
                    (isDark) ? ThemeManager.Accents.ToArray()[0] : ThemeManager.Accents.ToArray()[2],
                    (isDark) ? ThemeManager.AppThemes.ToArray()[1] : ThemeManager.AppThemes.ToArray()[0]);
                
                var reader = XmlReader.Create(style);

                Settings.EditorHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                Settings.EditorForeground = (isDark)
                    ? new SolidColorBrush(Color.FromRgb(255, 255, 255))
                    : new SolidColorBrush(Color.FromRgb(0, 0, 0));

                Properties.Settings.Default.ColorStyle = style;
                Properties.Settings.Default.Save();
            }
            catch(Exception e)
            {
                DoError("Startup Error", "An error occured while initializing styles: " + e.Message);
            }
            
            Settings.AddEditorToPane(EditorPane, new EditorTab {MainWindow = this});
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _engine = Ruby.CreateEngine();
                Scope = Ruby.CreateRuntime().CreateScope();

                Scope.SetVariable("pi", Math.PI);
                Scope.SetVariable("e", Math.E);
                Scope.SetVariable("_", new Extension());

                var source = _engine.CreateScriptSourceFromString("require 'RubyInt.exe'\nrequire 'Mathos.dll'\nrequire '" + Settings.DataDirectory + "Std.rb'", SourceCodeKind.Statements);

                source.Execute(Scope);
            }
            catch (Exception ee)
            {
                DoError("Startup Error", "An error occured while initializing Ruby: " + ee.Message);
            }
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
                var source = _engine.CreateScriptSourceFromString(Settings.GetCurrentEditor(EditorPane).TextEditor.Text, SourceCodeKind.Statements);

                source.Execute(Scope);
            }
            catch(Exception e)
            {
                DoError("Interpreter Error", e.Message);
            }

            var content = Settings.ReadFromStream(_ms, _lastBit - 1);

            _lastBit = Convert.ToInt32(_ms.Length) + 1;

            Results.Document.Blocks.Clear();
            Results.Document.Blocks.Add(new Paragraph(new Run(content)));
        }

        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            Compile();
        }

        private void New_Executed(object sender, RoutedEventArgs e)
        {
            Settings.AddEditorToPane(EditorPane, new EditorTab { MainWindow = this });
        }

        private void Save_Executed(object sender, RoutedEventArgs e)
        {
            var current = Settings.GetCurrentEditor(EditorPane);
            var tab = EditorPane.SelectedContent;

            if(current.FirstSave)
            {
                var saveFile = new SaveFileDialog
                {
                    Filter = Properties.Resources.RubyFileFilter,
                    CheckPathExists = true
                };

                if (saveFile.ShowDialog() != System.Windows.Forms.DialogResult.OK || saveFile.FileName.Length <= 0)
                    return;

                current.FirstSave = false;
                current.Saved = true;
                current.Filepath = saveFile.FileName;

                tab.Title = Path.GetFileNameWithoutExtension(saveFile.FileName);

                File.WriteAllText(saveFile.FileName, current.TextEditor.Text);

                var oldEditor = Settings.GetCurrentEditor(EditorPane);

                if (EditorPane.SelectedContent.Title == "Untitled" && !oldEditor.Saved)
                    EditorPane.RemoveChildAt(EditorPane.SelectedContentIndex);
            }
            else if(current.Filepath != "")
                File.WriteAllText(current.Filepath, current.TextEditor.Text);
        }

        private void SaveAs_Executed(object sender, RoutedEventArgs e)
        {
            var current = Settings.GetCurrentEditor(EditorPane);
            var tab = EditorPane.SelectedContent;

            var saveFile = new SaveFileDialog
            {
                Filter = Properties.Resources.RubyFileFilter,
                CheckPathExists = true
            };

            if (saveFile.ShowDialog() != System.Windows.Forms.DialogResult.OK || saveFile.FileName.Length <= 0)
                return;

            current.FirstSave = false;
            current.Saved = true;
            current.Filepath = saveFile.FileName;

            tab.Title = Path.GetFileNameWithoutExtension(saveFile.FileName);
            
            File.WriteAllText(saveFile.FileName, current.TextEditor.Text);
        }

        private void Open_Executed(object sender, RoutedEventArgs e)
        {
            var newEditor = new EditorTab();

            var openFile = new OpenFileDialog
            {
                Filter = Properties.Resources.RubyFileFilter,
                CheckFileExists = true
            };
            
            if (openFile.ShowDialog() != System.Windows.Forms.DialogResult.OK || openFile.FileName.Length <= 0)
                return;

            newEditor.FirstSave = false;
            newEditor.Saved = true;
            newEditor.Filepath = openFile.FileName;
            newEditor.MainWindow = this;
            newEditor.TextEditor.Text = File.ReadAllText(openFile.FileName);

            Settings.AddEditorToPane(EditorPane, newEditor, Path.GetFileNameWithoutExtension(openFile.FileName));

            var oldEditor = Settings.GetCurrentEditor(EditorPane);

            if(EditorPane.SelectedContent.Title == "Untitled" && !oldEditor.Saved)
                EditorPane.RemoveChildAt(EditorPane.SelectedContentIndex);
        }

        private void Style_Click(object sender, RoutedEventArgs e)
        {
            new StyleChangeWindow().Show();
        }

        private async void About_Executed(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("About",
@"Mathos Project was launched Jun 21, 2012, and is currently under active development. The project is based on contributions by users world wide, and is therefore entirely free to use unlimited amount of times, without any restrictions. You can also contribute in any ways!

We are currently taking a part in the Microsoft BizSpark programme, and we would like to extend a very special thanks to Microsoft BizSpark program for providing us with development tools, and other benefits of the programme! You can find out more about Microsoft BizSpark at http://bizspark.com/!", MessageDialogStyle.Affirmative, new MetroDialogSettings
            {
                AnimateShow = true,
                AnimateHide = true,
                ColorScheme = MetroDialogColorScheme.Accented
            });
        }

        private void Help_Executed(object sender, RoutedEventArgs e)
        {
            new HelpWindow {MainWindow = this}.Show();
        }

        private void Repl_OnClick(object sender, RoutedEventArgs e)
        {
            new ReplWindow().Show();
        }
    }
}
