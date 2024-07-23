using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public Book GetById(int id)
        {
            try
            {
                return _context.Books.Where(b => b.id == id).First();
            }
            catch
            {
                return null;
            }


        }

        public async Task DeleteById(int id)
        {
            Book book = await _context.Books.FirstOrDefaultAsync(b => b.id == id);
            if (book != null)
            {
                _context.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public void CreateBook(Book book)
        {
            _context.Books.Add(book);
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