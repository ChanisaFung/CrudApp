using Microsoft.EntityFrameworkCore;
using CrudApp.Models;
using CRUDApp.Models;
using System.Collections.Generic;


namespace CrudApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}

