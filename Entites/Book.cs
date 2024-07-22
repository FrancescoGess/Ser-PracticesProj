using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ser_PracticesProj.Entites
{
    public class Book
    {

        public int id { get; set; }
        public string title { get; set; }
        public string anno { get; set; }
        public string description { get; set; }

        [JsonIgnore]
        public Category? category { get; set; }
        public int categoryId { get; set; }
        public int authorId { get; set; }

        public Book()
        {

        }
        public Book(int id, string title, string anno, string description, Category? category, int categoryId, int authorId)
        {
            this.id = id;
            this.title = title;
            this.anno = anno;
            this.description = description;
            this.category = category;
            this.categoryId = categoryId;
            this.authorId = authorId;
        }
    }
}