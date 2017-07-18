using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lppa.Data;

namespace Lppa.UI.Website.Controllers
{
    public class TarjetasController : Controller
    {
        private SATCConexion db = new SATCConexion();

        // GET: Tarjetas
        public ActionResult Index()
        {

            var tarjetaDeCredito = db.TarjetaDeCredito.Include(t => t.ClienteTitular);
            List<Models.TarjetaModel> lista = new List<Models.TarjetaModel>();
            foreach (var item in tarjetaDeCredito)
            {
                var tarjeta = new Models.TarjetaModel();
                tarjeta.DNICliente = item.DNICliente;
                tarjeta.NumeroTarjeta = item.NumeroTarjeta;
                tarjeta.SaldoMaximo = item.SaldoMaximo;
                tarjeta.Tipo = PasarTipo(item.Tipo) ;
                tarjeta.Marca = PasarMarca(item.Marca);
                tarjeta.Estado = PasarEstado(item.Estado);
                lista.Add(tarjeta);
            }

            
            return View(lista);
        }

        public string PasarMarca(int i)
        {

            return ((Lppa.Entities.MarcasTarjetasCredito)i).ToString();


        }
        public string PasarEstado(int i)
        {

            return ((Lppa.Entities.EstadoTarjeta)i).ToString();


        }
        public string PasarTipo(int i)
        {

            return ((Lppa.Entities.TipoDeTarjetaDeCredito)i).ToString();


        }
    }
}
