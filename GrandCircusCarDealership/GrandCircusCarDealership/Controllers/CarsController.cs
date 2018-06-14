using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GrandCircusCarDealership.Models;

namespace GrandCircusCarDealership.Controllers
{
    public class CarsController : ApiController
    {
        private CarDealershipEntities db = new CarDealershipEntities();

        // GET: api/Cars
        public IQueryable<Car> GetCars()
        {
            return db.Cars;
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [ResponseType(typeof(Car))]
        [HttpGet]
        public IHttpActionResult GetCarByMake(string make)
        {
            List<Car> list = db.Cars.Where(
               c => c.Make.Contains(make)
                ).ToList();

            return Ok(list);
        }

        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCarByModel(string model)
        {
            List<Car> list = db.Cars.Where(
               c => c.Model.Contains(model)
                ).ToList();

            return Ok(list);
        }

        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCarByYear(int year)
        {
            List<Car> list = db.Cars.Where(
               c => c.Year == year
                ).ToList();

            return Ok(list);
        }

        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCarByColor(string color)
        {
            List<Car> list = db.Cars.Where(
               c => c.Color.Contains(color)
                ).ToList();

            return Ok(list);
        }

        [ResponseType(typeof(Car))]
        [HttpGet]
        public IHttpActionResult GetCarByEverything(string make = "boo", string model = "boo", int? year = 0, string color = "boo")
        {
            //There is a string.IsNullOrEmpty
            List<Car> cars = (from c in db.Cars
                              select c).ToList();
            if (make != "" && make != "boo" && make != null)
            {
                cars = (from c in cars
                        where c.Make.Contains(make)
                        select c
                        ).ToList();
            }
            if(model != "" && model != "boo" && model != null)
            {
                cars = (from c in cars
                        where c.Model.Contains(model)
                        select c).ToList();
            }
            if (year != 0 && year != null)
            {
                cars = (from c in cars
                        where c.Year == year
                        select c).ToList();
            }
            if (color != "" && color != "boo" && color != null)
            {
                cars = (from c in cars
                        where c.Color.Contains(color)
                        select c).ToList();
            }

            return Ok(cars);
        }

        //// PUT: api/Cars/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCar(int id, Car car)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != car.CarId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(car).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CarExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Cars
        //[ResponseType(typeof(Car))]
        //public IHttpActionResult PostCar(Car car)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Cars.Add(car);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = car.CarId }, car);
        //}

        //// DELETE: api/Cars/5
        //[ResponseType(typeof(Car))]
        //public IHttpActionResult DeleteCar(int id)
        //{
        //    Car car = db.Cars.Find(id);
        //    if (car == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Cars.Remove(car);
        //    db.SaveChanges();

        //    return Ok(car);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.CarId == id) > 0;
        }
    }
}