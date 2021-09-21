using System.Collections.Generic;
using AspNetSandbox2;
using AspNetSandbox2.DTOs;
using AspNetSandbox2.Models;

namespace AspNetSandbox
{
    public interface IBookRepository
    {
        void DeleteBook(int id);

        IEnumerable<Book> GetBooks();

        Book GetBooksById(int id);

        void AddBook(Book value);

        void ReplaceBook(int id, Book value);
    }
}