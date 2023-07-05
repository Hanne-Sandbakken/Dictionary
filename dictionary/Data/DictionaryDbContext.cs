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
        
    }
}
