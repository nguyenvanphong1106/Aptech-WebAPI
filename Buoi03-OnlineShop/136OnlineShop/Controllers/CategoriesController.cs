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
    [Authorize]
    public class CategoriesController : ApiController
    {
        private EShopDBEntities db = new EShopDBEntities();

        // GET: api/Categories
        public IQueryable<object> GetCategories()
        {
            //new code
            var categories = from c in db.Categories
                             select new
                             {
                                 c.Id,
                                 c.CategoryName
                             };
            return categories;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(object))]
        public IHttpActionResult GetCategory(int id)
        {
            //new code
            //loai bo doi tuong product ma json ko the parse dc
            var category = (from c in db.Categories
                           where c.Id == id
                           select new
                           {
                               c.Id,
                               c.CategoryName
                           }).SingleOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            //this shall not work
            //category.Products = new List<Product>();
            //category.Products = null;



            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}