using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lppa.Entities;

namespace Lppa.UI.Website.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: Solicitud
        public ActionResult Nueva()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Nueva(FormCollection Form)
        {
            ClienteTitular ClienteTitular = new ClienteTitular();
            Lppa.Business.BLLClienteTitular _BLLCliente = new Business.BLLClienteTitular(); 


            ClienteTitular.Apellido = Form.Get("apellidoTitular").ToString();
            ClienteTitular.Nombre = Form.Get("nombreTitular").ToString();
            ClienteTitular.FechaNacimiento = Convert.ToDateTime(Form.Get("fechaNacimiento").ToString());
            ClienteTitular.DNI = Convert.ToInt32(Form.Get("numeroDocumento").ToString());
            ClienteTitular.CUIT = Convert.ToInt32(Form.Get("cuilCuit").ToString());
            ClienteTitular.Domicilio = Form.Get("domicilioTitular").ToString();            
            //ClienteTitular = Form.Get("numeroTelefono").ToString();
            //ClienteTitular.DNIConyuge = Convert.ToInt32(Form.Get("numeroDocumentoCon").ToString()); 

            //RedirectToAction("DatosAdicionales", "Home");

            _BLLCliente.AptoNoAPto(ClienteTitular.DNI);
            
            return RedirectToAction("DatosAdicionales", "Solicitud", Form);//View();
        }

        public ActionResult DatosAdicionales(FormCollection cl)
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdicionarTarjeta()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}