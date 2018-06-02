﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppGestionEMS.Models;

namespace AppGestionEMS.Controllers
{
    [Authorize(Roles = "administrador")]
    public class GrupoClasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GrupoClases
        public ActionResult Index()
        {
            return View(db.GrupoClases.ToList());
        }

        // GET: GrupoClases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoClases grupoClases = db.GrupoClases.Find(id);
            if (grupoClases == null)
            {
                return HttpNotFound();
            }
            return View(grupoClases);
        }

        // GET: GrupoClases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoClases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,numAlumnos,turno")] GrupoClases grupoClases)
        {
            if (ModelState.IsValid)
            {
                db.GrupoClases.Add(grupoClases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoClases);
        }

        // GET: GrupoClases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoClases grupoClases = db.GrupoClases.Find(id);
            if (grupoClases == null)
            {
                return HttpNotFound();
            }
            return View(grupoClases);
        }

        // POST: GrupoClases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,numAlumnos,turno")] GrupoClases grupoClases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoClases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoClases);
        }

        // GET: GrupoClases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoClases grupoClases = db.GrupoClases.Find(id);
            if (grupoClases == null)
            {
                return HttpNotFound();
            }
            return View(grupoClases);
        }

        // POST: GrupoClases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoClases grupoClases = db.GrupoClases.Find(id);
            db.GrupoClases.Remove(grupoClases);
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