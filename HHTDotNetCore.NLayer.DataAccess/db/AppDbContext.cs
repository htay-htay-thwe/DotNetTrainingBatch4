using HHTDotNetCore.NLayer.DataAccess;
using HHTDotNetCore_ResetApiWithNLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace HHTDotNetCore.NLayer.DataAccess.db;

internal class AppDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<BlogModel> Blogs { get; set; }

}


