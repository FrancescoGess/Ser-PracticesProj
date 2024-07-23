using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ser_PracticesProj.Data;
using Ser_PracticesProj.Entites;

namespace Ser_PracticesProj.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public Category GetById(int id)
        {
            try
            {
                return _context.Categories.Where(c => c.id == id).First();
            }
            catch
            {
                return null;
            }
            /* if (category == null)
             {
                 throw new KeyNotFoundException($"Categoria con ID {id} non trovata");
             }
             return category;*/
        }

        public Category GetByName(String name)
        {
            try
            {
                return _context.Categories.Where((c) =>
                c.catName == name).First();
            }
            catch
            {
                return null;
            }
        }
        public async Task DeleteById(int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(b => b.id == id);
            if (category != null)
            {
                _context.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
        public void CreateCategory(Category category)
        {

            _context.Add(category);
            _context.SaveChanges();
        }

        public Category UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }




    }
}