using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pizza_Order_System.Application;
using Pizza_Order_System.Application.Contract.Request;
using Pizza_Order_System.Application.CustomException;
using Pizza_Order_System.Persistence;
using Pizza_Order_System.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contract = Pizza_Order_System.Application.Contract;

namespace Pizza_Order_System.UnitTest.Applications
{
    [TestClass]
    public class PizzaRepositoryUnitTest
    {
        Mock<ISeedDataRepository> mockSeedDataRepository = null;
        Mock<IPizzaBuilder> mockPizzaBuilder = null;

        PizzaRepository pizzaRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            mockSeedDataRepository = new Mock<ISeedDataRepository>(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };
            mockPizzaBuilder = new Mock<IPizzaBuilder>(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };

            pizzaRepository = new PizzaRepository(mockSeedDataRepository.Object, mockPizzaBuilder.Object);

        }

        [TestMethod]
        public async Task GetPizzasAsync()
        {
            // Arrange
            var result = new List<Pizza>() {
             new Pizza
            {
                Id = 1,
                Name = "Veggie",
                Description = "Veggie Pizza for vegitarians",
                Price = 100,
                ImageUrl = "",
                CategoriesId = 1,
                Ingredients = new List<PizzaIngredients>()
                    {
                        new PizzaIngredients()
                        {
                            IngredientId = 1,
                            PizzaId = 1
                        }
                    }
            }
            };

            mockSeedDataRepository.Setup(x => x.GetPizzasAsync()).ReturnsAsync(result);

            // act
            var actualResult = await pizzaRepository.GetPizzasAsync();

            // assert
            actualResult.Should().NotBeNull();
            mockSeedDataRepository.Verify(x => x.GetPizzasAsync(), Times.Once);
        }

        [TestMethod]
        public async Task GetPizzasByIdAsync()
        {
            // Arrange
            var result = new List<Pizza>() {
             new Pizza
            {
                Id = 1,
                Name = "Veggie",
                Description = "Veggie Pizza for vegitarians",
                Price = 100,
                ImageUrl = "",
                CategoriesId = 1,
                Ingredients = new List<PizzaIngredients>()
                    {
                        new PizzaIngredients()
                        {
                            IngredientId = 1,
                            PizzaId = 1
                        }
                    }
            }
            };

            mockSeedDataRepository.Setup(x => x.GetPizzasAsync()).ReturnsAsync(result);

            // act
            var actualResult = await pizzaRepository.GetPizzaByIdAsync(1);

            // assert
            actualResult.Should().NotBeNull();
            mockSeedDataRepository.Verify(x => x.GetPizzasAsync(), Times.Once);
        }

