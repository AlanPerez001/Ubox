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
using System.Windows.Threading;

namespace Ubox
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    // Ventana principal de la aplicacion
    public partial class MainWindow : Window
    {
        public static SerialPort ScannerQrSerial { get; set; }
        public static SerialPort DoorSerial { get; set; }
        public static SerialPort SimSerial { get; set; }
        public static DateTime today { get; set; }
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public MainWindow()
        {
            InitializeComponent();
            ScannerQrSerial = new SerialPort(
                  "COM3", 115200, Parity.None, 8, StopBits.One);
            //ScannerQrSerial.Open(); //Se abre el puerto COM3 con el que se activa el Scanner QR
            DoorSerial = new SerialPort("COM6", 115200, Parity.None, 8, StopBits.One);
            //DoorSerial.Open(); //Se abre el puerto COM6 con el que se abren las puertas de los Lockers
            today = Convert.ToDateTime(DateTime.Now); //Variable que contiene la fecha del día de manera global

            SimSerial = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One);
            SimSerial.Handshake = Handshake.RequestToSend;
            SimSerial.DtrEnable = true;
            SimSerial.RtsEnable = true;
            SimSerial.NewLine = System.Environment.NewLine;
            SimSerial.Open();


        }
        public static string Encrypt(string text) // Funcion con la cual se encripta una cadena en MD5
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
        public static string Decrypt(string cipher) // Funcion con la cual se desencripta una cadena en MD5
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
        public static string CodigoAleatorio() // Funcion que crea una cadena con longitud de 6 caracteres aleatorios alfanumericos
        {
            Random rdn = new Random();
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 6;
            string codigo = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                codigo += letra.ToString();
            }
            return codigo;
        }
    }
}
