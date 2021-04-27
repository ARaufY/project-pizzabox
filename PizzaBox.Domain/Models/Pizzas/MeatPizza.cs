using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class MeatPizza : APizza
  {
    public override void AddCrust(Crust crust = null)
    {
      Crust = new Crust() { Name = "New York Syle" };
    }

    public override void AddSize(Size size = null)
    {
      Size = new Size() { Name = "Large" };
    }

    public override void AddToppings(params Topping[] toppings)
    {
      Toppings = new List<Topping>()
      {
        new Topping(){Name = "Marinera Sauce"},
        new Topping() { Name = "Beef" },
        new Topping() { Name = "Chicken" },
        new Topping(){Name = "Pepperoni"}

      };
    }


  }
}