        [TestMethod]
        public void GetPizzasByIdAsync_Throw_Exception()
        {
            // assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async ()
                => await pizzaRepository.GetPizzaByIdAsync(0));
        }

        [TestMethod]
        public async Task CreateCustomAndSavePizzOrder()
        {
            // Arrange
            var result = new List<Pizza>() {
             new Pizza
            {
                Id = 1,
                Name = "Veggie",
                Description = "Veggie Pizza for vegitarians",
                Price = 100,
                ImageUrl = "",
                CategoriesId = 1,
                Ingredients = new List<PizzaIngredients>()
                    {
                        new PizzaIngredients()
                        {
                            IngredientId = 1,
                            PizzaId = 1
                        }
                    }
            }};

            var request = new CreatePizzaRequest()
            {
                Name = "Veggie",
                IsAddCheese = true,
                IsAddExtraCheese = true,
                Size = 1,
                NumberOfPizza = 1,
                PizzaIngredientsId = new List<int>() {
                    1,2
                }
            };

            mockSeedDataRepository.Setup(x => x.SaveAsync(It.IsAny<Pizza>())).ReturnsAsync(1);

            // act
            var actualResult = await pizzaRepository.CreateCustomAndSavePizzOrder(request);

            // assert
            actualResult.Should().NotBeNull();
            mockSeedDataRepository.Verify(x => x.SaveAsync(It.IsAny<Pizza>()), Times.Once);
            mockPizzaBuilder.Verify(x => x.CreateCustomPizzaBase(It.IsAny<string>()), Times.Once);
            mockPizzaBuilder.Verify(x => x.AddSize(It.IsAny<Size>()), Times.Once);
            mockPizzaBuilder.Verify(x => x.AddCheese(), Times.Once);
            mockPizzaBuilder.Verify(x => x.AddExtraCheese(), Times.Once);
            mockPizzaBuilder.Verify(x => x.AddIngredients(It.IsAny<Ingredients>()), Times.AtLeast(2));
            mockPizzaBuilder.Verify(x => x.AddNumberOfPizza(It.IsAny<int>()), Times.Once);
            mockPizzaBuilder.Verify(x => x.GetPizza(), Times.Once);
        }

        [TestMethod]
        public void CreateCustomAndSavePizzOrder_Throw_Exception()
        {
            // assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async ()
                => await pizzaRepository.CreateCustomAndSavePizzOrder(null));
        }

        [TestMethod]
        public async Task CreateAndSavePizzOrder()
        {
            // Arrange
            var request = new CreatePizzaRequest()
            {
                Name = "Veggie",
                IsAddCheese = true,
                IsAddExtraCheese = true,
                Size = 1,
                NumberOfPizza = 1,
                PizzaIngredientsId = new List<int>() {
                    1,2
                }
            };

            mockSeedDataRepository.Setup(x => x.SaveAsync(It.IsAny<Pizza>())).ReturnsAsync(1);

            // act
            var actualResult = await pizzaRepository.CreateAndSavePizzOrder(request, 1);

            // assert
            actualResult.Should().NotBeNull();
            mockSeedDataRepository.Verify(x => x.SaveAsync(It.IsAny<Pizza>()), Times.Once);
            mockPizzaBuilder.Verify(x => x.CreateSelectdPizza(It.IsAny<Pizza>()), Times.Once);
            mockPizzaBuilder.Verify(x => x.AddSize(It.IsAny<Size>()), Times.Once);
            mockPizzaBuilder.Verify(x => x.AddCheese(), Times.Once);
            mockPizzaBuilder.Verify(x => x.AddExtraCheese(), Times.Once);
            mockPizzaBuilder.Verify(x => x.AddIngredients(It.IsAny<Ingredients>()), Times.AtLeast(2));
            mockPizzaBuilder.Verify(x => x.AddNumberOfPizza(It.IsAny<int>()), Times.Once);
            mockPizzaBuilder.Verify(x => x.GetPizza(), Times.Once);
        }

        [TestMethod]
        public void CreateAndSavePizzOrder_Throw_Exception()
        {
            // assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async ()
                => await pizzaRepository.CreateAndSavePizzOrder(null, 1));
        }

        [TestMethod]
        public void CreateAndSavePizzOrder_Throw_Exception_IF_PizzaId_Not_Selected()
        {
            // Arrange
            var request = new CreatePizzaRequest()
            {
                Name = "Veggie",
                IsAddCheese = true,
                IsAddExtraCheese = true,
                Size = 1,
                NumberOfPizza = 1,
                PizzaIngredientsId = new List<int>() {
                    1,2
                }
            };
            // assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async ()
                => await pizzaRepository.CreateAndSavePizzOrder(request, 1));
        }

        [TestMethod]
        public void CreateAndSavePizzOrder_Throw_Exception_IF_PizzaId_Not_Found()
        {
            // Arrange
            var request = new CreatePizzaRequest()
            {
                Name = "Veggie",
                IsAddCheese = true,
                IsAddExtraCheese = true,
                Size = 1,
                NumberOfPizza = 1,
                PizzaIngredientsId = new List<int>() {
                    1,2
                }
            };
            // assert
            Assert.ThrowsExceptionAsync<PizzaNotFoundException>(async ()
                => await pizzaRepository.CreateAndSavePizzOrder(request, 10));
        }
    }
}
