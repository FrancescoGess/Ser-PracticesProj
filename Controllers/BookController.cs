using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ser_PracticesProj.Data;
using Ser_PracticesProj.Entites;
using Ser_PracticesProj.Repo;
using Ser_PracticesProj.Services;


namespace Ser_PracticesProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            /*var books = new List<Book>(){
                new Book (1, "Il signore degli anelli", "1954"),
                new Book (2, "Il signore degli orecchini", "1954"),
                new Book (3, "Il signore delle collane", "1954"),
                new Book (4, "Il signore dei bracciali", "1954"),
                new Book (5, "Il signore delle cavigliere", "1954"),
            };
            return Ok(books);*/
            List<Book> books = bookService.GetAll();
            if (books.IsNullOrEmpty())
            {
                return BadRequest("Lista vuota");
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Book ID non valido. ID non può essere 0 o minore.");
            }
            Book book = bookService.GetById(id);
            if (book == null)
            {
                return NotFound($"Libro con ID {id} non trovato nel database.");
            }
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Book ID non valido. ID non può essere 0 o minore.");
            }
            try
            {
                await bookService.DeleteById(id);
                return Ok("Libro eliminato con successo");
            }
            catch (Exception ex)
            {
                return BadRequest($"Errore durante l'eliminazione del libro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            bookService.CreateBook(book);
            return Ok("Libro creato con successo!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id <= 0)
            {
                return BadRequest("Book ID non valido. ID non può essere 0 o minore.");
            }

            var bookUp = bookService.GetById(id);

            if (bookUp == null)
            {
                throw new Exception("Libro non trovato!");
            }
            bookUp.title = book.title;
            bookUp.anno = book.anno;
            bookUp.description = book.description;
            bookUp.categoryId = book.categoryId;
            bookService.UpdateBook(bookUp);
            return Ok("Libro aggiornato correttamente!");
        }
    }
}