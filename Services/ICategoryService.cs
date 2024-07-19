using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ser_PracticesProj.Entites;

namespace Ser_PracticesProj.Services
{
    public interface ICategoryService
    {
        public List<Category> GetAll();
        public Category GetById(int id);
        public Category GetByName(String name);
        public void DeleteById(int id);
        public void CreateCategory(Category category);
        public Category UpdateCategory(Category category);

    }
}