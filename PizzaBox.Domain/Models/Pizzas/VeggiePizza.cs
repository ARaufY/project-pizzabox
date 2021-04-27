using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class VeggiePizza : APizza
  {
    public override void AddCrust(Crust crust = null)
    {
      Crust = new Crust() { Name = "Thin" };
    }

    public override void AddSize(Size size = null)
    {
      Size = new Size() { Name = "Medium" };
    }

    public override void AddToppings(params Topping[] toppings)
    {
      Toppings = new List<Topping>()
      {
        new Topping(){Name = "Marinera Sauce"},
        new Topping() { Name = "Spinach" },
        new Topping() { Name = "Onions" },
        new Topping(){Name = "Marinera Sauce"},
        new Topping(){Name = "Mashrooms"}

      };
    }


  }
}
