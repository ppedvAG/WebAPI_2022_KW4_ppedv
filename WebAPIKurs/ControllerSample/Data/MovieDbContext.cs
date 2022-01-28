using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControllerSample.Entities;

namespace ControllerSample.Data
{
    public class MovieDbContext : DbContext //EFCore 
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } //Table Movie alias DbSet
    }
}
