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

namespace Ubox
{
    /// <summary>
    /// Lógica de interacción para DejarPage.xaml
    /// </summary>
    public partial class GenerarCodigo : Page
    {
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public GenerarCodigo()
        {
            InitializeComponent();

            Thread thLocker = new Thread(() => GetLockers((App.Current as App).ConnectionString));
            thLocker.Start();

            Thread thTable = new Thread(() => FillTable((App.Current as App).ConnectionString));
            //thTable.Start();
        }

        private void FillTable(string ConnectionString)
        {
            string sql = @"Select Tamaño, Alto, Ancho, Costo from Lockers GROUP BY Tamaño, Alto, Ancho, Costo";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader != null)
                    {

                        List<Filas> filas = new List<Filas>();
                        Filas fila = new Filas();
                        while (reader.Read())
                        {

                            String Tamaño = Convert.ToString(reader["Tamaño"]);
                            int Alto = Convert.ToInt32(reader["Alto"]);
                            int Ancho = Convert.ToInt32(reader["Ancho"]);
                            int Costo = Convert.ToInt32(reader["Costo"]);

                            Console.WriteLine(Tamaño);
                            /*Console.WriteLine(Alto);
                            Console.WriteLine(Ancho);
                            Console.WriteLine(Costo);*/


                            fila.Columna1 = Tamaño;
                            Console.WriteLine(fila);
                            /*fila.Columna2 = Alto.ToString();
                            fila.Columna3 = Ancho.ToString();
                            fila.Columna4 = Costo.ToString();*/
                            
                            
                        }
                        filas.Add(fila);
                        dataGrid1.Dispatcher.Invoke(new Action(() => dataGrid1.ItemsSource = filas));
                    }
                }
            }
        }

        public class Filas
        {
            public string Columna1 { set; get; }
            public string Columna2 { set; get; }
            public string Columna3 { set; get; }
            public string Columna4 { set; get; }
        }

        private void RegresarbBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void PassMd5(object sender, RoutedEventArgs e)
        {
            var text = "9H21Z0";
            Console.WriteLine("Cadena: " + text);

            var cipher = Encrypt(text);
            Console.WriteLine("Codificado: " + cipher);

            text = Decrypt(cipher);
            Console.WriteLine("Decodificado: " + text);
        }

        public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public static string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }

        private void GetLockers(string ConnectionString)
        {
            string sql = @"SELECT * FROM Lockers";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            int locker = Convert.ToInt32(reader["NoLocker"]);
                            int disponible = Convert.ToInt32(reader["Disponible"]);
                            Console.WriteLine(locker);
                            if (disponible != 1)
                            {

                                switch (locker)
                                {
                                    case 1:
                                        Locker1.Dispatcher.Invoke(new Action(() => Locker1.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 2:
                                        Locker2.Dispatcher.Invoke(new Action(() => Locker2.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 3:
                                        Locker3.Dispatcher.Invoke(new Action(() => Locker3.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 4:
                                        Locker4.Dispatcher.Invoke(new Action(() => Locker4.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 5:
                                        Locker5.Dispatcher.Invoke(new Action(() => Locker5.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 6:
                                        Locker6.Dispatcher.Invoke(new Action(() => Locker6.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 7:
                                        Locker7.Dispatcher.Invoke(new Action(() => Locker7.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 8:
                                        Locker8.Dispatcher.Invoke(new Action(() => Locker8.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 9:
                                        Locker9.Dispatcher.Invoke(new Action(() => Locker9.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 10:
                                        Locker10.Dispatcher.Invoke(new Action(() => Locker10.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 11:
                                        Locker11.Dispatcher.Invoke(new Action(() => Locker11.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 12:
                                        Locker12.Dispatcher.Invoke(new Action(() => Locker12.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 13:
                                        Locker13.Dispatcher.Invoke(new Action(() => Locker13.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 14:
                                        Locker14.Dispatcher.Invoke(new Action(() => Locker14.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 15:
                                        Locker15.Dispatcher.Invoke(new Action(() => Locker15.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 16:
                                        Locker16.Dispatcher.Invoke(new Action(() => Locker16.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 17:
                                        Locker17.Dispatcher.Invoke(new Action(() => Locker17.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 18:
                                        Locker18.Dispatcher.Invoke(new Action(() => Locker18.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 19:
                                        Locker19.Dispatcher.Invoke(new Action(() => Locker19.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 20:
                                        Locker20.Dispatcher.Invoke(new Action(() => Locker20.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 21:
                                        Locker21.Dispatcher.Invoke(new Action(() => Locker21.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 22:
                                        Locker22.Dispatcher.Invoke(new Action(() => Locker22.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 23:
                                        Locker23.Dispatcher.Invoke(new Action(() => Locker23.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 24:
                                        Locker24.Dispatcher.Invoke(new Action(() => Locker24.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 25:
                                        Locker25.Dispatcher.Invoke(new Action(() => Locker25.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 26:
                                        Locker26.Dispatcher.Invoke(new Action(() => Locker26.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 27:
                                        Locker27.Dispatcher.Invoke(new Action(() => Locker27.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 28:
                                        Locker28.Dispatcher.Invoke(new Action(() => Locker28.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 29:
                                        Locker29.Dispatcher.Invoke(new Action(() => Locker29.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 30:
                                        Locker30.Dispatcher.Invoke(new Action(() => Locker30.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 31:
                                        Locker31.Dispatcher.Invoke(new Action(() => Locker31.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 32:
                                        Locker32.Dispatcher.Invoke(new Action(() => Locker32.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 33:
                                        Locker33.Dispatcher.Invoke(new Action(() => Locker33.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 34:
                                        Locker34.Dispatcher.Invoke(new Action(() => Locker34.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 35:
                                        Locker35.Dispatcher.Invoke(new Action(() => Locker35.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 36:
                                        Locker36.Dispatcher.Invoke(new Action(() => Locker36.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 37:
                                        Locker37.Dispatcher.Invoke(new Action(() => Locker37.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 38:
                                        Locker38.Dispatcher.Invoke(new Action(() => Locker38.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 39:
                                        Locker39.Dispatcher.Invoke(new Action(() => Locker39.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;
                                    case 40:
                                        Locker40.Dispatcher.Invoke(new Action(() => Locker40.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        break;


                                }
                            }

                        }
                    }
                }
            }
        }

        private void Locker1_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Locker1.Content.ToString());
            string seleccion = Locker1.Content.ToString();
            string[] words = seleccion.Split(' ');

            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            /*switch (seleccion)
            {
                case "j":
                    SeleccionLocker.Content = "";
                    break;
            }*/
        }

        private void IngresarPaquete(object sender, RoutedEventArgs e)
        {

        }
    }
}