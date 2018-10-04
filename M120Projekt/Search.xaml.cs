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
            InitializeHandlers();
            InitDropDownGeneration();
            InitDropDownTyp();
        }

        public void search(object sender, EventArgs e)
        {
            List<Data.Pokemon> pkms;
            try
            {
                pkms = readDatabase(txt_Name.Text, dd_Typen.Text, Int16.Parse(dd_Generation.Text));
            } catch
            {
                pkms = readDatabase(txt_Name.Text, dd_Typen.Text, 0);
            }
            if(pkms.Count < 1)
            {
                lbl_ReadDB_Error.Visibility = Visibility.Visible;
            }
            else { lbl_ReadDB_Error.Visibility = Visibility.Hidden;  }
        }

        public List<Data.Pokemon> readDatabase(String name, String type, int generation)
        {
            //TODO Aus DB lesen.
            return new List<Data.Pokemon>();
        }

        public void InitializeHandlers()
        {
            txt_Name.KeyUp += new KeyEventHandler(validateTextBox);
            btn_Suchen.Click += new RoutedEventHandler(search);
        }

        public void validateTextBox(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Label lbl = (Label)this.FindName(nameOfError(txt.Name.Split('_')[1]));
            if (regexName.IsMatch(txt.Text) || txt.Text.Equals(""))
            {
                btn_Suchen.IsEnabled = true;
                lbl.Visibility = Visibility.Hidden;
            }
            else
            {
                btn_Suchen.IsEnabled = false;
                lbl.Visibility = Visibility.Visible;
            }
        }

        public String nameOfError(String nameOfInput)
        {
            return "lbl_" + nameOfInput + "_Error";
        }

        public void InitDropDownTyp()
        {
            dd_Typen.Items.Add("Alle");
            dd_Typen.Items.Add("Normal");
            dd_Typen.Items.Add("Kampf");
            dd_Typen.Items.Add("Flug");
            dd_Typen.Items.Add("Gift");
            dd_Typen.Items.Add("Boden");
            dd_Typen.Items.Add("Gestein");
            dd_Typen.Items.Add("Käfer");
            dd_Typen.Items.Add("Geist");
            dd_Typen.Items.Add("Stahl");
            dd_Typen.Items.Add("Feuer");
            dd_Typen.Items.Add("Wasser");
            dd_Typen.Items.Add("Pflanze");
            dd_Typen.Items.Add("Elektro");
            dd_Typen.Items.Add("Psycho");
            dd_Typen.Items.Add("Eis");
            dd_Typen.Items.Add("Drache");
            dd_Typen.Items.Add("Unlicht");
            dd_Typen.Items.Add("Fee");
            dd_Typen.SelectedIndex = 0;
        }

        public void InitDropDownGeneration()
        {
            dd_Generation.Items.Add("Alle");
            dd_Generation.Items.Add("1");
            dd_Generation.Items.Add("2");
            dd_Generation.Items.Add("3");
            dd_Generation.Items.Add("4");
            dd_Generation.Items.Add("5");
            dd_Generation.Items.Add("6");
            dd_Generation.Items.Add("7");
            dd_Generation.SelectedIndex = 0;
        }
    }
}
