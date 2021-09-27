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
    public class InscricoesController : Controller
    {
        private MeuBD db = new MeuBD();

        // GET: Inscricoes
        public ActionResult Index()
        {
            var inscricao = db.Inscricao.Include(i => i.Inscrito).Include(i => i.Live);
            return View(inscricao.ToList());
        }

        // GET: Inscricoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricao.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }
        
        // GET: Inscricoes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Inscrito = new SelectList(db.Inscrito, "Id_Inscrito", "nm_Inscrito");
            ViewBag.Id_Live = new SelectList(db.Live, "Id_Live", "nm_Live");
            return View();
        }

        // POST: Inscricoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Inscricao,Id_Live,Id_Inscrito,vl_Inscricao,dt_Vencimento,status_Pag")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                db.Inscricao.Add(inscricao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Inscrito = new SelectList(db.Inscrito, "Id_Inscrito", "nm_Inscrito", inscricao.Id_Inscrito);
            ViewBag.Id_Live = new SelectList(db.Live, "Id_Live", "nm_Live", inscricao.Id_Live);
            return View(inscricao);
        }

        // GET: Inscricoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricao.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Inscrito = new SelectList(db.Inscrito, "Id_Inscrito", "nm_Inscrito", inscricao.Id_Inscrito);
            ViewBag.Id_Live = new SelectList(db.Live, "Id_Live", "nm_Live", inscricao.Id_Live);
            return View(inscricao);
        }

        // POST: Inscricoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Inscricao,Id_Live,Id_Inscrito,vl_Inscricao,dt_Vencimento,status_Pag")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscricao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Inscrito = new SelectList(db.Inscrito, "Id_Inscrito", "nm_Inscrito", inscricao.Id_Inscrito);
            ViewBag.Id_Live = new SelectList(db.Live, "Id_Live", "nm_Live", inscricao.Id_Live);
            return View(inscricao);
        }

        // GET: Inscricoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricao.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // POST: Inscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscricao inscricao = db.Inscricao.Find(id);
            db.Inscricao.Remove(inscricao);
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
