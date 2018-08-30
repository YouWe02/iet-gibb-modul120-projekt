using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Aufruf diverse APIDemo Methoden
            API_Pokemon.Create_Typ("Pflanze");
            API_Pokemon.Create_Typ("Gift");
            ICollection<Data.Typ> typs = new Collection<Data.Typ>();
            typs.Add(Data.Typ.Search("Pflanze").FirstOrDefault());
            typs.Add(Data.Typ.Search("Gift").FirstOrDefault());

            API_Pokemon.Create_Pokemon(1 ,"Bisasam", 1, 49, 49, 65, 65, 45, 45, "Dieses Pokemon trägt von Geburt an einen Samen auf dem Rücken, der mit ihm keimt und wächst.", typs);
            API_Pokemon.Get_All_Pokemon();
        }
    }
}
