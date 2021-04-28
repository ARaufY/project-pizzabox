using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class CustomerTests
  {
    [Fact]
    public void Test_CustomerName()
    {
      var sut = new Customer() { Name = "Afa Jato" };

      var actual = sut.Name;

      Assert.True(actual.Equals("Afa Jato"));
      Assert.True(sut.ToString().Equals(actual));
      Assert.NotNull(actual);

    }
  }

}