using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHTDotNetCore.ConsoleApp.Dtos;
using HHTDotNetCore.ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;

namespace HHTDotNetCore.ConsoleApp.EFCoreExmaples
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogDto> Blogs { get; set; }

    }
}
