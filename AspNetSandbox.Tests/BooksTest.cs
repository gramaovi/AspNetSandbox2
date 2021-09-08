using AspNetSandbox2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class BooksServiceTests
    {

        private BooksService booksService;
      
        [Fact]
        public void BooksServiceAddBookTest()
        {
            //Asume
            booksService = new BooksService();

            // Act
            booksService.AddBook(new Book
            {
                Title = "T1",
                Author = "T1 ",
                Language = "T1"
            });
            booksService.DeleteBook(2);
            booksService.AddBook(new Book
            {
                Title = "T2",
                Author = "T2",
                Language = "T2"
            });


            // Assert
            Assert.Equal("T2", booksService.GetBooks(2).Title);
            Assert.Equal("T2", booksService.GetBooks(2).Author);
            Assert.Equal("T2", booksService.GetBooks(2).Language);
        }

        [Fact]
        public void BooksServiceReplaceBookTest()
        {
            //Asume
            booksService = new BooksService();
   

            // Act
          
            booksService.ReplaceBook(0, new Book
            {
                Id = 0,
                Title = "TReplace",
                Author = "TReplace",
                Language = "TReplace"
            });

            // Assert
            Assert.Equal("TReplace", booksService.GetBooks(1).Title);
            Assert.Equal("TReplace", booksService.GetBooks(0).Author);
            Assert.Equal("TReplace", booksService.GetBooks(0).Language);
        }
    }
}
