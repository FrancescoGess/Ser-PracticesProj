using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet(Name = "Book")]
        public async Task<IActionResult> GetAll()
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
            return Ok(books);
        }


        [HttpGet("{Id}")]
        public Book GetById(int Id)
        {
            return bookService.GetById(Id);
        }


        [HttpDelete("{Id}")]
        public void DeleteById(int Id)
        {
            bookService.DeleteById(Id);
        }

        [HttpPost]
        public void CreateBook([FromBody] Book book)
        {
            bookService.CreateBook(book);
        }



    }
}