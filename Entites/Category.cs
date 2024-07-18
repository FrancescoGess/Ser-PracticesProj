using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ser_PracticesProj.Entites
{
    public class Category
    {

        public int Id { get; set; }
        public String CatName { get; set; }

        public Category()
        {
        }

        public Category(int id, string catName)
        {
            Id = id;
            CatName = catName;
        }
    }
}