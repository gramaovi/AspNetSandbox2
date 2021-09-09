using System.Collections.Generic;
using AspNetSandbox2;

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