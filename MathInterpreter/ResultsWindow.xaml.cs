using System;

namespace MathInterpreter
{
    public partial class ResultsWindow
    {
        public static ResultsWindow Instance;

        public ResultsWindow()
        {
            InitializeComponent();
        }

        private void ResultsWindow_OnClosed(object sender, EventArgs e)
        {
            Instance = null;
        }

        public static void Open()
        {
            if (Instance != null)
                return;

            Instance = new ResultsWindow();
            Instance.Show();
        }
    }
}
