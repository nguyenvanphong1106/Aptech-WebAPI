using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Homework.Models;

namespace Homework.Controllers
{
    [RoutePrefix("api/products")]
    public class productsController : ApiController
    {
        private aptech_onlineshopEntities db = new aptech_onlineshopEntities();

        // GET: api/products
        public IQueryable<object> Getproducts()
        {
            var products = from p in db.products
                           select new
                           {
                               p.Id,
                               p.Name,
                               p.Price
                           };
            return products;
        }

        // GET: api/products/5
        [Route("{id:int}")]
        [ResponseType(typeof(object))]
        public IHttpActionResult Getproduct(int id)
        {
            var product = (from p in db.products
                           where p.Id == id
                           select new
                           {
                               p.Id,
                               p.Name,
                               p.Price,
                               p.Stock,
                               p.SupplierId,
                               p.Description
                           }).SingleOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //Get products with discount < 10%
        //GET api/products/discount
        [Route("{discount}")]
        public IQueryable<object> GetProductByDiscount(string discount)
        {
            var product = from p in db.products
                           where p.Discount <= 10
                           select new
                           {
                               p.Name,
                               p.Price,
                               p.Discount,
                               p.Stock,
                               p.SupplierId,
                               p.Description
                           };
            return product;
        }












        // PUT: api/products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putproduct(int id, product product)
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
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productExists(id))
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

        // POST: api/products
        [ResponseType(typeof(product))]
        public async Task<IHttpActionResult> Postproduct(product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/products/5
        [ResponseType(typeof(product))]
        public async Task<IHttpActionResult> Deleteproduct(int id)
        {
            product product = await db.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.products.Remove(product);
            await db.SaveChangesAsync();

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

        private bool productExists(int id)
        {
            return db.products.Count(e => e.Id == id) > 0;
        }
    }
}