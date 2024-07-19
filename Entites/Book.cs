using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ser_PracticesProj.Entites
{
    public class Book
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public string Anno { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }


        public Book()
        {

        }
        public Book(int id, string title, string anno, string description, Category category, int categoryId)
        {
            Id = id;
            Title = title;
            Anno = anno;
            Description = description;
            Category = category;
            CategoryId = categoryId;
        }
    }
}