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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{Id},GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            Category category = categoryService.GetById(Id);
            return Ok(category);
        }
        [HttpDelete("{Id},DeleteById")]
        public void DeleteById(int Id)
        {
            categoryService.DeleteById(Id);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            var categoryDB = categoryService.GetByName(category.CatName);
            if (categoryDB == null)
            {
                categoryService.CreateCategory(category);
                return Ok("Categoria creata con successo!");
            }
            return BadRequest("Categoria già esistente");
        }

        [HttpPut("{Id}UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int Id, [FromBody] Category category)
        {
            var categoryUp = categoryService.GetById(Id);
            if (categoryUp == null)
            {
                throw new Exception("Categoria non trovata!");
            }
            categoryUp.CatName = category.CatName;
            categoryService.UpdateCategory(categoryUp);
            return Ok("Categoria aggiornata correttamente!");
        }
    }

}
