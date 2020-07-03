using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using VivoApi.Entities;
namespace VivoApi.Data
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<Users> Users { get; set; }
    protected readonly IConfiguration Configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   base.OnModelCreating(modelBuilder);
    //   modelBuilder.Entity<User>().HasKey(i => i.Id);
    // }

    // connection with database
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    }
  }

}