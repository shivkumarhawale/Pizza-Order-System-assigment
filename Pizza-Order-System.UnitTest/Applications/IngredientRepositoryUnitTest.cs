using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pizza_Order_System.Application;
using Pizza_Order_System.Persistence;
using Pizza_Order_System.Persistence.Enum;
using Pizza_Order_System.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contract = Pizza_Order_System.Application.Contract;

namespace Pizza_Order_System.UnitTest.Applications
{
    [TestClass]
    public class IngredientRepositoryUnitTest
    {
        Mock<ISeedDataRepository> mockSeedDataRepository = null;
        IngredientRepository ingredientRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            mockSeedDataRepository = new Mock<ISeedDataRepository>(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };
            ingredientRepository = new IngredientRepository(mockSeedDataRepository.Object);

        }

        [TestMethod]
        public async Task GetAllIngredientsAsync()
        {
            // Arrange
            var result = new List<Ingredients>() {
             new Ingredients()
             {
                 Id = 5,
                 Name ="Cheese",
                 FoodType = FoodType.Veg,
                 IngredientTypeId = 4,
                 Price = 90
             }
            };

            mockSeedDataRepository.Setup(x => x.GetAllIngredientsAsync()).ReturnsAsync(result);

            // act
            var actualResult = await ingredientRepository.GetAllIngredientsAsync();

            // assert
            actualResult.Should().NotBeNull();
            actualResult.Equals(new Contract.Ingredients()
            {
                Id = 5,
                Name = "Cheese"
            });
        }

        [TestMethod]
        public async Task GetIngredientsByTypeIdAsync()
        {
            // Arrange
            var result = new List<Ingredients>() {
             new Ingredients()
             {
                 Id = 5,
                 Name ="Cheese",
                 FoodType = FoodType.Veg,
                 IngredientTypeId = 4,
                 Price = 90
             }
            };

            mockSeedDataRepository.Setup(x => x.GetAllIngredientsAsync()).ReturnsAsync(result);

            // act
            var actualResult = await ingredientRepository.GetIngredientsByTypeIdAsync(4);

            // assert
            actualResult.Should().NotBeNull();
            actualResult.Equals(new Contract.Ingredients()
            {
                Id = 5,
                Name = "Cheese"
            });
        }

        [TestMethod]
        public void GetIngredientsByTypeIdAsync_Throw_Exception()
        {
            // assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async ()
                => await ingredientRepository.GetIngredientsByTypeIdAsync(0));
        }

        [TestMethod]
        public async Task GetAllIngredientTypesAsync()
        {
            // Arrange
            var result = new List<IngredientType>() {
             new IngredientType(){
                 Id = 1,
                 Name = "Crust"
             } 
            };

            mockSeedDataRepository.Setup(x => x.GetAllIngredientTypesAsync()).ReturnsAsync(result);

            // act
            var actualResult = await ingredientRepository.GetAllIngredientTypesAsync();

            // assert
            actualResult.Should().NotBeNull();
            actualResult.Equals(new Contract.IngredientType()
            {
                Id = 1,
                Name = "Crust"
            });
        }

        [TestMethod]
        public async Task GetAllSizeAsync()
        {
            // Arrange
            var result = new List<Size>() {
             new Size() {
                  Id=1,
                  Name="Small",
                  Multiplier=1
             }
            };

            mockSeedDataRepository.Setup(x => x.GetSizeAsync()).ReturnsAsync(result);

            // act
            var actualResult = await ingredientRepository.GetSizeAsync();

            // assert
            actualResult.Should().NotBeNull();
            actualResult.Equals(new Contract.Size()
            {
                Id = 1,
                Name = "Small"
            });
        }
    }
}
