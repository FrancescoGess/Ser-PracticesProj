using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ser_PracticesProj.Entites
{
    public class Book
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public string Anno { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }


        public Book()
        {

        }

        public Book(int id, string title, string anno, string description, Category category)
        {
            Id = id;
            Title = title;
            Anno = anno;
            Description = description;
            this.Category = category;
        }
    }
}