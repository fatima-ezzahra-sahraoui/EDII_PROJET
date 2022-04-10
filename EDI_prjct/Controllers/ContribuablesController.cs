using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EDI_prjct.Models;

namespace EDI_prjct.Controllers
{
    public class ContribuablesController : Controller
    {
        private RDbContext db = new RDbContext();

        // GET: Contribuables
        public ActionResult Index()
        {
            return View(db.Contribuables.ToList());
        }

        // GET: Contribuables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribuable contribuable = db.Contribuables.Find(id);
            if (contribuable == null)
            {
                return HttpNotFound();
            }
            return View(contribuable);
        }

        // GET: Contribuables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contribuables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Code_contibuable,FirstName,LastName,Email,UserName,Password,ConfirmPassword")] Contribuable contribuable)
        {
            if (ModelState.IsValid)
            {
                db.Contribuables.Add(contribuable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contribuable);
        }

        // GET: Contribuables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribuable contribuable = db.Contribuables.Find(id);
            if (contribuable == null)
            {
                return HttpNotFound();
            }
            return View(contribuable);
        }

        // POST: Contribuables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Code_contibuable,FirstName,LastName,Email,UserName,Password,ConfirmPassword")] Contribuable contribuable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contribuable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contribuable);
        }

        // GET: Contribuables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contribuable contribuable = db.Contribuables.Find(id);
            if (contribuable == null)
            {
                return HttpNotFound();
            }
            return View(contribuable);
        }

        // POST: Contribuables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contribuable contribuable = db.Contribuables.Find(id);
            db.Contribuables.Remove(contribuable);
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
