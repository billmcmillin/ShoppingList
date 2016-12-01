using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingList.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace ShoppingList.Controllers
{
    public class KrogerOdataProductsController : ODataController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private bool KrogerProductExists(int key)
        {
            return db.KrogerProducts.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        
        [EnableQuery(PageSize = 30)]
        public IQueryable<KrogerProduct> Get()
        {
            return db.KrogerProducts.AsQueryable();
        }
        [EnableQuery]
        public SingleResult<KrogerProduct> Get([FromODataUri] int key)
        {
            IQueryable<KrogerProduct> result = db.KrogerProducts.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }
    }
}