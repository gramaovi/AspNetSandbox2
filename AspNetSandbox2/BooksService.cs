﻿using AspNetSandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox2
{
    public class BooksService : IBooksService
    {
        private List<Book> books;
        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 0,
                Title = "Amintirile peregrinului apter",
                Language = "Romanian",
                Author = "Valeriu Anania"
            });

            books.Add(new Book
            {
                Id = 1,
                Title = "test",
                Language = "Romanian",
                Author = "asaa"
            });
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
            int id = books.Count;

            value.Id = id;
            books.Add(value);
        }
        public void ReplaceBook(int id, Book value)
        {
            if (id == value.Id)
            {
                books[id - 1] = value;
            }
        }

        public void DeleteBook(int id)
        {
            books.Remove(GetBooks(id));
        }
    }
}
