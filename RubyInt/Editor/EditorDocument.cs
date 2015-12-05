using System;
using System.IO;
using System.Text;
using System.Windows.Forms.Integration;
using Microsoft.Scripting.Hosting;
using Microsoft.Win32;
using ScintillaNET;
using Xceed.Wpf.AvalonDock.Layout;

namespace RubyInt.Editor
{
    public class EditorDocument : LayoutDocument
    {
        public bool SavedBefore;
        public string InputFile;
        
        [CLSCompliant(false)]
        public Scintilla Editor
        {
            get
            {
                return ((WindowsFormsHost) Content).Child as Scintilla;
            }
        }

        private readonly ScriptEngine _ruby;
        private readonly ScriptScope _scope;
        private readonly MemoryStream _output;

        public EditorDocument(string input = "")
        {
            if (input == "")
            {
                Title = "Untitled";
                SavedBefore = false;
            }
            else
            {
                Title = Path.GetFileName(input);
                SavedBefore = true;
                InputFile = input;
            }

            _ruby = Settings.RubyTemplate;
            _scope = Settings.ScopeTemplate;
            _output = new MemoryStream();
            _ruby.Runtime.IO.SetOutput(_output, Encoding.UTF8);

            var editor = Settings.ScintillaTemplate;
            
            if (input != "")
                editor.Text = File.ReadAllText(input);

            Content = new WindowsFormsHost
            {
                Child = editor
            };
        }

        public string Run()
        {
            try
            {
                _output.SetLength(0);
                _ruby.Execute(Editor.Text, _scope);

                return Settings.ReadFromStream(_output);
            }
            catch (Exception e)
            {
                return "ERROR!" + Environment.NewLine + e.Message;
            }
        }

        public void Save()
        {
            if (!SavedBefore)
            {
                SaveAs();

                return;
            }

            Title = Path.GetFileName(InputFile);
            File.WriteAllText(InputFile, Editor.Text);
        }

        public void SaveAs()
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "Ruby File (*.rb)|*.rb|Any File (*.*)|*.*",
                CheckPathExists = true,
                RestoreDirectory = true
            };

            if (saveDialog.ShowDialog() != true || saveDialog.FileName.Trim().Length <= 0)
                return;

            SavedBefore = true;
            InputFile = saveDialog.FileName;
            Title = Path.GetFileName(saveDialog.FileName);
            File.WriteAllText(saveDialog.FileName, Editor.Text);
        }
    }
}
