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
    /// Lógica de interacción para Seleccion.xaml
    /// </summary>
    public partial class Seleccion : Page
    {
        public Seleccion()
        {
            InitializeComponent();
            CostoSeleccion.Content = GenerarCodigo.Costo;
            NoLockerDejar.Content = GenerarCodigo.NoLocker;
            TamañoSeleccion.Content = GenerarCodigo.Tamaño;
        }

        private void RegresarbBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        
        private void UnoBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("1");
        }
        
        private void DosBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("2");
        }
        
        private void TresBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("3");
        }
        
        private void CuatroBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("4");
        }
        
        private void CincoBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("5");
        }
        
        private void SeisBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("6");
        }
        
        private void SieteBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("7");
        }
        
        private void OchoBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("8");
        }
        
        private void NueveBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("9");
        }
        
        private void CeroBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("0");
        }
        
        private void QBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("Q");
        }
        
        private void WBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("W");
        }
        
        private void EBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("E");
        }
        
        private void RBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("R");
        }
        
        private void TBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("T");
        }
        
        private void YBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("Y");
        }
        
        private void UBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("U");
        }
        
        private void IBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("I");
        }
        
        private void OBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("O");
        }
        
        private void PBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("P");
        }
        
        private void DELBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.Clear();
        }
        
        private void ABtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("A");
        }
        
        private void SBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("S");
        }
        
        private void DBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("D");
        }
        
        private void FBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("F");
        }
        
        private void GBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("G");
        }
        
        private void HBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("H");
        }
        
        private void JBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("J");
        }
        
        private void KBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("K");
        }
        
        private void LBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("L");
        }
        
        private void ÑBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("Ñ");
        }
        
        private void ENTERBtn(object sender, RoutedEventArgs e)
        {
            //Enter
        }
        
        private void SHIFTIBtn(object sender, RoutedEventArgs e)
        {
            //Shift Izquierdo
        }
        
        private void ZBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("Z");
        }
        
        private void XBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("X");
        }
        
        private void CBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("C");
        }
        
        private void VBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("V");
        }
        
        private void BBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("B");
        }
        
        private void NBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("N");
        }
        
        private void MBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText("M");
        }
        
        private void COMABtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText(",");
        }
        
        private void PUNTOBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText(".");
        }
        
        private void SHIFTDBtn(object sender, RoutedEventArgs e)
        {
            //Shift Derecho
        }
        
        private void NUMBtn(object sender, RoutedEventArgs e)
        {
            //Numeros
        }
        
        private void CTRLBtn(object sender, RoutedEventArgs e)
        {
            //Ctrl
        }
        
        private void HOMEBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        
        private void ESPACIOBtn(object sender, RoutedEventArgs e)
        {
            NumeroTelefono.AppendText(" ");
        }
        
        private void FLECHA_IZQBtn(object sender, RoutedEventArgs e)
        {
            //Flecha Izquierda
        }
        
        private void FLECHA_DERBtn(object sender, RoutedEventArgs e)
        {
            //Flecha Derecha
        }
        
        private void ENGBtn(object sender, RoutedEventArgs e)
        {
            //ENG
        }

        private void CheckCode(object sender, RoutedEventArgs e)
        {

        }
    }
}
