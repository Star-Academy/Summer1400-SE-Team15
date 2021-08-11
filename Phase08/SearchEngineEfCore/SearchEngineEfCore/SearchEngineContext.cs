using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SearchEngineEfCore
{
    public class SearchEngineContext : DbContext
    {
        public DbSet<WordModel> Words { get; set; }
        public DbSet<Posting> Postings { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false)
                .Build();
            
            optionsBuilder.UseSqlServer(configuration["standard"]);
        }
    }
}