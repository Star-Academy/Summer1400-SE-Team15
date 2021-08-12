using System.IO;
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
            var connectionString = GetConnectionString("windows");
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer("Server=.;Database=SearchEngineDB;Trusted_Connection=True");
        }

        private string GetConnectionString(string operationSystem)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(getProjectBasePath(operationSystem))
                .AddJsonFile("config.json", optional: false)
                .Build();
            
            return configuration[operationSystem];
        }

        private string getProjectBasePath(string operationSystem)
        {
            if (operationSystem.Equals("windows"))
            {
                return Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.FullName;
            }else
            {
                return Directory.GetCurrentDirectory();
            }

        }
    }
}