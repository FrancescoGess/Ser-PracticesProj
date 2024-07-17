using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ser_PracticesProj.Entites;

namespace Ser_PracticesProj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var books = new List<Book>(){
                new Book (1, "Il signore degli anelli", "1954"),
            };
            return Ok(books);
        }
    }
}