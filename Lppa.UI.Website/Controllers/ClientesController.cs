﻿using System;
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
    public class ClientesController : Controller
    {
        private SATCConexion db = new SATCConexion();

        // GET: Clientes
        public ActionResult Index()
        {
            var clienteTitular = db.ClienteTitular.Include(c => c.ClienteTitular2);
            List<Lppa.UI.Website.Models.ClienteModel> lista = new List<Lppa.UI.Website.Models.ClienteModel>();
            foreach (var item in clienteTitular){
                var cliente = new Lppa.UI.Website.Models.ClienteModel();
                cliente.Nombre = item.Nombre;
                cliente.Apellido = item.Apellido;
                cliente.DNI = item.DNI;
                cliente.CUIT = item.CUIT;
                cliente.FechaNacimiento = item.FechaNacimiento;
                cliente.Domicilio = item.Domicilio;
                cliente.Telefono = item.Telefono;
                cliente.EstadoCivil = PasarEstadoCivil(item.EstadoCivil);
                cliente.IngresoMensual = item.IngresoMensual;
                cliente.Sexo = PasarSexo(item.Sexo);
                cliente.DNIConyuge = item.DNIConyuge;
                cliente.NombreConyuge = item.NombreConyuge;
                cliente.ApellidoConyuge = item.ApellidoConyuge;
                cliente.SituacionLaboral = PasarSituacionLaboral(item.SituacionLaboral);

                lista.Add(cliente);
            }
          

            return View(lista);
        }

        // GET: Clientes/Details/5
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

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.DNIConyuge = new SelectList(db.ClienteTitular, "DNI", "Nombre");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Apellido,DNI,CUIT,FechaNacimiento,Domicilio,Telefono,Email,EstadoCivil,IngresoMensual,Sexo,SituacionLaboral,DNIConyuge,NombreConyuge,ApellidoConyuge,DNIAdicional")] ClienteTitular clienteTitular)
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

        // GET: Clientes/Edit/5
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

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,Apellido,DNI,CUIT,FechaNacimiento,Domicilio,Telefono,Email,EstadoCivil,IngresoMensual,Sexo,SituacionLaboral,DNIConyuge,NombreConyuge,ApellidoConyuge,DNIAdicional")] ClienteTitular clienteTitular)
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

        // GET: Clientes/Delete/5
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

        // POST: Clientes/Delete/5
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
        public string PasarSituacionLaboral(int i)
        {

            return ((Lppa.Entities.SituacionLaboral)i).ToString();

        }

        public string PasarSexo(int i) {

            return ((Lppa.Entities.Sexo)i).ToString();

        }
        public string PasarEstadoCivil(int i) {

            return  ((Lppa.Entities.EstadoCivil)i).ToString();


        }
    }
}
