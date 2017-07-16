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
            TarjetaDeCredito TarjetaCredito = new TarjetaDeCredito();

            Lppa.Business.BLLClienteTitular _BLLCliente = new Business.BLLClienteTitular(); 


            ClienteTitular.Apellido = Form.Get("apellidoTitular").ToString();
            ClienteTitular.Nombre = Form.Get("nombreTitular").ToString();
            ClienteTitular.FechaNacimiento = Convert.ToDateTime(Form.Get("fechaNacimiento").ToString());
            ClienteTitular.DNI = Convert.ToInt32(Form.Get("numeroDocumento").ToString());
            ClienteTitular.CUIT = Convert.ToInt32(Form.Get("cuilCuit").ToString());
            ClienteTitular.Domicilio = Form.Get("domicilioTitular").ToString();
            ClienteTitular.Telefono= Convert.ToInt32(Form.Get("numeroTelefono").ToString());             
            ClienteTitular.EstadoCivil = (EstadoCivil)Convert.ToInt32(Form.Get("estadoCivil").ToString());
            ClienteTitular.IngresosMensualesAprox = Convert.ToInt32(Form.Get("ingresos").ToString());
            ClienteTitular.Sexo = (Sexo)Convert.ToInt32(Form.Get("Sexo").ToString()); 
            ClienteTitular.SituacionLaboral = (SituacionLaboral)Convert.ToInt32(Form.Get("situacionLaboral").ToString());

            //ClienteTitular.DNIConyuge = Convert.ToInt32(Form.Get("numeroDocumentoCon").ToString());
            //ClienteTitular.NombreConyuge = Convert.ToInt32(Form.Get("nombreConyuge").ToString());
            //ClienteTitular.ApellidoConyuge = Convert.ToInt32(Form.Get("apellidoConyuge").ToString());
            TarjetaCredito.Marca = (MarcasTarjetasCredito)Convert.ToInt32(Form.Get("tipoTarjeta").ToString());

            if (_BLLCliente.AptoNoAPto(ClienteTitular.DNI))
            {
                try{

                    _BLLCliente.CrearClienteTitular(ClienteTitular);

                }
                catch (Exception ex)
                    {
                    throw new Exception("ERROR al crear Cliente / Controller", ex);

                }

 

            }
            
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

        [HttpPost]
        public ActionResult AdicionarTarjeta(FormCollection Form)
        {
            ClienteTitular ClienteTitular = new ClienteTitular();
            Lppa.Business.BLLClienteTitular _BLLCliente = new Business.BLLClienteTitular();

            ClienteTitular.DNI= Convert.ToInt32( Form.Get("numeroDocumentoTitular"));
            ClienteTitular = _BLLCliente.ListarClientePorDNI(ClienteTitular.DNI);

            return View();
          
        }

        public ActionResult NuevaAdicional()
        {
            ViewBag.Message = "Nueva Adicional";

            return View();
        }

       /* public ActionResult NuevaAdicional(int dniTitular)
        {
            ViewBag.Message = "Nueva Adicional";

            return View();
        }
        */
        [HttpPost]
        public ActionResult NuevaAdicional(FormCollection Collection)
        {
            ViewBag.Message = "Nueva Adicional Post";
        
            return View();
        }



    }
}