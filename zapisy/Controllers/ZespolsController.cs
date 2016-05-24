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
    public class ZespolsController : Controller
    {
        private ZapisyContext db = new ZapisyContext();

        // GET: Zespols
        public ActionResult Index()
        {
            return View(db.Zespoly.ToList());
        }

        // GET: Zespols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zespol zespol = db.Zespoly.Find(id);
            if (zespol == null)
            {
                return HttpNotFound();
            }
            return View(zespol);
        }

        // GET: Zespols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zespols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZespolID,nazwa")] Zespol zespol)
        {
            if (ModelState.IsValid)
            {
                db.Zespoly.Add(zespol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zespol);
        }

        // GET: Zespols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zespol zespol = db.Zespoly.Find(id);
            if (zespol == null)
            {
                return HttpNotFound();
            }
            return View(zespol);
        }

        // POST: Zespols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZespolID,nazwa")] Zespol zespol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zespol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zespol);
        }

        // GET: Zespols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zespol zespol = db.Zespoly.Find(id);
            if (zespol == null)
            {
                return HttpNotFound();
            }
            return View(zespol);
        }

        // POST: Zespols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zespol zespol = db.Zespoly.Find(id);
            db.Zespoly.Remove(zespol);
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
