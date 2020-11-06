using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.Timers;

namespace Ubox
{
    /// <summary>
    /// Lógica de interacción para Seleccion.xaml
    /// </summary>
    public partial class Seleccion : Page
    {
        public static Random random = new Random();
        public static string CodeGenerated { get; set; }
        public Seleccion()
        {
            InitializeComponent();
            CostoSeleccion.Content = "$" + GenerarCodigo.Costo * GenerarCodigo.SumaDiasInt;
            NoLockerDejar.Content = GenerarCodigo.NoLocker;
            TamañoSeleccion.Content = GenerarCodigo.Tamaño;

            InicioReserva.Content = MainWindow.today.ToString("dd/MM/yyyy HH:mm:ss");
            VencimientoReserva.Content = GenerarCodigo.SumaDiasFecha.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void RegresarbBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UnoBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("1");
            }

        }

        private void DosBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("2");
            }

        }

        private void TresBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("3");
            }

        }

        private void CuatroBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("4");
            }

        }

        private void CincoBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("5");
            }

        }

        private void SeisBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("6");
            }

        }

        private void SieteBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("7");
            }

        }

        private void OchoBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("8");
            }

        }

        private void NueveBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("9");
            }

        }

        private void CeroBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("0");
            }

        }

        private void QBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("Q");
            }

        }

        private void WBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("W");
            }

        }

        private void EBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("E");
            }

        }

        private void RBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("R");
            }

        }

        private void TBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("T");
            }

        }

        private void YBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("Y");
            }

        }

        private void UBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("U");
            }

        }

        private void IBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("I");
            }

        }

        private void OBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("O");
            }

        }

        private void PBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("P");
            }

        }

        private void DELBtn(object sender, RoutedEventArgs e)
        {

            NumeroTelefono.Clear();


        }

        private void ABtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("A");
            }

        }

        private void SBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("S");
            }

        }

        private void DBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("D");
            }

        }

        private void FBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("F");
            }

        }

        private void GBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("G");
            }

        }

        private void HBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("H");
            }

        }

        private void JBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("J");
            }

        }

        private void KBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("K");
            }

        }

        private void LBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("L");
            }

        }

        private void ÑBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("Ñ");
            }

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
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("Z");
            }

        }

        private void XBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("X");
            }

        }

        private void CBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("C");
            }

        }

        private void VBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("V");
            }

        }

        private void BBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("B");
            }

        }

        private void NBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("N");
            }

        }

        private void MBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText("M");
            }

        }

        private void COMABtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText(",");
            }

        }

        private void PUNTOBtn(object sender, RoutedEventArgs e)
        {
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText(".");
            }

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
            string Numero = NumeroTelefono.Text;
            if (Numero.Length <= 9)
            {
                NumeroTelefono.AppendText(" ");
            }

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
        private void InsertReserva(string CodeGenerated , string Usuario)
        {
            string CodeEncrypted = MainWindow.Encrypt(CodeGenerated);
            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"INSERT INTO Usuarios(Usuario,NoLocker , Vencimiento, DiaRenta, UbicacionLocker, Codigo) VALUES ('" + Usuario + "', '" + GenerarCodigo.NoLocker + "' , '" + GenerarCodigo.SumaDiasFecha.ToString("dd/MM/yyyy HH:mm") + "','" + MainWindow.today.ToString("dd/MM/yyyy HH:mm") + "','Zion','" + CodeEncrypted + "');";
            string SqlUpdate = @"UPDATE [dbo].[Lockers] SET [Disponible] = 1, [Codigo] = '" + CodeEncrypted + "' WHERE NoLocker = '" + GenerarCodigo.NoLocker + "'";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand QueryInsert = new SqlCommand(sql, conn);
                QueryInsert.ExecuteNonQuery();

                SqlCommand QueryUpdate = new SqlCommand(SqlUpdate, conn);
                QueryUpdate.ExecuteNonQuery();
            }
        }



        private void ReservarBtn(object sender, RoutedEventArgs e)
        {
            string numero = NumeroTelefono.Text;
            if (numero.Length == 10)
            {
                int lengthcode = 6;
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                CodeGenerated = new string(Enumerable.Repeat(chars, lengthcode)
                   .Select(s => s[random.Next(s.Length)]).ToArray());
                Thread ReservaThread = new Thread( () => InsertReserva(CodeGenerated, numero));
                ReservaThread.Start();
                Uri uri = new Uri("ReservaPage.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                NumeroIncorrecto.Visibility = Visibility.Visible;
            }

        }
    }
}
