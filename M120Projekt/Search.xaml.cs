using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M120Projekt.View
{
    /// <summary>
    /// Interaktionslogik für Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private Regex regexName = new Regex("^[a-zA-Z]+$");
        public Search()
        {
            InitializeComponent();
            txtName.KeyUp += new KeyEventHandler(validateTextBox);
            btnSuchen.Click += new RoutedEventHandler(search);
        }

        public void validateTextBox(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (regexName.IsMatch(txt.Text) || txt.Text.Equals("")){
                btnSuchen.IsEnabled = true;
            }
            else
            {
                btnSuchen.IsEnabled = false;
            }
        }

        public void search(object sender, EventArgs e)
        {
            List<Data.Pokemon> pkms = readDatabase("pikachu", "", 0);
            if(pkms.Count < 1)
            {
                lblError.Visibility = Visibility.Visible;
            }
            else { lblError.Visibility = Visibility.Hidden;  }
        }

        public List<Data.Pokemon> readDatabase(String name, String type, int generation)
        {
            return new List<Data.Pokemon>();
        }
    }
}
