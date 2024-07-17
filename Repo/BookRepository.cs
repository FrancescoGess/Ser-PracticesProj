using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ser_PracticesProj.Data;
using Ser_PracticesProj.Entites;

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

    }
}