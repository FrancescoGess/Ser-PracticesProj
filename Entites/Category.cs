using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ser_PracticesProj.Entites
{
    public class Category
    {
        public int id { get; set; }
        public String catName { get; set; }
        [JsonIgnore]
        public List<Book>? books { get; set; }

        public Category(int id, string catName, List<Book>? books)
        {
            this.id = id;
            this.catName = catName;
            this.books = books;
        }

        public Category()
        {
        }
    }
}