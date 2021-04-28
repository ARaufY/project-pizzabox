using Xunit;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Testing.Tests
{
  public class StoreTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[] { new ChicagoStore() },
      new object[] { new NewYorkStore() }
    };
    [Fact]
    public void Test_ChicagoStore()
    {
      // arrange
      var sut = new ChicagoStore();


      // act
      var actual = sut.Name;

      // Assert
      Assert.True(actual.Equals("ChicagoStore"));
      Assert.True(sut.ToString().Equals(actual));
    }

    [Fact]
    public void Test_NewYorkStore()
    {
      var sut = new NewYorkStore();

      var actual = sut.Name;

      Assert.True(actual.Equals("NewYorkStore"));
      Assert.True(sut.ToString().Equals(actual));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="store"></param>
    [Theory]
    [MemberData(nameof(values))]
    public void Test_StoreName(AStore store)
    {
      Assert.NotNull(store.Name);
      Assert.Equal(store.Name, store.ToString());
    }
  }
}