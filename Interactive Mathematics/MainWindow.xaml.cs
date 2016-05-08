using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Globalization;

using Mathos.Parser;
using Mathos.Arithmetic.Numbers;

namespace Interactive_Mathematics
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// The logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        readonly MathParser _parser = new MathParser();
        FrmTable _form = new FrmTable();

        public MainWindow()
        {
            InitializeComponent();
            TextBox1.Focus();

            _parser.OperatorList.Add("isnot");
            _parser.OperatorList.Add("and");
            _parser.OperatorList.Add("or");

            _parser.OperatorAction.Add("isnot", (x, y) => x != y ? 1 : 0);
            _parser.OperatorAction.Add("and", (x, y) => x == 1 && y == 1 ? 1 : 0);
            _parser.OperatorAction.Add("or", (x, y) => x == 1 || y == 1 ? 1 : 0);

            _parser.LocalFunctions.Add("IsPrime", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Check.IsPrime((long)x[0]) ? 1 : 0;
                }

                throw new ArgumentException("The input is not an integer");
            });

            _parser.LocalFunctions.Add("IsOdd", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Check.IsOdd((long)x[0]) ? 1 : 0;
                }

                throw new ArgumentException("The input is not an integer");
            });

            _parser.LocalFunctions.Add("IsEven", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Check.IsEven((long)x[0]) ? 1 : 0;
                }

                throw new ArgumentException("The input is not an integer");
            });

            _parser.LocalFunctions.Add("IsCoprime", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Check.IsCoprime((long)x[0],(long)x[1]) ? 1 : 0;
                }
                
                throw new ArgumentException("The input is not an integer");
            });

            _parser.LocalFunctions.Add("gdc", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Get.Gdc((long)x[0], (long)x[1]);
                }
                
                throw new ArgumentException("The input is not an integer");
            });

            _parser.LocalFunctions.Add("lcm", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Get.Lcm((long)x[0], (long)x[1]);
                }
            
                throw new ArgumentException("The input is not an integer");
            });

            _parser.LocalFunctions.Add("mod", x =>
            {
                if (x[0] % 1 == 0) // check if it's an integer
                {
                    return Get.Gdc((long)x[0], (long)x[1]);
                }
                
                throw new ArgumentException("The input is not an integer");
            });

            _parser.LocalFunctions.Add("mean", x =>
            {
                var result = x.Sum();

                return result / x.Length;
            });


            //tables
            //one main problem, we cannot store a the variable x in a decimal
            var isDone = false;

            _parser.LocalFunctions.Add("table", x =>
            {
                // remake this method, so that the the parser.LocalVariables["x"] < parser.LocalVariables["table_max"]
                // is in front of everything. then, we can reuse  the newWindow check code
                GC.Collect();

                if (isDone == false)
                {
                    _parser.LocalVariables["x"] = _parser.LocalVariables["table_min"];
                    if (_parser.LocalVariables["newWindow"] == 1)
                    {
                        _form = new FrmTable();
                    }
                    else
                    {
                        ListView1.Items.Add("x  |  y");
                        ListView1.Items.Add("-----------");
                    }
                    isDone = true;
                }

                if (_parser.LocalVariables["x"] <= _parser.LocalVariables["table_max"])
                {
                    if (_parser.LocalVariables["newWindow"] == 1)
                    {
                        _form.Funcs.Add(_parser.LocalVariables["x"], x[0]);
                    }
                    else
                    {
                        ListView1.Items.Add(_parser.LocalVariables["x"] + "  :  " + x[0]);
                    }
                    _parser.LocalVariables["x"] += _parser.LocalVariables["table_step"];
                    _parser.Parse(TextBox1.Text);
                    _parser.LocalVariables["x"] += _parser.LocalVariables["table_step"];
                    
                }
                else
                {
                    if (_parser.LocalVariables["newWindow"] == 1)
                    {
                        _form.ShowDialog();
                    }
                    _parser.LocalVariables["x"] = 0;
                    isDone = false;
                }

                return 1;
            });
            
            _parser.LocalVariables.Add("table_min", 0);
            _parser.LocalVariables.Add("table_max", 100);
            _parser.LocalVariables.Add("table_step", 1);
            _parser.LocalVariables.Add("newWindow",1);
            _parser.LocalVariables.Add("x", 0);

            // conditional operators
            _parser.LocalFunctions.Add("if", x =>
            {
                if (x[0] == 1)
                {
                    return x[1];
                }
                
                return x.Length == 3 ? x[2] : 0;
            });

            DataGrid1.ItemsSource = _parser.LocalVariables;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            // create a variable list at the RHS
            try
            {
                switch (e.Key)
                {
                    case Key.Enter:
                        ListView1.Items.Add(TextBox1.Text);
                        ListView1.Items.Add(_parser.ProgrammaticallyParse(TextBox1.Text).ToString(new CultureInfo("en-US")));
                        TextBox1.Text = "";
                        break;
                    default:
                        return;
                }
            }
            catch (Exception ex)
            {
                ListView1.Items.Add( ex.Message);

                TextBox1.Text = "";

            }
            finally
            {
                if (e.Key == Key.Enter)
                {
                    ListView1.ScrollIntoView(ListView1.Items.Count);
                    DataGrid1.Items.Refresh();
                }
            }
            
        }

        private void treeView1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var item = TreeView1.SelectedItem as TreeViewItem;

            if (item == null) return;
            
            if (_parser.LocalFunctions.ContainsKey(item.Header.ToString()))
            {
                TextBox1.SelectedText = item.Header + "(";
                TextBox1.Focus();
                TextBox1.Select(TextBox1.SelectionStart + TextBox1.SelectionLength, 0);

            }
            else if (_parser.LocalVariables.ContainsKey(item.Header.ToString()))
            {
                TextBox1.SelectedText = item.Header + " := ";
                TextBox1.Focus();
                TextBox1.Select(TextBox1.SelectionStart + TextBox1.SelectionLength, 0);
            }
            else if(_parser.OperatorList.Contains(item.Header.ToString()))
            {
                TextBox1.SelectedText = item.Header.ToString();
                TextBox1.Focus();
                TextBox1.Select(TextBox1.SelectionStart + TextBox1.SelectionLength, 0);
            }
        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dynamic item = DataGrid1.SelectedItem;

            if (item.Key == "") return;
            
            TextBox1.SelectedText = item.Key;
            TextBox1.Focus();
            TextBox1.Select(TextBox1.SelectionStart + TextBox1.SelectionLength, 0);
        }


        private void listView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListView1.SelectedItem == null) return;
            
            TextBox1.Select(TextBox1.SelectionStart + TextBox1.SelectionLength, 0);
            TextBox1.SelectedText = (String)ListView1.SelectedItem;
        }
    }
}
