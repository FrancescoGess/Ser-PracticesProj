using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Category GetByName(String CatName)
        {
            Category category = _context.Categories.Where(c => c.CatName == CatName).First();
            return category;
        }
        public void DeleteById(int Id)
        {
            Category category = _context.Categories.Where(c => c.Id == Id).First();
            _context.Remove(category);
            _context.SaveChanges();
        }
        public void CreateCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }


    }
}