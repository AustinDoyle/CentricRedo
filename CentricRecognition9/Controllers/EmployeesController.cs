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
using Microsoft.AspNet.Identity;
using System.IO;

namespace CentricRecognition9.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private Context db = new Context();

        // GET: Employees
        public ActionResult Index(string EmployeesSearchString)
        {
            var employeesearch = from u in db.employees select u;
            if (!String.IsNullOrEmpty(EmployeesSearchString))
            {
                employeesearch = employeesearch.Where(u => u.LastName.Contains(EmployeesSearchString) || u.FirstName.Contains(EmployeesSearchString));
                // if here, employees were found so view them
                return View(employeesearch.ToList());
            }
            return View(db.employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UID,FirstName,LastName,BusinessUnit,PersonalEmail,MobilePhone,Linkedin,EmploymentStatus,Skills,StartDate,School,PreviousJob,PersonalImage")] Employee Employee)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                Employee.UID = memberID;
                HttpPostedFileBase file = Request.Files["PersonalImage"];
                Employee.UID = memberID;

                if (file != null && file.FileName != null && file.FileName != "")
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    if (fi.Extension != ".jpeg" && fi.Extension != ".jpg" && fi.Extension != "gif")
                    {
                        TempData["Errormsg"] = "Image File Extension is not valid";
                        return View(Employee);
                    }
                    else
                    {
                        Employee.PersonalImage = Employee.UID + fi.Extension;

                        file.SaveAs(Server.MapPath("~/Content/EmployeeImages/" + Employee.UID + fi.Extension));
                    }
                }


                db.employees.Add(Employee);
                db.SaveChanges();
                return RedirectToAction("Index", "Employees");
            }

            return View(Employee);
        }


        // GET: Employees/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee Employee = db.employees.Find(id);
            if (Employee == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (Employee.UID == memberID)
            {
                return View(Employee);
            }
            else
            {
                return View("NotAuthenticated");
            }
            

            
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,FirstName,LastName,BusinessUnit,PersonalEmail,MobilePhone,Linkedin,EmploymentStatus,Skills,StartDate,School,PreviousJob,PersonalImage")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                HttpPostedFileBase file = Request.Files["PersonalImage"];
                if (file != null && file.FileName != null && file.FileName != "")
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    if (fi.Extension != ".jpeg" && fi.Extension != ".jpg" && fi.Extension != "gif")
                    {
                        TempData["Errormsg"] = "Image File Extension is not valid";
                        return View(employee);
                    }
                    else
                    {
                        Employee employeeOld = db.employees.Find(employee.UID);
                        string imageName = employeeOld.PersonalImage;
                        string path = Server.MapPath("~/Content/EmployeeImages/" + imageName);
                        try
                        {
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }
                            else
                            {

                            }
                        }
                        catch (Exception)
                        {


                        }
                        employee.PersonalImage = employee.UID + fi.Extension;
                        file.SaveAs(Server.MapPath("~/Content/EmployeeImages/" + employee.UID + fi.Extension));
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        // GET: Employees/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.employees.Find(id);
            string imageName = employee.PersonalImage;
            string path = Server.MapPath("~/Content/EmployeeImages/" + imageName);

            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                else
                {

                }
            }
            catch (Exception)
            {

            }
            db.employees.Remove(employee);
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

        public ActionResult NotAuthenticated()
        {
            return View();
        }
    }

}
