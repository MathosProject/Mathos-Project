using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.CodeCompletion;
using Microsoft.Scripting.Utils;

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

        private void EditorTab_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextEditor.FontFamily = new FontFamily("Consolas");
            TextEditor.FontSize = 15;
            TextEditor.Foreground = Settings.EditorForeground;
            TextEditor.SyntaxHighlighting = Settings.EditorHighlighting;

            TextEditor.TextChanged += (o, args) =>
            {
                Saved = false;

                var p = Parent as TabItem;

                if (p == null)
                    return;

                if (!p.Header.ToString().EndsWith("*"))
                    p.Header = p.Header + "*";
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

                data.AddRange(MainWindow.Scope.GetItems().Select(pair => new CompletionData(pair.Key, pair.Value.ToString())));
                data.AddRange(Settings.CompletionList);

                _completionWindow.Show();

                _completionWindow.Closed += (c, a) => _completionWindow = null;
            };

            TextEditor.KeyDown += (o, args) =>
            {
                if (args.Key == Key.F5)
                    MainWindow.Compile();
            };
        }
    }
}
