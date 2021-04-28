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

    private static readonly ToppingSingleton _toppingSingleton = ToppingSingleton.Instance(_context);




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

      System.Console.WriteLine("Custom or pre-made (1 - Custom, 2 - Premade):");
      int choice = int.Parse(Console.ReadLine());
      if (choice == 1)
      {
        order.Pizza = SelectCustomPizza();
      }
      else
      {
        System.Console.WriteLine("Please select a pizza from the list:");
        var pp = new List<APizza>();
        for (int i = 0; i < 3; i++)
        {

          System.Console.WriteLine(_pizzaSingleton.Pizzas[i]);
        }

        order.Pizza = SelectPizza();
      }

      PrintOrder(order.Pizza);


      _orderSingleton.addOrder(order);

      System.Console.WriteLine($"Your order total is: {order.Pizza.Size.Price + order.Pizza.Crust.Price + order.Pizza.Toppings.Sum(t => t.Price)}");

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

      System.Console.WriteLine("Please Select a Store: ");
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

    private static Topping SelectToppings()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }
      var toppings = new List<Topping>();

      return _toppingSingleton.Toppings[input - 1];
    }

    private static APizza SelectPizza()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }
      System.Console.WriteLine("Select a size:");
      PrintItems(_sizeSingleton.Sizes);
      var size = SelectSize();

      var pizza = _pizzaSingleton.Pizzas[input - 1];
      pizza.Size = size;



      return pizza;
    }

    private static APizza SelectCustomPizza()
    {

      var pizza = new CustomPizza();

      System.Console.WriteLine("Select a crust:");
      PrintCrust();
      var crust = SelectCrust();
      System.Console.WriteLine("Select a size:");
      PrintItems(_sizeSingleton.Sizes);
      var size = SelectSize();

      var toppingCount = 0;

      var toppings = new List<Topping>();
      System.Console.WriteLine("Select toppings:");
      PrintItems(_toppingSingleton.Toppings);
      toppings.Add(SelectToppings());
      System.Console.WriteLine("Add more toppings? (Y/N) ");
      var stop = Console.ReadLine();
      while (stop != "n")
      {
        PrintItems(_toppingSingleton.Toppings);
        toppings.Add(SelectToppings());
        toppingCount++;
        if (toppingCount == 2)
        {
          System.Console.WriteLine("You can no longer add toppings!");
          break;
        }
        System.Console.WriteLine("Add another topping? (Y/N)");
        stop = Console.ReadLine();
      }

      pizza.AddCrust(crust);
      pizza.AddSize(size);
      pizza.AddToppings(toppings.ToArray());


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


      return _storeSingleton.Stores[input - 1];
    }
  }
}
