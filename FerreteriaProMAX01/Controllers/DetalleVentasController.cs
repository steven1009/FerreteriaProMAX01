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
    public class DetalleVentasController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();
        Metodos.Metodos m = new Metodos.Metodos();
        // GET: DetalleVentas
        public ActionResult Index()
        {
            var detalleVenta = db.DetalleVenta.Include(d => d.Producto).Include(d => d.Ventas);
            return View(detalleVenta.ToList());
        }

        // GET: DetalleVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }
        public ActionResult DetailsVentas(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta1 = new DetalleVenta();
            detalleVenta1.IdVenta =id;


            List<DetalleVenta> detalleVenta = m.Get4((int)detalleVenta1.IdVenta);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Create
        public ActionResult Create()
        {
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre");
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta");
            return View();
        }

        // POST: DetalleVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleV,IdVenta,IdProducto,Cantidad,SubTOTAL,Descuento,Iva,Total")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.DetalleVenta.Add(detalleVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", detalleVenta.IdProducto);
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", detalleVenta.IdVenta);
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", detalleVenta.IdProducto);
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", detalleVenta.IdVenta);
            return View(detalleVenta);
        }

        // POST: DetalleVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleV,IdVenta,IdProducto,Cantidad,SubTOTAL,Descuento,Iva,Total")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", detalleVenta.IdProducto);
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", detalleVenta.IdVenta);
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // POST: DetalleVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleVenta detalleVenta = db.DetalleVenta.Find(id);
            db.DetalleVenta.Remove(detalleVenta);
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
