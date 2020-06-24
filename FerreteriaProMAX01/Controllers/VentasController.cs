using FerreteriaProMAX01.Models;
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
            //Ventas ventas1 = db.Ventas.Find(m.ObtenerVentaT());
            //if (ventas1 == null)
            //{
            //    ViewBag.idVenta = 1;
            //}
            //else
            //{
            //    ViewBag.idVenta = (int)ventas1.IdVenta + 1;
            //}
            ViewBag.IdEmpleado = Session["idempleado"];
            ViewBag.IdPago = new SelectList(db.TipoPago, "IdPago", "Nombre");
            ViewBag.IdProductoL = new SelectList(db.Producto, "IdProducto", "Nombre");
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
            //Ventas ventas1 = db.Ventas.Find(m.ObtenerVentaT());
            //if (ventas1 == null)
            //{
            //    ViewBag.idVenta = 1;
            //}
            //else
            //{
            //    ViewBag.idVenta = (int)ventas1.IdVenta + 1;
            //}
            ViewBag.IdEmpleado = Session["idempleado"];
            ViewBag.IdPago = new SelectList(db.TipoPago, "IdPago", "Nombre");
            ViewBag.IdProductoL = new SelectList(db.Producto, "IdProducto", "Nombre");
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
                    List<Persona> persona = m.Get0((int)(objCliente.Codigo));
                    return View(persona);
            }
            else if (!objCliente.nombre.ToString().Equals("-1"))
            {
                List<Persona> persona = m.Get1(objCliente.nombre);
                return View(persona);
            }
            else if (!objCliente.Primer_Apellido.ToString().Equals("-1"))
            {
                List<Persona> persona = m.Get3(objCliente.Primer_Apellido);
                return View(persona);
            }
            else if (!objCliente.Cedula.ToString().Equals("-1"))
            {
                List<Persona> persona = m.Get2(objCliente.Cedula);
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
            Producto p = db.Producto.Find(Int32.Parse(idProducto));

            Producto producto = new Producto();
            producto.IdProducto = p.IdProducto;
            producto.Nombre = p.Nombre;
            producto.PrecioU = p.PrecioU;
                //db.Producto.Find(1);
            return Json(producto, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult PruebaJson()
        //{  // escribir la url directa  para ver el formato
        //    List<Producto> lista = objProductoNeg.findAll();
        //    return Json(lista, JsonRequestBehavior.AllowGet);

        //}
        [HttpPost]
        public ActionResult GuardarVenta(DateTime fecha, string Cedula, string idEmpleado, string idPago, string total1,  List<DetalleVenta> ListadoDetalle)
        {
            string mensaje = "";
            decimal iva = 0;
            int idVenta = 0;
            decimal total = 0;

            if (Cedula=="" || idEmpleado == "")
            {
                if (Cedula == "") mensaje = "ERROR CON CEDULA DEL CLIENTE";
                if (idEmpleado == "") mensaje = "ERROR EN EL ID DEL CLIENTE";
            }
            else
            {
                Ventas venta = db.Ventas.Find(m.ObtenerVentaT());
                if (venta == null)
                {
                    idVenta = 1;
                }
                else
                {
                    idVenta = (int) venta.IdVenta + 1;
                }
                //codigoPago = Convert.ToInt32(modoPago);
                Persona persona = db.Persona.Find(m.BuscarCedulaP(Cedula));
                //int
                //if (persona == null) { 
                
                //}
                //int 

                //REGISTRO DE VENTA
                Ventas venta1 = new Ventas();
                venta1.fecha = fecha;
                venta1.idPersona = persona.idPersona;
                venta1.idEmpleado = Int32.Parse(idEmpleado);
                db.Ventas.Add(venta1);
                db.SaveChanges();
                decimal tdescuento = (decimal) 0;
                int indexv = m.ObtenerVentaT();
                foreach (var data in ListadoDetalle)
                {
                    int idProducto = Convert.ToInt32(data.IdProducto.ToString());
                    int cantidad = Convert.ToInt32(data.Cantidad.ToString());
                    decimal descuento = Convert.ToDecimal(data.Descuento.ToString());
                    tdescuento = tdescuento + descuento;
                    decimal subtotal = Convert.ToDecimal(data.SubTOTAL.ToString());
                    iva = subtotal * (decimal) 0.15;
                    total = subtotal - descuento + iva;
                    DetalleVenta detalleVenta= new DetalleVenta();
                    detalleVenta.IdVenta = indexv;
                    detalleVenta.IdProducto = idProducto;
                    detalleVenta.Cantidad = cantidad;
                    detalleVenta.SubTOTAL = subtotal;
                    detalleVenta.Descuento = descuento;
                    detalleVenta.Iva = iva;
                    detalleVenta.Total = total;
                    db.DetalleVenta.Add(detalleVenta);
                    db.SaveChanges();


                }
                Factura factura = new Factura();
                factura.IdPago = 1;
                factura.idVenta = indexv;
                factura.Fecha = fecha;
                factura.Descuento = tdescuento;
                factura.Iva = (Convert.ToDecimal(total1) - tdescuento) * (decimal)0.15;
                factura.Total = (float)(Convert.ToDecimal(total1) + (Convert.ToDecimal(total1) - tdescuento) * (decimal)0.15);

                db.Factura.Add(factura);
                db.SaveChanges();
                mensaje = "VENTA GUARDADA CON EXITO...";
            }
            return Json(mensaje);

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
