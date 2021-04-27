using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Size : AComponent
  {
    public override string ToString()
    {
      return $"{Name}";
    }
  }
}
