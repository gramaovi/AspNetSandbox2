using System.Collections.Generic;
using System.Linq;
using AspNetSandbox;
using AspNetSandbox2.Models;

namespace AspNetSandbox2.Services
{
    public class BooksInMemoryRepository : IBookRepository
    {
        private List<Book> books;

        public BooksInMemoryRepository()
        {
            books = new List<Book>
            {
                new Book
                {
                    Id = 0,
                    Title = "Amintirile peregrinului apter",
                    Language = "Romanian",
                    Author = "Valeriu Anania",
                },

                new Book
                {
                    Id = 1,
                    Title = "test",
                    Language = "Romanian",
                    Author = "asaa",
                },
            };
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Book GetBooks(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public void AddBook(Book value)
        {
            int lastId = books[books.Count - 1].Id;
            value.Id = lastId + 1;

            books.Add(value);
        }

        public void ReplaceBook(int id, Book value)
        {
            if (id == value.Id)
            {
                books[id] = value;
            }
        }

        public void DeleteBook(int id)
        {
            books.Remove(GetBooks(id));
        }
    }
}
