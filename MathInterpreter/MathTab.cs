using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Windows.Controls;

using Microsoft.Win32;

using ICSharpCode.AvalonEdit;

using Mathos.Parser;

namespace MathInterpreter
{
    public class MathTab : TabItem
    {
        private string _filePath;
        private bool _savedBefore;

        private readonly MathParser _parser = new MathParser();
        private readonly TextEditor _editor = new TextEditor();

        public MathTab() : this("Untitled")
        {
        }

        public MathTab(string header)
        {
            Header = header;
            Content = _editor;

            _editor.FontSize = Properties.Settings.Default.EditorFontSize;
        }

        public void Run()
        {
            ResultsWindow.Open();

            var lineNumber = 1;
            var builder = new StringBuilder();

            foreach (var line in _editor.Text.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                if(line.Trim().Length == 0)
                    continue;

                try
                {
                    builder.AppendLine(_parser.ProgrammaticallyParse(line).ToString(CultureInfo.InvariantCulture));
                }
                catch (Exception e)
                {
                    builder.AppendLine("ERROR (Line " + lineNumber + ") : " + e.Message);
                }

                lineNumber++;
            }

            ResultsWindow.Instance.Results.Text = builder.ToString();
        }

        public void Save()
        {
            if (!_savedBefore)
            {
                SaveAs();

                return;
            }

            File.WriteAllText(_filePath, _editor.Text);
        }

        public void SaveAs()
        {
            var saveFile = new SaveFileDialog {Filter = "Mathos Parser File (*.mpf)|*.mpf|Any File (*.*)|*.*", CheckPathExists = true};

            if (saveFile.ShowDialog() != true)
                return;

            Header = Path.GetFileName(saveFile.FileName);

            _savedBefore = true;
            _filePath = saveFile.FileName;

            File.WriteAllText(_filePath, _editor.Text);
        }
        
        public static MathTab Open()
        {
            var openFile = new OpenFileDialog {Filter = "Mathos Parser File (*.mpf)|*.mpf|Any File (*.*)|*.*", CheckFileExists = true};

            if (openFile.ShowDialog() != true)
                return null;

            var tab = new MathTab(Path.GetFileName(openFile.FileName)) {_filePath = openFile.FileName};

            tab._editor.Text = File.ReadAllText(openFile.FileName);

            return tab;
        }
    }
}
