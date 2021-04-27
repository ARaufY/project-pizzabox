using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaSingleton
  {

    private static PizzaSingleton _instance;

    private readonly PizzaBoxContext _context;

    public List<APizza> Pizzas { get; set; }
    public static PizzaSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new PizzaSingleton(context);
      }

      return _instance;

    }

    /// <summary>
    /// 
    /// </summary>
    private PizzaSingleton(PizzaBoxContext context)
    {
      _context = context;

      Pizzas = _context.Pizzas.ToList();

    }


  }
}
