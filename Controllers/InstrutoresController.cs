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
    public class InstrutoresController : Controller
    {
        private MeuBD db = new MeuBD();

        // GET: Instrutores
        public ActionResult Index()
        {
            return View(db.Instrutor.ToList());
        }

        // GET: Instrutores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrutor instrutor = db.Instrutor.Find(id);
            if (instrutor == null)
            {
                return HttpNotFound();
            }
            return View(instrutor);
        }

        // GET: Instrutores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instrutores/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Instrutor,nm_Instrutores,dt_Nasci_Instrutores,email_Instrutores,insta_Instrutores")] Instrutor instrutor)
        {
            if (ModelState.IsValid)
            {
                db.Instrutor.Add(instrutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instrutor);
        }

        // GET: Instrutores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrutor instrutor = db.Instrutor.Find(id);
            if (instrutor == null)
            {
                return HttpNotFound();
            }
            return View(instrutor);
        }

        // POST: Instrutores/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Instrutor,nm_Instrutores,dt_Nasci_Instrutores,email_Instrutores,insta_Instrutores")] Instrutor instrutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instrutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instrutor);
        }

        // GET: Instrutores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrutor instrutor = db.Instrutor.Find(id);
            if (instrutor == null)
            {
                return HttpNotFound();
            }
            return View(instrutor);
        }

        // POST: Instrutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instrutor instrutor = db.Instrutor.Find(id);
            db.Instrutor.Remove(instrutor);
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
