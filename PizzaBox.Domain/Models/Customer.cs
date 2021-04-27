
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Customer : AModel
  {
    public string Name { get; set; }

    // public ICollection<Order> Orders { get; set; }
    // public ICollection<AStore> Stores { get; set; }
    // public long OrderEntityId { get; set; }
    // public long StoreEntiryId { get; set; }

    public override string ToString()
    {
      return $"{Name}";
    }

  }
}