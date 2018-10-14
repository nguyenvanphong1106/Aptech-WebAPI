using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookAPI___DatabaseFirst.Models;

namespace BookAPI___DatabaseFirst.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BookAPIEntities db = new BookAPIEntities();

        //Type Lambda expression for select() method
        private static readonly Expression<Func<Book, BookDto>> AsBookDto = x => new BookDto
        {
            Title = x.Title,
            Genre = x.Genre,
            Author = x.Author.Name
        };

        // GET: api/Books
        [Route("")]
        public IQueryable<BookDto> GetBooks()
        {
            return db.Books.Include(b => b.Author).Select(AsBookDto);
        }

        // GET: api/Books/5
        [Route("{id:int}")]
        [ResponseType(typeof(BookDto))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            BookDto book = await db.Books.Include(b => b.Author).Where(b => b.BookId == id).Select(AsBookDto).FirstOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        //GET BOOK DETAILS
        [Route("{id:int}/details")]
        [ResponseType(typeof(BookDetailDto))]
        public async Task<IHttpActionResult> GetBookDetail(int id)
        {
            var book = await (from b in db.Books.Include(b => b.Author)
                                  where b.BookId == id
                                  select new 
                                  {
                                      b.Title,
                                      b.Genre,
                                      b.Price,
                                      b.PublishDate,
                                      b.Description
                                  }).SingleOrDefaultAsync();
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //GET BOOK GENRE
        [Route("{genre}")]
        //[ResponseType(typeof(object))]
        public IQueryable<BookDto> GetBookByGenre(string genre)
        {
            return db.Books.Include(b => b.Author)
                .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                .Select(AsBookDto);
        }

        //GET BOOK BY AUTHOR
        [Route("~/api/authors/{authorId:int}/books")]
        public IQueryable<BookDto> GetBooksByAuthor(int authorId)
        {
            return db.Books.Include(b => b.Author)
                .Where(b => b.AuthorId == authorId)
                .Select(AsBookDto);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.BookId == id) > 0;
        }
    }
}