using AspNetSandbox;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetSandbox2
{



    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return booksService.GetBooks();
        }
        private bool SomeFunction(Book book)
        {
            return book.Id == 1;
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            booksService.ReplaceBook(id, value);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {

            return booksService.GetBooks(id);

        }

        // POST api/<BooksController>
        [HttpPost]
        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            booksService.AddBook(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            booksService.DeleteBook(id);
        }
    }
}
