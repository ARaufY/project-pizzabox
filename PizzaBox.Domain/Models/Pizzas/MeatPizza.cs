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
      Crust = new Crust() { Name = "New York Syle", Price = 2.0m };
    }

    public override void AddSize(Size size = null)
    {
      Size = size;
      //Size.Price = 3.0m;
      //Size = new Size() { Name = "Large", Price = 3.0m };
    }

    public override void AddToppings(params Topping[] toppings)
    {
      Toppings = new List<Topping>()
      {
        new Topping(){Name = "Marinera Sauce", Price = 1.0m},
        new Topping() { Name = "Beef", Price = 1.9m},
        new Topping() { Name = "Chicken", Price = 1.6m},
        new Topping(){Name = "Pepperoni", Price = 1.2m}

      };
    }




  }
}
