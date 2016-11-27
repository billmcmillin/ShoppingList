using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class KrogerProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KrogerProducts
        public ActionResult Index()
        {
            return View(db.KrogerProducts.ToList());
        }

        // GET: KrogerProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KrogerProduct krogerProduct = db.KrogerProducts.Find(id);
            if (krogerProduct == null)
            {
                return HttpNotFound();
            }
            return View(krogerProduct);
        }

        // GET: KrogerProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KrogerProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,buyable,regularPrice,salePrice,offerQuantity,offerPrice,offerType,offerEndDate,sizing,currentPrice,Self")] KrogerProduct krogerProduct)
        {
            if (ModelState.IsValid)
            {
                db.KrogerProducts.Add(krogerProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(krogerProduct);
        }

        // GET: KrogerProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KrogerProduct krogerProduct = db.KrogerProducts.Find(id);
            if (krogerProduct == null)
            {
                return HttpNotFound();
            }
            return View(krogerProduct);
        }

        // POST: KrogerProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,buyable,regularPrice,salePrice,offerQuantity,offerPrice,offerType,offerEndDate,sizing,currentPrice,Self")] KrogerProduct krogerProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(krogerProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(krogerProduct);
        }

        // GET: KrogerProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KrogerProduct krogerProduct = db.KrogerProducts.Find(id);
            if (krogerProduct == null)
            {
                return HttpNotFound();
            }
            return View(krogerProduct);
        }

        // POST: KrogerProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KrogerProduct krogerProduct = db.KrogerProducts.Find(id);
            db.KrogerProducts.Remove(krogerProduct);
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
