﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FerreteriaProMAX01.Models;

namespace FerreteriaProMAX01.Controllers
{
    public class Empleadoes1Controller : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: Empleadoes1
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.Cargo).Include(e => e.Persona);
            return View(empleado.ToList());
        }

        // GET: Empleadoes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes1/Create
        public ActionResult Create()
        {
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Nombre_cargo");
            ViewBag.IdPersona = new SelectList(db.Persona, "idPersona", "Cedula");
            return View();
        }

        // POST: Empleadoes1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,IdCargo,IdPersona")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Nombre_cargo", empleado.IdCargo);
            ViewBag.IdPersona = new SelectList(db.Persona, "idPersona", "Cedula", empleado.IdPersona);
            return View(empleado);
        }

        // GET: Empleadoes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Nombre_cargo", empleado.IdCargo);
            ViewBag.IdPersona = new SelectList(db.Persona, "idPersona", "Cedula", empleado.IdPersona);
            return View(empleado);
        }

        // POST: Empleadoes1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,IdCargo,IdPersona")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCargo = new SelectList(db.Cargo, "IdCargo", "Nombre_cargo", empleado.IdCargo);
            ViewBag.IdPersona = new SelectList(db.Persona, "idPersona", "Cedula", empleado.IdPersona);
            return View(empleado);
        }

        // GET: Empleadoes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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
