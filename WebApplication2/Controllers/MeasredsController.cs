using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MeasredsController : Controller
    {
        private DbTaskEntities db = new DbTaskEntities();

        // GET: Measreds
        public ActionResult Index()
        {
            var measreds = db.Measreds.Include(m => m.ListMotor);
            return View(measreds.ToList());
        }

        // GET: Measreds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measred measred = db.Measreds.Find(id);
            if (measred == null)
            {
                return HttpNotFound();
            }
            return View(measred);
        }

        // GET: Measreds/Create
        public ActionResult Create()
        {
            ViewBag.MotorsId = new SelectList(db.ListMotors, "Id", "Motor_Name");
            return View();
        }

        // POST: Measreds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Time_of_measurement,Actual_current__A_,Actual_revs___rpm_,Actual_pressure__bar_,MotorsId")] Measred measred)
        {
            if (ModelState.IsValid)
            {
                db.Measreds.Add(measred);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MotorsId = new SelectList(db.ListMotors, "Id", "Motor_Name", measred.MotorsId);
            return View(measred);
        }

        // GET: Measreds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measred measred = db.Measreds.Find(id);
            if (measred == null)
            {
                return HttpNotFound();
            }
            ViewBag.MotorsId = new SelectList(db.ListMotors, "Id", "Motor_Name", measred.MotorsId);
            return View(measred);
        }

        // POST: Measreds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Time_of_measurement,Actual_current__A_,Actual_revs___rpm_,Actual_pressure__bar_,MotorsId")] Measred measred)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measred).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MotorsId = new SelectList(db.ListMotors, "Id", "Motor_Name", measred.MotorsId);
            return View(measred);
        }

        // GET: Measreds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measred measred = db.Measreds.Find(id);
            if (measred == null)
            {
                return HttpNotFound();
            }
            return View(measred);
        }

        // POST: Measreds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measred measred = db.Measreds.Find(id);
            db.Measreds.Remove(measred);
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
