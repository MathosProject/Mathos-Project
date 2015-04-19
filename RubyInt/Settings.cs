using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Highlighting;
using MahApps.Metro.Controls;

namespace RubyInt
{
    public class Settings
    {
        public static SolidColorBrush EditorForeground;
        public static IHighlightingDefinition EditorHighlighting;

        public static readonly string DataDirectory = Environment.CurrentDirectory + "/Data/";
        public static readonly string StyleDirectory = Environment.CurrentDirectory + "/Styles/";

        public static readonly List<CompletionData> StaticCompletionList = new List<CompletionData>
        {
            new CompletionData("fsb", "Convert a fraction represent in Stern-Brocot\nnumber system to a normal fraction.\nNote that this method is case sensetive.\nOnly L's and R's are allowed."),
            new CompletionData("new", "Creates a new instance of an object"),
            new CompletionData("save", "Save a variable to disk.\nNeeds one parameter, name."),
            new CompletionData("tsb", "Convert a fraction string (i.e. 3/7)\nto a Stern-Brocot number system.\nThe output will be expressed in terms of L's and R's.")
        };

        public static EditorTab GetCurrentEditor(TabControl control)
        {
            var tab = control.SelectedItem as TabItem;

            return (tab == null) ? null : tab.GetChildObjects().ToArray()[0] as EditorTab;
        }

        public static string ReadFromStream(Stream ms, int start = 0)
        {
            var length = (int)ms.Length;
            var bytes = new Byte[length];

            ms.Seek(start, SeekOrigin.Begin);
            ms.Read(bytes, start, (int)ms.Length - start);

            return Encoding.GetEncoding("utf-8").GetString(bytes, start, (int)ms.Length - start);
        }
    }
}
