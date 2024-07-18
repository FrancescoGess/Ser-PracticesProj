using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ser_PracticesProj.Entites;

namespace Ser_PracticesProj.Repo
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();
        public Category GetByName(String CatName);
        public void DeleteById(int Id);
        public void CreateCategory(Category category);





    }
}