using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ubox.ModelService.Autenticacion;

namespace Ubox.ModelService
{
    /// <summary>
    /// Clase para llamar al web api
    /// </summary>
    public class ClienteWebApi
    {
        private Uri url = new Uri(ConfigurationManager.AppSettings["UrlWebApi"].ToString());
        private const int timeoutWebApi = 120;

        /// <summary>
        /// Metodo para hacer llamadas post sin autorizacion al wep api. Inicio de sesion por ejemplo.
        /// </summary>
        /// <param name="metodoYAccion">Metodo</param>
        /// <param name="postBody">Datos a enviar por post</param>
        /// <returns></returns>
        public async Task<RespuestaApiObjeto> callWebApiSinAutorizacion(string metodoYAccion, string postBody)
        {
            RespuestaApiObjeto res = null;
            try
            {
                using (var cliente = new HttpClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    cliente.Timeout = TimeSpan.FromSeconds(timeoutWebApi);
                    var uri = new Uri(string.Format("{0}{1}", url, metodoYAccion));
                    var requestContent = new StringContent(postBody, Encoding.UTF8, "application/json");
                    using (var response = await cliente.PostAsync(uri, requestContent))
                    {
                        //var statusCode = response.StatusCode;
                        var content = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(content);
                        res = JsonConvert.DeserializeObject<RespuestaApiObjeto>(content);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(postBody);
            }
            return res;
        }

        //Metodo para cuando el web api devuelva un objeto en el valor datos
        public async Task<RespuestaApiObjeto> callWebApiAutorizacionPostObjeto(string metodoYAccion, string postBody)
        {
            var res = new RespuestaApiObjeto();
            try
            {
                var sessionJwt = Globals.JWT;
                using (var cliente = new HttpClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    cliente.Timeout = TimeSpan.FromSeconds(timeoutWebApi);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                    var cts = new CancellationTokenSource();
                    var uri = new Uri(string.Format("{0}{1}", url, metodoYAccion));
                    var requestContent = new StringContent(postBody, Encoding.UTF8, "application/json");
                    using (var response = await cliente.PostAsync(uri, requestContent))
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(content);
                        res = JsonConvert.DeserializeObject<RespuestaApiObjeto>(content);
                        //Si el web api responde 401 no autorizado se hace una refresh token 
                        if (res.statusCode == 401)
                        {
                            //Si se pudo hacer el refrsh token se hace una nueva peticion del metodo original
                            //Si no se devuelve null y se debe iniciar sesion de nuevo.
                            var actualizaToken = await callWebApiRefreshToken();
                            if (actualizaToken)
                            {
                                sessionJwt = Globals.JWT;
                                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                                using (var response2 = await cliente.PostAsync(uri, requestContent))
                                {
                                    content = await response2.Content.ReadAsStringAsync();
                                    res = JsonConvert.DeserializeObject<RespuestaApiObjeto>(content);
                                    if (res.statusCode == 401)
                                    {
                                        res = null;
                                    }
                                }
                            }
                            else
                            {
                                res = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(postBody);
            }
            return res;
        }
        //Metodo para cuando el web api devuelva un objeto en el valor datos
        public async Task<RespuestaApiObjeto> callWebApiAutorizacionGetObjeto(string metodoYAccion)
        {
            var res = new RespuestaApiObjeto();
            try
            {
                var sessionJwt = Globals.JWT;
                using (var cliente = new HttpClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    cliente.Timeout = TimeSpan.FromSeconds(timeoutWebApi);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                    var cts = new CancellationTokenSource();
                    var uri = new Uri(string.Format("{0}{1}", url, metodoYAccion));
                    using (var response = await cliente.GetAsync(uri))
                    {
                        //var statusCode = response.StatusCode;
                        var content = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(content);
                        res = JsonConvert.DeserializeObject<RespuestaApiObjeto>(content);
                        //Si el web api responde 401 no autorizado se hace una refresh token 
                        if (res.statusCode == 401)
                        {
                            //Si se pudo hacer el refrsh token se hace una nueva peticion del metodo original
                            //Si no se devuelve null y se debe iniciar sesion de nuevo.
                            var actualizaToken = await callWebApiRefreshToken();
                            if (actualizaToken)
                            {
                                sessionJwt = Globals.JWT;
                                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                                using (var response2 = await cliente.GetAsync(uri))
                                {
                                    content = await response2.Content.ReadAsStringAsync();
                                    res = JsonConvert.DeserializeObject<RespuestaApiObjeto>(content);
                                    if (res.statusCode == 401)
                                    {
                                        res = null;
                                    }
                                }
                            }
                            else
                            {
                                res = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return res;
        }

        //Metodo para cuando el web api devuelva una lista en el valor datos
        public async Task<RespuestaApiLista> callWebApiAutorizacionPostLista(string metodoYAccion, string postBody)
        {
            var res = new RespuestaApiLista();
            try
            {
                var sessionJwt = Globals.JWT;
                using (var cliente = new HttpClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    cliente.Timeout = TimeSpan.FromSeconds(timeoutWebApi);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                    var cts = new CancellationTokenSource();
                    var uri = new Uri(string.Format("{0}{1}", url, metodoYAccion));
                    var requestContent = new StringContent(postBody, Encoding.UTF8, "application/json");
                    using (var response = await cliente.PostAsync(uri, requestContent))
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(content);
                        res = JsonConvert.DeserializeObject<RespuestaApiLista>(content);
                        //Si el web api responde 401 no autorizado se hace una refresh token 
                        if (res.statusCode == 401)
                        {
                            //Si se pudo hacer el refrsh token se hace una nueva peticion del metodo original
                            //Si no se devuelve null y se debe iniciar sesion de nuevo.
                            var actualizaToken = await callWebApiRefreshToken();
                            if (actualizaToken)
                            {
                                sessionJwt = Globals.JWT;
                                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                                using (var response2 = await cliente.PostAsync(uri, requestContent))
                                {
                                    content = await response.Content.ReadAsStringAsync();
                                    res = JsonConvert.DeserializeObject<RespuestaApiLista>(content);
                                    if (res.statusCode == 401)
                                    {
                                        res = null;
                                    }
                                }
                            }
                            else
                            {
                                res = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(postBody);
            }
            return res;
        }

        //Metodo para cuando el web api devuelva una lista en el valor datos
        public async Task<RespuestaApiLista> callWebApiAutorizacionGetLista(string metodoYAccion)
        {
            var res = new RespuestaApiLista();
            try
            {
                var sessionJwt = Globals.JWT;
                using (var cliente = new HttpClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    cliente.Timeout = TimeSpan.FromSeconds(timeoutWebApi);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                    var cts = new CancellationTokenSource();
                    var uri = new Uri(string.Format("{0}{1}", url, metodoYAccion));
                    using (var response = await cliente.GetAsync(uri))
                    {
                        //var statusCode = response.StatusCode;
                        var content = await response.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<RespuestaApiLista>(content);
                        //Si el web api responde 401 no autorizado se hace una refresh token 
                        if (res.statusCode == 401)
                        {
                            //Si se pudo hacer el refrsh token se hace una nueva peticion del metodo original
                            //Si no se devuelve null y se debe iniciar sesion de nuevo.
                            var actualizaToken = await callWebApiRefreshToken();
                            if (actualizaToken)
                            {
                                sessionJwt = Globals.JWT;
                                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                                using (var response2 = await cliente.GetAsync(uri))
                                {
                                    content = await response.Content.ReadAsStringAsync();
                                    res = JsonConvert.DeserializeObject<RespuestaApiLista>(content);
                                    if (res.statusCode == 401)
                                    {
                                        res = null;
                                    }
                                }
                            }
                            else
                            {
                                res = null;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return res;
        }

        //Metodo para cuando el web api devuelva un valor primitivo en el valor datos
        public async Task<RespuestaApiValor> callWebApiAutorizacionPostValor(string metodoYAccion, string postBody)
        {
            var res = new RespuestaApiValor();
            try
            {
                var sessionJwt = Globals.JWT;
                using (var cliente = new HttpClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    cliente.Timeout = TimeSpan.FromSeconds(timeoutWebApi);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                    var cts = new CancellationTokenSource();
                    var uri = new Uri(string.Format("{0}{1}", url, metodoYAccion));
                    var requestContent = new StringContent(postBody, Encoding.UTF8, "application/json");
                    using (var response = await cliente.PostAsync(uri, requestContent))
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(content);
                        res = JsonConvert.DeserializeObject<RespuestaApiValor>(content);
                        //Si el web api responde 401 no autorizado se hace una refresh token 
                        if (res.statusCode == 401)
                        {
                            //Si se pudo hacer el refrsh token se hace una nueva peticion del metodo original
                            //Si no se devuelve null y se debe iniciar sesion de nuevo.
                            var actualizaToken = await callWebApiRefreshToken();
                            if (actualizaToken)
                            {
                                sessionJwt = Globals.JWT;
                                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                                using (var response2 = await cliente.PostAsync(uri, requestContent))
                                {
                                    content = await response.Content.ReadAsStringAsync();
                                    res = JsonConvert.DeserializeObject<RespuestaApiValor>(content);
                                    if (res.statusCode == 401)
                                    {
                                        res = null;
                                    }
                                }
                            }
                            else
                            {
                                res = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(postBody);
            }
            return res;
        }

        //Metodo para cuando el web api devuelva un valor primitivo en el valor datos
        public async Task<RespuestaApiValor> callWebApiAutorizacionGetValor(string metodoYAccion)
        {
            var res = new RespuestaApiValor();
            try
            {
                var sessionJwt = Globals.JWT;
                using (var cliente = new HttpClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    cliente.Timeout = TimeSpan.FromSeconds(timeoutWebApi);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                    var cts = new CancellationTokenSource();
                    var uri = new Uri(string.Format("{0}{1}", url, metodoYAccion));
                    using (var response = await cliente.GetAsync(uri))
                    {
                        //var statusCode = response.StatusCode;
                        var content = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(content);
                        res = JsonConvert.DeserializeObject<RespuestaApiValor>(content);
                        //Si el web api responde 401 no autorizado se hace una refresh token 
                        if (res.statusCode == 401)
                        {
                            //Si se pudo hacer el refrsh token se hace una nueva peticion del metodo original
                            //Si no se devuelve null y se debe iniciar sesion de nuevo.
                            var actualizaToken = await callWebApiRefreshToken();
                            if (actualizaToken)
                            {
                                sessionJwt = Globals.JWT;
                                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionJwt.ToString());
                                using (var response2 = await cliente.GetAsync(uri))
                                {
                                    content = await response.Content.ReadAsStringAsync();
                                    res = JsonConvert.DeserializeObject<RespuestaApiValor>(content);
                                    if (res.statusCode == 401)
                                    {
                                        res = null;
                                    }
                                }
                            }
                            else
                            {
                                res = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return res;
        }

      

        /// <summary>
        /// Metodo para actualizar el token de acceso en caso de que se haya expirado
        /// </summary>
        /// <returns></returns>
        public async Task<bool> callWebApiRefreshToken()
        {
            var resultado = false;
            string refreshToken = Globals.RefreshToken;
            string user = Globals.IdUser.ToString();
            string jwt = Globals.JWT;
            var peticion = new ActualizarToken(refreshToken, user, jwt);
            try
            {
                using (var cliente = new HttpClient())
                {
                    var res = new RespuestaApiObjeto();
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    cliente.Timeout = TimeSpan.FromSeconds(timeoutWebApi);
                    var cts = new CancellationTokenSource();
                    var postBody = JsonConvert.SerializeObject(peticion);
                    var uri = new Uri(string.Format("{0}{1}", url, "Autenticacion/RefreshToken"));
                    var requestContent = new StringContent(postBody, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(uri, requestContent);
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(content);
                    res = JsonConvert.DeserializeObject<RespuestaApiObjeto>(content);
                    if (res.statusCode == 200)
                    {
                        ////Se guarda el JWt en Session y el RefreshToken en Cookie
                        RespuestaAutenticacion modeloAprobado = res.respuesta.Datos.ToObject<RespuestaAutenticacion>();
                        Globals.JWT = modeloAprobado.jwtToken;
                        Globals.RefreshToken = modeloAprobado.refreshToken;
                        Globals.IdUser = res.respuesta.IdRespuesta;
                        resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return resultado;
        }

    }
}
