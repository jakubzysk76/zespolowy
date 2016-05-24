using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using zapisy.DAL;
using zapisy.Models;

namespace zapisy.Controllers
{
    public class StudentsController : Controller
    {
        private ZapisyContext db = new ZapisyContext();

        // GET: Students
        public ActionResult Index()
        {
            var studenci = db.Studenci.Include(s => s.Zespol);
            return View(studenci.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Studenci.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.ZespolID = new SelectList(db.Zespoly, "ZespolID", "nazwa");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,ZespolID,Imie,Nazwisko,nr_indeksu,email")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Studenci.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ZespolID = new SelectList(db.Zespoly, "ZespolID", "nazwa", student.ZespolID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Studenci.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZespolID = new SelectList(db.Zespoly, "ZespolID", "nazwa", student.ZespolID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,ZespolID,Imie,Nazwisko,nr_indeksu,email")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZespolID = new SelectList(db.Zespoly, "ZespolID", "nazwa", student.ZespolID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Studenci.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Studenci.Find(id);
            db.Studenci.Remove(student);
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
