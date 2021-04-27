
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client
{
  public class OrderSingleton
  {
    private readonly PizzaBoxContext _context;

    private static OrderSingleton _instance;

    public List<Order> Orders { get; }

    public static OrderSingleton Instance(PizzaBoxContext context)
    {

      if (_instance == null)
      {
        _instance = new OrderSingleton(context);
      }
      return _instance;

    }

    private OrderSingleton(PizzaBoxContext context)
    {
      _context = context;
      if (Orders == null)
      {
        Orders = _context.Orders.ToList();
      }
    }

    public void addOrder(Order order)
    {
      order.Store = _context.Stores.FirstOrDefault(s => s.EntityId == order.Store.EntityId);
      _context.Orders.Add(order);
      _context.SaveChanges();
    }
  }
}