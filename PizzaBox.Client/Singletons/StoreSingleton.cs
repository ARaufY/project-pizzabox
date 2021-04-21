using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{

  public class StoreSingleton
  {
    private const string _path = @"data/store.xml";
    private readonly FileRepository _fr = new FileRepository();
    private static StoreSingleton _instance;
    public List<AStore> Stores { get; }


    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }

        return _instance;
      }
    }

    private StoreSingleton()
    {

      List<AStore> s = new List<AStore> { new NewYorkStore(), new ChicagoStore() };
      _fr.WriteToFile<AStore>(_path, s);
      if (Stores == null)
      {

        Stores = _fr.ReadFromFile<List<AStore>>(_path);
      }


    }
  }
}
