using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ser_PracticesProj.Entites;

namespace Ser_PracticesProj.Repo
{
    public interface IBookRepository
    {
        public List<Book> GetAll();

        public Book GetById(int Id);
        public void DeleteById(int Id);

        public void CreateBook(Book book);
    }
}