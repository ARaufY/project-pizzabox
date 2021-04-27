using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class CustomerSingleton
  {
    private readonly PizzaBoxContext _context;

    private static CustomerSingleton _instance;

    public List<Customer> Customers { get; }

    public static CustomerSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new CustomerSingleton(context);
      }

      return _instance;
    }

    private CustomerSingleton(PizzaBoxContext context)
    {
      _context = context;
      if (Customers == null)
      {
        Customers = _context.Customers.ToList();
      }
    }

    public void addCustomer(Customer customer)
    {
      _context.Customers.Add(customer);
      _context.SaveChanges();
    }

    public List<Order> GetOrders(Customer customer)
    {
      var orders = _context.Orders.Where(o => o.Customer.Name == customer.Name);
      return orders.ToList();
    }


  }
}