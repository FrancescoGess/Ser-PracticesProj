using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ser_PracticesProj.Entites;

namespace Ser_PracticesProj.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}