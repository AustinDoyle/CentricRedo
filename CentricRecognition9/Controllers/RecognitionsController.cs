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
    public class RecognitionsController : Controller
    {
        private Context db = new Context();

        // GET: Recognitions
        public ActionResult Index()
        {
            var recognitions = db.Recognitions.Include(r => r.CoreValue).Include(r => r.Employee);
            return View(recognitions.ToList());
        }

        // GET: Recognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // GET: Recognitions/Create
        public ActionResult Create()
        {
            ViewBag.CoreValueID = new SelectList(db.CoreValues, "CoreValueID", "CoreValueName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "fullName");
            return View();
        }

        // POST: Recognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecognitionID,description,EmployeeID,CoreValueID")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Recognitions.Add(recognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoreValueID = new SelectList(db.CoreValues, "CoreValueID", "CoreValueName", recognition.CoreValueID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "fullName", recognition.EmployeeID);
            return View(recognition);
        }

        // GET: Recognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoreValueID = new SelectList(db.CoreValues, "CoreValueID", "CoreValueName", recognition.CoreValueID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "fullName", recognition.EmployeeID);
            return View(recognition);
        }

        // POST: Recognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecognitionID,description,EmployeeID,CoreValueID")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoreValueID = new SelectList(db.CoreValues, "CoreValueID", "CoreValueName", recognition.CoreValueID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "fullName", recognition.EmployeeID);
            return View(recognition);
        }

        // GET: Recognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // POST: Recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recognition recognition = db.Recognitions.Find(id);
            db.Recognitions.Remove(recognition);
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
