using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetSandbox2;
using AspNetSandbox2.Models;
using AspNetSandbox2.Services;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class BooksInMemoryRepositoryTest
    {
        private BooksInMemoryRepository booksService;

        [Fact]
        public void BooksInMemoryRepository()
        {
            // Asume
            booksService = new BooksInMemoryRepository();

            // Act
            booksService.AddBook(new Book
            {
                Title = "T1",
                Author = "T1 ",
                Language = "T1",
            });
            booksService.DeleteBook(2);
            booksService.AddBook(new Book
            {
                Title = "T2",
                Author = "T2",
                Language = "T2",
            });

            // Assert
            Assert.Equal("T2", booksService.GetBooks(2).Title);
            Assert.Equal("T2", booksService.GetBooks(2).Author);
            Assert.Equal("T2", booksService.GetBooks(2).Language);
        }

        [Fact]
        public void BooksServiceReplaceBookTest()
        {
            // Assume
            booksService = new BooksInMemoryRepository();

            // Act
            booksService.ReplaceBook(0, new Book
            {
                Id = 0,
                Title = "TReplace",
                Author = "TReplace",
                Language = "TReplace",
            });

            // Assert
            Assert.Equal("TReplace", booksService.GetBooks(0).Title);
            Assert.Equal("TReplace", booksService.GetBooks(0).Author);
            Assert.Equal("TReplace", booksService.GetBooks(0).Language);
        }
    }
}
