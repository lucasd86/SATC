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
    [Authorize]
    public class SolicitarTarjetaController : Controller
    {
        private SATCconexion db = new SATCconexion();

        // GET: SolicitarTarjeta
        public ActionResult Index()
        {
            var clienteTitular = db.ClienteTitular.Include(c => c.ClienteTitular2);
            return View(clienteTitular.ToList());
        }

        // GET: SolicitarTarjeta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteTitular clienteTitular = db.ClienteTitular.Find(id);
            if (clienteTitular == null)
            {
                return HttpNotFound();
            }
            return View(clienteTitular);
        }

        // GET: SolicitarTarjeta/Create
        public ActionResult Create()
        {
            ViewBag.DNIConyuge = new SelectList(db.ClienteTitular, "DNI", "Nombre");
            return View();
        }

        // POST: SolicitarTarjeta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Apellido,DNI,CUIT,FechaNacimiento,Domicilio,EstadoCivil,IngresoMensual,Sexo,SituacionLaboral,DNIConyuge")] ClienteTitular clienteTitular)
        {
            if (ModelState.IsValid)
            {
                db.ClienteTitular.Add(clienteTitular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DNIConyuge = new SelectList(db.ClienteTitular, "DNI", "Nombre", clienteTitular.DNIConyuge);
            return View(clienteTitular);
        }

        // GET: SolicitarTarjeta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteTitular clienteTitular = db.ClienteTitular.Find(id);
            if (clienteTitular == null)
            {
                return HttpNotFound();
            }
            ViewBag.DNIConyuge = new SelectList(db.ClienteTitular, "DNI", "Nombre", clienteTitular.DNIConyuge);
            return View(clienteTitular);
        }

        // POST: SolicitarTarjeta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,Apellido,DNI,CUIT,FechaNacimiento,Domicilio,EstadoCivil,IngresoMensual,Sexo,SituacionLaboral,DNIConyuge")] ClienteTitular clienteTitular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteTitular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DNIConyuge = new SelectList(db.ClienteTitular, "DNI", "Nombre", clienteTitular.DNIConyuge);
            return View(clienteTitular);
        }

        // GET: SolicitarTarjeta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteTitular clienteTitular = db.ClienteTitular.Find(id);
            if (clienteTitular == null)
            {
                return HttpNotFound();
            }
            return View(clienteTitular);
        }

        // POST: SolicitarTarjeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteTitular clienteTitular = db.ClienteTitular.Find(id);
            db.ClienteTitular.Remove(clienteTitular);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
