using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
            if (categories.IsNullOrEmpty())
            {
                return BadRequest("Lista vuota");
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Category ID non valido. ID non può essere 0.");
            }
            Category category = categoryService.GetById(id);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Category ID non valido. ID non può essere 0.");
            }

            try
            {
                await categoryService.DeleteById(id);
                return Ok("Categoria eliminata con successo");
            }
            catch (Exception ex)
            {
                return BadRequest($"Errore durante l'eliminazione della categoria: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            var categoryDB = categoryService.GetByName(category.catName);
            if (categoryDB == null)
            {
                categoryService.CreateCategory(category);
                return Ok("Categoria creata con successo!");
            }
            return BadRequest("Categoria già esistente");
        }

        [HttpPut("{id},UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (id == 0)
            {
                return BadRequest("Category ID non valido. ID non può essere 0.");
            }

            var categoryUp = categoryService.GetById(id);

            if (categoryUp == null)
            {
                throw new Exception("Categoria non trovata!");
            }
            categoryUp.catName = category.catName;
            categoryService.UpdateCategory(categoryUp);
            return Ok("Categoria aggiornata correttamente!");
        }
    }

}
