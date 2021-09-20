using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandbox;
using AspNetSandbox2.Data;
using AspNetSandbox2.DTOs;
using AspNetSandbox2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        public BooksController(IBookRepository repository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.repository = repository;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetBooks());
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateBookDto bookDto)
        {
            Book book = mapper.Map<Book>(bookDto);
            repository.ReplaceBook(id, book);
            hubContext.Clients.All.SendAsync("UpdatedBook", book);
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
        public IActionResult Post([FromBody] CreateBookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(bookDto);
                repository.AddBook(book);
                hubContext.Clients.All.SendAsync("CreatedBook", book);
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
            repository.DeleteBook(id);
            hubContext.Clients.All.SendAsync("DeletedBook", id);
            return Ok();
        }
    }
}
