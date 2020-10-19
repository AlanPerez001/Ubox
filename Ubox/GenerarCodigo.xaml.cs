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
    /// Lógica de interacción para DejarPage.xaml
    /// </summary>
    public partial class GenerarCodigo : Page
    {
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public static int NoLocker { get; set; }
        public static string Tamaño { get; set; }
        public static int Costo { get; set; }
        public static string DiaRenta { get; set; }
        public static string Selecciontamañolabel { get; set; }
        public static string SeleccionLockerlabel { get; set; }
        public static string SeleccionDialabel { get; set; }



        private static System.Timers.Timer aTimer;

        public GenerarCodigo()
        {
            InitializeComponent();

            Thread thLocker = new Thread(() => GetLockers((App.Current as App).ConnectionString));
            thLocker.Start();

            Thread thTable = new Thread(() => FillTable((App.Current as App).ConnectionString));
            thTable.Start();
        }

        private void FillTable(string ConnectionString)
        {
            string sql = @"Select Tamaño, Alto, Ancho, Costo from Lockers GROUP BY Tamaño, Alto, Ancho, Costo";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                queryCommand.ExecuteNonQuery();
                SqlDataAdapter datasql = new SqlDataAdapter(queryCommand);
                DataTable dt = new DataTable("Lockers");
                datasql.Fill(dt);
                dataGrid1.Dispatcher.Invoke(new Action(() => dataGrid1.ItemsSource = dt.DefaultView));
                datasql.Update(dt);
                Console.WriteLine("Tabla: " + dt.Rows);
            }
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
        private void OpacityBtn(object sender, ElapsedEventArgs e)
        {
            Locker1.Dispatcher.Invoke(new Action(() => Locker1.Opacity = 1));
            Locker2.Dispatcher.Invoke(new Action(() => Locker2.Opacity = 1));
            Locker3.Dispatcher.Invoke(new Action(() => Locker3.Opacity = 1));
            Locker4.Dispatcher.Invoke(new Action(() => Locker4.Opacity = 1));
            Locker5.Dispatcher.Invoke(new Action(() => Locker5.Opacity = 1));
            Locker6.Dispatcher.Invoke(new Action(() => Locker6.Opacity = 1));
            Locker7.Dispatcher.Invoke(new Action(() => Locker7.Opacity = 1));
            Locker8.Dispatcher.Invoke(new Action(() => Locker8.Opacity = 1));
            Locker9.Dispatcher.Invoke(new Action(() => Locker9.Opacity = 1));
            Locker10.Dispatcher.Invoke(new Action(() => Locker10.Opacity = 1));
            Locker11.Dispatcher.Invoke(new Action(() => Locker11.Opacity = 1));
            Locker12.Dispatcher.Invoke(new Action(() => Locker12.Opacity = 1));
            Locker13.Dispatcher.Invoke(new Action(() => Locker13.Opacity = 1));
            Locker14.Dispatcher.Invoke(new Action(() => Locker14.Opacity = 1));
            Locker15.Dispatcher.Invoke(new Action(() => Locker15.Opacity = 1));
            Locker16.Dispatcher.Invoke(new Action(() => Locker16.Opacity = 1));
            Locker17.Dispatcher.Invoke(new Action(() => Locker17.Opacity = 1));
            Locker18.Dispatcher.Invoke(new Action(() => Locker18.Opacity = 1));
            Locker19.Dispatcher.Invoke(new Action(() => Locker19.Opacity = 1));
            Locker20.Dispatcher.Invoke(new Action(() => Locker20.Opacity = 1));
            Locker21.Dispatcher.Invoke(new Action(() => Locker21.Opacity = 1));
            Locker22.Dispatcher.Invoke(new Action(() => Locker22.Opacity = 1));
            Locker23.Dispatcher.Invoke(new Action(() => Locker23.Opacity = 1));
            Locker24.Dispatcher.Invoke(new Action(() => Locker24.Opacity = 1));
            Locker25.Dispatcher.Invoke(new Action(() => Locker25.Opacity = 1));
            Locker26.Dispatcher.Invoke(new Action(() => Locker26.Opacity = 1));
            Locker27.Dispatcher.Invoke(new Action(() => Locker27.Opacity = 1));
            Locker28.Dispatcher.Invoke(new Action(() => Locker28.Opacity = 1));
            Locker29.Dispatcher.Invoke(new Action(() => Locker29.Opacity = 1));
            Locker30.Dispatcher.Invoke(new Action(() => Locker30.Opacity = 1));
            Locker31.Dispatcher.Invoke(new Action(() => Locker31.Opacity = 1));
            Locker32.Dispatcher.Invoke(new Action(() => Locker32.Opacity = 1));
            Locker33.Dispatcher.Invoke(new Action(() => Locker33.Opacity = 1));
            Locker34.Dispatcher.Invoke(new Action(() => Locker34.Opacity = 1));
            Locker35.Dispatcher.Invoke(new Action(() => Locker35.Opacity = 1));
            Locker36.Dispatcher.Invoke(new Action(() => Locker36.Opacity = 1));
            Locker37.Dispatcher.Invoke(new Action(() => Locker37.Opacity = 1));
            Locker38.Dispatcher.Invoke(new Action(() => Locker38.Opacity = 1));
            Locker39.Dispatcher.Invoke(new Action(() => Locker39.Opacity = 1));
            Locker40.Dispatcher.Invoke(new Action(() => Locker40.Opacity = 1));
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
                            if (disponible != 1)
                            {

                                switch (locker)
                                {
                                    case 1:
                                        Locker1.Dispatcher.Invoke(new Action(() => Locker1.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker1.Dispatcher.Invoke(new Action(() => Locker1.IsEnabled = true));
                                        Console.WriteLine("Entrando al case 1");
                                        break;
                                    case 2:
                                        Locker2.Dispatcher.Invoke(new Action(() => Locker2.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker2.Dispatcher.Invoke(new Action(() => Locker2.IsEnabled = true));
                                        break;
                                    case 3:
                                        Locker3.Dispatcher.Invoke(new Action(() => Locker3.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker3.Dispatcher.Invoke(new Action(() => Locker3.IsEnabled = true));
                                        break;
                                    case 4:
                                        Locker4.Dispatcher.Invoke(new Action(() => Locker4.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker4.Dispatcher.Invoke(new Action(() => Locker4.IsEnabled = true));
                                        break;
                                    case 5:
                                        Locker5.Dispatcher.Invoke(new Action(() => Locker5.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker5.Dispatcher.Invoke(new Action(() => Locker5.IsEnabled = true));
                                        break;
                                    case 6:
                                        Locker6.Dispatcher.Invoke(new Action(() => Locker6.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker6.Dispatcher.Invoke(new Action(() => Locker6.IsEnabled = true));
                                        break;
                                    case 7:
                                        Locker7.Dispatcher.Invoke(new Action(() => Locker7.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker7.Dispatcher.Invoke(new Action(() => Locker7.IsEnabled = true));
                                        break;
                                    case 8:
                                        Locker8.Dispatcher.Invoke(new Action(() => Locker8.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker8.Dispatcher.Invoke(new Action(() => Locker8.IsEnabled = true));
                                        break;
                                    case 9:
                                        Locker9.Dispatcher.Invoke(new Action(() => Locker9.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker9.Dispatcher.Invoke(new Action(() => Locker9.IsEnabled = true));
                                        break;
                                    case 10:
                                        Locker10.Dispatcher.Invoke(new Action(() => Locker10.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker10.Dispatcher.Invoke(new Action(() => Locker10.IsEnabled = true));
                                        break;
                                    case 11:
                                        Locker11.Dispatcher.Invoke(new Action(() => Locker11.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker11.Dispatcher.Invoke(new Action(() => Locker11.IsEnabled = true));
                                        break;
                                    case 12:
                                        Locker12.Dispatcher.Invoke(new Action(() => Locker12.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker12.Dispatcher.Invoke(new Action(() => Locker12.IsEnabled = true));
                                        break;
                                    case 13:
                                        Locker13.Dispatcher.Invoke(new Action(() => Locker13.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker13.Dispatcher.Invoke(new Action(() => Locker13.IsEnabled = true));
                                        break;
                                    case 14:
                                        Locker14.Dispatcher.Invoke(new Action(() => Locker14.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker14.Dispatcher.Invoke(new Action(() => Locker14.IsEnabled = true));
                                        break;
                                    case 15:
                                        Locker15.Dispatcher.Invoke(new Action(() => Locker15.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker15.Dispatcher.Invoke(new Action(() => Locker15.IsEnabled = true));
                                        break;
                                    case 16:
                                        Locker16.Dispatcher.Invoke(new Action(() => Locker16.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker16.Dispatcher.Invoke(new Action(() => Locker16.IsEnabled = true));
                                        break;
                                    case 17:
                                        Locker17.Dispatcher.Invoke(new Action(() => Locker17.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker17.Dispatcher.Invoke(new Action(() => Locker17.IsEnabled = true));
                                        break;
                                    case 18:
                                        Locker18.Dispatcher.Invoke(new Action(() => Locker18.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker18.Dispatcher.Invoke(new Action(() => Locker18.IsEnabled = true));
                                        break;
                                    case 19:
                                        Locker19.Dispatcher.Invoke(new Action(() => Locker19.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker19.Dispatcher.Invoke(new Action(() => Locker19.IsEnabled = true));
                                        break;
                                    case 20:
                                        Locker20.Dispatcher.Invoke(new Action(() => Locker20.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker20.Dispatcher.Invoke(new Action(() => Locker20.IsEnabled = true));
                                        break;
                                    case 21:
                                        Locker21.Dispatcher.Invoke(new Action(() => Locker21.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker21.Dispatcher.Invoke(new Action(() => Locker21.IsEnabled = true));
                                        break;
                                    case 22:
                                        Locker22.Dispatcher.Invoke(new Action(() => Locker22.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker22.Dispatcher.Invoke(new Action(() => Locker22.IsEnabled = true));
                                        break;
                                    case 23:
                                        Locker23.Dispatcher.Invoke(new Action(() => Locker23.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker23.Dispatcher.Invoke(new Action(() => Locker23.IsEnabled = true));
                                        break;
                                    case 24:
                                        Locker24.Dispatcher.Invoke(new Action(() => Locker24.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker24.Dispatcher.Invoke(new Action(() => Locker24.IsEnabled = true));
                                        break;
                                    case 25:
                                        Locker25.Dispatcher.Invoke(new Action(() => Locker25.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker25.Dispatcher.Invoke(new Action(() => Locker25.IsEnabled = true));
                                        break;
                                    case 26:
                                        Locker26.Dispatcher.Invoke(new Action(() => Locker26.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker26.Dispatcher.Invoke(new Action(() => Locker26.IsEnabled = true));
                                        break;
                                    case 27:
                                        Locker27.Dispatcher.Invoke(new Action(() => Locker27.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker27.Dispatcher.Invoke(new Action(() => Locker27.IsEnabled = true));
                                        break;
                                    case 28:
                                        Locker28.Dispatcher.Invoke(new Action(() => Locker28.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker28.Dispatcher.Invoke(new Action(() => Locker28.IsEnabled = true));
                                        break;
                                    case 29:
                                        Locker29.Dispatcher.Invoke(new Action(() => Locker29.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker29.Dispatcher.Invoke(new Action(() => Locker29.IsEnabled = true));
                                        break;
                                    case 30:
                                        Locker30.Dispatcher.Invoke(new Action(() => Locker30.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker30.Dispatcher.Invoke(new Action(() => Locker30.IsEnabled = true));
                                        break;
                                    case 31:
                                        Locker31.Dispatcher.Invoke(new Action(() => Locker31.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker31.Dispatcher.Invoke(new Action(() => Locker31.IsEnabled = true));
                                        break;
                                    case 32:
                                        Locker32.Dispatcher.Invoke(new Action(() => Locker32.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker32.Dispatcher.Invoke(new Action(() => Locker32.IsEnabled = true));
                                        break;
                                    case 33:
                                        Locker33.Dispatcher.Invoke(new Action(() => Locker33.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker33.Dispatcher.Invoke(new Action(() => Locker33.IsEnabled = true));
                                        break;
                                    case 34:
                                        Locker34.Dispatcher.Invoke(new Action(() => Locker34.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker34.Dispatcher.Invoke(new Action(() => Locker34.IsEnabled = true));
                                        break;
                                    case 35:
                                        Locker35.Dispatcher.Invoke(new Action(() => Locker35.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker35.Dispatcher.Invoke(new Action(() => Locker35.IsEnabled = true));
                                        break;
                                    case 36:
                                        Locker36.Dispatcher.Invoke(new Action(() => Locker36.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker36.Dispatcher.Invoke(new Action(() => Locker36.IsEnabled = true));
                                        break;
                                    case 37:
                                        Locker37.Dispatcher.Invoke(new Action(() => Locker37.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker37.Dispatcher.Invoke(new Action(() => Locker37.IsEnabled = true));
                                        break;
                                    case 38:
                                        Locker38.Dispatcher.Invoke(new Action(() => Locker38.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker38.Dispatcher.Invoke(new Action(() => Locker38.IsEnabled = true));
                                        break;
                                    case 39:
                                        Locker39.Dispatcher.Invoke(new Action(() => Locker39.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker39.Dispatcher.Invoke(new Action(() => Locker39.IsEnabled = true));
                                        break;
                                    case 40:
                                        Locker40.Dispatcher.Invoke(new Action(() => Locker40.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                        Locker40.Dispatcher.Invoke(new Action(() => Locker40.IsEnabled = true));
                                        break;
                                }
                            }

                        }
                    }
                }
            }
        }

        private void IngresarPaquete(object sender, RoutedEventArgs e)
        {
            Selecciontamañolabel = SeleccionTamañoLoccker.Content.ToString();
            SeleccionLockerlabel = SeleccionNolocker.Content.ToString();
            SeleccionDialabel = SeleccionDias.Content.ToString();
            if (Selecciontamañolabel != "" && SeleccionLockerlabel != "" && SeleccionDialabel != "")
            {
                Console.WriteLine("El locker es: " + SeleccionLockerlabel + ", El tamaño es: " + Selecciontamañolabel + ", Los dias son: " + SeleccionDialabel);
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }



        private void Locker1Seleccion(object sender, RoutedEventArgs e)
        {
            Locker1.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker,Tamaño ,Alto, Ancho, Costo FROM Lockers where NoLocker =" + 1;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }


        private void Locker2Seleccion(object sender, RoutedEventArgs e)
        {

            Locker11.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 11;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker3Seleccion(object sender, RoutedEventArgs e)
        {
            Locker3.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 3;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker4Seleccion(object sender, RoutedEventArgs e)
        {
            Locker4.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 4;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker5Seleccion(object sender, RoutedEventArgs e)
        {
            Locker5.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true; string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 5;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker6Seleccion(object sender, RoutedEventArgs e)
        {
            Locker6.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 6;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker7Seleccion(object sender, RoutedEventArgs e)
        {
            Locker7.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 7;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker8Seleccion(object sender, RoutedEventArgs e)
        {
            Locker8.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 8;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker9Seleccion(object sender, RoutedEventArgs e)
        {
            Locker9.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 9;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker10Seleccion(object sender, RoutedEventArgs e)
        {
            Locker10.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 10;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker11Seleccion(object sender, RoutedEventArgs e)
        {
            Locker2.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 2;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker12Seleccion(object sender, RoutedEventArgs e)
        {
            Locker12.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 12;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker13Seleccion(object sender, RoutedEventArgs e)
        {

            Locker13.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 13;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker14Seleccion(object sender, RoutedEventArgs e)
        {
            Locker14.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 14;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker15Seleccion(object sender, RoutedEventArgs e)
        {
            Locker15.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 15;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker16Seleccion(object sender, RoutedEventArgs e)
        {
            Locker16.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 16;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker17Seleccion(object sender, RoutedEventArgs e)
        {
            Locker17.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 17;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker18Seleccion(object sender, RoutedEventArgs e)
        {
            Locker18.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 18;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker19Seleccion(object sender, RoutedEventArgs e)
        {
            Locker19.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 19;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker20Seleccion(object sender, RoutedEventArgs e)
        {
            Locker20.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 20;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker21Seleccion(object sender, RoutedEventArgs e)
        {
            Locker21.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 21;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker22Seleccion(object sender, RoutedEventArgs e)
        {
            Locker22.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 22;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker23Seleccion(object sender, RoutedEventArgs e)
        {
            Locker23.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 23;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker24Seleccion(object sender, RoutedEventArgs e)
        {
            Locker24.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 24;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker25Seleccion(object sender, RoutedEventArgs e)
        {
            Locker25.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 25;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker26Seleccion(object sender, RoutedEventArgs e)
        {
            Locker26.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 26;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker27Seleccion(object sender, RoutedEventArgs e)
        {
            Locker27.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 27;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker28Seleccion(object sender, RoutedEventArgs e)
        {
            Locker28.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 28;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker29Seleccion(object sender, RoutedEventArgs e)
        {
            Locker29.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 29;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker30Seleccion(object sender, RoutedEventArgs e)
        {
            Locker30.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 30;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker31Seleccion(object sender, RoutedEventArgs e)
        {
            Locker31.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 31;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker32Seleccion(object sender, RoutedEventArgs e)
        {
            Locker32.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 32;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker33Seleccion(object sender, RoutedEventArgs e)
        {
            Locker33.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 33;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {


                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker34Seleccion(object sender, RoutedEventArgs e)
        {
            Locker34.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 34;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker35Seleccion(object sender, RoutedEventArgs e)
        {
            Locker35.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 35;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker36Seleccion(object sender, RoutedEventArgs e)
        {
            Locker36.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 36;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker37Seleccion(object sender, RoutedEventArgs e)
        {
            Locker37.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 37;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker38Seleccion(object sender, RoutedEventArgs e)
        {
            Locker38.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;


            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 38;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Locker39Seleccion(object sender, RoutedEventArgs e)
        {
            Locker39.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 39;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }
        private void Locker40Seleccion(object sender, RoutedEventArgs e)
        {
            Locker40.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT NoLocker, Tamaño, Alto, Ancho, Costo FROM Lockers where NoLocker = " + 40;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NoLocker = Convert.ToInt32(reader["NoLocker"]);
                        Tamaño = Convert.ToString(reader["Tamaño"]);
                        Costo = Convert.ToInt32(reader["Costo"]);
                        SeleccionTamañoLoccker.Content = Tamaño;
                        SeleccionNolocker.Content = "No. " + NoLocker;
                    }
                }
            }
        }

        private void Check1Dia_Checked(object sender, RoutedEventArgs e)
        {
            Check2Dia.IsChecked = false;
            Check3Dia.IsChecked = false;
            Check4Dia.IsChecked = false;
            Check5Dia.IsChecked = false;
            Check6Dia.IsChecked = false;
            Check7Dia.IsChecked = false;
            CheckMarcado2Dia.Visibility = Visibility.Hidden;
            CheckMarcado3Dia.Visibility = Visibility.Hidden;
            CheckMarcado4Dia.Visibility = Visibility.Hidden;
            CheckMarcado5Dia.Visibility = Visibility.Hidden;
            CheckMarcado6Dia.Visibility = Visibility.Hidden;
            CheckMarcado7Dia.Visibility = Visibility.Hidden;
            CheckMarcado1Dia.Visibility = Visibility.Visible;
            SeleccionDias.Content = "1 día";

        }

        private void Check2Dia_Checked(object sender, RoutedEventArgs e)
        {
            Check1Dia.IsChecked = false;
            Check3Dia.IsChecked = false;
            Check4Dia.IsChecked = false;
            Check5Dia.IsChecked = false;
            Check6Dia.IsChecked = false;
            Check7Dia.IsChecked = false;
            CheckMarcado1Dia.Visibility = Visibility.Hidden;
            CheckMarcado3Dia.Visibility = Visibility.Hidden;
            CheckMarcado4Dia.Visibility = Visibility.Hidden;
            CheckMarcado5Dia.Visibility = Visibility.Hidden;
            CheckMarcado6Dia.Visibility = Visibility.Hidden;
            CheckMarcado7Dia.Visibility = Visibility.Hidden;
            CheckMarcado2Dia.Visibility = Visibility.Visible;
            SeleccionDias.Content = "2 días";
        }

        private void Check3Dia_Checked(object sender, RoutedEventArgs e)
        {
            Check1Dia.IsChecked = false;
            Check2Dia.IsChecked = false;
            Check4Dia.IsChecked = false;
            Check5Dia.IsChecked = false;
            Check6Dia.IsChecked = false;
            Check7Dia.IsChecked = false;
            CheckMarcado1Dia.Visibility = Visibility.Hidden;
            CheckMarcado2Dia.Visibility = Visibility.Hidden;
            CheckMarcado4Dia.Visibility = Visibility.Hidden;
            CheckMarcado5Dia.Visibility = Visibility.Hidden;
            CheckMarcado6Dia.Visibility = Visibility.Hidden;
            CheckMarcado7Dia.Visibility = Visibility.Hidden;
            CheckMarcado3Dia.Visibility = Visibility.Visible;
            SeleccionDias.Content = "3 días";
        }

        private void Check4Dia_Checked(object sender, RoutedEventArgs e)
        {
            Check2Dia.IsChecked = false;
            Check3Dia.IsChecked = false;
            Check1Dia.IsChecked = false;
            Check5Dia.IsChecked = false;
            Check6Dia.IsChecked = false;
            Check7Dia.IsChecked = false;
            CheckMarcado1Dia.Visibility = Visibility.Hidden;
            CheckMarcado2Dia.Visibility = Visibility.Hidden;
            CheckMarcado3Dia.Visibility = Visibility.Hidden;
            CheckMarcado5Dia.Visibility = Visibility.Hidden;
            CheckMarcado6Dia.Visibility = Visibility.Hidden;
            CheckMarcado7Dia.Visibility = Visibility.Hidden;
            CheckMarcado4Dia.Visibility = Visibility.Visible;
            SeleccionDias.Content = "4 días";
        }

        private void Check5Dia_Checked(object sender, RoutedEventArgs e)
        {
            Check2Dia.IsChecked = false;
            Check3Dia.IsChecked = false;
            Check4Dia.IsChecked = false;
            Check1Dia.IsChecked = false;
            Check6Dia.IsChecked = false;
            Check7Dia.IsChecked = false;
            CheckMarcado1Dia.Visibility = Visibility.Hidden;
            CheckMarcado2Dia.Visibility = Visibility.Hidden;
            CheckMarcado3Dia.Visibility = Visibility.Hidden;
            CheckMarcado4Dia.Visibility = Visibility.Hidden;
            CheckMarcado6Dia.Visibility = Visibility.Hidden;
            CheckMarcado7Dia.Visibility = Visibility.Hidden;
            CheckMarcado5Dia.Visibility = Visibility.Visible;
            SeleccionDias.Content = "5 días";
        }

        private void Check6Dia_Checked(object sender, RoutedEventArgs e)
        {
            Check2Dia.IsChecked = false;
            Check3Dia.IsChecked = false;
            Check4Dia.IsChecked = false;
            Check5Dia.IsChecked = false;
            Check1Dia.IsChecked = false;
            Check7Dia.IsChecked = false;
            CheckMarcado1Dia.Visibility = Visibility.Hidden;
            CheckMarcado2Dia.Visibility = Visibility.Hidden;
            CheckMarcado3Dia.Visibility = Visibility.Hidden;
            CheckMarcado4Dia.Visibility = Visibility.Hidden;
            CheckMarcado5Dia.Visibility = Visibility.Hidden;
            CheckMarcado7Dia.Visibility = Visibility.Hidden;
            CheckMarcado6Dia.Visibility = Visibility.Visible;
            SeleccionDias.Content = "6 días";
        }

        private void Check7Dia_Checked(object sender, RoutedEventArgs e)
        {
            Check2Dia.IsChecked = false;
            Check3Dia.IsChecked = false;
            Check4Dia.IsChecked = false;
            Check5Dia.IsChecked = false;
            Check6Dia.IsChecked = false;
            Check1Dia.IsChecked = false;
            CheckMarcado1Dia.Visibility = Visibility.Hidden;
            CheckMarcado2Dia.Visibility = Visibility.Hidden;
            CheckMarcado3Dia.Visibility = Visibility.Hidden;
            CheckMarcado4Dia.Visibility = Visibility.Hidden;
            CheckMarcado5Dia.Visibility = Visibility.Hidden;
            CheckMarcado6Dia.Visibility = Visibility.Hidden;
            CheckMarcado7Dia.Visibility = Visibility.Visible;
            SeleccionDias.Content = "7 días";
        }
    }
}