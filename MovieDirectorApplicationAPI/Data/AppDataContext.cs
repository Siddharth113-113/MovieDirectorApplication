using Microsoft.EntityFrameworkCore;
using MovieDirectorApplicationAPI.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Data
{
    public class AppDataContext:DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDirector>()
                .HasOne(b => b.Movie)
                .WithMany(ba => ba.MovieDirectors)
                .HasForeignKey(bi => bi.movieId);

            modelBuilder.Entity<MovieDirector>()
              .HasOne(b => b.Director)
              .WithMany(ba => ba.MovieDirectors)
              .HasForeignKey(bi => bi.directorName);

        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<MovieDirector> MovieDirector { get; set; }  

    }
}
