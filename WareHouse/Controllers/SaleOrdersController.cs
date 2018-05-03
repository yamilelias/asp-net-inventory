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
    public class SaleOrdersController : Controller
    {
        private WareHouseContext db = new WareHouseContext();

        // GET: SaleOrders
        public ActionResult Index()
        {
            return View(db.SaleOrders.ToList());
        }

        // GET: SaleOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleOrder saleOrder = db.SaleOrders.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }
            return View(saleOrder);
        }

        // GET: SaleOrders/AddItems/5
        public ActionResult AddItems(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleOrder saleOrder = db.SaleOrders.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }
            return View(saleOrder);
        }

        // POST: Albums/AddItems
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItems(int id)
        {

            SaleOrder saleOrder = db.SaleOrders.Find(id);
            return RedirectToAction("Create", "SalesLogs", new { id = saleOrder.SaleOrderID });
        }

        // GET: SaleOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleOrders/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleOrderID,SaleOrderStatus,SaleOrderDate")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                db.SaleOrders.Add(saleOrder);
                db.SaveChanges();
                return RedirectToAction("AddItems", new { id=saleOrder.SaleOrderID});
            }

            return View(saleOrder);
        }

        // GET: SaleOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleOrder saleOrder = db.SaleOrders.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }
            return View(saleOrder);
        }

        // POST: SaleOrders/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleOrderID,SaleOrderStatus,SaleOrderDate")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saleOrder);
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
