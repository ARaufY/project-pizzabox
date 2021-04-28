using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class ToppingSingleton
  {

    private readonly PizzaBoxContext _context;
    private static ToppingSingleton _instance;

    public List<Topping> Toppings { get; }
    public static ToppingSingleton Instance(PizzaBoxContext context)
    {


      if (_instance == null)
      {
        _instance = new ToppingSingleton(context);
      }

      return _instance;

    }

    /// <summary>
    /// 
    /// </summary>
    private ToppingSingleton(PizzaBoxContext context)
    {
      _context = context;
      if (Toppings == null)
      {
        Toppings = _context.Toppings.ToList();
      }
    }


  }
}
