using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : AComponent
  {

    public override string ToString()
    {
      return $"{Name}";
    }

  }
}
