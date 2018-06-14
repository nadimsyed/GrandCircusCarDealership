using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrandCircusCarDealership.Models;
using Newtonsoft.Json.Linq;

namespace GrandCircusCarDealership.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetByCarID(int CarID)
        {
            ViewBag.CarID = CarID;
            return View();
        }

        //[Route("~/api/cars/GetCarByMake/{make:string}/cars")]
        //public ActionResult GetCarsByMake(string publisher)
        //{
        //    //LibraryEntities db = new LibraryEntities();

        //    List<Car> list = db.Car.Where(
        //       c => c.Publisher.Contains(publisher)
        //        ).ToList();

        //    return Json(list);
        //}

        public ActionResult GetByCarMake(string make)
        {
            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:52043/api/Cars/GetCarByMake?make={make}");

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string Data = reader.ReadToEnd();

            try
            {
                JArray JsonData = JArray.Parse(Data);
                ViewBag.Cars = JsonData/*["Make"]*/;

                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }
        }

        public ActionResult GetByCarModel(string model)
        {
            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:52043/api/Cars/GetCarByModel?model={model}");

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string Data = reader.ReadToEnd();

            try
            {
                JArray JsonData = JArray.Parse(Data);
                ViewBag.Cars = JsonData/*["Make"]*/;

                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

        }

        public ActionResult GetByCarYear(int year)
        {
            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:52043/api/Cars/GetCarByYear?year={year}");

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string Data = reader.ReadToEnd();

            try
            {
                JArray JsonData = JArray.Parse(Data);
                ViewBag.Cars = JsonData/*["Make"]*/;

                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

        }

        public ActionResult GetByCarColor(string color)
        {
            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:52043/api/Cars/GetCarByColor?color={color}");

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string Data = reader.ReadToEnd();

            try
            {
                JArray JsonData = JArray.Parse(Data);
                ViewBag.Cars = JsonData/*["Make"]*/;

                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

        }

        public ActionResult GetEverythingStart()
        {

            return View();
        }

        [HttpGet]
        public ActionResult GetByCarEverything(string make = "boo", string model = "boo", int year = 0, string color = "boo")
        {
            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:52043/api/Cars/GetCarByEverything?make={make}&model={model}&year={year}&color={color}");

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string Data = reader.ReadToEnd();

            try
            {
                JArray JsonData = JArray.Parse(Data);
                ViewBag.Cars = JsonData/*["Make"]*/;

                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

        }
    }
}