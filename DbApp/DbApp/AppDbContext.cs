using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace DbApp
{
    class AppDbContext : DbContext
    {

        public AppDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                string file = Path.Combine(FileSystem.AppDataDirectory, "mydb.db");
                optionsBuilder.UseSqlite($"filename={file}");
                
            }
            catch (NotImplementedInReferenceAssemblyException)
            {
                optionsBuilder.UseSqlite("nodb.db");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
