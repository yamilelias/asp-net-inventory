using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Models;

namespace WareHouse.Controllers
{
    public class HomeController : Controller
    {
        private WareHouseContext db = new WareHouseContext();
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        public ActionResult About()
        {
            if (User.Identity.IsAuthenticated)
            {
                var lowInventoryItems = db.Items.ToList().OrderBy(f => f.ItemQTY * 100 / f.ItemThres).Take(10);
                var MostSelledItems = db.SalesLogs.ToList();

                // var tuple = new Tuple<lowInventoryItems, SalesLog>(new Item(), new SalesLog());
                return View(lowInventoryItems);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}