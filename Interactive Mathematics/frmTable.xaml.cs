using System.Collections.Generic;

namespace Interactive_Mathematics
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// Logic of interaction for Window1.xaml
    /// </summary>
    public partial class FrmTable
    {
        public FrmTable()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = Funcs;
        }

        public Dictionary<decimal, decimal> Funcs = new Dictionary<decimal, decimal>();
    }
}
