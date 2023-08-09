using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;

namespace dictionary.Data
{
    public class DictionaryDbContext : DbContext
    {
        public DictionaryDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Word> Words { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WordProject> WordProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = 1,
                   Name = "Noun",
               }, new Category
               {
                   Id = 2,
                   Name = "Verb",
               }, new Category
               {
                   Id = 3,
                   Name = "Adjective",
               }
           );
            modelBuilder.Entity<Word>().HasData(
                new Word
                {
                    Id = 1,
                    NorwegianWord = "hus",
                    GermanWord = "Haus",
                    CategoryId = 1
                }, new Word
                {
                    Id = 2,
                    NorwegianWord = "flaske",
                    GermanWord = "Flasche",
                    CategoryId = 1
       
                }, new Word
                {
                    Id = 3,
                    NorwegianWord = "gå",
                    GermanWord = "gehen",
                    CategoryId = 2
                }, new Word
                {
                    Id = 4,
                    NorwegianWord = "sitte",
                    GermanWord = "sitzen",
                    CategoryId = 2
                }, new Word
                {
                    Id = 5,
                    NorwegianWord = "blå",
                    GermanWord = "blau",
                    CategoryId = 3
                }, new Word
                {
                    Id = 6,
                    NorwegianWord = "liten",
                    GermanWord = "Klein",
                    CategoryId = 3
                }

            );
           

        }

    }
}
