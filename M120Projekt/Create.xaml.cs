using M120Projekt.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Create.xaml
    /// </summary>
    public partial class Create : UserControl
    {
        private Regex regexInt = new Regex("^[0-9]+$");
        private Regex regexString = new Regex("^[a-zA-Z]+$");

        public Create()
        {
            InitializeComponent();
            InitDropDownGeneration();
            InitDropDownsTyp();
        }

        public void validateTextBox(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Label lbl = (Label)this.FindName("lbl_" + txt.Name.Split('_')[1]);
            String datatype = txt.Name.Split('_')[2];
            if (datatype.Equals("String"))
            {
                if (regexString.IsMatch(txt.Text) || txt.Text.Equals(""))
                {
                    btn_Create.IsEnabled = true;
                    lbl.Foreground = Brushes.Black;
                }
                else
                {
                    btn_Create.IsEnabled = false;
                    lbl.Foreground = Brushes.Red;
                }
            } else if (datatype.Equals("Int"))
            {
                if(regexInt.IsMatch(txt.Text) || txt.Text.Equals(""))
                {
                    btn_Create.IsEnabled = true;
                    lbl.Foreground = Brushes.Black;
                }
                else
                {
                    btn_Create.IsEnabled = false;
                    lbl.Foreground = Brushes.Red;
                }
            }
        }

        private void Save(object sender, RoutedEventArgs e) {
            long pkdx_nr = long.Parse(txt_PokedexNr_Int.Text);
            string name = txt_Name_String.Text;

            long generation = long.Parse(dd_Generation.SelectedValue.ToString());

            long angriff = long.Parse(txt_Angriff_Int.Text);
            long verteidigung = long.Parse(txt_Verteidigung_Int.Text);
            long spezial_angriff = long.Parse(txt_SpezialAngriff_Int.Text);
            long spezial_verteidigung = long.Parse(txt_SpezialVerteidigung_Int.Text);
            long kp = long.Parse(txt_KP_Int.Text);
            long initiative = long.Parse(txt_Initiative_Int.Text);

            string pokedex_eintrag = txt_Pokedex.Text;

            List<Int64> typen = new List<long>();

            long typ_1 = long.Parse(dd_Typen1.SelectedValue.ToString());
            long typ_2 = long.Parse(dd_Typen2.SelectedValue.ToString());

            typen.Add(typ_1);
            if(typ_2 != 0)
            {
                typen.Add(typ_2);
            }

            API_Pokemon.Create_Pokemon(pkdx_nr, name, generation, angriff, verteidigung, spezial_angriff, spezial_verteidigung, kp, initiative, pokedex_eintrag, typen);

            txt_Name_String.Text = "";
            txt_PokedexNr_Int.Text = "";
            dd_Generation.SelectedIndex = 0;
            txt_Angriff_Int.Text = "";
            txt_Verteidigung_Int.Text = "";
            txt_SpezialAngriff_Int.Text = "";
            txt_SpezialVerteidigung_Int.Text = "";
            txt_KP_Int.Text = "";
            txt_Initiative_Int.Text = "";
            txt_Pokedex.Text = "";
            dd_Typen1.SelectedIndex = 0;
            dd_Typen2.SelectedIndex = 0;
        }
        public void InitDropDownsTyp()
        {
            ICollection<Data.Typ> types = API_Pokemon.Get_All_Types();
            dd_Typen2.Items.Add(new KeyValuePair<int, string>(0, "--none--"));
            foreach (Data.Typ type in types) {
                dd_Typen1.Items.Add(new KeyValuePair<int, string>((int)type.ID_Typ, type.Type));
                dd_Typen2.Items.Add(new KeyValuePair<int, string>((int)type.ID_Typ, type.Type));
            }
            dd_Typen1.SelectedIndex = 0;
            dd_Typen2.SelectedIndex = 0;
        }

        public void InitDropDownGeneration()
        {
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
