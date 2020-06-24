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
    public class DetalleEstadoUsuariosController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: DetalleEstadoUsuarios
        public ActionResult Index()
        {
            var detalleEstadoUsuario = db.DetalleEstadoUsuario.Include(d => d.Estado).Include(d => d.USUARIO_LOGIN);
            return View(detalleEstadoUsuario.ToList());
        }

        // GET: DetalleEstadoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleEstadoUsuario detalleEstadoUsuario = db.DetalleEstadoUsuario.Find(id);
            if (detalleEstadoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(detalleEstadoUsuario);
        }

        // GET: DetalleEstadoUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "Estado1");
            ViewBag.idUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario");
            return View();
        }

        // POST: DetalleEstadoUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleEstadoUsuario,IdEstado,FechaInicio,FechaFIN,idUsuario")] DetalleEstadoUsuario detalleEstadoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.DetalleEstadoUsuario.Add(detalleEstadoUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "Estado1", detalleEstadoUsuario.IdEstado);
            ViewBag.idUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario", detalleEstadoUsuario.idUsuario);
            return View(detalleEstadoUsuario);
        }

        // GET: DetalleEstadoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleEstadoUsuario detalleEstadoUsuario = db.DetalleEstadoUsuario.Find(id);
            if (detalleEstadoUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "Estado1", detalleEstadoUsuario.IdEstado);
            ViewBag.idUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario", detalleEstadoUsuario.idUsuario);
            return View(detalleEstadoUsuario);
        }

        // POST: DetalleEstadoUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleEstadoUsuario,IdEstado,FechaInicio,FechaFIN,idUsuario")] DetalleEstadoUsuario detalleEstadoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleEstadoUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "Estado1", detalleEstadoUsuario.IdEstado);
            ViewBag.idUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario", detalleEstadoUsuario.idUsuario);
            return View(detalleEstadoUsuario);
        }

        // GET: DetalleEstadoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleEstadoUsuario detalleEstadoUsuario = db.DetalleEstadoUsuario.Find(id);
            if (detalleEstadoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(detalleEstadoUsuario);
        }

        // POST: DetalleEstadoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleEstadoUsuario detalleEstadoUsuario = db.DetalleEstadoUsuario.Find(id);
            db.DetalleEstadoUsuario.Remove(detalleEstadoUsuario);
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
