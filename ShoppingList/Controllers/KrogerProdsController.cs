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
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class KrogerProdsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/KrogerProds
        public IQueryable<KrogerProduct> GetKrogerProducts()
        {
            return db.KrogerProducts;
        }

        // GET: api/KrogerProds/5
        [ResponseType(typeof(KrogerProduct))]
        public IHttpActionResult GetKrogerProduct(int id)
        {
            KrogerProduct krogerProduct = db.KrogerProducts.Find(id);
            if (krogerProduct == null)
            {
                return NotFound();
            }

            return Ok(krogerProduct);
        }

        // PUT: api/KrogerProds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKrogerProduct(int id, KrogerProduct krogerProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != krogerProduct.Id)
            {
                return BadRequest();
            }

            db.Entry(krogerProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KrogerProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KrogerProds
        [ResponseType(typeof(KrogerProduct))]
        public IHttpActionResult PostKrogerProduct(KrogerProduct krogerProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KrogerProducts.Add(krogerProduct);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = krogerProduct.Id }, krogerProduct);
        }

        // DELETE: api/KrogerProds/5
        [ResponseType(typeof(KrogerProduct))]
        public IHttpActionResult DeleteKrogerProduct(int id)
        {
            KrogerProduct krogerProduct = db.KrogerProducts.Find(id);
            if (krogerProduct == null)
            {
                return NotFound();
            }

            db.KrogerProducts.Remove(krogerProduct);
            db.SaveChanges();

            return Ok(krogerProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KrogerProductExists(int id)
        {
            return db.KrogerProducts.Count(e => e.Id == id) > 0;
        }
    }
}