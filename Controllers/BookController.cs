using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                return NotFound("Lista vuota");
            }
            return Ok(books);
        }

        [HttpGet("{id},GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            Book book = bookService.GetById(id);
            return Ok(book);
        }

        [HttpDelete("{id},DeleteById")]
        public void DeleteById(int id)
        {
            bookService.DeleteById(id);
        }

        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            var bookDB = bookService.GetById(book.id);
            if (bookDB == null)
            {
                bookService.CreateBook(book);
                return Ok("Libro creato con successo!");
            }
            return BadRequest("Libro già esistente");
        }

        [HttpPut("{id},UpdateBook")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
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