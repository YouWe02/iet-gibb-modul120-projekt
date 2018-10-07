using M120Projekt.View;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ChangeViewListener(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String windowName = btn.Name.Split('_')[1];
            switch (windowName)
            {
                case "Create":
                    Create createWindow = new Create();
                    createWindow.Show();
                    Close();
                    break;

                case "Search":
                    Search searchWindow = new Search();
                    searchWindow.Show();
                    Close();
                    break;

                case "Home":
                    Home homeWindow = new Home();
                    homeWindow.Show();
                    Close();
                    break;

            }
        }

    }
}
