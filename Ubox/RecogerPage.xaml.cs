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
using System.Windows.Threading;

namespace Ubox
{
    /// <summary>
    /// Lógica de interacción para DejarPage.xaml
    /// </summary>
    public partial class RecogerPage : Page
    {
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public static string Trama { get; set; }
        public static int NoLockerSQL { get; set; }
        private static System.Timers.Timer aTimer;
        static SerialPort DoorSerial { get; set; }
        public RecogerPage()
        {
            InitializeComponent();
            Thread thr1 = new Thread(ScannerQR);
            thr1.Start();
        }

        private void ScannerQR()
        {
            Console.WriteLine("Escanenado");
            string Start = "02 54 0d 02 55";
            byte[] ByteMessage = Start
              .Split(' ')
              .Select(item => Convert.ToByte(item, 16))
              .ToArray();
            string HexMessage = string.Join("-", ByteMessage
              .Select(item => item.ToString("X2")));

            MainWindow.ScannerQrSerial.Write(ByteMessage, 0, ByteMessage.Length);
            Console.WriteLine("Byte: " + MainWindow.ScannerQrSerial.ReadByte());
            string code = MainWindow.ScannerQrSerial.ReadExisting();
            Console.WriteLine(code);
            if (code.Length == 6)
            {
                Code1.Dispatcher.Invoke(new Action(() => Code1.AppendText(code.Substring(0, 1))));
                Code2.Dispatcher.Invoke(new Action(() => Code2.AppendText(code.Substring(1, 1))));
                Code3.Dispatcher.Invoke(new Action(() => Code3.AppendText(code.Substring(2, 1))));
                Code4.Dispatcher.Invoke(new Action(() => Code4.AppendText(code.Substring(3, 1))));
                Code5.Dispatcher.Invoke(new Action(() => Code5.AppendText(code.Substring(4, 1))));
                Code6.Dispatcher.Invoke(new Action(() => Code6.AppendText(code.Substring(5, 1))));
                CheckCodeSQL();
            }
        }

        private void EscanearBtn(object sender, RoutedEventArgs e)
        {
            Thread thr1 = new Thread(ScannerQR);
            thr1.Start();
        }

