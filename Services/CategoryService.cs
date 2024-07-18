using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ser_PracticesProj.Entites;
using Ser_PracticesProj.Repo;

namespace Ser_PracticesProj.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
        public Category GetByName(String CatName)
        {
            return _categoryRepository.GetByName(CatName);
        }
        public void DeleteById(int Id)
        {
            _categoryRepository.DeleteById(Id);
        }
        public void CreateCategory(Category category)
        {
            _categoryRepository.CreateCategory(category);
        }

        public Category UpdateCategory(Category category)
        {
            {
                _categoryRepository.UpdateCategory(category);
                return category;
            }

        }
    }

}
