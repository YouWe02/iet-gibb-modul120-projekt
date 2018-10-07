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
    /// Interaktionslogik für Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
        private Create oldWindow;
        private Button desiredView;
        public Popup(Create oldWindow, Button desiredView)
        {
            this.oldWindow = oldWindow;
            this.desiredView = desiredView;
            InitializeComponent();
        }

        private void ButtonListener(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            if (clicked.Name.Equals("btn_Stay"))
            {
                oldWindow.IsEnabled = true;
                Close();
            }
            else
            {
                oldWindow.ChangeView(desiredView.Name.Split('_')[1]);
                oldWindow.Close();
                Close();
            }
        }

        private void Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            oldWindow.IsEnabled = true;
        }
    }
}
