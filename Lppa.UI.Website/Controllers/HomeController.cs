using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lppa.Entities;

namespace Lppa.UI.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Solicitud()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Solicitud(FormCollection Form)
        {
            ClienteTitular ClienteTitular = new ClienteTitular();

            ClienteTitular.Apellido = Form.Get("apellidoTitular").ToString();
            ClienteTitular.Nombre = Form.Get("nombreTitular").ToString();
            ClienteTitular.FechaNacimiento = Convert.ToDateTime(Form.Get("fechaNacimiento").ToString());
            ClienteTitular.DNI = Convert.ToInt32(Form.Get("numeroDocumento").ToString());
            ClienteTitular.CUIT = Convert.ToInt32(Form.Get("cuilCuit").ToString());
            ClienteTitular.Domicilio = Form.Get("domicilioTitular").ToString();
            //ClienteTitular = Form.Get("numeroTelefono").ToString();
            //ClienteTitular.DNIConyuge = Convert.ToInt32(Form.Get("numeroDocumentoCon").ToString()); 

            RedirectToAction("DatosAdicionales", "Home");
        }

        public ActionResult DatosAdicionales(ClienteTitular Cliente)
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}