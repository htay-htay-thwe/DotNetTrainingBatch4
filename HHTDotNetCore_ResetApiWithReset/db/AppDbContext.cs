
using HHTDotNetCore_ResetApiWithNLayer.Models;
using HtayHtayThwe_RestAPI;
using Microsoft.EntityFrameworkCore;
namespace HHTDotNetCore_ResetApiWithNLayer.db;

    internal class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }

    }


