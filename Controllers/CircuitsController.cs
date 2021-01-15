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
    public class CircuitsController : Controller
    {
        private F1Context db = new F1Context();

        // GET: Circuits
        public ViewResult Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;
            var circuits = from c in db.Circuits
                          select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                circuits = circuits.Where(p => p.Pays.Contains(searchString));
            }
            return View(circuits.ToList());
        }

        // GET: Circuits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuit circuit = db.Circuits.Find(id);
            if (circuit == null)
            {
                return HttpNotFound();
            }
            return View(circuit);
        }

        // GET: Circuits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Circuits/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CircuitID,Nom_c,Ville,Pays")] Circuit circuit)
        {
            if (ModelState.IsValid)
            {
                db.Circuits.Add(circuit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(circuit);
        }

        // GET: Circuits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuit circuit = db.Circuits.Find(id);
            if (circuit == null)
            {
                return HttpNotFound();
            }
            return View(circuit);
        }

        // POST: Circuits/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CircuitID,Nom_c,Ville,Pays")] Circuit circuit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(circuit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(circuit);
        }

        // GET: Circuits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuit circuit = db.Circuits.Find(id);
            if (circuit == null)
            {
                return HttpNotFound();
            }
            return View(circuit);
        }

        // POST: Circuits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Circuit circuit = db.Circuits.Find(id);
            db.Circuits.Remove(circuit);
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
