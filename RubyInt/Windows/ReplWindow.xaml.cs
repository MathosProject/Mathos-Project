using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using IronRuby;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Utils;

namespace RubyInt.Windows
{
    public partial class ReplWindow
    {
        private readonly ScriptScope _scope;
        private readonly ScriptEngine _engine;

        private readonly MemoryStream _ms = new MemoryStream();
        private readonly MemoryStream _er = new MemoryStream();

        private int _lastBit = 1;


        public ReplWindow()
        {
            InitializeComponent();

            _engine = Ruby.CreateEngine();
            _scope = Ruby.CreateRuntime().CreateScope();

            _scope.SetVariable("pi", Math.PI);
            _scope.SetVariable("e", Math.E);
            _scope.SetVariable("_", new Extension());

            var source = _engine.CreateScriptSourceFromString("require 'RubyInt.exe'\nrequire 'Mathos.dll'\nrequire '" + Settings.DataDirectory + "Std.rb'", SourceCodeKind.Statements);

            source.Execute(_scope);
        }

        private void InputBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter && e.Key != Key.Return)
                return;

            _engine.Runtime.IO.SetOutput(_ms, Encoding.Unicode);
            _engine.Runtime.IO.SetErrorOutput(_er, Encoding.Unicode);

            try
            {
                var source = _engine.CreateScriptSourceFromString(InputBox.Text, SourceCodeKind.Statements);

                source.Execute(_scope);
            }
            catch (Exception ex)
            {
                OutputBox.Document.Blocks.Add(new Paragraph(new Run("[ERROR] " + ex.Message)));
            }

            var content = Settings.ReadFromStream(_ms, _lastBit - 1);

            _lastBit = Convert.ToInt32(_ms.Length) + 1;

            OutputBox.Document.Blocks.Clear();
            OutputBox.Document.Blocks.Add(new Paragraph(new Run("> " + InputBox.Text)));
            OutputBox.Document.Blocks.Add(new Paragraph(new Run(content)));

            InputBox.Text = "";
        }
    }
}
