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
using _136OnlineShop.Models;

namespace _136OnlineShop.Controllers
{
    //[Authorize]
    public class ProductsController : ApiController
    {     
        private EShopDBEntities db = new EShopDBEntities();

        // GET: api/Products
        public IQueryable<object> GetProducts()
        {
            //new code
            var products = from p in db.Products
                           select new
                           {
                               p.Id,
                               p.ProductName,
                               p.Price,
                               p.Category.CategoryName
                           };
            return products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(object))]              //sua Product thanh` object
        public IHttpActionResult GetProduct(int id)
        {
            //new code
            var product = (from p in db.Products
                           where p.Id == id
                           select new
                           {
                               p.Id,
                               p.ProductName,
                               p.Price,
                               p.CategoryId,
                               p.Description,
                               p.Picture,
                               p.Active
                           }).SingleOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}