using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ser_PracticesProj.Entites
{
    public class Category
    {
        public int Id { get; set; }
        public String CatName { get; set; }
        [JsonIgnore]
        public List<Book>? Books { get; set; }

        public Category()
        {
        }

        public Category(int id, string catName, List<Book> books)
        {
            Id = id;
            CatName = catName;
            Books = books;
        }
    }
}