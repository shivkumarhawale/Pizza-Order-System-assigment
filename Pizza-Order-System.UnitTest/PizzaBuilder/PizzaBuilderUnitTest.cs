using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza_Order_System.Application;
using Pizza_Order_System.Persistence;
using Pizza_Order_System.Persistence.Enum;

namespace Pizza_Order_System.UnitTest
{
    [TestClass]
    public class PizzaBuilderUnitTest
    {
        PizzaBuilder pizzaBuilder;

        [TestInitialize]
        public void TestInitialize()
        {
            pizzaBuilder = new PizzaBuilder();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void CreateCustomPizza()
        {
            pizzaBuilder.CreateCustomPizzaBase("Custom");
            pizzaBuilder.AddNumberOfPizza(1);
            pizzaBuilder.AddCheese();
            pizzaBuilder.AddExtraCheese();
            pizzaBuilder.AddSize(new Size() { Id = 1, Name = "small", Multiplier = 1.5m });
            pizzaBuilder.AddIngredients(new Ingredients()
            {
                Id = 1,
                Name = "Grilled Mushrooms",
                FoodType = FoodType.Veg,
                IngredientTypeId = 3,
                Price = 60,
            });

            var pizza = pizzaBuilder.GetPizza();
            pizza.Should().NotBeNull();
        }
    }
}
