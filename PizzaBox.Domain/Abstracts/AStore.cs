using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using System.Xml.Serialization;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Domain.Abstracts
{

  [XmlInclude(typeof(ChicagoStore))]
  [XmlInclude(typeof(NewYorkStore))]
  public abstract class AStore : AModel
  {
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
    // public long CustomerEntityId { get; set; }
    // public long OrderEntityId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return Name;
    }
  }
}
