using AspNetSandbox2;
using System.Collections.Generic;

namespace AspNetSandbox
{
    public interface IBooksService
    {
        void DeleteBook(int id);
        IEnumerable<Book> GetBooks();
        Book GetBooks(int id);
        void AddBook(Book value);
        void ReplaceBook(int id, Book value);
    }
}