        public void RegresarbBtn(object sender, RoutedEventArgs e)
        {
            if (aTimer != null)
            {
                Console.WriteLine("Entrando");
                try
                {
                    aTimer.Stop();
                }
                catch (System.NullReferenceException Ex)
                {
                    Console.Write(Ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void UnoBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("1");
                            break;
                        case "2":
                            Code2.AppendText("1");
                            break;
                        case "3":
                            Code3.AppendText("1");
                            break;
                        case "4":
                            Code4.AppendText("1");
                            break;
                        case "5":
                            Code5.AppendText("1");
                            break;
                        case "6":
                            Code6.AppendText("1");
                            break;

                    }
                    break;
                }
            }
        }
        private void DosBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("2");
                            break;
                        case "2":
                            Code2.AppendText("2");
                            break;
                        case "3":
                            Code3.AppendText("2");
                            break;
                        case "4":
                            Code4.AppendText("2");
                            break;
                        case "5":
                            Code5.AppendText("2");
                            break;
                        case "6":
                            Code6.AppendText("2");
                            break;

                    }
                    break;
                }
            }
        }
        private void TresBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("3");
                            break;
                        case "2":
                            Code2.AppendText("3");
                            break;
                        case "3":
                            Code3.AppendText("3");
                            break;
                        case "4":
                            Code4.AppendText("3");
                            break;
                        case "5":
                            Code5.AppendText("3");
                            break;
                        case "6":
                            Code6.AppendText("3");
                            break;

                    }
                    break;
                }
            }
        }
        private void CuatroBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("4");
                            break;
                        case "2":
                            Code2.AppendText("4");
                            break;
                        case "3":
                            Code3.AppendText("4");
                            break;
                        case "4":
                            Code4.AppendText("4");
                            break;
                        case "5":
                            Code5.AppendText("4");
                            break;
                        case "6":
                            Code6.AppendText("4");
                            break;

                    }
                    break;
                }
            }
        }
        private void CincoBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("5");
                            break;
                        case "2":
                            Code2.AppendText("5");
                            break;
                        case "3":
                            Code3.AppendText("5");
                            break;
                        case "4":
                            Code4.AppendText("5");
                            break;
                        case "5":
                            Code5.AppendText("5");
                            break;
                        case "6":
                            Code6.AppendText("5");
                            break;

                    }
                    break;
                }
            }
        }
        private void SeisBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("6");
                            break;
                        case "2":
                            Code2.AppendText("6");
                            break;
                        case "3":
                            Code3.AppendText("6");
                            break;
                        case "4":
                            Code4.AppendText("6");
                            break;
                        case "5":
                            Code5.AppendText("6");
                            break;
                        case "6":
                            Code6.AppendText("6");
                            break;

                    }
                    break;
                }
            }
        }
        private void SieteBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("7");
                            break;
                        case "2":
                            Code2.AppendText("7");
                            break;
                        case "3":
                            Code3.AppendText("7");
                            break;
                        case "4":
                            Code4.AppendText("7");
                            break;
                        case "5":
                            Code5.AppendText("7");
                            break;
                        case "6":
                            Code6.AppendText("7");
                            break;

                    }
                    break;
                }
            }
        }
        private void OchoBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("8");
                            break;
                        case "2":
                            Code2.AppendText("8");
                            break;
                        case "3":
                            Code3.AppendText("8");
                            break;
                        case "4":
                            Code4.AppendText("8");
                            break;
                        case "5":
                            Code5.AppendText("8");
                            break;
                        case "6":
                            Code6.AppendText("8");
                            break;

                    }
                    break;
                }
            }
        }
        private void NueveBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("9");
                            break;
                        case "2":
                            Code2.AppendText("9");
                            break;
                        case "3":
                            Code3.AppendText("9");
                            break;
                        case "4":
                            Code4.AppendText("9");
                            break;
                        case "5":
                            Code5.AppendText("9");
                            break;
                        case "6":
                            Code6.AppendText("9");
                            break;

                    }
                    break;
                }
            }
        }
        private void CeroBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("0");
                            break;
                        case "2":
                            Code2.AppendText("0");
                            break;
                        case "3":
                            Code3.AppendText("0");
                            break;
                        case "4":
                            Code4.AppendText("0");
                            break;
                        case "5":
                            Code5.AppendText("0");
                            break;
                        case "6":
                            Code6.AppendText("0");
                            break;

                    }
                    break;
                }
            }
        }
        private void QBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("Q");
                            break;
                        case "2":
                            Code2.AppendText("Q");
                            break;
                        case "3":
                            Code3.AppendText("Q");
                            break;
                        case "4":
                            Code4.AppendText("Q");
                            break;
                        case "5":
                            Code5.AppendText("Q");
                            break;
                        case "6":
                            Code6.AppendText("Q");
                            break;

                    }
                    break;
                }
            }
        }
        private void WBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("W");
                            break;
                        case "2":
                            Code2.AppendText("W");
                            break;
                        case "3":
                            Code3.AppendText("W");
                            break;
                        case "4":
                            Code4.AppendText("W");
                            break;
                        case "5":
                            Code5.AppendText("W");
                            break;
                        case "6":
                            Code6.AppendText("W");
                            break;

                    }
                    break;
                }
            }
        }
        private void EBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("E");
                            break;
                        case "2":
                            Code2.AppendText("E");
                            break;
                        case "3":
                            Code3.AppendText("E");
                            break;
                        case "4":
                            Code4.AppendText("E");
                            break;
                        case "5":
                            Code5.AppendText("E");
                            break;
                        case "6":
                            Code6.AppendText("E");
                            break;

                    }
                    break;
                }
            }
        }
        private void RBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("R");
                            break;
                        case "2":
                            Code2.AppendText("R");
                            break;
                        case "3":
                            Code3.AppendText("R");
                            break;
                        case "4":
                            Code4.AppendText("R");
                            break;
                        case "5":
                            Code5.AppendText("R");
                            break;
                        case "6":
                            Code6.AppendText("R");
                            break;

                    }
                    break;
                }
            }
        }
        private void TBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("T");
                            break;
                        case "2":
                            Code2.AppendText("T");
                            break;
                        case "3":
                            Code3.AppendText("T");
                            break;
                        case "4":
                            Code4.AppendText("T");
                            break;
                        case "5":
                            Code5.AppendText("T");
                            break;
                        case "6":
                            Code6.AppendText("T");
                            break;

                    }
                    break;
                }
            }
        }
        private void YBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("Y");
                            break;
                        case "2":
                            Code2.AppendText("Y");
                            break;
                        case "3":
                            Code3.AppendText("Y");
                            break;
                        case "4":
                            Code4.AppendText("Y");
                            break;
                        case "5":
                            Code5.AppendText("Y");
                            break;
                        case "6":
                            Code6.AppendText("Y");
                            break;

                    }
                    break;
                }
            }
        }
        private void UBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("U");
                            break;
                        case "2":
                            Code2.AppendText("U");
                            break;
                        case "3":
                            Code3.AppendText("U");
                            break;
                        case "4":
                            Code4.AppendText("U");
                            break;
                        case "5":
                            Code5.AppendText("U");
                            break;
                        case "6":
                            Code6.AppendText("U");
                            break;

                    }
                    break;
                }
            }
        }
        private void IBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("I");
                            break;
                        case "2":
                            Code2.AppendText("I");
                            break;
                        case "3":
                            Code3.AppendText("I");
                            break;
                        case "4":
                            Code4.AppendText("I");
                            break;
                        case "5":
                            Code5.AppendText("I");
                            break;
                        case "6":
                            Code6.AppendText("I");
                            break;

                    }
                    break;
                }
            }
        }
        private void OBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("O");
                            break;
                        case "2":
                            Code2.AppendText("O");
                            break;
                        case "3":
                            Code3.AppendText("O");
                            break;
                        case "4":
                            Code4.AppendText("O");
                            break;
                        case "5":
                            Code5.AppendText("O");
                            break;
                        case "6":
                            Code6.AppendText("O");
                            break;

                    }
                    break;
                }
            }
        }
        private void PBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("P");
                            break;
                        case "2":
                            Code2.AppendText("P");
                            break;
                        case "3":
                            Code3.AppendText("P");
                            break;
                        case "4":
                            Code4.AppendText("P");
                            break;
                        case "5":
                            Code5.AppendText("P");
                            break;
                        case "6":
                            Code6.AppendText("P");
                            break;

                    }
                    break;
                }
            }
        }
        private void DELBtn(object sender, RoutedEventArgs e)
        {
            Code1.Clear();
            Code2.Clear();
            Code3.Clear();
            Code4.Clear();
            Code5.Clear();
            Code6.Clear();
        }
        private void ABtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("A");
                            break;
                        case "2":
                            Code2.AppendText("A");
                            break;
                        case "3":
                            Code3.AppendText("A");
                            break;
                        case "4":
                            Code4.AppendText("A");
                            break;
                        case "5":
                            Code5.AppendText("A");
                            break;
                        case "6":
                            Code6.AppendText("A");
                            break;

                    }
                    break;
                }
            }
        }
        private void SBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("S");
                            break;
                        case "2":
                            Code2.AppendText("S");
                            break;
                        case "3":
                            Code3.AppendText("S");
                            break;
                        case "4":
                            Code4.AppendText("S");
                            break;
                        case "5":
                            Code5.AppendText("S");
                            break;
                        case "6":
                            Code6.AppendText("S");
                            break;

                    }
                    break;
                }
            }
        }
        private void DBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("D");
                            break;
                        case "2":
                            Code2.AppendText("D");
                            break;
                        case "3":
                            Code3.AppendText("D");
                            break;
                        case "4":
                            Code4.AppendText("D");
                            break;
                        case "5":
                            Code5.AppendText("D");
                            break;
                        case "6":
                            Code6.AppendText("D");
                            break;

                    }
                    break;
                }
            }
        }
        private void FBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("F");
                            break;
                        case "2":
                            Code2.AppendText("F");
                            break;
                        case "3":
                            Code3.AppendText("F");
                            break;
                        case "4":
                            Code4.AppendText("F");
                            break;
                        case "5":
                            Code5.AppendText("F");
                            break;
                        case "6":
                            Code6.AppendText("F");
                            break;

                    }
                    break;
                }
            }
        }
        private void GBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("G");
                            break;
                        case "2":
                            Code2.AppendText("G");
                            break;
                        case "3":
                            Code3.AppendText("G");
                            break;
                        case "4":
                            Code4.AppendText("G");
                            break;
                        case "5":
                            Code5.AppendText("G");
                            break;
                        case "6":
                            Code6.AppendText("G");
                            break;

                    }
                    break;
                }
            }
        }
        private void HBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("H");
                            break;
                        case "2":
                            Code2.AppendText("H");
                            break;
                        case "3":
                            Code3.AppendText("H");
                            break;
                        case "4":
                            Code4.AppendText("H");
                            break;
                        case "5":
                            Code5.AppendText("H");
                            break;
                        case "6":
                            Code6.AppendText("H");
                            break;

                    }
                    break;
                }
            }
        }
        private void JBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("J");
                            break;
                        case "2":
                            Code2.AppendText("J");
                            break;
                        case "3":
                            Code3.AppendText("J");
                            break;
                        case "4":
                            Code4.AppendText("J");
                            break;
                        case "5":
                            Code5.AppendText("J");
                            break;
                        case "6":
                            Code6.AppendText("J");
                            break;

                    }
                    break;
                }
            }
        }
        private void KBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("K");
                            break;
                        case "2":
                            Code2.AppendText("K");
                            break;
                        case "3":
                            Code3.AppendText("K");
                            break;
                        case "4":
                            Code4.AppendText("K");
                            break;
                        case "5":
                            Code5.AppendText("K");
                            break;
                        case "6":
                            Code6.AppendText("K");
                            break;

                    }
                    break;
                }
            }
        }
        private void LBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("L");
                            break;
                        case "2":
                            Code2.AppendText("L");
                            break;
                        case "3":
                            Code3.AppendText("L");
                            break;
                        case "4":
                            Code4.AppendText("L");
                            break;
                        case "5":
                            Code5.AppendText("L");
                            break;
                        case "6":
                            Code6.AppendText("L");
                            break;

                    }
                    break;
                }
            }
        }
        private void ÑBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("Ñ");
                            break;
                        case "2":
                            Code2.AppendText("Ñ");
                            break;
                        case "3":
                            Code3.AppendText("Ñ");
                            break;
                        case "4":
                            Code4.AppendText("Ñ");
                            break;
                        case "5":
                            Code5.AppendText("Ñ");
                            break;
                        case "6":
                            Code6.AppendText("Ñ");
                            break;

                    }
                    break;
                }
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
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("Z");
                            break;
                        case "2":
                            Code2.AppendText("Z");
                            break;
                        case "3":
                            Code3.AppendText("Z");
                            break;
                        case "4":
                            Code4.AppendText("Z");
                            break;
                        case "5":
                            Code5.AppendText("Z");
                            break;
                        case "6":
                            Code6.AppendText("Z");
                            break;

                    }
                    break;
                }
            }
        }
        private void XBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("X");
                            break;
                        case "2":
                            Code2.AppendText("X");
                            break;
                        case "3":
                            Code3.AppendText("X");
                            break;
                        case "4":
                            Code4.AppendText("X");
                            break;
                        case "5":
                            Code5.AppendText("X");
                            break;
                        case "6":
                            Code6.AppendText("X");
                            break;

                    }
                    break;
                }
            }
        }
        private void CBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("C");
                            break;
                        case "2":
                            Code2.AppendText("C");
                            break;
                        case "3":
                            Code3.AppendText("C");
                            break;
                        case "4":
                            Code4.AppendText("C");
                            break;
                        case "5":
                            Code5.AppendText("C");
                            break;
                        case "6":
                            Code6.AppendText("C");
                            break;

                    }
                    break;
                }
            }
        }
        private void VBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("V");
                            break;
                        case "2":
                            Code2.AppendText("V");
                            break;
                        case "3":
                            Code3.AppendText("V");
                            break;
                        case "4":
                            Code4.AppendText("V");
                            break;
                        case "5":
                            Code5.AppendText("V");
                            break;
                        case "6":
                            Code6.AppendText("V");
                            break;

                    }
                    break;
                }
            }
        }
        private void BBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("B");
                            break;
                        case "2":
                            Code2.AppendText("B");
                            break;
                        case "3":
                            Code3.AppendText("B");
                            break;
                        case "4":
                            Code4.AppendText("B");
                            break;
                        case "5":
                            Code5.AppendText("B");
                            break;
                        case "6":
                            Code6.AppendText("B");
                            break;

                    }
                    break;
                }
            }
        }
        private void NBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("N");
                            break;
                        case "2":
                            Code2.AppendText("N");
                            break;
                        case "3":
                            Code3.AppendText("N");
                            break;
                        case "4":
                            Code4.AppendText("N");
                            break;
                        case "5":
                            Code5.AppendText("N");
                            break;
                        case "6":
                            Code6.AppendText("N");
                            break;

                    }
                    break;
                }
            }
        }
        private void MBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText("M");
                            break;
                        case "2":
                            Code2.AppendText("M");
                            break;
                        case "3":
                            Code3.AppendText("M");
                            break;
                        case "4":
                            Code4.AppendText("M");
                            break;
                        case "5":
                            Code5.AppendText("M");
                            break;
                        case "6":
                            Code6.AppendText("M");
                            break;

                    }
                    break;
                }
            }
        }
        private void COMABtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText(",");
                            break;
                        case "2":
                            Code2.AppendText(",");
                            break;
                        case "3":
                            Code3.AppendText(",");
                            break;
                        case "4":
                            Code4.AppendText(",");
                            break;
                        case "5":
                            Code5.AppendText(",");
                            break;
                        case "6":
                            Code6.AppendText(",");
                            break;

                    }
                    break;
                }
            }
        }
        private void PUNTOBtn(object sender, RoutedEventArgs e)
        {
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText(".");
                            break;
                        case "2":
                            Code2.AppendText(".");
                            break;
                        case "3":
                            Code3.AppendText(".");
                            break;
                        case "4":
                            Code4.AppendText(".");
                            break;
                        case "5":
                            Code5.AppendText(".");
                            break;
                        case "6":
                            Code6.AppendText(".");
                            break;

                    }
                    break;
                }
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
            string code1 = Code1.Text;
            string code2 = Code2.Text;
            string code3 = Code3.Text;
            string code4 = Code4.Text;
            string code5 = Code5.Text;
            string code6 = Code6.Text;

            Dictionary<string, string> Codes = new Dictionary<string, string>();
            Codes.Add("1", code1);
            Codes.Add("2", code2);
            Codes.Add("3", code3);
            Codes.Add("4", code4);
            Codes.Add("5", code5);
            Codes.Add("6", code6);

            foreach (KeyValuePair<string, string> item in Codes)
            {
                Console.WriteLine(item.Key + " Su valor es: " + item.Value);
                if (item.Value == "")
                {
                    switch (item.Key)
                    {
                        case "1":
                            Code1.AppendText(" ");
                            break;
                        case "2":
                            Code2.AppendText(" ");
                            break;
                        case "3":
                            Code3.AppendText(" ");
                            break;
                        case "4":
                            Code4.AppendText(" ");
                            break;
                        case "5":
                            Code5.AppendText(" ");
                            break;
                        case "6":
                            Code6.AppendText(" ");
                            break;

                    }
                    break;
                }
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
        private void CheckCodeSQL()
        {
            string Codigo = string.Empty;
            System.Windows.Application.Current.Dispatcher.Invoke(
   DispatcherPriority.Normal,
   (ThreadStart)delegate { Codigo = Code1.Text + Code2.Text + Code3.Text + Code4.Text + Code5.Text + Code6.Text; });
            Console.WriteLine("El codigo ingresado es: " + Codigo);
            var cipher = Encrypt(Codigo);
            Console.WriteLine("Codificado: " + cipher);

            string ConnectionString = (App.Current as App).ConnectionString;
            string sql = @"SELECT Lockers.NoLocker, Lockers.Codigo, Usuarios.Usuario, Lockers.Trama, Usuarios.Tiempo,Usuarios.DiaRenta FROM Lockers INNER JOIN Usuarios on Lockers.NoLocker = Usuarios.NoLocker Where Lockers.Codigo ='" + cipher + "'";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand queryCommand = new SqlCommand(sql, conn);
                using (SqlDataReader reader = queryCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        String CodigoSQL = Convert.ToString(reader["Codigo"]);
                        Trama = Convert.ToString(reader["Trama"]);
                        NoLockerSQL = Convert.ToInt32(reader["NoLocker"]);
                        Console.WriteLine("Entrando     " + CodigoSQL);
                        if (CodigoSQL == cipher)
                        {
                            Console.WriteLine("El Numero de Locker es: " + NoLockerSQL + ", La trama es: " + Trama);

                            // Abre la puerta del locker correspondiente
                            string InicioTrama = "10 02 57 4f 02 00 ";
                            string FinTrama = " 10 03";
                            string hex = InicioTrama + Trama + FinTrama;
                            byte[] ByteMessage = hex
                              .Split(' ')
                              .Select(item => Convert.ToByte(item, 16))
                              .ToArray();
                            string HexMessage = string.Join("-", ByteMessage
                              .Select(item => item.ToString("X2")));
                            Console.WriteLine("boton precionado  el Hex es... " + HexMessage);
                            Thread.Sleep(300);
                            DoorSerial = new SerialPort(
                              "COM6", 115200, Parity.None, 8, StopBits.One);
                            DoorSerial.Open();
                            DoorSerial.Write(ByteMessage, 0, ByteMessage.Length);
                            DoorSerial.Close();
                            DoorSerial.Close();
                            CodigoIncorrectolabel.Dispatcher.Invoke(new Action(() => CodigoIncorrectolabel.Visibility = Visibility.Hidden));
                            NoLocker.Dispatcher.Invoke(new Action(() => NoLocker.Content = "No. 0" + NoLockerSQL));
                            NotificacionGrid.Dispatcher.Invoke(new Action(() => NotificacionGrid.Visibility = Visibility.Visible));
                            aTimer = new System.Timers.Timer(15000);
                            // Hook up the Elapsed event for the timer. 
                            aTimer.Elapsed += NotificacionTimer;
                            aTimer.AutoReset = false;
                            aTimer.Enabled = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Codigo Incorrecto");
                        CodigoIncorrectolabel.Dispatcher.Invoke(new Action(() => CodigoIncorrectolabel.Visibility = Visibility.Visible));
                    }

                }
            }
        }
        private void CheckCode(object sender, RoutedEventArgs e)
        {
            CheckCodeSQL();
        }

        private void NotificacionTimer(object sender, ElapsedEventArgs e)
        {

            NotificacionGrid.Dispatcher.Invoke(new Action(() => NotificacionGrid.Visibility = Visibility.Collapsed));
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.Dispatcher.Invoke(new Action(() => this.NavigationService.Navigate(uri)));

        }

        private void CloseNotificacion(object sender, RoutedEventArgs e)
        {
            aTimer.Stop();
            NotificacionGrid.Visibility = Visibility.Collapsed;
            Uri uri = new Uri("Home.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

    }
}




