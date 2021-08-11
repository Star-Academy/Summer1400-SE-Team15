using Microsoft.EntityFrameworkCore;

namespace SearchEngineEfCore
{
    public class SearchEngineContext : DbContext
    {
        public DbSet<WordModel> Words { get; set; }
        public DbSet<Posting> Postings { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=.;Database=SearchEngineDB;User Id=sa;Password=YourPassword");
        }
    }
}