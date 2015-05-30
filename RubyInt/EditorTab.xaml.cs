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

        public bool Saved;
        public bool FirstSave = true;

        private CompletionWindow _completionWindow;

        public EditorTab()
        {
            InitializeComponent();
        }

        private void EditorTab_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextEditor.Foreground = Settings.EditorForeground;
            TextEditor.SyntaxHighlighting = Settings.EditorHighlighting;
            TextEditor.ShowLineNumbers = Properties.Settings.Default.LineNumbers;
            TextEditor.LineNumbersForeground = new SolidColorBrush(Color.FromRgb(101, 98, 88));

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
                    _completionWindow.CompletionList.RequestInsertion(e);
            };

            TextEditor.TextArea.TextEntered += (o, args) =>
            {
                if (args.Text != ".")
                    return;

                _completionWindow = new CompletionWindow(TextEditor.TextArea);

                var data = _completionWindow.CompletionList.CompletionData;

                data.AddRange(MainWindow.Scope.GetItems().Select(pair => new CompletionData(pair.Key, pair.Value.ToString())));
                data.AddRange(Settings.StaticCompletionList);

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
