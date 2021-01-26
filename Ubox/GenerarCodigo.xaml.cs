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
using Newtonsoft.Json;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using Ubox.ModelService;
using Ubox.ModelService.Ubox;
using System.Threading.Tasks;

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
        public static DateTime SumaDiasFecha { get; set; }
        public static int SumaDiasInt { get; set; }
        public static int IdLocker { get; set; }



        private static System.Timers.Timer aTimer;


        public GenerarCodigo()
        {
            InitializeComponent();

            Thread thLocker = new Thread(() => GetLockers((ConfigurationManager.ConnectionStrings.ToString())));
            thLocker.Start();

            Thread thTable = new Thread(() => FillTable((ConfigurationManager.ConnectionStrings.ToString())));
            //thTable.Start();
        }

        private void FillTable(string ConnectionString)
        {
            string sql = @"Select Tamaño, Alto, Ancho, Costo from Locker GROUP BY Tamaño, Alto, Ancho, Costo";
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

        private async void GetLockers(string ConnectionString)
        {
            string idUbox = ConfigurationManager.AppSettings["IdUbox"].ToString();
            ClienteWebApi clienteWebApi = new ClienteWebApi();
            var respuestaDatosBasicos = await clienteWebApi.callWebApiAutorizacionGetLista($"Ubox/getLockers/{idUbox}");
            if (respuestaDatosBasicos != null)
            {
                var datosBasicos = respuestaDatosBasicos.respuesta.Datos.ToObject<List<ModeloUbox>>();

                foreach (var datos in datosBasicos)
                {
                    int IdLocker = datos.IdLocker;
                    int Disponible = datos.Disponible;
                    Console.WriteLine("El Locker {0} tiene un estado {1}", IdLocker, Disponible);
                    if (Disponible != 0)
                    {

                        switch (IdLocker)
                        {
                            case 1:
                                Locker1.Dispatcher.Invoke(new Action(() => Locker1.Style = (Style)Application.Current.Resources["ButtonEmpty"]));
                                Locker1.Dispatcher.Invoke(new Action(() => Locker1.IsEnabled = true));
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
            else
            {
                ////Si se vencieron los tokens se logea de nuevo y se llama de nuevo al metodo
                if (await Globals.iniciaSesionAsync())
                {
                    respuestaDatosBasicos = await clienteWebApi.callWebApiAutorizacionGetLista($"Ubox/getLockers/{idUbox}");
                    if (respuestaDatosBasicos != null)
                    {
                        var datosBasicos = respuestaDatosBasicos.respuesta.Datos.ToObject<List<ModeloUbox>>();
                        Console.WriteLine("Imprimiendo datos basicos " + Convert.ToString(datosBasicos.ElementAt(0).IdLocker));

                    }
                    else
                    {
                        Uri uri = new Uri("Home.xaml", UriKind.Relative);
                        try
                        {
                            this.Dispatcher.Invoke(new Action(() => this.NavigationService.Navigate(uri)));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
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

        private async void Locker1Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 1;

            Locker1.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }





        private async void Locker2Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 2;

            Locker2.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker3Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 3;

            Locker3.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker4Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 4;

            Locker4.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker5Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 5;

            Locker5.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker6Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 6;

            Locker6.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker7Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 7;

            Locker7.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker8Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 8;

            Locker8.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker9Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 9;

            Locker9.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker10Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 10;

            Locker10.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker11Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 11;

            Locker11.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker12Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 12;

            Locker12.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker13Seleccion(object sender, RoutedEventArgs e)
        {

            IdLocker = 13;

            Locker13.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker14Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 14;

            Locker14.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker15Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 15;

            Locker15.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker16Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 16;

            Locker16.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker17Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 17;

            Locker17.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker18Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 18;

            Locker18.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker19Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 19;

            Locker19.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker20Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 20;

            Locker20.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker21Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 21;

            Locker21.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker22Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 22;

            Locker22.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker23Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 23;

            Locker23.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker24Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 24;

            Locker24.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker25Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 25;

            Locker25.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker26Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 26;

            Locker26.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker27Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 27;

            Locker27.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker28Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 28;

            Locker28.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker29Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 29;

            Locker29.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker30Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 30;

            Locker30.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker31Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 31;

            Locker31.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker32Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 32;

            Locker32.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker33Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 33;

            Locker33.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker34Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 34;

            Locker34.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker35Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 35;

            Locker35.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker36Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 36;

            Locker36.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker37Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 37;

            Locker37.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker38Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 38;

            Locker38.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }

        private async void Locker39Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 39;

            Locker39.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
        private async void Locker40Seleccion(object sender, RoutedEventArgs e)
        {
            IdLocker = 40;

            Locker40.Opacity = 0.5;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OpacityBtn;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;

            if (await Globals.ObtenerPrecio(IdLocker))
            {
                SeleccionTamañoLoccker.Content = Tamaño;
                SeleccionNolocker.Content = "No. " + NoLocker;
            }
            else
            {
                Uri uri = new Uri("Seleccion.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
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
            SumaDiasFecha = Convert.ToDateTime(DateTime.Now).AddDays(1);
            SumaDiasInt = 1;

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
            SumaDiasFecha = Convert.ToDateTime(DateTime.Now).AddDays(2);
            SumaDiasInt = 2;
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
            SumaDiasFecha = Convert.ToDateTime(DateTime.Now).AddDays(3);
            SumaDiasInt = 3;
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
            SumaDiasFecha = Convert.ToDateTime(DateTime.Now).AddDays(4);
            SumaDiasInt = 4;
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
            SumaDiasFecha = Convert.ToDateTime(DateTime.Now).AddDays(5);
            SumaDiasInt = 5;
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
            SumaDiasFecha = Convert.ToDateTime(DateTime.Now).AddDays(6);
            SumaDiasInt = 6;
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
            SumaDiasFecha = Convert.ToDateTime(DateTime.Now).AddDays(7);
            SumaDiasInt = 7;
        }
    }
}