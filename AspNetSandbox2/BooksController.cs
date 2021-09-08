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
        private Book[] books;

        public BooksController()
        {
            books = new Book[2];
            books[0] = new Book
            {
                Id = 0,
                Title = "Amintirile peregrinului apter",
                Language = "Romanian",
                Author = "Valeriu Anania"
            };

            books[1] = new Book
            {
                Id = 1,
                Title = "test",
                Language = "Romanian",
                Author = "asaa"
            };
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }
        private bool SomeFunction(Book book)
        {
            return book.Id == 1;
        }
        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {

            return books.Single(book => book.Id == id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
