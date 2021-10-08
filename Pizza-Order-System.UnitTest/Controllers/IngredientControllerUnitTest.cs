using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pizza_Order_System.Application;
using Pizza_Order_System.Application.Contract;
using Pizza_Order_System.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza_Order_System.UnitTest.Controllers
{
    [TestClass]
    public class IngredientControllerUnitTest
    {
        Mock<IIngredientRepository> mockIngredientRepository = null;
        IngredientController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            mockIngredientRepository = new Mock<IIngredientRepository>(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };
            controller = new IngredientController(mockIngredientRepository.Object);

        }

        [TestMethod]
        public async Task Get_All_Ingredients()
        {
            // Arrange
            var result = new List<Ingredients>() {
             new Ingredients(){
                 Id = 1,
                 Name ="Grilled Mushrooms",
             }};

            mockIngredientRepository.Setup(x => x.GetAllIngredientsAsync()).ReturnsAsync(result);

            // act
            var actualResult = await controller.GetAllIngredients();

            // assert
            actualResult.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Get_All_Ingredients_Types()
        {
            // Arrange
            var result = new List<IngredientType>() {
             new IngredientType(){
                 Id = 1,
                 Name ="Crust",
             }};

            mockIngredientRepository.Setup(x => x.GetAllIngredientTypesAsync()).ReturnsAsync(result);

            // act
            var actualResult = await controller.GetAllIngredientType();

            // assert
            actualResult.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Get_All_Ingredients_Types_By_Id()
        {
            // Arrange
            var result = new List<Ingredients>() {
             new Ingredients(){
                 Id = 1,
                 Name ="Grilled Mushrooms",
             }};

            mockIngredientRepository.Setup(x => x.GetIngredientsByTypeIdAsync(It.IsAny<int>())).ReturnsAsync(result);

            // act
            var actualResult = await controller.GetIngredientType(1);

            // assert
            actualResult.Should().NotBeNull();
        }

        [TestMethod]
        public void GetAllIngredientsTypesById_Throw_Exception()
        {
            // Arrange
            mockIngredientRepository.Setup(x => x.GetIngredientsByTypeIdAsync(It.IsAny<int>()))
                .ThrowsAsync(new ArgumentNullException("typeId can not be zero"));

            // assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>  await controller.GetIngredientType(1));
        }

        [TestMethod]
        public async Task GetAllSize()
        {
            // Arrange
            var result = new List<Size>() {
             new Size(){
                 Id = 1,
                 Name ="Small",
             }};

            mockIngredientRepository.Setup(x => x.GetSizeAsync()).ReturnsAsync(result);

            // act
            var actualResult = await controller.GetSize();

            // assert
            actualResult.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetToppings()
        {
            // Arrange
            var result = new List<Ingredients>() {
             new Ingredients(){
                 Id = 1,
                 Name ="Pepper Barbecue Chicken",
             }};

            mockIngredientRepository.Setup(x => x.GetIngredientsByTypeIdAsync(It.IsAny<int>())).ReturnsAsync(result);

            // act
            var actualResult = await controller.GetIngredientType(3);

            // assert
            actualResult.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetSauce()
        {
            // Arrange
            var result = new List<Ingredients>() {
             new Ingredients(){
                 Id = 1,
                 Name ="White Garlic Sauce",
             }};

            mockIngredientRepository.Setup(x => x.GetIngredientsByTypeIdAsync(It.IsAny<int>())).ReturnsAsync(result);

            // act
            var actualResult = await controller.GetIngredientType(3);

            // assert
            actualResult.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetCrust()
        {
            // Arrange
            var result = new List<Ingredients>() {
             new Ingredients(){
                 Id = 1,
                 Name ="Stuffed Crust",
             }};

            mockIngredientRepository.Setup(x => x.GetIngredientsByTypeIdAsync(It.IsAny<int>())).ReturnsAsync(result);

            // act
            var actualResult = await controller.GetIngredientType(3);

            // assert
            actualResult.Should().NotBeNull();
        }
    }
}
