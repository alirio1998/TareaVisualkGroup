using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Web;
using TareaVisualkGroup.Models;

namespace TareaVisualkGroup.Conexion
{
    public class conexion
    {
        //si se cambia el dominio de las APIs solo se cambia en esta variable
        //sin tener que cambiarla en todos los llamados, enviando como parámetro solo el final de la url que implica la Acción
        private static string url = "https://office.visualk.cl:50346/b1s/v1/";
        public static IRestResponse ConexionRest(string endUrl, string body, Method method)
        {
            var client = new RestClient(url + endUrl);
            client.Timeout = -1;
            var request = new RestRequest(method);
            request.AddHeader("Content-Type", "application/json");
            client.RemoteCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var B1session = Convert.ToString(HttpContext.Current.Session["B1SESSION"]);
            var CompanyDB = Convert.ToString(HttpContext.Current.Session["CompanyDB"]);
            if (B1session != "" && CompanyDB != "")
            {
                request.AddCookie("B1SESSION", B1session);
                request.AddCookie("CompanyDB", CompanyDB);
            }
            return client.Execute(request);
        }

    }
}