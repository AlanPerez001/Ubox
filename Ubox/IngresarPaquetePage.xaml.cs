using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ubox
{
    /// <summary>
    /// Lógica de interacción para IngresarPaquetePage.xaml
    /// </summary>
    public partial class IngresarPaquetePage : Page
    {
        public IngresarPaquetePage()
        {
            InitializeComponent();
        }

        private void RegresarbBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
