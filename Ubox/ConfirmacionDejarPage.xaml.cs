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
    /// Lógica de interacción para ConfirmacionDejarPage.xaml
    /// </summary>
    public partial class ConfirmacionDejarPage : Page
    {
        private static System.Timers.Timer aTimer;
        public Thread Finalizar { get; set; }
        public ConfirmacionDejarPage()
        {
            InitializeComponent();
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            VencimientoLabel.Content = DejarPage.Vencimiento;
            /*aTimer = new System.Timers.Timer(60000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += FinalizarBtn;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;*/

            Finalizar = new Thread(FinalizarTimer);
            Finalizar.Start();
        }

        private void RegresarbBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void FinalizarBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                Finalizar.Abort();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Finalizar Exception: " + ex);
            }
            finally
            {
                Uri uri = new Uri("Home.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }

        }

        private void FinalizarTimer()
        {
            for (int i = 1; i <=60;i++)
            {
                Thread.Sleep(1000);
            }
            try
            {
                Uri uri = new Uri("Home.xaml", UriKind.Relative);
                this.Dispatcher.Invoke(new Action(() => this.NavigationService.Navigate(uri)));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
