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
using System.IO.Ports;

namespace Ubox
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SerialPort ScannerQrSerial { get; set; }
        public static SerialPort DoorSerial { get; set; }
        public static DateTime today {get;set;}
        public MainWindow()
        {
            InitializeComponent();
            ScannerQrSerial = new SerialPort(
                  "COM3", 115200, Parity.None, 8, StopBits.One);
            ScannerQrSerial.Open();
            DoorSerial = new SerialPort(
  "COM6", 115200, Parity.None, 8, StopBits.One);
            DoorSerial.Open();
            today = Convert.ToDateTime(DateTime.Today) ;
            
        }
    }
}
