using System.Collections.Generic;
using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing;
using System.Linq;

namespace PizzaBox.Client
{

  public class Program
  {

    private static readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance(_context);
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance(_context);

    private static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance(_context);
    private static readonly SizeSingleton _sizeSingleton = SizeSingleton.Instance(_context);

    private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance(_context);
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance(_context);




    private static void Main()
    {
      Run();
    }


    private static void Run()
    {
      var order = new Order();

      Console.WriteLine("Welcome to PizzaBox");
      PrintItems(_customerSingleton.Customers);

      order.Customer = SelectCustomer();
      order.Store = SelectStore();

      //order.Pizza.Crust = SelectCrust();
      //order.Pizza.Size = SelectSize();
      order.Pizza = SelectPizza();


      _orderSingleton.addOrder(order);

      //var orders = _context.Orders.Where(o => o.Customer.Name == order.Customer.Name);

      //PrintItems(orders);
    }

    private static void PrintOrder(APizza pizza)
    {
      Console.WriteLine($"Your order is: {pizza}");
    }



    private static Size SelectSize()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);
      if (!valid)
      {
        return null;
      }

      var size = _sizeSingleton.Sizes[input - 1];

      PrintItems(_crustSingleton.Crusts);

      return _sizeSingleton.Sizes[input - 1];

    }

    private static Customer SelectCustomer()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }

      var customer = _customerSingleton.Customers[input - 1];

      PrintItems(_storeSingleton.Stores);

      return customer;
    }
    private static Crust SelectCrust()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);
      if (!valid)
      {
        return null;
      }

      var crust = _crustSingleton.Crusts[input - 1];

      PrintItems(_sizeSingleton.Sizes);

      return _crustSingleton.Crusts[input - 1];

    }


    private static void PrintItems(IEnumerable<object> items)
    {
      var index = 0;

      foreach (var item in items)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    private static void PrintCrust()
    {
      var index = 0;

      foreach (var item in _crustSingleton.Crusts)
      {
        System.Console.WriteLine($"{++index} - {item}");
      }
    }


    private static APizza SelectPizza()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }

      var pizza = _pizzaSingleton.Pizzas[input - 1];

      // System.Console.WriteLine("Select a crust:");
      // SelectCrust();
      //System.Console.WriteLine("Select a size:");
      //SelectSize();

      PrintOrder(pizza);

      return pizza;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }

      PrintItems(_pizzaSingleton.Pizzas);

      return _storeSingleton.Stores[input - 1];
    }
  }
}
