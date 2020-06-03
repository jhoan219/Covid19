﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationPIT.Models;

namespace WebApplicationPIT.Views
{
    public class ciudadano1Controller : Controller
    {
        private PITEntities3 db = new PITEntities3();

        // GET: ciudadano1
        public ActionResult Index()
        {
            var ciudadano = db.ciudadano.Include(c => c.estado);
            return View(ciudadano.ToList());
        }

        // GET: ciudadano1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudadano ciudadano = db.ciudadano.Find(id);
            if (ciudadano == null)
            {
                return HttpNotFound();
            }
            return View(ciudadano);
        }

        // GET: ciudadano1/Create
        public ActionResult Create()
        {
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descripcion");
            return View();
        }

        // POST: ciudadano1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idciudadano,nombres,nacionalidad,tipodocumento,numdocumento,iddepartamento,idprovincia,iddistrito,idestado")] ciudadano ciudadano)
        {
            if (ModelState.IsValid)
            {
                db.ciudadano.Add(ciudadano);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idestado = new SelectList(db.estado, "idestado", "descripcion", ciudadano.idestado);
            return View(ciudadano);
        }

        // GET: ciudadano1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudadano ciudadano = db.ciudadano.Find(id);
            if (ciudadano == null)
            {
                return HttpNotFound();
            }
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descripcion", ciudadano.idestado);
            return View(ciudadano);
        }

        // POST: ciudadano1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idciudadano,nombres,nacionalidad,tipodocumento,numdocumento,iddepartamento,idprovincia,iddistrito,idestado")] ciudadano ciudadano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudadano).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idestado = new SelectList(db.estado, "idestado", "descripcion", ciudadano.idestado);
            return View(ciudadano);
        }

        // GET: ciudadano1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudadano ciudadano = db.ciudadano.Find(id);
            if (ciudadano == null)
            {
                return HttpNotFound();
            }
            return View(ciudadano);
        }

        // POST: ciudadano1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ciudadano ciudadano = db.ciudadano.Find(id);
            db.ciudadano.Remove(ciudadano);
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

        private int numreg = 10;
        public ActionResult Paginacion(int? pag)
        {
            List<ciudadano> lstCiudadano = db.ciudadano.ToList();
            int cantreg = lstCiudadano.Count;

            ViewBag.numpag = (cantreg % numreg != 0 ? cantreg / numreg + 1 : cantreg / numreg);

            int pagact = (pag == null ? 0 : pag.Value);
            int reginicial = (pagact * numreg);
            int regfinal = (reginicial + numreg);

            List<ciudadano> lstLista = new List<ciudadano>();

            for (int i = reginicial; i < regfinal; i++)
            {
                if (i == cantreg)
                    break;
                lstLista.Add(lstCiudadano[i]);
            }

            return View(lstLista);
        }
    }
}