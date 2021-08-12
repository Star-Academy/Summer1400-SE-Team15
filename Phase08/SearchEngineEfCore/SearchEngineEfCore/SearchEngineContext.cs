using System;
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
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(GetProjectBasePath())
                .AddJsonFile("config.json", optional: false)
                .Build();
            
            return configuration[configuration["methode"]];
        }

        private string GetProjectBasePath()
        {
            var projectBasePath = Directory.GetCurrentDirectory();
            var length = projectBasePath.LastIndexOf("bin", StringComparison.Ordinal);
            
            if (length != -1)
            {
                projectBasePath = projectBasePath.Substring(0, length);
            }

            return projectBasePath;
        }
    }
}