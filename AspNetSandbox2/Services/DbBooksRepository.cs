using AspNetSandbox;
using AspNetSandbox2.Data;
using AspNetSandbox2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox2.Services
{
    public class DbBooksRepository : IBookRepository
    {
        private List<Book> books;
        private readonly ApplicationDbContext _context;

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

        public Book GetBooks(int id)
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
    }
}
