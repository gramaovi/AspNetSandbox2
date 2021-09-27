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
        private readonly ApplicationDbContext context;
        private List<Book> books;

        public DbBooksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
        }

        public IEnumerable<Book> GetBooks()
        {
            books = context.Book.ToList();
            return books;
        }

        public Book GetBooksById(int id)
        {
            var book = context.Book
            .FirstOrDefault(m => m.Id == id);
            return book;
        }

        public void ReplaceBook(int id, Book book)
        {
            context.Update(book);
            context.SaveChanges();
        }

        public void AddBook(CreateBookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
