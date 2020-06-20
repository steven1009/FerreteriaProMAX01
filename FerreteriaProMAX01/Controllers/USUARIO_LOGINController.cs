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
    public class USUARIO_LOGINController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: USUARIO_LOGIN
        public ActionResult Index()
        {
            var uSUARIO_LOGIN = db.USUARIO_LOGIN.Include(u => u.Persona);
            return View(uSUARIO_LOGIN.ToList());
        }

        // GET: USUARIO_LOGIN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            if (uSUARIO_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO_LOGIN);
        }

        // GET: USUARIO_LOGIN/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula");
            return View();
        }

        // POST: USUARIO_LOGIN/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Usuario,Contraseña,idPersona")] USUARIO_LOGIN uSUARIO_LOGIN)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO_LOGIN.Add(uSUARIO_LOGIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            return View(uSUARIO_LOGIN);
        }

        // GET: USUARIO_LOGIN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            if (uSUARIO_LOGIN == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            return View(uSUARIO_LOGIN);
        }

        // POST: USUARIO_LOGIN/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Usuario,Contraseña,idPersona")] USUARIO_LOGIN uSUARIO_LOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO_LOGIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            return View(uSUARIO_LOGIN);
        }

        // GET: USUARIO_LOGIN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            if (uSUARIO_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO_LOGIN);
        }

        // POST: USUARIO_LOGIN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            db.USUARIO_LOGIN.Remove(uSUARIO_LOGIN);
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
