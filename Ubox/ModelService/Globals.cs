using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ubox.ModelService.Autenticacion;
using Ubox.ModelService.Ubox;

namespace Ubox.ModelService
{
    class Globals
    {
        public static string JWT { get; set; }
        public static string RefreshToken { get; set; }

        public static int IdUser { get; set; }


        public static string getMacAddress()
        {
            string value = "";
            try
            {
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        value = nic.GetPhysicalAddress().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                value = "-1";
            }
            return value;
        }

        public static async Task<bool> iniciaSesionAsync()
        {
            var res = false;
            string plataforma = ConfigurationManager.AppSettings["Plataforma"].ToString();
            string app = ConfigurationManager.AppSettings["App"].ToString();
            string version = ConfigurationManager.AppSettings["Version"].ToString();
            string idUbox = ConfigurationManager.AppSettings["IdUbox"].ToString();
            string clave = ConfigurationManager.AppSettings["ClaveUbox"].ToString();
            string macAddress = getMacAddress();
            Console.WriteLine(macAddress);
            IniciarSesion peticion = new IniciarSesion(idUbox, clave, app, version, "", plataforma, macAddress);
            ClienteWebApi clienteWebApi = new ClienteWebApi();
            var respuestaWebApi = await clienteWebApi.callWebApiSinAutorizacion("Autenticacion/LoginWindows",
                JsonConvert.SerializeObject(peticion));
            if (respuestaWebApi != null)
            {
                if (respuestaWebApi.statusCode == 200)
                {
                    ////Se guarda el JWt en Session y el RefreshToken en Cookie
                    RespuestaAutenticacion modeloAprobado = respuestaWebApi.respuesta.Datos.ToObject<RespuestaAutenticacion>();
                    ////Ahorita guardariamos los datos en memoria 
                    JWT = modeloAprobado.jwtToken;
                    RefreshToken = modeloAprobado.refreshToken;
                    IdUser = respuestaWebApi.respuesta.IdRespuesta;
                    res = true;
                }
                else if (respuestaWebApi.statusCode == 400)
                {
                    ////Aqui se veria que mensaje poner en caso de que no se pueda hacer un login
                    ///porque falte un dato
                    MessageBox.Show(respuestaWebApi.message);
                }
                else
                {
                    ////Aqui habria que ver igual que mensaje poner desde el web api
                    ////Por que debio ocurrir un error en el web api
                    MessageBox.Show(respuestaWebApi.message);
                }
            }
            else
            {
                MessageBox.Show("Por el momento el servicio esta fuera de linea, intentalo más tarde.");
            }

            return res;
        }

        public static async Task<bool> ObtenerPrecio(int IdLocker)
        {


            string idUbox = ConfigurationManager.AppSettings["IdUbox"].ToString();
            ClienteWebApi clienteWebApi = new ClienteWebApi();
            var respuestaDatosBasicos = await clienteWebApi.callWebApiAutorizacionGetLista($"Ubox/ObtenerPrecio/{IdLocker}");
            if (respuestaDatosBasicos != null)
            {
                var datosBasicos = respuestaDatosBasicos.respuesta.Datos.ToObject<List<ModeloCostoLocker>>();

                string Costostring = Convert.ToString(datosBasicos.ElementAt(0).Costo);


                string[] subs = Costostring.Split('.');

                GenerarCodigo.NoLocker = Convert.ToInt32(datosBasicos.ElementAt(0).IdLocker);
                GenerarCodigo.Tamaño = Convert.ToString(datosBasicos.ElementAt(0).Descripcion);
                GenerarCodigo.Costo = Convert.ToInt32(subs[0]);
                //SeleccionTamañoLoccker.Content = Tamaño;
                //SeleccionNolocker.Content = "No. " + NoLocker;
                return true;
            }
            else
            {
                ////Si se vencieron los tokens se logea de nuevo y se llama de nuevo al metodo
                if (await Globals.iniciaSesionAsync())
                {
                    respuestaDatosBasicos = await clienteWebApi.callWebApiAutorizacionGetLista($"Ubox/ObtenerPrecio/{IdLocker}");
                    if (respuestaDatosBasicos != null)
                    {
                        var datosBasicos = respuestaDatosBasicos.respuesta.Datos.ToObject<List<ModeloCostoLocker>>();
                        string Costostring = Convert.ToString(datosBasicos.ElementAt(0).Costo);


                        string[] subs = Costostring.Split('.');

                        GenerarCodigo.NoLocker = Convert.ToInt32(datosBasicos.ElementAt(0).IdLocker);
                        GenerarCodigo.Tamaño = Convert.ToString(datosBasicos.ElementAt(0).Descripcion);
                        GenerarCodigo.Costo = Convert.ToInt32(subs[0]);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }

        public static async Task<object> CheckCode()
        {
            string idUbox = ConfigurationManager.AppSettings["IdUbox"].ToString();
            ClienteWebApi clienteWebApi = new ClienteWebApi();
            var respuestaDatosBasicos = await clienteWebApi.callWebApiAutorizacionGetLista($"Ubox/getLockers/{idUbox}");
            if (respuestaDatosBasicos != null)
            {
                var datosBasicos = respuestaDatosBasicos.respuesta.Datos.ToObject<List<ModeloUbox>>();
                Console.WriteLine("Imprimiendo datos basicos "+Convert.ToString(datosBasicos.ElementAt(0).IdLocker));
                return datosBasicos;
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
                        Console.WriteLine(datosBasicos[35].ToString());
                        return datosBasicos;
                    }
                    else
                    {
                        ////Aqui ya mejor se navegaria al home para volver a empezar
                    }
                }
                return 0;
            }
            //CheckCodeSQL();
        }

    }


}
