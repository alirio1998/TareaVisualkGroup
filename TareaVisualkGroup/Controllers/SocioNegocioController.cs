using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaVisualkGroup.Conexion;
using TareaVisualkGroup.Models;

namespace TareaVisualkGroup.Controllers
{
    public class SocioNegocioController : Controller
    {
        // GET: SocioNegocio
        public ActionResult Listado()
        {
            return View();
        }

        [HttpGet]
        public JsonResult BalanceSocio(string cod)
        {
            try
            {
                string url = $"BusinessPartners?$select=CurrentAccountBalance&$filter=CardCode eq '{cod}'";

                string body = "";
                IRestResponse respuesta = conexion.ConexionRest(url, body, Method.GET);

                if (respuesta.IsSuccessful)
                {

                    var jsonData = new
                    {
                        data = respuesta.Content,
                        isSuccess = true,
                        error = ""
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else if (respuesta.StatusCode == 0)
                {
                    var jsonData = new
                    {
                        data = "",
                        isSuccess = false,
                        error = "No se pudo conectar con el servidor"
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    JObject error = JObject.Parse(respuesta.Content);
                    var prueba = error["error"]["message"]["value"];
                    var jsonData = new
                    {
                        data = "",
                        isSuccess = false,
                        error = prueba
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }

            }
            catch
            {
                var jsonData = new
                {
                    data = "",
                    isSuccess = false,
                    error = "No se pudo conectar con el servidor"
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Crear(BusinessPartners model)
        {
            try
            {

                string body = JsonConvert.SerializeObject(model);
                IRestResponse respuesta = conexion.ConexionRest("BusinessPartners", body, Method.POST);

                if (respuesta.IsSuccessful)
                {

                    var jsonData = new
                    {
                        data = respuesta.Content,
                        isSuccess = true,
                        error = ""
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else if (respuesta.StatusCode == 0)
                {
                    var jsonData = new
                    {
                        data = "",
                        isSuccess = false,
                        error = "No se pudo conectar con el servidor"
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    JObject error = JObject.Parse(respuesta.Content);
                    var mensaje = error["error"]["message"]["value"];
                    var jsonData = new
                    {
                        data = "",
                        isSuccess = false,
                        error = mensaje.ToString()
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch
            {
                var jsonData = new
                {
                    data = "",
                    isSuccess = false,
                    error = "No se pudo conectar con el servidor"
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public JsonResult BuscarSocio (string nombreSocio = "")
        {
            try
            {
                // TODO: Add insert logic here


                string endurl = $"BusinessPartners?$select=CardCode,CardName,CardType,FederalTaxID&$filter=startswith(CardName, '{nombreSocio}')";
                IRestResponse respuesta = conexion.ConexionRest(endurl, "", Method.GET);
                List<BusinessPartners> socios = new List<BusinessPartners>();

                if (respuesta.IsSuccessful)
                {
                    JObject json = JObject.Parse(respuesta.Content);
                    dynamic contenido = json["value"];

                    foreach (var item in contenido)
                    {
                        socios.Add(new BusinessPartners { CardCode = item["CardCode"], CardName = item["CardName"], CardType = item["CardType"], FederalTaxID = item["FederalTaxID"] });
                    }

                    var jsonData = new
                    {
                        data = socios,
                        isSuccess = true,
                        error = ""
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else if (respuesta.StatusCode == 0)
                {
                    var jsonData = new
                    {
                        data = socios,
                        isSuccess = false,
                        error = "No se pudo conectar con el servidor"
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    JObject error = JObject.Parse(respuesta.Content);
                    var mensaje = error["error"]["message"]["value"];
                    var jsonData = new
                    {
                        data = "",
                        isSuccess = false,
                        error = mensaje.ToString()
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }

            }
            catch
            {
                var jsonData = new
                {
                    data = "",
                    isSuccess = false,
                    error = "No se pudo conectar con el servidor"
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult Edit(BusinessPartners model)
        {
            try
            {
                string url = $"BusinessPartners('{model.CardCode}')";

                string body = JsonConvert.SerializeObject(model);
                IRestResponse respuesta = conexion.ConexionRest(url, body, Method.PATCH);

                if (respuesta.IsSuccessful)
                {

                    var jsonData = new
                    {
                        data = model,
                        isSuccess = true,
                        error = ""
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else if (respuesta.StatusCode == 0)
                {
                    var jsonData = new
                    {
                        data = "",
                        isSuccess = false,
                        error = "No se pudo conectar con el servidor"
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    JObject error = JObject.Parse(respuesta.Content);
                    var mensaje = error["error"]["message"]["value"];
                    var jsonData = new
                    {
                        data = "",
                        isSuccess = false,
                        error = mensaje.ToString()
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }

            }
            catch
            {
                var jsonData = new
                {
                    data = "",
                    isSuccess = false,
                    error = "No se pudo conectar con el servidor"
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult Delete(string cod)
        {
            try
            {
                string url = $"BusinessPartners('{cod}')";

                string body = "";
                IRestResponse respuesta = conexion.ConexionRest(url, body, Method.DELETE);

                if (respuesta.IsSuccessful)
                {

                    var jsonData = new
                    {
                        data = respuesta.Content,
                        isSuccess = true,
                        error = ""
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else if (respuesta.StatusCode == 0)
                {
                    var jsonData = new
                    {
                        data = "",
                        isSuccess = false,
                        error = "No se pudo conectar con el servidor"
                    };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    JObject error = JObject.Parse(respuesta.Content);
                    var mensaje = error["error"]["message"]["value"];
                    var jsonData = new
                    {
                        data = "",
                        isSuccess = false,
                        error = mensaje.ToString()
                    };

                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }

            }
            catch
            {
                var jsonData = new
                {
                    data = "",
                    isSuccess = false,
                    error = "No se pudo conectar con el servidor"
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
