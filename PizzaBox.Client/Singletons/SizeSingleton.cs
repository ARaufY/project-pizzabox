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
  public class SizeSingleton
  {

    private readonly PizzaBoxContext _context;
    private static SizeSingleton _instance;

    public List<Size> Sizes { get; }
    public static SizeSingleton Instance(PizzaBoxContext context)
    {


      if (_instance == null)
      {
        _instance = new SizeSingleton(context);
      }

      return _instance;

    }

    /// <summary>
    /// 
    /// </summary>
    private SizeSingleton(PizzaBoxContext context)
    {
      _context = context;
      if (Sizes == null)
      {
        Sizes = _context.Sizes.ToList();
      }
    }


  }
}
