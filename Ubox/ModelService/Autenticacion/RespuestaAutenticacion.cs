using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubox.ModelService.Autenticacion
{
    public class RespuestaAutenticacion
    {
        public string jwtToken { get; set; }
        public string refreshToken { get; set; }
    }
}
