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
  public class CrustSingleton
  {

    private readonly PizzaBoxContext _context;
    private static CrustSingleton _instance;

    public List<Crust> Crusts { get; }
    public static CrustSingleton Instance(PizzaBoxContext context)
    {


      if (_instance == null)
      {
        _instance = new CrustSingleton(context);
      }

      return _instance;

    }

    /// <summary>
    /// 
    /// </summary>
    private CrustSingleton(PizzaBoxContext context)
    {
      _context = context;
      if (Crusts == null)
      {
        Crusts = _context.Crust.ToList();
      }
    }


  }
}
