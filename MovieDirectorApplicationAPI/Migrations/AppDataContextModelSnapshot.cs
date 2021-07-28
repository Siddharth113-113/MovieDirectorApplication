﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDirectorApplicationAPI.Data;

namespace MovieDirectorApplicationAPI.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.3.21201.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieDirectorApplicationAPI.Data.Model.Director", b =>
                {
                    b.Property<string>("directorName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("awardCount")
                        .HasColumnType("tinyint");

                    b.HasKey("directorName");

                    b.ToTable("Director");
                });

            modelBuilder.Entity("MovieDirectorApplicationAPI.Data.Model.Movie", b =>
                {
                    b.Property<int>("movieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Ratings")
                        .HasColumnType("tinyint");

                    b.Property<int>("boxOfficeCollection")
                        .HasColumnType("int");

                    b.Property<string>("movieName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("movieId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieDirectorApplicationAPI.Data.Model.MovieDirector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("directorName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("directorName");

                    b.HasIndex("movieId");

                    b.ToTable("MovieDirector");
                });

            modelBuilder.Entity("MovieDirectorApplicationAPI.Data.Model.MovieDirector", b =>
                {
                    b.HasOne("MovieDirectorApplicationAPI.Data.Model.Director", "Director")
                        .WithMany("MovieDirectors")
                        .HasForeignKey("directorName");

                    b.HasOne("MovieDirectorApplicationAPI.Data.Model.Movie", "Movie")
                        .WithMany("MovieDirectors")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieDirectorApplicationAPI.Data.Model.Director", b =>
                {
                    b.Navigation("MovieDirectors");
                });

            modelBuilder.Entity("MovieDirectorApplicationAPI.Data.Model.Movie", b =>
                {
                    b.Navigation("MovieDirectors");
                });
#pragma warning restore 612, 618
        }
    }
}