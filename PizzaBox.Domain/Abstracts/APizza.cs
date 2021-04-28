using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  public abstract class APizza : AModel
  {
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Topping> Toppings { get; set; }

    public long SizeEntityId { get; set; }
    public long ToppingEntityId { get; set; }


    protected virtual void Factory()
    {
      AddCrust();
      AddSize();
      AddToppings();
    }

    protected APizza()
    {
      Factory();
    }
    public abstract void AddSize(Size size = null);

    public abstract void AddCrust(Crust crust = null);




    public abstract void AddToppings(params Topping[] toppings);

    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{separator}");
      }

      return $"{Size} - {Crust} - {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }
  }
}
