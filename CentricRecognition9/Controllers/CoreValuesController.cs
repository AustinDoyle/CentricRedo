using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentricRecognition9.DAL;
using CentricRecognition9.Models;

namespace CentricRecognition9.Controllers
{
    public class CoreValuesController : Controller
    {
        private Context db = new Context();

        // GET: CoreValues
        public ActionResult Index()
        {
            return View(db.CoreValues.ToList());
        }

        // GET: CoreValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValue coreValue = db.CoreValues.Find(id);
            if (coreValue == null)
            {
                return HttpNotFound();
            }
            return View(coreValue);
        }

        // GET: CoreValues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoreValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoreValueID,CoreValueName,CoreValueDescription")] CoreValue coreValue)
        {
            if (ModelState.IsValid)
            {
                db.CoreValues.Add(coreValue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coreValue);
        }

        // GET: CoreValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValue coreValue = db.CoreValues.Find(id);
            if (coreValue == null)
            {
                return HttpNotFound();
            }
            return View(coreValue);
        }

        // POST: CoreValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoreValueID,CoreValueName,CoreValueDescription")] CoreValue coreValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coreValue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coreValue);
        }

        // GET: CoreValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValue coreValue = db.CoreValues.Find(id);
            if (coreValue == null)
            {
                return HttpNotFound();
            }
            return View(coreValue);
        }

        // POST: CoreValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoreValue coreValue = db.CoreValues.Find(id);
            db.CoreValues.Remove(coreValue);
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
