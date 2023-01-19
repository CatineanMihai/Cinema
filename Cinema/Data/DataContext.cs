using Cinema.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Transactions;

namespace Cinema.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<TypeMovie> TypeMovies { get; set; }
        public DbSet<Movie> Movies { get; set; }
       

    }
}
