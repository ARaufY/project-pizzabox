using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Singletons
{

  public class StoreSingleton
  {


    private static StoreSingleton _instance;
    public List<AStore> Stores { get; }

    private readonly PizzaBoxContext _context;


    public static StoreSingleton Instance(PizzaBoxContext context)
    {

      if (_instance == null)
      {
        _instance = new StoreSingleton(context);
      }

      return _instance;

    }

    private StoreSingleton(PizzaBoxContext context)
    {
      _context = context;
      if (Stores == null)
      {
        Stores = _context.Stores.ToList();
      }
    }

    public IEnumerable<AStore> ViewOrders(AStore store)
    {
      var orders = _context.Stores
                    .Include(s => s.Orders)
                    .ThenInclude(o => o.Pizza)
                    .Where(s => s.Name == store.Name);
      return orders.ToList();
    }
  }
}
