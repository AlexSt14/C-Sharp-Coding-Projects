using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurances.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                db.Insurances.Add(insurance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insurance);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insurance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insurance);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insurance insurance = db.Insurances.Find(id);
            db.Insurances.Remove(insurance);
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

        public ActionResult CalculateQuote(int Id)
        {
            var userDetails = db.Insurances.Find(Id);
            int basePrice = 50;
            int age = DateTime.Now.Year - userDetails.DateOfBirth.Year;
            decimal insurancePrice = 0;
            if (age < 19)
            {
                insurancePrice = basePrice + 100;
            }
            else if (age > 18 && age < 25)
            {
                insurancePrice = basePrice + 50;
            }
            else if (age > 25)
            {
                insurancePrice = basePrice + 25;

            }
            if (userDetails.CarYear < 2000)
            {
                insurancePrice += 25;
            }
            else if (userDetails.CarYear > 2015)
            {
                insurancePrice += 25;
            }
            if (userDetails.CarMake == "Porche" || userDetails.CarMake == "porche")
            {
                insurancePrice += 25;
                if (userDetails.CarModel == "911 Carrera" || userDetails.CarModel == "911 carrera")
                {
                    insurancePrice += 25;
                }
            }
            if (userDetails.DUI == true)
            {
                insurancePrice *= 1.25m;
            }
            if (userDetails.CoverageType == true)
            {
                insurancePrice *= 1.5m;
            }
            for (int i = 0; i < userDetails.SpeedingTickets; i++)
            {
                insurancePrice += 10;
            }
            userDetails.Quote = insurancePrice;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

