using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ser_PracticesProj.Data;
using Ser_PracticesProj.Entites;

namespace Ser_PracticesProj.Repo
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetById(int id)
        {
            try
            {
                return _context.Authors.Where(a => a.id == id).First();
            }
            catch
            {
                return null;
            }
            /*if (author == null)
            {
                throw new KeyNotFoundException($"Autore con ID {id} non trovato");
            }
            return author;*/
        }

        public Author GetByName(String name)
        {
            try
            {
                return _context.Authors.Where((a) => a.nameAuth == name).First();
            }
            catch
            {
                return null;
            }
        }

        public async Task DeleteById(int id)
        {
            Author author = await _context.Authors.FirstOrDefaultAsync(b => b.id == id);
            if (author != null)
            {
                _context.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public void CreateAuthor(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
        }

        public Author UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
            return author;
        }

    }
}