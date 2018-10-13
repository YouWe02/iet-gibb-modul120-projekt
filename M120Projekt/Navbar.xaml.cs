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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Navbar.xaml
    /// </summary>
    public partial class Navbar : Window
    {
        private Create createView;
        private Home homeView;
        private Search searchView;

        private Boolean create = false;

        public Navbar()
        {
            InitializeComponent();
            homeView = new Home();
            stp_content.Children.Add(homeView);
        }

        public void ChangeViewListener (object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (create)
            {
                IsEnabled = false;
                Popup popup = new Popup(this, btn);
                popup.Show();
            } else
            {
                ChangeView(btn.Name.Split('_')[1]);
            }
        }
        public void ChangeView(String desiredView)
        {
            stp_content.Children.RemoveAt(0);
            switch (desiredView)
            {
                case "Home":
                    create = false;
                    homeView = new Home();
                    stp_content.Children.Add(homeView);
                    break;
                case "Search":
                    create = false;
                    searchView = new Search();
                    stp_content.Children.Add(searchView);
                    break;
                case "Create":
                    create = true;
                    createView = new Create();
                    stp_content.Children.Add(createView);
                    break;
            }

        }
    }
}
