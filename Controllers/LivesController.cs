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
    public class LivesController : Controller
    {
        private MeuBD db = new MeuBD();

        // GET: Lives
        public ActionResult Index()
        {
            var live = db.Live.Include(l => l.Instrutor);
            return View(live.ToList());
        }

        // GET: Lives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Live live = db.Live.Find(id);
            if (live == null)
            {
                return HttpNotFound();
            }
            return View(live);
        }

        // GET: Lives/Create
        public ActionResult Create()
        {
            ViewBag.Id_Instrutor = new SelectList(db.Instrutor, "Id_Instrutor", "nm_Instrutores");
            return View();
        }

        // POST: Lives/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Live,nm_Live,Id_Instrutor,dt_Live,hr_Live,ds_tempo_Live,vl_Live")] Live live)
        {
            if (ModelState.IsValid)
            {
                db.Live.Add(live);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Instrutor = new SelectList(db.Instrutor, "Id_Instrutor", "nm_Instrutores", live.Id_Instrutor);
            return View(live);
        }

        // GET: Lives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Live live = db.Live.Find(id);
            if (live == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Instrutor = new SelectList(db.Instrutor, "Id_Instrutor", "nm_Instrutores", live.Id_Instrutor);
            return View(live);
        }

        // POST: Lives/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Live,nm_Live,Id_Instrutor,dt_Live,hr_Live,ds_tempo_Live,vl_Live")] Live live)
        {
            if (ModelState.IsValid)
            {
                db.Entry(live).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Instrutor = new SelectList(db.Instrutor, "Id_Instrutor", "nm_Instrutores", live.Id_Instrutor);
            return View(live);
        }

        // GET: Lives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Live live = db.Live.Find(id);
            if (live == null)
            {
                return HttpNotFound();
            }
            return View(live);
        }

        // POST: Lives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Live live = db.Live.Find(id);
            db.Live.Remove(live);
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
