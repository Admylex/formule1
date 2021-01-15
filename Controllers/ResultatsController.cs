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
    public class ResultatsController : Controller
    {
        private F1Context db = new F1Context();

        // GET: Resultats
        public ActionResult Index(int? id)
        {
            return View(db.Resultats.Where(r=>r.CircuitID ==id).ToList());
        }

        // GET: Resultats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultat resultat = db.Resultats.Find(id);
            if (resultat == null)
            {
                return HttpNotFound();
            }
            return View(resultat);
        }

        // GET: Resultats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resultats/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResultatID,PiloteID,CircuitID,Position,MT")] Resultat resultat)
        {
            if (ModelState.IsValid)
            {
                db.Resultats.Add(resultat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resultat);
        }

        // GET: Resultats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultat resultat = db.Resultats.Find(id);
            if (resultat == null)
            {
                return HttpNotFound();
            }
            return View(resultat);
        }

        // POST: Resultats/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResultatID,PiloteID,CircuitID,Position,MT")] Resultat resultat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resultat);
        }

        // GET: Resultats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultat resultat = db.Resultats.Find(id);
            if (resultat == null)
            {
                return HttpNotFound();
            }
            return View(resultat);
        }

        // POST: Resultats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resultat resultat = db.Resultats.Find(id);
            db.Resultats.Remove(resultat);
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
