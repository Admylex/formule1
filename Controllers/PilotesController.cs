using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet.DAL;
using Projet.Models;

namespace Projet.Controllers
{
    public class PilotesController : Controller
    {
        private F1Context db = new F1Context();

        // GET: Pilotes
        public ViewResult Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;
            var pilotes = from p in db.Pilotes
                         select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                pilotes = pilotes.Where(p => p.Nom.Contains(searchString));
            }
            return View(pilotes.ToList());
        }

        // GET: Pilotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilote pilote = db.Pilotes.Find(id);
            if (pilote == null)
            {
                return HttpNotFound();
            }
            return View(pilote);
        }

        // GET: Pilotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pilotes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PiloteID,Numero,Nom,Prenom,Date_Naissance")] Pilote pilote)
        {
            if (ModelState.IsValid)
            {
                db.Pilotes.Add(pilote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pilote);
        }

        // GET: Pilotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilote pilote = db.Pilotes.Find(id);
            if (pilote == null)
            {
                return HttpNotFound();
            }
            return View(pilote);
        }

        // POST: Pilotes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PiloteID,Numero,Nom,Prenom,Date_Naissance")] Pilote pilote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pilote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pilote);
        }

        // GET: Pilotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilote pilote = db.Pilotes.Find(id);
            if (pilote == null)
            {
                return HttpNotFound();
            }
            return View(pilote);
        }

        // POST: Pilotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pilote pilote = db.Pilotes.Find(id);
            db.Pilotes.Remove(pilote);
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
