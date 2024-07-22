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
        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void DeleteById(int id)
        {
            _categoryRepository.DeleteById(id);
        }
        public void CreateCategory(Category category)
        {
            _categoryRepository.CreateCategory(category);
        }

        public Category UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
            return category;
        }
    }

}
