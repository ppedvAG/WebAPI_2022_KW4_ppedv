using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControllerSample.Models;

namespace ControllerSample.Data
{
    public class MovieDbContext : DbContext //EFCore 
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<ControllerSample.Models.Movie> Movie { get; set; } //Table Movie alias DbSet
    }
}
