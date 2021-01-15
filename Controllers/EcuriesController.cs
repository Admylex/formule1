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
    public class EcuriesController : Controller
    {
        private F1Context db = new F1Context();

        // GET: Ecuries
        public ViewResult Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;
            var ecuries = from e in db.Ecuries
                           select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                ecuries = ecuries.Where(e => e.Nom_e.Contains(searchString));
            }
            return View(ecuries.ToList());
        }

        // GET: Ecuries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecurie ecurie = db.Ecuries.Find(id);
            if (ecurie == null)
            {
                return HttpNotFound();
            }
            return View(ecurie);
        }

        // GET: Ecuries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ecuries/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EcurieID,Nom_e,Nationalite_e")] Ecurie ecurie)
        {
            if (ModelState.IsValid)
            {
                db.Ecuries.Add(ecurie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ecurie);
        }

        // GET: Ecuries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecurie ecurie = db.Ecuries.Find(id);
            if (ecurie == null)
            {
                return HttpNotFound();
            }
            return View(ecurie);
        }

        // POST: Ecuries/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EcurieID,Nom_e,Nationalite_e")] Ecurie ecurie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecurie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ecurie);
        }

        // GET: Ecuries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecurie ecurie = db.Ecuries.Find(id);
            if (ecurie == null)
            {
                return HttpNotFound();
            }
            return View(ecurie);
        }

        // POST: Ecuries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ecurie ecurie = db.Ecuries.Find(id);
            db.Ecuries.Remove(ecurie);
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
