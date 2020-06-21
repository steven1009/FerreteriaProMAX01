using FerreteriaProMAX01.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FerreteriaProMAX01.Controllers
{
    public class PersonasController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: Personas
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {


                return View(db.Persona.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }

        // GET: Personas/Details/5
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
                Persona persona = db.Persona.Find(id);
                if (persona == null)
                {
                    return HttpNotFound();
                }
                return View(persona);

            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }




        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPersona,Codigo,Cedula,nombre,Primer_Apellido,Segund_Apellido,Fecha_nacimiento,Telefono,Correo,Sexo,Direccion")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: Personas/Edit/5
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
                Persona persona = db.Persona.Find(id);
                if (persona == null)
                {
                    return HttpNotFound();
                }
                return View(persona);

            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }



        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPersona,Codigo,Cedula,nombre,Primer_Apellido,Segund_Apellido,Fecha_nacimiento,Telefono,Correo,Sexo,Direccion")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
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
                Persona persona = db.Persona.Find(id);
                if (persona == null)
                {
                    return HttpNotFound();
                }
                return View(persona);

            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }




        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
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
