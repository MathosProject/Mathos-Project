using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml;
using System.Windows.Input;

using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.CodeCompletion;

using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;

using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

using IronRuby;
using RubyInt.Windows;
using Key = System.Windows.Input.Key;

namespace RubyInt
{
    public partial class MainWindow
    {
        public readonly string ColorStyle;

        private readonly ScriptScope _scope;
        private readonly ScriptEngine _engine;

        private readonly MemoryStream _ms = new MemoryStream();
        private readonly MemoryStream _er = new MemoryStream();

        private RichTextBox _currentOutputTextBox;

        private int _lastBit = 1;

        private string _currentFile;

        private bool _saved = true;
        private bool _firstSave = true;

        public  EventHandler CodeChangedEvent;

        public MainWindow()
        {
            InitializeComponent();

            if(!File.Exists(Environment.CurrentDirectory + "/style.txt"))
                File.WriteAllText(Environment.CurrentDirectory + "/style.txt", @"light");

            try
            {
                ColorStyle = File.ReadAllText(Environment.CurrentDirectory + "/style.txt").Trim().ToLower();

                ThemeManager.ChangeAppStyle(Application.Current,
                    ColorStyle == "dark" ? ThemeManager.Accents.ToArray()[0] : ThemeManager.Accents.ToArray()[2],
                    ColorStyle == "dark" ? ThemeManager.AppThemes.ToArray()[1] : ThemeManager.AppThemes.ToArray()[0]);

                var reader = XmlReader.Create(ColorStyle == "dark" ? Environment.CurrentDirectory + "/RubyDark.xshd" : Environment.CurrentDirectory + "/RubyLight.xshd");

                TextEditor.Foreground = (ColorStyle == "dark") ? new SolidColorBrush(Color.FromRgb(255, 255, 255)) : new SolidColorBrush(Color.FromRgb(0, 0, 0));
                TextEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                TextEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
                TextEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;

                _currentOutputTextBox = Results;

                _engine = Ruby.CreateEngine();
                _scope = Ruby.CreateRuntime().CreateScope();

                _scope.SetVariable("pi", Math.PI);
                _scope.SetVariable("e", Math.E);
                _scope.SetVariable("_", new Extension());

                var source = _engine.CreateScriptSourceFromString("require 'RubyInt.exe'\nrequire 'Mathos.dll'\nrequire '" + Environment.CurrentDirectory + "/Std.rb'", SourceCodeKind.Statements);
                
                source.Execute(_scope);
            }
            catch(Exception e)
            {
                DoError("Startup Error", "An error occured while starting Ruby: " + e.Message);
            }

            //TextEditor.Text = "print exec('2+3')\n";

            TextEditor.KeyDown += (sender, e) =>
            {
                if (e.Key == Key.F5)
                    Compile();
            };

                //_dataView = new DataViewWindow(this);
                //_dataView.Show();
                //_dataView.UpdateData(_engine);
            
        }

        private CompletionWindow _completionWindow;

        void textEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != ".") return;
            
            // Open code completion after the user has pressed dot:
            _completionWindow = new CompletionWindow(TextEditor.TextArea);
            var data = _completionWindow.CompletionList.CompletionData;

            data.Add(new MyCompletionData("fsb", "Convert a fraction represent in Stern-Brocot\nnumber system to a normal fraction.\nNote that this method is case sensetive.\nOnly L's and R's are allowed."));
            data.Add(new MyCompletionData("new", "Creates a new instance of an object"));
            data.Add(new MyCompletionData("save","Save a variable to disk.\nNeeds one parameter, name."));
            data.Add(new MyCompletionData("tsb", "Convert a fraction string (i.e. 3/7)\nto a Stern-Brocot number system.\nThe output will be expressed in terms of L's and R's."));

                
            _completionWindow.Show();
                
