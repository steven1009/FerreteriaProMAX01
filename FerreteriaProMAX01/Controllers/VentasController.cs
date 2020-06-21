﻿using FerreteriaProMAX01.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FerreteriaProMAX01.Controllers
{
    public class VentasController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();
        Metodos.Metodos m = new Metodos.Metodos();
        // GET: Ventas
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {
                var ventas = db.Ventas.Include(v => v.Empleado).Include(v => v.Persona);
                return View(ventas.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {

            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Ventas ventas = db.Ventas.Find(id);
                if (ventas == null)
                {
                    return HttpNotFound();
                }
                return View(ventas);
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }


        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "IdEmpleado", "IdEmpleado");
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVenta,fecha,idPersona,idEmpleado")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "IdEmpleado", "IdEmpleado", ventas.idEmpleado);
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula", ventas.idPersona);
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Ventas ventas = db.Ventas.Find(id);
                if (ventas == null)
                {
                    return HttpNotFound();
                }
                ViewBag.idEmpleado = new SelectList(db.Empleado, "IdEmpleado", "IdEmpleado", ventas.idEmpleado);
                ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula", ventas.idPersona);
                return View(ventas);
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }




        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVenta,fecha,idPersona,idEmpleado")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "IdEmpleado", "IdEmpleado", ventas.idEmpleado);
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula", ventas.idPersona);
            return View(ventas);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Ventas ventas = db.Ventas.Find(id);
                if (ventas == null)
                {
                    return HttpNotFound();
                }
                return View(ventas);
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }


        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ventas ventas = db.Ventas.Find(id);
            db.Ventas.Remove(ventas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VentaN()
        {
            ViewBag.IdPago = new SelectList(db.TipoPago, "IdPago", "Nombre");
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VentaN([Bind(Include = "IdVenta,fecha,idPersona,idEmpleado")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPago = new SelectList(db.TipoPago, "IdPago", "Nombre");
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre");
            return View(ventas);
        }
        [HttpGet]
        public ActionResult ObtenerClientes()
        {
            return View(db.Persona.ToList());
        }

        [HttpPost]//para buscar clientes
        public ActionResult ObtenerClientes(string txtnombre, string txtappaterno, string txtdni, string txtcliente)
        {
            if (txtnombre == "")
            {
                txtnombre = "-1";
            }
            if (txtappaterno == "")
            {
                txtappaterno = "-1";
            }
            if (txtdni == "")
            {
                txtdni = "-1";
            }
            if (txtcliente == "")
            {
                txtcliente = "-1";
            }
            Persona objCliente = new Persona();
            objCliente.Codigo = Int32.Parse(txtcliente);
            objCliente.nombre = txtnombre;
            objCliente.Primer_Apellido = txtappaterno;
            objCliente.Cedula = txtdni;

            if (objCliente.Codigo!=-1){
                    List<Persona> persona = m.Get(objCliente.nombre);
                    return View(persona);
            }
            else if (!objCliente.nombre.ToString().Equals("-1"))
            {
                List<Persona> persona = m.Get(objCliente.nombre);
                return View(persona);
            }
            else if (!objCliente.Primer_Apellido.ToString().Equals("-1"))
            {
                List<Persona> persona = m.Get(objCliente.Primer_Apellido);
                return View(persona);
            }
            else if (!objCliente.Cedula.ToString().Equals("-1"))
            {
                List<Persona> persona = m.Get(objCliente.Cedula);
                return View(persona);
            }
            else {
                return View(db.Persona.ToList());
            }
            //List<Persona> persona = db.Persona.Find(objCliente);

        }
        [HttpPost]
        public ActionResult Seleccionar(string idProducto)
        {
            Producto producto = db.Producto.Find(1);
            Console.WriteLine((producto.IdProducto));
            return Json(producto, JsonRequestBehavior.AllowGet);

        }
        //public ActionResult PruebaJson()
        //{  // escribir la url directa  para ver el formato      
        //    List<Producto> lista = objProductoNeg.findAll();
        //    return Json(lista, JsonRequestBehavior.AllowGet);

        //}


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
