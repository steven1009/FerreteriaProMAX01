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
    public class IdDetalleProvProdsController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: IdDetalleProvProds
        public ActionResult Index()
        {
            var idDetalleProvProd = db.IdDetalleProvProd.Include(i => i.CompraProdProv);
            return View(idDetalleProvProd.ToList());
        }

        // GET: IdDetalleProvProds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdDetalleProvProd idDetalleProvProd = db.IdDetalleProvProd.Find(id);
            if (idDetalleProvProd == null)
            {
                return HttpNotFound();
            }
            return View(idDetalleProvProd);
        }

        // GET: IdDetalleProvProds/Create
        public ActionResult Create()
        {
            ViewBag.IdCompraProdProv = new SelectList(db.CompraProdProv, "IdCompraProdProv", "IdCompraProdProv");
            return View();
        }

        // POST: IdDetalleProvProds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleProvProd1,Cantidad,Precio,IdCompraProdProv")] IdDetalleProvProd idDetalleProvProd)
        {
            if (ModelState.IsValid)
            {
                db.IdDetalleProvProd.Add(idDetalleProvProd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCompraProdProv = new SelectList(db.CompraProdProv, "IdCompraProdProv", "IdCompraProdProv", idDetalleProvProd.IdCompraProdProv);
            return View(idDetalleProvProd);
        }

        // GET: IdDetalleProvProds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdDetalleProvProd idDetalleProvProd = db.IdDetalleProvProd.Find(id);
            if (idDetalleProvProd == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCompraProdProv = new SelectList(db.CompraProdProv, "IdCompraProdProv", "IdCompraProdProv", idDetalleProvProd.IdCompraProdProv);
            return View(idDetalleProvProd);
        }

        // POST: IdDetalleProvProds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleProvProd1,Cantidad,Precio,IdCompraProdProv")] IdDetalleProvProd idDetalleProvProd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idDetalleProvProd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCompraProdProv = new SelectList(db.CompraProdProv, "IdCompraProdProv", "IdCompraProdProv", idDetalleProvProd.IdCompraProdProv);
            return View(idDetalleProvProd);
        }

        // GET: IdDetalleProvProds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdDetalleProvProd idDetalleProvProd = db.IdDetalleProvProd.Find(id);
            if (idDetalleProvProd == null)
            {
                return HttpNotFound();
            }
            return View(idDetalleProvProd);
        }

        // POST: IdDetalleProvProds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdDetalleProvProd idDetalleProvProd = db.IdDetalleProvProd.Find(id);
            db.IdDetalleProvProd.Remove(idDetalleProvProd);
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
