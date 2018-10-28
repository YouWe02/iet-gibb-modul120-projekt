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
    /// Interaktionslogik für PokemonRow.xaml
    /// </summary>
    public partial class PokemonRow : UserControl
    {
        Data.Pokemon pkmn;
        private long id;
        private string name;
        private long ang;
        private long ver;
        private long sAng;
        private long sVer;
        private long init;
        private long kp;
        private string pkdx;

        public PokemonRow(Data.Pokemon pkmn)
        {
            InitializeComponent();

            btn_Delete.Click += new RoutedEventHandler(Delete);
            this.pkmn = pkmn;

            id = pkmn.Nr_Pokemon;
            name = pkmn.Name;
            ang = pkmn.Angriff;
            ver = pkmn.Verteidigung;
            sAng = pkmn.Spezial_Angriff;
            sVer = pkmn.Spezial_Verteidigung;
            init = pkmn.Initiative;
            kp = pkmn.KP;
            pkdx = pkmn.Pokedex_Eintrag;

            initLabels();
        }

        public void initLabels()
        {
            pkmn_Nr.Content = "Nr: " + id;
            pkmn_Name.Content = "Name: " + name;
            pkmn_Angriff.Content = "Ang: " + ang;
            pkmn_Verteidigung.Content = "Ver: " + ver;
            pkmn_SpezialAngriff.Content = "sAng: " + sAng;
            pkmn_SpezialVerteidigung.Content = "sVer: " + sVer;
            pkmn_Initiative.Content = "Init: " + init;
            pkmn_KP.Content = "KP: " + kp;
            pkmn_Pokedex.Content = "Pkdx: " + pkdx;

            string typen = "Typen: ";

            foreach(Data.Typ typ in pkmn.Typs)
            {
                if (typ != null)
                {
                    typen += typ.Type + "  ";
                }
            }

            pkmn_Typen.Content = typen;

        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            API_Pokemon.Delete_Pokemon(id);
            Infos.Children.RemoveRange(0, Infos.Children.Count);
        }
    }
}
