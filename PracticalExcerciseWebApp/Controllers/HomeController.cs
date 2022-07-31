using Newtonsoft.Json;
using PracticalExcerciseWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalExcerciseWebApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<Appointment> lstApp;

        public ActionResult Index()
        {
            string practitioners = Server.MapPath("~/App_Data/") + "practitioners.json";
            string appointments = Server.MapPath("~/App_Data/") + "appointments.json";
            List<Practitioner> lstPra = JsonConvert.DeserializeObject<List<Practitioner>>(System.IO.File.ReadAllText(practitioners));
            lstApp = JsonConvert.DeserializeObject<List<Appointment>>(System.IO.File.ReadAllText(appointments));
            ViewBag.Appointment = lstApp;
            ViewBag.Practitioner = lstPra.Select(x => new SelectListItem { Text = x.name, Value = x.id.ToString() });
            return View();
        }

        [HttpGet]
        public ActionResult GetReport(string date,int pract)
        {
           DateTime _date= Convert.ToDateTime(date);
            date = _date.ToString("M/d/yyyy").Replace('-', '/');
            var data = lstApp.Where(x => x.date == date && x.practitioner_id == pract).GroupBy(x => new { x.practitioner_id, x.cost, x.revenue })
                .Select(x => new { practitioner_id = x.Key.practitioner_id, cost = x.Key.cost, revenue = x.Key.revenue }).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDetailReport(string date, int pract)
        {
            DateTime _date = Convert.ToDateTime(date);
            date = _date.ToString("M/d/yyyy").Replace('-', '/');
            var data = lstApp.Where(x => x.date == date && x.practitioner_id == pract);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}