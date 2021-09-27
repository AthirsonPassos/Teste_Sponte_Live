using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teste_Sponte_Live;

namespace Teste_Sponte_Live.Controllers
{
    public class InscritosController : Controller
    {
        private MeuBD db = new MeuBD();

        // GET: Inscritos
        public ActionResult Index()
        {
            return View(db.Inscrito.ToList());
        }

        // GET: Inscritos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscrito inscrito = db.Inscrito.Find(id);
            if (inscrito == null)
            {
                return HttpNotFound();
            }
            return View(inscrito);
        }

        // GET: Inscritos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inscritos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Inscrito,nm_Inscrito,dt_Nasci_Inscrito,email_Inscrito,insta_Inscrito")] Inscrito inscrito)
        {
            if (ModelState.IsValid)
            {
                db.Inscrito.Add(inscrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inscrito);
        }

        // GET: Inscritos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscrito inscrito = db.Inscrito.Find(id);
            if (inscrito == null)
            {
                return HttpNotFound();
            }
            return View(inscrito);
        }

        // POST: Inscritos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Inscrito,nm_Inscrito,dt_Nasci_Inscrito,email_Inscrito,insta_Inscrito")] Inscrito inscrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inscrito);
        }

        // GET: Inscritos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscrito inscrito = db.Inscrito.Find(id);
            if (inscrito == null)
            {
                return HttpNotFound();
            }
            return View(inscrito);
        }

        // POST: Inscritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscrito inscrito = db.Inscrito.Find(id);
            db.Inscrito.Remove(inscrito);
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
