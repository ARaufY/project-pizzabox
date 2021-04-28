using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class CustomPizza : APizza
  {
    public override void AddCrust(Crust crust = null)
    {
      Crust = crust;
    }



    public override void AddSize(Size size = null)
    {
      Size = size;
    }

    public override void AddToppings(params Topping[] toppings)
    {
      Toppings = new List<Topping>()
      {
        new Topping(){Name = "Marinera Sauce", Price = 1.0m},
        new Topping() { Name = "Cheese", Price = 1.9m},

      };
      //var t = new List<Topping>();
      Toppings.AddRange(toppings.ToList());
      //Toppings = t;
    }


  }
}
