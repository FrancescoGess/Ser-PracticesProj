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
    public class AuthorController : ControllerBase
    {
        public readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Author> authors = authorService.GetAll();
            if (authors.IsNullOrEmpty())
            {
                return BadRequest("Lista vuota");
            }
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Author author = authorService.GetById(id);
            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await authorService.DeleteById(id);
                return Ok("Autore eliminato con successo");
            }
            catch (Exception ex)
            {
                return BadRequest($"Errore durante l'eliminazione dell'autore: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {
            var authorDB = authorService.GetByName(author.nameAuth);
            if (authorDB == null)
            {
                authorService.CreateAuthor(author);
                return Ok("Autore creato con successo!");
            }
            return BadRequest("Autore già esistente");
        }

        [HttpPut("{id},UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            var authorUp = authorService.GetById(id);
            if (authorUp == null)
            {
                throw new Exception("Autore non trovato!");
            }
            authorUp.nameAuth = author.nameAuth;
            author.address = author.address;
            authorUp.city = author.city;
            authorService.UpdateAuthor(authorUp);
            return Ok("Autore aggiornato correttamente!");
        }
    }
}