using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pizza_Order_System.Application;
using Pizza_Order_System.Application.Contract;
using Pizza_Order_System.Application.Contract.Request;
using Pizza_Order_System.Application.Contract.Response;
using Pizza_Order_System.Application.CustomException;
using Pizza_Order_System.Controllers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Pizza_Order_System.UnitTest.Controllers
{
    [TestClass]
    public class PizzaControllerUnitTest
    {
        Mock<IPizzaRepository> mockPizzaRepository = null;
        PizzaController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            mockPizzaRepository = new Mock<IPizzaRepository>(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };
            controller = new PizzaController(mockPizzaRepository.Object);

        }

        [TestMethod]
        public async Task Get_All_Pizza()
        {
            // Arrange
            var result = new List<Pizza>() {
             new Pizza(){
                  Id = 1,
                Name = "Veggie",
                Description = "Veggie Pizza for vegitarians",
                Price = 100,
                ImageUrl = "",
                Ingredients = new List<Ingredients>()
                    {
                        new Ingredients()
                        {
                            Id = 1,
                            Name = "Cheese"
                        }
                    }
             }};

            mockPizzaRepository.Setup(x => x.GetPizzasAsync()).ReturnsAsync(result);

            // act
            var actualResult = await controller.GetPizzas();

            // assert
            actualResult.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Get_Pizza_By_Id()
        {
            // Arrange
            var result = new Pizza()
            {
                Id = 1,
                Name = "Veggie",
                Description = "Veggie Pizza for vegitarians",
                Price = 100,
                ImageUrl = "",
                Ingredients = new List<Ingredients>()
                    {
                        new Ingredients()
                        {
                            Id = 1,
                            Name = "Cheese"
                        }
                    }
            };

            mockPizzaRepository.Setup(x => x.GetPizzaByIdAsync(It.IsAny<int>())).ReturnsAsync(result);

            // act
            var actualResult = await controller.GetPizzaById(1);

            // assert
            actualResult.Should().NotBeNull();
        }


        [TestMethod]
        public void Get_Pizza_By_Id_Throw_Exception()
        {
            // Arrange
            mockPizzaRepository.Setup(x => x.GetPizzaByIdAsync(It.IsAny<int>()))
                .ThrowsAsync(new ArgumentNullException("pizzaId can not be zero"));

            // assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await controller.GetPizzaById(1));
        }


        [TestMethod]
        public async Task CreateCustomPizzaOrder_CreatePizza()
        {
            // Arrange
            var request = new CreatePizzaRequest()
            {
                Name = "Veggie",
                IsAddCheese = true,
                IsAddExtraCheese =true,
                Size =1,
                NumberOfPizza =1,
                PizzaIngredientsId = new List<int>() { 
                    1,2
                }
            };

            mockPizzaRepository.Setup(x => x.CreateCustomAndSavePizzOrder(It.IsAny<CreatePizzaRequest>()))
                .ReturnsAsync(new OrderResponse() { 
                    OrderId = 1,
                    PizzId = 1,
                    NumberOfPizza = 1,
                    Price = 210,
                    PizzaName = "Veggie"

                });

            // act
            var actualResult = await controller.CreateCustomPizzaOrder(request);

            // assert
            actualResult.Should().NotBeNull();
            var result = actualResult as OkObjectResult;
            result.Should().NotBeNull();
            result?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            mockPizzaRepository.VerifyAll();
        }

        [TestMethod]
        public void CreateCustomPizzaOrder_Throw_Exception_Not_Valid_Request()
        {
            // Arrange
            mockPizzaRepository.Setup(x => x.CreateCustomAndSavePizzOrder(It.IsAny<CreatePizzaRequest>()))
                .ThrowsAsync(new ArgumentNullException("please select pizza"));

            // assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await controller.CreateCustomPizzaOrder(null));
        }

        [TestMethod]
        public async Task CreateSelectedPizzaOrder_CreatePizza()
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

            mockPizzaRepository.Setup(x => x.CreateAndSavePizzOrder(It.IsAny<CreatePizzaRequest>(),
                 It.IsAny<int>()))
                .ReturnsAsync(new OrderResponse()
                {
                    OrderId = 1,
                    PizzId = 1,
                    NumberOfPizza = 1,
                    Price = 210,
                    PizzaName = "Veggie"

                });

            // act
            var actualResult = await controller.CreateSelectdPizzaOrder(request, 1);

            // assert
            actualResult.Should().NotBeNull();
            var result = actualResult as OkObjectResult;
            result.Should().NotBeNull();
            result?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            mockPizzaRepository.VerifyAll();
        }

        [TestMethod]
        public void CreateSelectPizzaOrder_Throw_Not_Found_Exception()
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

            mockPizzaRepository.Setup(x => x.CreateAndSavePizzOrder(It.IsAny<CreatePizzaRequest>(),
                  It.IsAny<int>()))
                 .ThrowsAsync(new PizzaNotFoundException("selected pizza not found"));

            // assert
            Assert.ThrowsExceptionAsync<PizzaNotFoundException>(async () => await controller.CreateSelectdPizzaOrder(request, 10));
        }

        [TestMethod]
        public void CreateSelectPizzaOrder_Throw__Exception_Request_NotValid()
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

            mockPizzaRepository.Setup(x => x.CreateAndSavePizzOrder(It.IsAny<CreatePizzaRequest>(),
                  It.IsAny<int>()))
                 .ThrowsAsync(new ArgumentNullException("pizzaId not null"));

            // assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await controller.CreateSelectdPizzaOrder(request, 0));
        }
    }

}
