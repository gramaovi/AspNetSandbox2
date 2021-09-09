﻿using System;
using System.Collections.Generic;
using AspNetSandbox;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            booksService.ReplaceBook(id, value);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(booksService.GetBooks(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

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
