using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox;
using AspNetSandbox2.Data;
using AspNetSandbox2.DTOs;
using AspNetSandbox2.Models;

namespace AspNetSandbox2.Services
{
    public class DbBooksRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        private List<Book> books;

        public DbBooksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Book.Find(id);
            _context.Book.Remove(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetBooks()
        {
            books = _context.Book.ToList();
            return books;
        }

        public Book GetBooksById(int id)
        {
            var book = _context.Book
            .FirstOrDefault(m => m.Id == id);
            return book;
        }

        public void ReplaceBook(int id, Book book)
        {
            _context.Update(book);
            _context.SaveChanges();
        }

        public void AddBook(CreateBookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
