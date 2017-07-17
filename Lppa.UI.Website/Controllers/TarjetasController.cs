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
            var tarjetaDeCredito = db.TarjetaDeCredito.Include(t => t.ClienteTitular).Include(t => t.TarjetaDeCredito2);
            return View(tarjetaDeCredito.ToList());
        }

        
    }
}
