using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubox.ModelService
{
    public class RespuestaApiObjeto
    {
        public int statusCode { get; set; } = 0;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string message { get; set; } = "";
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ItemModel> errors { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public RespuestaOKObjeto respuesta { get; set; }

    }

    public class RespuestaApiLista
    {
        public int statusCode { get; set; } = 0;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string message { get; set; } = "";
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ItemModel> errors { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public RespuestaOKLista respuesta { get; set; }

    }

    public class RespuestaApiValor
    {
        public int statusCode { get; set; } = 0;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string message { get; set; } = "";
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ItemModel> errors { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public RespuestaOKValor respuesta { get; set; }

    }


    public class ItemModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string campo { get; set; }

        public string mensaje { get; set; }
    }

    public class RespuestaOKObjeto
    {
        public int IdRespuesta { get; set; }
        public string Mensaje { get; set; }
        public JObject Datos { get; set; }
        public RespuestaOKObjeto(int idRespuesta, string mensaje, JObject datos)
        {
            IdRespuesta = idRespuesta;
            Mensaje = mensaje;
            Datos = datos;
        }
    }

    public class RespuestaOKLista
    {
        public int IdRespuesta { get; set; }
        public string Mensaje { get; set; }
        public JArray Datos { get; set; }
        public RespuestaOKLista(int idRespuesta, string mensaje, JArray datos)
        {
            IdRespuesta = idRespuesta;
            Mensaje = mensaje;
            Datos = datos;
        }
    }

    public class RespuestaOKValor
    {
        public int IdRespuesta { get; set; }
        public string Mensaje { get; set; }
        public JValue Datos { get; set; }
        public RespuestaOKValor(int idRespuesta, string mensaje, JValue datos)
        {
            IdRespuesta = idRespuesta;
            Mensaje = mensaje;
            Datos = datos;
        }
    }
}
