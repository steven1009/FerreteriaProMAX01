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
    public class CompraProdProvsController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: CompraProdProvs
        public ActionResult Index()
        {
            var compraProdProv = db.CompraProdProv.Include(c => c.Producto).Include(c => c.proveedores);
            return View(compraProdProv.ToList());
        }

        // GET: CompraProdProvs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraProdProv compraProdProv = db.CompraProdProv.Find(id);
            if (compraProdProv == null)
            {
                return HttpNotFound();
            }
            return View(compraProdProv);
        }

        // GET: CompraProdProvs/Create
        public ActionResult Create()
        {
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre");
            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre");
            return View();
        }

        // POST: CompraProdProvs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompraProdProv,Fecha,IdProveedores,IdProducto")] CompraProdProv compraProdProv)
        {
            if (ModelState.IsValid)
            {
                db.CompraProdProv.Add(compraProdProv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", compraProdProv.IdProducto);
            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre", compraProdProv.IdProveedores);
            return View(compraProdProv);
        }

        // GET: CompraProdProvs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraProdProv compraProdProv = db.CompraProdProv.Find(id);
            if (compraProdProv == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", compraProdProv.IdProducto);
            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre", compraProdProv.IdProveedores);
            return View(compraProdProv);
        }

        // POST: CompraProdProvs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompraProdProv,Fecha,IdProveedores,IdProducto")] CompraProdProv compraProdProv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compraProdProv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", compraProdProv.IdProducto);
            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre", compraProdProv.IdProveedores);
            return View(compraProdProv);
        }

        // GET: CompraProdProvs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraProdProv compraProdProv = db.CompraProdProv.Find(id);
            if (compraProdProv == null)
            {
                return HttpNotFound();
            }
            return View(compraProdProv);
        }

        // POST: CompraProdProvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompraProdProv compraProdProv = db.CompraProdProv.Find(id);
            db.CompraProdProv.Remove(compraProdProv);
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
