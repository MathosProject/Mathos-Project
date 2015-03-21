using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.CodeCompletion;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace RubyInt
{
    public partial class EditorTab
    {
        public string Filepath;
        public MainWindow MainWindow;

        public bool FirstSave = true;
        public bool Saved = true;

        private CompletionWindow _completionWindow;

        public EditorTab()
        {
            InitializeComponent();
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextEditor.FontFamily = new FontFamily("Consolas");
            TextEditor.FontSize = 15;
            TextEditor.Foreground = Settings.EditorForeground;
            TextEditor.SyntaxHighlighting = Settings.EditorHighlighting;

            TextEditor.TextChanged += (o, args) =>
            {
                Saved = false;
            };

            TextEditor.TextArea.TextEntering += (o, args) =>
            {
                if (args.Text.Length <= 0 || _completionWindow == null) return;

                if (!char.IsLetterOrDigit(args.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    _completionWindow.CompletionList.RequestInsertion(e);
                }

                // Do not set e.Handled=true.
                // We still want to insert the character that was typed.
            };

            TextEditor.TextArea.TextEntered += (o, args) =>
            {
                if (args.Text != ".")
                    return;

                _completionWindow = new CompletionWindow(TextEditor.TextArea);

                var data = _completionWindow.CompletionList.CompletionData;

                data.Add(new CompletionData("fsb", "Convert a fraction represent in Stern-Brocot\nnumber system to a normal fraction.\nNote that this method is case sensetive.\nOnly L's and R's are allowed."));
                data.Add(new CompletionData("new", "Creates a new instance of an object"));
                data.Add(new CompletionData("save", "Save a variable to disk.\nNeeds one parameter, name."));
                data.Add(new CompletionData("tsb", "Convert a fraction string (i.e. 3/7)\nto a Stern-Brocot number system.\nThe output will be expressed in terms of L's and R's."));

                _completionWindow.Show();

                _completionWindow.Closed += (c, a) => _completionWindow = null;
            };

            TextEditor.KeyDown += delegate(object o, KeyEventArgs args)
            {
                if (args.Key == Key.F5)
                    MainWindow.Compile();
            };
        }
    }
}
