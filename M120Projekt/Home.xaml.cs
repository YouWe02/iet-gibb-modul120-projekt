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
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private UserControl ChangeViewListener(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            String windowName = btn.Name.Split('_')[1];
            switch (windowName)
            {
                case "Create":
                    return new Create();

                case "Search":
                    return new Search();

                case "Home":
                    return this;

            }
            return this;
        }

    }
}
