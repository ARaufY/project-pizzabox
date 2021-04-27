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
      Toppings.AddRange(toppings);
    }


  }
}
