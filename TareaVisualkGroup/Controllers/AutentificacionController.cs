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
    public class AutentificacionController : Controller
    {
        public ActionResult Login()
        {
            User oUser = new User();
            oUser.Empresa = "VISUALK_CL";
            oUser.Pass = "123qwe";
            oUser.Usuario = "postulante2";
            return View(oUser);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    //hacer la conexión Login
                    JObject cadena = new JObject();
                    cadena.Add(new JProperty("CompanyDB", model.Empresa));
                    cadena.Add(new JProperty("Password", model.Pass));
                    cadena.Add(new JProperty("UserName", model.Usuario));
                    
                    string body = JsonConvert.SerializeObject(cadena);
                    IRestResponse respuesta = conexion.ConexionRest("Login", body, Method.POST);
                    if (respuesta.IsSuccessful)
                    {
                        Session["B1SESSION"] = respuesta.Cookies[0].Value;
                        Session["CompanyDB"] = respuesta.Cookies[1].Value;
                        return RedirectToAction("Listado", "SocioNegocio");
                    }
                    else if(respuesta.StatusCode == 0)
                    {
                        ViewBag.Error = "No se pudo conectar con el servidor";
                        return View(model);
                    }
                    else
                    {
                        ViewBag.Error = "Datos Incorrectos";
                        return View(model);
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
