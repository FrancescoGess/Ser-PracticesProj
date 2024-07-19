using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ser_PracticesProj.Entites
{
    public class Author
    {

        public int id { get; set; }
        public String nameAuth { get; set; }
        public String address { get; set; }
        public String city { get; set; }
        [JsonIgnore]
        public List<Book>? books { get; set; }


        public Author()
        {
        }

        public Author(int id, string nameAuth, string address, string city, List<Book>? books)
        {
            this.id = id;
            this.nameAuth = nameAuth;
            this.address = address;
            this.city = city;
            this.books = books;
        }
    }
}