using Xunit;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using System.Linq;

namespace PizzaBox.Testing.Tests
{
  public class PizzaTests
  {
    [Fact]
    public void Test_MeatPizza()
    {
      // arrange
      var sut = new MeatPizza();


      // act
      List<Topping> actual = sut.Toppings;
      var toppings = new List<Topping>()
      {
        new Topping(){Name = "Marinera Sauce"},
        new Topping() { Name = "Beef" },
        new Topping() { Name = "Chicken" },
        new Topping(){Name = "Pepperoni"}
      };

      var trueCount = 0;
      for (int i = 0; i < actual.Count; i++)
      {
        if (actual[i].Name == toppings[i].Name)
          trueCount++;
      }


      // Assert
      Assert.True(actual.Count != 0);
      Assert.NotNull(actual);
      Assert.True(trueCount == actual.Count);
      //Assert.True(sut.ToString().Equals(actual));
    }

    [Fact]
    public void Test_VeggiePizza()
    {
      var sut = new VeggiePizza();


      List<Topping> actual = sut.Toppings;
      var toppings = new List<Topping>()
      {
        new Topping(){Name = "Marinera Sauce"},
        new Topping() { Name = "Spinach" },
        new Topping() { Name = "Onions" },
        new Topping(){Name = "Marinera Sauce"},
        new Topping(){Name = "Mashrooms"}

      };

      var size = sut.Size;

      var trueCount = 0;
      for (int i = 0; i < actual.Count; i++)
      {
        if (actual[i].Name == toppings[i].Name)
          trueCount++;
      }


      // Assert
      Assert.True(actual.Count != 0);

      Assert.True(trueCount == actual.Count);
      Assert.True(sut.Size.Name == "Medium");
    }

    [Fact]
    public void Test_VeggiePizza_NotNull()
    {
      var sut = new VeggiePizza();
      List<Topping> actual = sut.Toppings;

      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_CustomPizza()
    {
      var sut = new CustomPizza();
      sut.AddCrust(new Crust() { Name = "Thin" });

      sut.AddSize(new Size() { Name = "Large" });

      var actual = sut.Crust;


      //Assert.True(sut.Size.Name == "Large");
      Assert.True(actual.Name == "Thin");


    }


  }
}