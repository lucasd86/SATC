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
            ClienteTitular _ClienteTitular = new ClienteTitular();
            TarjetaDeCredito _TarjetaCredito = new TarjetaDeCredito();

            Business.BLLClienteTitular _BLLCliente = new Business.BLLClienteTitular();
            Business.BLLTarjetaDeCredito _BLLTarjeta = new Business.BLLTarjetaDeCredito();

            _ClienteTitular.Apellido = Form.Get("apellidoTitular").ToString();
            _ClienteTitular.Nombre = Form.Get("nombreTitular").ToString();
            _ClienteTitular.FechaNacimiento = Convert.ToDateTime(Form.Get("fechaNacimiento").ToString());
            _ClienteTitular.DNI = Convert.ToInt32(Form.Get("numeroDocumento").ToString());
            _ClienteTitular.CUIT = Convert.ToInt32(Form.Get("cuilCuit").ToString());
            _ClienteTitular.Domicilio = Form.Get("domicilioTitular").ToString();
            _ClienteTitular.Telefono= Convert.ToInt32(Form.Get("numeroTelefono").ToString());
            _ClienteTitular.EstadoCivil = (EstadoCivil)Convert.ToInt32(Form.Get("estadoCivil").ToString());
            _ClienteTitular.IngresosMensualesAprox = Convert.ToInt32(Form.Get("ingresos").ToString());
            _ClienteTitular.Sexo = (Sexo)Convert.ToInt32(Form.Get("Sexo").ToString());
            _ClienteTitular.SituacionLaboral = (SituacionLaboral)Convert.ToInt32(Form.Get("situacionLaboral").ToString());

            //_ClienteTitular.DNIConyuge = Convert.ToInt32(Form.Get("numeroDocumentoCon").ToString());
            //_ClienteTitular.NombreConyuge = Convert.ToInt32(Form.Get("nombreConyuge").ToString());
            //_ClienteTitular.ApellidoConyuge = Convert.ToInt32(Form.Get("apellidoConyuge").ToString());
            _TarjetaCredito.Marca = (MarcasTarjetasCredito)Convert.ToInt32(Form.Get("tipoTarjeta").ToString());
            _TarjetaCredito.CreditoMaximo = 15000;
            _TarjetaCredito.Tipo = TipoDeTarjetaDeCredito.Titular;
            _TarjetaCredito._cliente = _ClienteTitular;
            _TarjetaCredito._estadoTarjeta = EstadoTarjeta.Emitida;
            if (_BLLCliente.AptoNoAPto(_ClienteTitular.DNI))
            {
                try{

                    _BLLCliente.CrearClienteTitular(_ClienteTitular);
                    _BLLTarjeta.CrearTarjetaDeCredito(_TarjetaCredito, _ClienteTitular.DNI);
                }
                catch (Exception ex)
                    {
                    throw new Exception("ERROR al crear Cliente / Controller", ex);

                }

 

            }
            
            
            
            return RedirectToAction("DatosAdicionales", "Solicitud");//View();
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
            if (_BLLCliente.Existe(ClienteTitular.DNI))
            {
 
                return RedirectToAction("NuevaAdicional", "Solicitud", ClienteTitular);
            }
            else
            {

                ViewData["mensaje"] = "NO EXISTE CLIENTE";

            }

            
           
            return View();
          
        }

      

       public ActionResult NuevaAdicional(ClienteTitular _cliente)
        {
            ViewBag.Message = "Nueva Adicional";
            ViewData["titular"] = Convert.ToString(_cliente.DNI);
            return View();
        }
        
        [HttpPost]
        public ActionResult NuevaAdicional(FormCollection Form)
        {
           
            ClienteTitular _ClienteAdicional = new ClienteTitular();
            TarjetaDeCredito _TarjetaCredito = new TarjetaDeCredito();
            int _TitularDNI = Convert.ToInt32(Form.Get("titular").ToString());
            Business.BLLClienteTitular _BLLCliente = new Business.BLLClienteTitular();
            Business.BLLTarjetaDeCredito _BLLTarjeta = new Business.BLLTarjetaDeCredito();

            _ClienteAdicional.Apellido = Form.Get("apellidoAdicional").ToString();
            _ClienteAdicional.Nombre = Form.Get("nombreAdicional").ToString();
            _ClienteAdicional.FechaNacimiento = Convert.ToDateTime(Form.Get("fechaNacimiento").ToString());
            _ClienteAdicional.DNI = Convert.ToInt32(Form.Get("numeroDocumento").ToString());
            _ClienteAdicional.CUIT = Convert.ToInt32(Form.Get("cuilCuit").ToString());
            _ClienteAdicional.Domicilio = Form.Get("domicilioAdicional").ToString();
            _ClienteAdicional.Telefono = Convert.ToInt32(Form.Get("numeroTelefono").ToString());
            _ClienteAdicional.EstadoCivil = (EstadoCivil)Convert.ToInt32(Form.Get("estadoCivil").ToString());
            _ClienteAdicional.IngresosMensualesAprox = Convert.ToInt32(Form.Get("ingresos").ToString());
            _ClienteAdicional.Sexo = (Sexo)Convert.ToInt32(Form.Get("Sexo").ToString());
            _ClienteAdicional.SituacionLaboral = (SituacionLaboral)Convert.ToInt32(Form.Get("situacionLaboral").ToString());

            //_ClienteAdicional.DNIConyuge = Convert.ToInt32(Form.Get("numeroDocumentoCon").ToString());
            //_ClienteAdicional.NombreConyuge = Convert.ToInt32(Form.Get("nombreConyuge").ToString());
            //_ClienteAdicional.ApellidoConyuge = Convert.ToInt32(Form.Get("apellidoConyuge").ToString());
            _TarjetaCredito.Marca = (MarcasTarjetasCredito)Convert.ToInt32(Form.Get("tipoTarjeta").ToString());
            
            _TarjetaCredito.CreditoMaximo = 15000;
            _TarjetaCredito.Tipo = TipoDeTarjetaDeCredito.Titular;
            _TarjetaCredito._cliente = _ClienteAdicional;
            _TarjetaCredito._estadoTarjeta = EstadoTarjeta.Emitida;
          
            if (_BLLCliente.AptoNoAPto(_ClienteAdicional.DNI))
            {
                try
                {

                    _BLLCliente.CrearAdicional(_ClienteAdicional, _TitularDNI);
                    _BLLTarjeta.CrearTarjetaDeCredito(_TarjetaCredito, _ClienteAdicional.DNI);
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR al crear Cliente / Controller", ex);

                }



            }

            return RedirectToAction("DatosAdicionales", "Solicitud", Form);//View();
        }

        public ActionResult DatosAdicionales( )
        {

            ViewBag.Message = "Your contact page.";

            return View();


        }
        [HttpPost]
        public ActionResult DatosAdicionales(FormCollection form)
        { 
            ViewBag.Message = "Your contact page.";

            return RedirectToAction("Index", "Clientes");


        }
        



    }
}