using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using IronRuby;
using Microsoft.Scripting.Hosting;
using ScintillaNET;

namespace RubyInt
{
    public static class Settings
    {
        public static readonly string HelpDirectory = Environment.CurrentDirectory + "/Help/";

        public static readonly ScriptEngine RubyTemplate = Ruby.CreateEngine();
        public static readonly ScriptScope ScopeTemplate = RubyTemplate.CreateScope();

        [CLSCompliant(false)] public static readonly Scintilla ScintillaTemplate = new Scintilla
        {
            Lexer = Lexer.Ruby,
            Styles =
            {
                [Style.Default] =
                {
                    Font = "Consolas",
                    Size = 12
                },
                [Style.Ruby.CommentLine] = { ForeColor = Color.DimGray },
                [Style.Ruby.String] = { ForeColor = Color.FromArgb(71, 140, 00) },
                [Style.Ruby.Character] = { ForeColor = Color.FromArgb(71, 140, 00) },
                [Style.Ruby.Word] = { ForeColor = Color.FromArgb(89, 59, 168), Bold = true },
                [Style.Ruby.Identifier] = { ForeColor = Color.FromArgb(42, 71, 174) },
                [Style.Ruby.ClassName] = { ForeColor = Color.FromArgb(42, 71, 174) },
                [Style.Ruby.ModuleName] = { ForeColor = Color.FromArgb(42, 71, 174) },
                [Style.Ruby.Number] = { ForeColor = Color.FromArgb(245, 87, 31)}
            }
        };

        public static void Initialize()
        {
            var std = Environment.CurrentDirectory + "/Std.rb";
            
            ScopeTemplate.Engine.Runtime.LoadAssembly(Assembly.LoadFile(Environment.CurrentDirectory + "/Mathos.dll"));
            ScopeTemplate.SetVariable("_", new Extension());

            if (File.Exists(std))
                RubyTemplate.ExecuteFile(std);

            ScintillaTemplate.SetKeywords(0, "include begin end alias and break case class def defined? do else elsif ensure false for if in module next nil not or redo rescue retry return self super then true undef unless until when while yield __encoding__ __end__ __file__ __line__");
        }

        public static string ReadFromStream(MemoryStream stream, int start = 0)
        {
            var length = (int) stream.Length;
            var bytes = new byte[length];

            stream.Seek(start, SeekOrigin.Begin);
            stream.Read(bytes, start, length);

            return Encoding.UTF8.GetString(bytes, start, length - start);
        }
    }
}
