using M120Projekt.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            firstOutput();
        }

        public void firstOutput()
        {
            List<Data.Pokemon> pkmns = API_Pokemon.Get_All_Pokemon();

            foreach(Data.Pokemon pkmn in pkmns)
            {
                PokemonRow row = new PokemonRow(pkmn);
                this.pkmns.Children.Add(row);
            }
        }

    }
}
