using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MotorApp.BuisnessLogic;
using MotorApp.DataAccess;

namespace MotorApp.WebClient.Controllers
{
    public class MotorsController : Controller
    {
        private MotorRepository db = new MotorRepository();

        // GET: Motors
        public ActionResult Index()
        {
            return View(db.GetMotors());
        }

        // GET: Motors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motor motor = db.FindById(Convert.ToInt32(id));
            if (motor == null)
            {
                return HttpNotFound();
            }
            return View(motor);
        }

        // GET: Motors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TimeStamp,MotorName,Current,DifferenceC,Revs,DifferenceR,Pressure,DifferenceP")] Motor motor)
        {
            if (ModelState.IsValid)
            {
                db.Motors.Add(motor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motor);
        }

        // GET: Motors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motor motor = db.Motors.Find(id);
            if (motor == null)
            {
                return HttpNotFound();
            }
            return View(motor);
        }

        // POST: Motors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TimeStamp,MotorName,Current,DifferenceC,Revs,DifferenceR,Pressure,DifferenceP")] Motor motor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motor);
        }

        // GET: Motors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motor motor = db.Motors.Find(id);
            if (motor == null)
            {
                return HttpNotFound();
            }
            return View(motor);
        }

        // POST: Motors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motor motor = db.Motors.Find(id);
            db.Motors.Remove(motor);
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
