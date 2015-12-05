using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RubyInt.Windows
{
    public partial class DocumentationWindow
    {
        public DocumentationWindow()
        {
            InitializeComponent();
        }

        private void DocumentationWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(Settings.HelpDirectory))
            {
                Directory.CreateDirectory(Settings.HelpDirectory);

                return;
            }

            foreach (var page in Directory.GetFiles(Settings.HelpDirectory).Where(s =>
            {
                var ext = Path.GetExtension(s);

                return ext != null && ext.ToLower() == ".html";
            }).Reverse())
            {
                DocList.Items.Add(Path.GetFileNameWithoutExtension(page));
            }
        }

        private void DocList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = DocList.SelectedItems[0];

            if (selected == null)
                return;

            DocBrowser.Navigate(Settings.HelpDirectory + selected + ".html");
        }
    }
}
