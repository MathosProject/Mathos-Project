using System;
using System.IO;

namespace RubyInt
{
    public partial class EditorTab
    {
        public bool Saved = true;
        public bool FirstSave = true;

        public EditorTab()
        {
            InitializeComponent();

            Header = "Untitled";
        }

        public EditorTab(string file)
        {
            InitializeComponent();

            Header = Path.GetFileNameWithoutExtension(file);
            TextEditor.Text = File.ReadAllText(file);
            FirstSave = false;
        }

        public void Save(string file, bool saveAs = false)
        {
            
        }

        private void TextEditor_OnTextChanged(object sender, EventArgs e)
        {
            Saved = false;
        }
    }
}
