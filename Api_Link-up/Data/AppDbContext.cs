using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Link_up.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Link_up.Data
{
    public class AppDbContext : DbContext
    {   
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Add this DbSet property to represent the Coders table
        public DbSet<Coder> Coders { get; set; }

    }
}