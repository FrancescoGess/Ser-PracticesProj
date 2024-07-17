using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ser_PracticesProj.Entites
{
    public class Book
    {
        public Book(int id, string title, string anno)
        {
            Id = id;
            Title = title;
            Anno = anno;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Anno { get; set; }

        public Book()
        {

        }
    }
}