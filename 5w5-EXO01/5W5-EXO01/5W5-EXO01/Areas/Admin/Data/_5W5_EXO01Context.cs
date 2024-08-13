using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _5W5_EXO01.Models;

namespace _5W5_EXO01.Data
{
    public class _5W5_EXO01Context : DbContext
    {
        public _5W5_EXO01Context (DbContextOptions<_5W5_EXO01Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatModel>().HasData(
                new CatModel { id = 1, name = "Felix", image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHjQzMaiAHTUrzQAcq0hxckWeFKaMT-9UA3w&s" },
                new CatModel { id = 2, name = "Garfield", image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzX9A_f_jDYExfolsAhVX7IgctPaA9qU0KUg&s" },
                new CatModel { id = 3, name = "Whiskers", image = "https://images.unsplash.com/photo-1608848461950-0fe51dfc41cb?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxleHBsb3JlLWZlZWR8MXx8fGVufDB8fHx8fA%3D%3D" });
        }

        public DbSet<_5W5_EXO01.Models.CatModel> CatModel { get; set; } = default!;
    }

   
}