            _completionWindow.Closed += delegate
            {
                _completionWindow = null;
            };
        }

        void textEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length <= 0 || _completionWindow == null) return;
            
            if (!char.IsLetterOrDigit(e.Text[0]))
            {
                // Whenever a non-letter is typed while the completion window is open,
                // insert the currently selected element.
                _completionWindow.CompletionList.RequestInsertion(e);
            }
            // Do not set e.Handled=true.
            // We still want to insert the character that was typed.
        }

        private static string ReadFromStream(Stream ms, int start = 0)
        {
            var length = (int)ms.Length;
            var bytes = new Byte[length];

            ms.Seek(start, SeekOrigin.Begin);
            ms.Read(bytes, start, (int)ms.Length - start);

            return Encoding.GetEncoding("utf-8").GetString(bytes, start, (int)ms.Length - start);
        }

        private void TextChanged(object sender, EventArgs e)
        {
            _saved = false;
        }

        private void Results_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var originalMargin = TextEditor.Margin;

            Results.Visibility = Visibility.Hidden;
            TextEditor.Margin = new Thickness(0, 0, 0, 0);

            var outWindow = new ResultsWindow();

            _currentOutputTextBox = outWindow.OutputTextBox;

            outWindow.Show();

            outWindow.Closed += (o, args) =>
            {
                Results.Visibility = Visibility.Visible;
                TextEditor.Margin = originalMargin;

                _currentOutputTextBox = Results;
            };
        }

        private async void DoError(string title, string msg)
        {
            await this.ShowMessageAsync(title, title + ": " + msg);
        }

        private void Compile()
        {
            _engine.Runtime.IO.SetOutput(_ms, Encoding.Unicode);
            _engine.Runtime.IO.SetErrorOutput(_er, Encoding.Unicode);

            try
            {
                var source = _engine.CreateScriptSourceFromString(TextEditor.Text, SourceCodeKind.Statements);

                source.Execute(_scope);
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
            if (!_saved)
            {
                var result = MessageBox.Show("Do you want to save the current file?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                    Save_Executed(sender, e);
            }

            _firstSave = true;
            _saved = true;
            _currentFile = "";

            TextEditor.Clear();
        }

        private void Save_Executed(object sender, RoutedEventArgs e)
        {
            if(_firstSave)
            {
                var saveFile = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "IronRuby File (*.rb)|*.rb",
                    CheckPathExists = true
                };

                var showDialog = saveFile.ShowDialog();
                
                if (showDialog != null && ((bool)showDialog && saveFile.FileName.Length > 0))
                {
                    _firstSave = false;
                    _saved = true;
                    _currentFile = saveFile.FileName;

                    File.WriteAllText(_currentFile, TextEditor.Text);
                }
            }

            if(_currentFile != "")
                File.WriteAllText(_currentFile, TextEditor.Text);
        }

        private void SaveAs_Executed(object sender, RoutedEventArgs e)
        {
            var saveFile = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "IronRuby Source File (*.rb)|*.rb",
                CheckPathExists = true
            };

            var showDialog = saveFile.ShowDialog();

            if (showDialog == null || (!(bool) showDialog || saveFile.FileName.Length <= 0)) return;
            
            _firstSave = false;
            _saved = true;
            _currentFile = saveFile.FileName;

            File.WriteAllText(_currentFile, TextEditor.Text);
        }

        private void Open_Executed(object sender, RoutedEventArgs e)
        {
            var openFile = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "IronRuby Source File (*.rb)|*.rb",
                CheckFileExists = true
            };

            var showDialog = openFile.ShowDialog();

            if (showDialog == null || (!(bool) showDialog || openFile.FileName.Length <= 0)) return;
            
            _firstSave = false;
            _saved = true;
            _currentFile = openFile.FileName;
            TextEditor.Text = File.ReadAllText(openFile.FileName);
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

            var frm = new HelpWindow();
            frm.Show();

            //this.AddToEventRoute(TextEditor.TextChanged, utedEventArgs());

            //
            
            //TextEditor.Text = frm.CodeChange;
            //TextEditor.Text = ControlID.TextData;
        }
    }
}
