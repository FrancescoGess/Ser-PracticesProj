using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ser_PracticesProj.Entites;

namespace Ser_PracticesProj.Services
{
    public interface IAuthorService
    {
        public List<Author> GetAll();
        public Author GetById(int id);
        public Author GetByName(String name);
        public Task DeleteById(int id);
        public void CreateAuthor(Author author);
        public Author UpdateAuthor(Author author);

    }
}