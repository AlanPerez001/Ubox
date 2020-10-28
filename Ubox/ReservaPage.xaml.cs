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
    /// Lógica de interacción para ReservaPage.xaml
    /// </summary>
    public partial class ReservaPage : Page
    {
        public ReservaPage()
        {
            InitializeComponent();
            CostoReservado.Content = "$" + GenerarCodigo.Costo * GenerarCodigo.SumaDiasInt;
            NoLockerReservado.Content = GenerarCodigo.NoLocker;
            CodeGenerate.Content = Seleccion.CodeGenerated;
        }

        private void RegresarbBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void FinalizarBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
