using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using Microsoft.Extensions.Configuration;


namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {

    private readonly IConfiguration _configuration;


    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }



    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<Crust>().HasKey(e => e.EntityId);
    }
  }
}