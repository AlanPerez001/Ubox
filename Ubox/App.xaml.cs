using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Data.SqlClient;

namespace Ubox
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Connection string for using Windows Authentication.
        //private string connectionString = @"data source=desarrollozion.ddns.net; database=Ubox; User Id=sa; Password=Linda-058";
        private string connectionString = ConfigurationManager.ConnectionStrings["str"].ToString();
        public string ConnectionString { get => connectionString; set => connectionString = value; }
    }
}
