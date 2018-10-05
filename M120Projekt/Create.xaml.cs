using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
            InitDropDownGeneration();
            InitDropDownsTyp();
        }

        public void InitDropDownsTyp()
        {
            dd_Typen1.Items.Add("Normal");
            dd_Typen1.Items.Add("Kampf");
            dd_Typen1.Items.Add("Flug");
            dd_Typen1.Items.Add("Gift");
            dd_Typen1.Items.Add("Boden");
            dd_Typen1.Items.Add("Gestein");
            dd_Typen1.Items.Add("Käfer");
            dd_Typen1.Items.Add("Geist");
            dd_Typen1.Items.Add("Stahl");
            dd_Typen1.Items.Add("Feuer");
            dd_Typen1.Items.Add("Wasser");
            dd_Typen1.Items.Add("Pflanze");
            dd_Typen1.Items.Add("Elektro");
            dd_Typen1.Items.Add("Psycho");
            dd_Typen1.Items.Add("Eis");
            dd_Typen1.Items.Add("Drache");
            dd_Typen1.Items.Add("Unlicht");
            dd_Typen1.Items.Add("Fee");
            dd_Typen1.SelectedIndex = 0;

            dd_Typen2.Items.Add("Keinen");
            dd_Typen2.Items.Add("Normal");
            dd_Typen2.Items.Add("Kampf");
            dd_Typen2.Items.Add("Flug");
            dd_Typen2.Items.Add("Gift");
            dd_Typen2.Items.Add("Boden");
            dd_Typen2.Items.Add("Gestein");
            dd_Typen2.Items.Add("Käfer");
            dd_Typen2.Items.Add("Geist");
            dd_Typen2.Items.Add("Stahl");
            dd_Typen2.Items.Add("Feuer");
            dd_Typen2.Items.Add("Wasser");
            dd_Typen2.Items.Add("Pflanze");
            dd_Typen2.Items.Add("Elektro");
            dd_Typen2.Items.Add("Psycho");
            dd_Typen2.Items.Add("Eis");
            dd_Typen2.Items.Add("Drache");
            dd_Typen2.Items.Add("Unlicht");
            dd_Typen2.Items.Add("Fee");
            dd_Typen2.SelectedIndex = 0;
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
