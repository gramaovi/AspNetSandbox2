using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandbox;
using AspNetSandbox2.Data;
using AspNetSandbox2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace AspNetSandbox2
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;
        private readonly ApplicationDbContext _context;

        public BooksController(IBookRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetBooks());
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
             _context.Update(book);
             _context.SaveChangesAsync();
             return Ok();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var book = repository.GetBooks(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                repository.AddBook(book);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            repository.DeleteBook(repository.GetBooks(id).Id);
            return Ok();
        }
    }
}
