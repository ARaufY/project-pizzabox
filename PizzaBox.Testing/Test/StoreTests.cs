using Xunit;
using PizzaBox.Domain.Models.Stores;
namespace PizzaBox.Testing.Tests
{
    public class StoreTests{
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
    }
}