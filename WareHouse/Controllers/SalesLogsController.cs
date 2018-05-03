using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WareHouse.Models;

namespace WareHouse.Controllers
{
    public class SalesLogsController : Controller
    {
        private WareHouseContext db = new WareHouseContext();
        

        // GET: SalesLogs
        public ActionResult Index()
        {
            var salesLogs = db.SalesLogs.Include(s => s.Item).Include(s => s.SaleOrder);
            return View(salesLogs.ToList());
        }

        // GET: SalesLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesLog salesLog = db.SalesLogs.Find(id);
            if (salesLog == null)
            {
                return HttpNotFound();
            }
            return View(salesLog);
        }

        // GET: SalesLogs/Create
        public ActionResult Create(int? id)
        { 
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName");
            ViewBag.SaleOrderID = new SelectList(db.SaleOrders, "SaleOrderID", "SaleOrderID");
            

            return View();
        }

        // POST: SalesLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesLogID,ItemOrderQTY,ItemID,SaleOrderID")] SalesLog salesLog, int id)
        {
            if (ModelState.IsValid)
            {
                Item items = db.Items.Find(salesLog.ItemID);

                if (salesLog.ItemOrderQTY <= items.ItemQTY)
                {
                    ViewBag.mensaje = "1";
                items.ItemQTY = items.ItemQTY - salesLog.ItemOrderQTY;
                salesLog.SaleOrderID = id;
                db.SalesLogs.Add(salesLog);
                db.SaveChanges();
                    if(items.ItemQTY < items.ItemThres)
                    {
                        MailMessage mail = new MailMessage("no-reply@ordersmaster.mx", "A01561056@itesm.mx"));
                        SmtpClient client = new SmtpClient();
                        client.Port = 25;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Host = "localhost";
                        mail.Subject = "WARNING, one of your items has reached its threshold: " + items.ItemName;
                        mail.Body = mail.Body = "The item " + items.ItemName + " is low in stock, you have " + items.ItemQTY + " and its threshold is " + items.ItemThres + " , order more.";
                        mail.IsBodyHtml = true;
                        client.Send(mail);

                    }

                    return RedirectToAction("AddItems", "SaleOrders", new { id = salesLog.SaleOrderID });
                 }
                else
                {
                    ViewBag.mensaje = "0";
                    salesLog.SaleOrderID = id;
                }
            }

            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", salesLog.ItemID);
            ViewBag.SaleOrderID = new SelectList(db.SaleOrders, "SaleOrderID", "SaleOrderID", salesLog.SaleOrderID);
            return View(salesLog);
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
