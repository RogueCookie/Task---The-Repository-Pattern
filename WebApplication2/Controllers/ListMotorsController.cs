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
    public class ListMotorsController : Controller
    {
        private DbTaskEntities db = new DbTaskEntities();

        // GET: ListMotors
        public ActionResult Index()
        {
            return View(db.ListMotors.ToList());
        }

        // GET: ListMotors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListMotor listMotor = db.ListMotors.Find(id);
            if (listMotor == null)
            {
                return HttpNotFound();
            }
            return View(listMotor);
        }

        // GET: ListMotors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListMotors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Motor_Name,Type,Max_power__kW_,Voltage__V_,Current__A_,Fuel_consumtion_per_hour_l_h_,Max_torque_at__rpm_,Max_presure__bar_,Displacement__cm3_rev_")] ListMotor listMotor)
        {
            if (ModelState.IsValid)
            {
                db.ListMotors.Add(listMotor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listMotor);
        }

        // GET: ListMotors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListMotor listMotor = db.ListMotors.Find(id);
            if (listMotor == null)
            {
                return HttpNotFound();
            }
            return View(listMotor);
        }

        // POST: ListMotors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Motor_Name,Type,Max_power__kW_,Voltage__V_,Current__A_,Fuel_consumtion_per_hour_l_h_,Max_torque_at__rpm_,Max_presure__bar_,Displacement__cm3_rev_")] ListMotor listMotor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listMotor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listMotor);
        }

        // GET: ListMotors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListMotor listMotor = db.ListMotors.Find(id);
            if (listMotor == null)
            {
                return HttpNotFound();
            }
            return View(listMotor);
        }

        // POST: ListMotors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListMotor listMotor = db.ListMotors.Find(id);
            db.ListMotors.Remove(listMotor);
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
