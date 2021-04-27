using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Storing
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;

    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Crust> Crust { get; set; }
    public DbSet<Order> Orders { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<ChicagoStore>().HasBaseType<AStore>();
      builder.Entity<NewYorkStore>().HasBaseType<AStore>();

      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<CustomPizza>().HasBaseType<APizza>();
      builder.Entity<MeatPizza>().HasBaseType<APizza>();
      builder.Entity<VeggiePizza>().HasBaseType<APizza>();

      builder.Entity<Crust>().HasKey(e => e.EntityId);
      builder.Entity<Order>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasKey(e => e.EntityId);

      builder.Entity<Topping>().HasKey(e => e.EntityId);

      builder.Entity<Customer>().HasKey(e => e.EntityId);

      builder.Entity<AStore>().HasMany<Order>(s => s.Orders).WithOne(o => o.Store);
      builder.Entity<Customer>().HasMany<Order>().WithOne(o => o.Customer);
      builder.Entity<APizza>().HasMany<Order>().WithOne(o => o.Pizza);

      // builder.Entity<Size>().HasMany<APizza>().WithOne(); // orm is creating the has
      // builder.Entity<APizza>().HasOne<Size>().WithMany();
      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { EntityId = 1, Name = "Small", Price = 1.0m },
        new Size() { EntityId = 2, Name = "Medium", Price = 2.0m },
        new Size() { EntityId = 3, Name = "Large", Price = 3.0m }
      }
      );
      SeedCrust(builder);
      SeedCustomer(builder);
      SeedToppings(builder);
      SeedStore(builder);
      //SeedPizza(builder);
    }

    private void SeedToppings(ModelBuilder builder)
    {
      builder.Entity<Topping>().HasData(new Topping[]
      {
        new Topping(){EntityId = 1, Name = "Pepperoni", Price = 1.2m},
        new Topping(){EntityId = 2, Name = "Chicken", Price = 1.6m},
        new Topping(){EntityId = 3, Name = "Beef", Price = 1.9m},
        new Topping(){EntityId = 4, Name = "Onions", Price = 0.6m}
      });

    }

    private void SeedCrust(ModelBuilder builder)
    {
      builder.Entity<Crust>().HasData(new Crust[]
          {
            new Crust() { EntityId = 1, Name = "Thin", Price = 1.0m },
            new Crust() { EntityId = 2, Name = "New York Style", Price = 2.0m },
            new Crust() { EntityId = 3, Name = "Pan", Price = 3.0m }
          }
          );
    }

    private void SeedCustomer(ModelBuilder builder)
    {
      builder.Entity<Customer>().HasData(new Customer[]
          {
            new Customer() { EntityId = 2, Name = "Sam Joe"},
            new Customer() { EntityId = 3, Name = "Dan James" },
            new Customer() { EntityId = 4, Name = "Peter Pan"}
          }
          );
    }

    private void SeedPizza(ModelBuilder builder)
    {
      builder.Entity<APizza>().HasData(new MeatPizza() { EntityId = 1 });
    }

    private void SeedStore(ModelBuilder builder)
    {
      builder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
      {
        new ChicagoStore() { EntityId = 2, Name = "Chitown Main Street" },
        new ChicagoStore() { EntityId = 3, Name = "Windy City" }
      });

      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
      {
        new NewYorkStore() { EntityId = 4, Name = "Big Apple" },
        new NewYorkStore() { EntityId = 5, Name = "Broklyn Store" }

      });

    }




  }
}
