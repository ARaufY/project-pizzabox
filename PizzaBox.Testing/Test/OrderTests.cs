using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class OrderTests
  {

    [Fact]
    public void Test_Order()
    {
      var sut = new Order();
      var pizza = new MeatPizza();
      sut.Pizza = pizza;
      var actual = sut.Pizza;

      actual.Size.Name = "Medium";

      Assert.False(sut.Cost == 9.7m);


    }
  }

}