using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SearchEngineApi
{
    public class SearchEngineContext : DbContext
    {
        public DbSet<WordModel> Words { get; set; }
        public DbSet<Posting> Postings { get; set; }

        private static IConfiguration _configuration;

        public SearchEngineContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return _configuration[_configuration["method"]];
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