using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Ser_PracticesProj.Data;
using Ser_PracticesProj.Entites;
using Ser_PracticesProj.Services;

namespace Ser_PracticesProj.Repo
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int Id)
        {
            Book book = _context.Books.Where(b => b.Id == Id).First();
            return book;
        }

        public void DeleteById(int Id)
        {
            Book book = _context.Books.Where(b => b.Id == Id).First();
            _context.Remove(book);
            _context.SaveChanges();
        }

        public void CreateBook(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        public Book UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return book;

        }

    }
}