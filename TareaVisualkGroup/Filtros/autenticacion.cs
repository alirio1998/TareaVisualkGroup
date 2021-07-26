using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaVisualkGroup.Controllers;

namespace TareaVisualkGroup.Filtros
{
    public class autenticacion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var B1session = Convert.ToString(HttpContext.Current.Session["B1SESSION"]);
            var CompanyDB = Convert.ToString(HttpContext.Current.Session["CompanyDB"]);
            if (B1session == "" && CompanyDB == "")
            {
                if (filterContext.Controller is AutentificacionController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Autentificacion/Login");

                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}