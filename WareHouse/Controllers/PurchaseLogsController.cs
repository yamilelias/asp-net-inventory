using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WareHouse.Models;

namespace WareHouse.Controllers
{
    [Authorize(Roles = "Administrator, Supervisor")]
    public class PurchaseLogsController : Controller
    {
        private WareHouseContext db = new WareHouseContext();

        // GET: PurchaseLogs
        public ActionResult Index()
        {
            var purchaseLogs = db.PurchaseLogs.Include(p => p.Item).Include(p => p.PurchaseOrder);
            return View(purchaseLogs.ToList());
        }

        // GET: PurchaseLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseLog purchaseLog = db.PurchaseLogs.Find(id);
            if (purchaseLog == null)
            {
                return HttpNotFound();
            }
            return View(purchaseLog);
        }

        // GET: PurchaseLogs/Create
        public ActionResult Create(int? id)
        {
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName");
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "PurchaseOrderDesc");
            return View();
        }

        // POST: PurchaseLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseLogID,ItemOrderQTY,ItemID,PurchaseOrderID")] PurchaseLog purchaseLog, int id)
        {
            if (ModelState.IsValid)
            {
                Item items = db.Items.Find(purchaseLog.ItemID);
                items.ItemQTY = items.ItemQTY + purchaseLog.ItemOrderQTY;
                purchaseLog.PurchaseOrderID = id;
                db.PurchaseLogs.Add(purchaseLog);
                db.SaveChanges();
                return RedirectToAction("AddItems", "PurchaseOrders", new { id = purchaseLog.PurchaseOrderID });
            }

            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", purchaseLog.ItemID);
            ViewBag.PurchaseOrderID = new SelectList(db.PurchaseOrders, "PurchaseOrderID", "PurchaseOrderDesc", purchaseLog.PurchaseOrderID);
            return View(purchaseLog);
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
