using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ser_PracticesProj.Entites;

namespace Ser_PracticesProj.Services
{
    public interface IBookService
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public void DeleteById(int id);
        public void CreateBook(Book book);
        public Book UpdateBook(Book book);
    }
}