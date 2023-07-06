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
        public DbSet<WordProject> WordsProjects { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Word>().HasData(
        //        new Word
        //        {
        //            Id = 1,
        //            NorwegianWord = "hus",
        //            GermanWord = "Haus"
        //        },new Word
        //        {
        //            Id = 2,
        //            NorwegianWord = "flaske",
        //            GermanWord = "Flasche"
        //        },new Word
        //        {
        //            Id = 3,
        //            NorwegianWord = "gå",
        //            GermanWord = "gehen"
        //        },new Word
        //        {
        //            Id = 4,
        //            NorwegianWord = "sitte",
        //            GermanWord = "sitzen"
        //        },new Word
        //        {
        //            Id = 5,
        //            NorwegianWord = "blå",
        //            GermanWord = "blau"
        //        },new Word
        //        {
        //            Id = 6,
        //            NorwegianWord = "liten",
        //            GermanWord = "Klein"
        //        }

        //    );
        //    modelBuilder.Entity<Category>().HasData(
        //        new Category
        //        {
        //            Id = 1,

        //        }
        //    );
            
        //}

    }
}
