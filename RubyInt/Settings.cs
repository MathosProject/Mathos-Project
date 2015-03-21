using System;
using System.Linq;
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

        public static EditorTab GetCurrentEditor(TabControl control)
        {
            var tab = control.SelectedItem as TabItem;

            if (tab == null)
                return null;

            return ((TabItem)control.SelectedItem).GetChildObjects().ToArray()[0] as EditorTab;
        }
    }
}
