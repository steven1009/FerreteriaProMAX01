using System;
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
    public class DetalleRolesController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: DetalleRoles
        public ActionResult Index()
        {
            var detalleRoles = db.DetalleRoles.Include(d => d.USUARIO_LOGIN).Include(d => d.Roles);
            return View(detalleRoles.ToList());
        }

        // GET: DetalleRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleRoles detalleRoles = db.DetalleRoles.Find(id);
            if (detalleRoles == null)
            {
                return HttpNotFound();
            }
            return View(detalleRoles);
        }

        // GET: DetalleRoles/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario");
            ViewBag.IdRoles = new SelectList(db.Roles, "IdRoles", "Nombre");
            return View();
        }

        // POST: DetalleRoles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_DetalleRoles,IdUsuario,FechaMOD,IdRoles")] DetalleRoles detalleRoles)
        {
            if (ModelState.IsValid)
            {
                db.DetalleRoles.Add(detalleRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario", detalleRoles.IdUsuario);
            ViewBag.IdRoles = new SelectList(db.Roles, "IdRoles", "Nombre", detalleRoles.IdRoles);
            return View(detalleRoles);
        }

        // GET: DetalleRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleRoles detalleRoles = db.DetalleRoles.Find(id);
            if (detalleRoles == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario", detalleRoles.IdUsuario);
            ViewBag.IdRoles = new SelectList(db.Roles, "IdRoles", "Nombre", detalleRoles.IdRoles);
            return View(detalleRoles);
        }

        // POST: DetalleRoles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_DetalleRoles,IdUsuario,FechaMOD,IdRoles")] DetalleRoles detalleRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario", detalleRoles.IdUsuario);
            ViewBag.IdRoles = new SelectList(db.Roles, "IdRoles", "Nombre", detalleRoles.IdRoles);
            return View(detalleRoles);
        }

        // GET: DetalleRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleRoles detalleRoles = db.DetalleRoles.Find(id);
            if (detalleRoles == null)
            {
                return HttpNotFound();
            }
            return View(detalleRoles);
        }

        // POST: DetalleRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleRoles detalleRoles = db.DetalleRoles.Find(id);
            db.DetalleRoles.Remove(detalleRoles);
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
