using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ser_PracticesProj.Entites;
using Ser_PracticesProj.Services;

namespace Ser_PracticesProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet(Name = "Book")]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            Category category = categoryService.GetById(Id);
            return Ok(category);
        }
        [HttpDelete("{Id}")]
        public void DeleteById(int Id)
        {
            categoryService.DeleteById(Id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            categoryService.CreateCategory(category);
            return Ok("Categoria creata con successo!");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCategory(int Id, [FromBody] Category category)
        {
            var categoryUp = categoryService.GetById(Id);
            if (categoryUp == null)
            {
                throw new Exception("Categoria non trovata!");
            }
            categoryUp.CatName = category.CatName;
            return Ok("Categoria aggiornata correttamente!");
        }
    }

}
