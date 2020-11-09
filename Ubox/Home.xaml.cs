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
using System.Threading;

namespace Ubox
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void DejarBtn(object sender, RoutedEventArgs e)
        {
            // Uri redirige a DejarPage
            Uri uri = new Uri("DejarPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void RecogerBtn(object sender, RoutedEventArgs e)
        {
            // Uri redirige a RecogerPage
            Uri uri = new Uri("RecogerPage.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
