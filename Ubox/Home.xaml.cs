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
using System.Threading.Tasks;
using System.Configuration;
using Ubox.ModelService.Autenticacion;
using Ubox.ModelService;
using Newtonsoft.Json;

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
            var x = Globals.getMacAddress();
        }

    

        private async void DejarBtn(object sender, RoutedEventArgs e)
        {
            // Uri redirige a DejarPage
            if(await Globals.iniciaSesionAsync())
            {
                Uri uri = new Uri("DejarPage.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }

        }

        private async void RecogerBtn(object sender, RoutedEventArgs e)
        {
            if(await Globals.iniciaSesionAsync())
            {
                // Uri redirige a RecogerPage
                Uri uri = new Uri("RecogerPage.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }

           
        }
    }
}
