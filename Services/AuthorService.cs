using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ser_PracticesProj.Entites;
using Ser_PracticesProj.Repo;

namespace Ser_PracticesProj.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }
        public Author GetById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public void DeleteById(int id)
        {
            _authorRepository.DeleteById(id);
        }
        public void CreateAuthor(Author author)
        {
            _authorRepository.CreateAuthor(author);
        }

        public Author UpdateAuthor(Author author)
        {
            _authorRepository.UpdateAuthor(author);
            return author;
        }


    }
}