using assignment1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace assignment1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
