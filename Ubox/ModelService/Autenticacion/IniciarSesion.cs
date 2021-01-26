using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubox.ModelService.Autenticacion
{
    public class IniciarSesion
    {
        public IniciarSesion(string idUbox, string clave, string App, string Version, string TokenApp, string Plataforma, string macAddress)
        {
            IdUbox = idUbox;
            Clave = clave;
            this.App = App;
            this.Version = Version;
            this.TokenApp = TokenApp;
            this.Plataforma = Plataforma;
            MacAddress = macAddress;
        }

        public string IdUbox { get; }
        public string Clave { get; }
        public string App { get; set; }
        public string Version { get; set; }
        public string TokenApp { get; set; }
        public string Plataforma { get; set; }
        public string MacAddress { get; }
    }
}
