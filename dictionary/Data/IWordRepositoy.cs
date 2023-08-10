using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;

namespace dictionary.Data
{
    public class IWordRepositoy : DbContext
    {
        public IWordRepositoy(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordClass> WordClasses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WordProject> WordProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WordClass>().HasData(
               new WordClass
               {
                   Id = 1,
                   Name = "Noun",
               }, new WordClass
               {
                   Id = 2,
                   Name = "Verb",
               }, new WordClass
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
                    WordClassId = 1
                }, new Word
                {
                    Id = 2,
                    NorwegianWord = "flaske",
                    GermanWord = "Flasche",
                    WordClassId = 1
       
                }, new Word
                {
                    Id = 3,
                    NorwegianWord = "gå",
                    GermanWord = "gehen",
                    WordClassId = 2
                }, new Word
                {
                    Id = 4,
                    NorwegianWord = "sitte",
                    GermanWord = "sitzen",
                    WordClassId = 2
                }, new Word
                {
                    Id = 5,
                    NorwegianWord = "blå",
                    GermanWord = "blau",
                    WordClassId = 3
                }, new Word
                {
                    Id = 6,
                    NorwegianWord = "liten",
                    GermanWord = "Klein",
                    WordClassId = 3
                }

            );
           

        }

    }
}
