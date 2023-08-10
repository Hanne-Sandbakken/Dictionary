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
                    no = "hus",
                    de = "Haus",
                    WordClassId = 1
                }, new Word
                {
                    Id = 2,
                    no = "flaske",
                    de = "Flasche",
                    WordClassId = 1
       
                }, new Word
                {
                    Id = 3,
                    no = "gå",
                    de = "gehen",
                    WordClassId = 2
                }, new Word
                {
                    Id = 4,
                    no = "sitte",
                    de = "sitzen",
                    WordClassId = 2
                }, new Word
                {
                    Id = 5,
                    no = "blå",
                    de = "blau",
                    WordClassId = 3
                }, new Word
                {
                    Id = 6,
                    no = "liten",
                    de = "Klein",
                    WordClassId = 3
                }

            );
           

        }

    }
}
