using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMCars.Models;
using PagedList;

namespace CRMCars.Controllers
{
    public class CarsController : Controller
    {
        private Context db = new Context();

        // Search 

        public ActionResult Search(string option, string search , int? pageNumber)
        {

            //if a user choose the radio button option as Subject  
            if (option == "Flag")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View("Index", db.Cars.Where(c => c.Flag.Contains(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 3));
            }
            else if (option == "Brand")
            {
                return View("Index", db.Cars.Where(c => c.Brand == search || search == null).ToList().ToPagedList(pageNumber ?? 1, 3));
            }
            else if (option == null)
            {
                return View("Index", db.Cars.ToList().ToPagedList(pageNumber ?? 1, 3));
            }

            else
            {
                return View("Index", db.Cars.ToList().ToPagedList(pageNumber ?? 1, 3));
            }
        }

        // GET: Cars
        public ActionResult Index(int? pageNumber)
        {

            IPagedList<Car> carpage = db.Cars.OrderBy(x=>x.Flag).ToPagedList(pageNumber ?? 1, 3);

          
            return View(carpage);
        }
        
        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Flag,VIN,FirstRegistration,Date,VechicleType,Brand,Yearofconstruction,Color,EngineType,Enginepower,DriveType,Status,Username,LogDate")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
       

            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Flag,VIN,FirstRegistration,Date,VechicleType,Brand,Yearofconstruction,Color,EngineType,Enginepower,DriveType,Status,Username,LogDate")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
