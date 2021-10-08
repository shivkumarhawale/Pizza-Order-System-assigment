using Pizza_Order_System.Application.Contract;
using Pizza_Order_System.Application.Contract.Request;
using Pizza_Order_System.Application.Contract.Response;
using Pizza_Order_System.Application.CustomException;
using Pizza_Order_System.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel = Pizza_Order_System.Persistence;



namespace Pizza_Order_System.Application
{
    public class PizzaRepository : IPizzaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ISeedDataRepository _seedDataRepository;

        /// <summary>
        /// 
        /// </summary>
        private readonly IPizzaBuilder  _pizzaBuilder;

        /// <summary>
        /// 
        /// </summary>
        public static int OrderId = 10;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seedDataRepository"></param>
        public PizzaRepository(
            ISeedDataRepository seedDataRepository,
            IPizzaBuilder pizzaBuilder)
        {
            _seedDataRepository = seedDataRepository;
            _pizzaBuilder = pizzaBuilder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Pizza>> GetPizzasAsync()
        {
            var result = (from pizza in await _seedDataRepository.GetPizzasAsync()
                             select new Contract.Pizza
                             {
                                 Id = pizza.Id,
                                 Name = pizza.Name,
                                 ImageUrl = pizza.ImageUrl,
                                 Description = pizza.Description,
                                 Price = pizza.Price,
                                 Ingredients = (from ingredient in _seedDataRepository.GetAllIngredients()
                                                where pizza.Ingredients.Select(item => item.IngredientId).Contains(ingredient.Id)
                                                select new Contract.Ingredients {
                                                    Id = ingredient.Id,
                                                    Name = ingredient.Name,
                                                    Price = ingredient.Price
                                                }).ToList()
                             }).AsEnumerable();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pizzaId"></param>
        /// <returns></returns>
        public async Task<Pizza> GetPizzaByIdAsync(int pizzaId)
        {
            if(pizzaId == 0)
                throw new ArgumentNullException("pizzaId can not be zero");

            var result = (from pizza in await _seedDataRepository.GetPizzasAsync()
                          where pizza.Id == pizzaId
                          select new Contract.Pizza
                          {
                              Id = pizza.Id,
                              Name = pizza.Name,
                              ImageUrl = pizza.ImageUrl,
                              Description = pizza.Description,
                              Price = pizza.Price,
                              Ingredients = (from ingredient in _seedDataRepository.GetAllIngredients()
                                             where pizza.Ingredients.Select(item => item.IngredientId).Contains(ingredient.Id)
                                             select new Contract.Ingredients
                                             {
                                                 Id = ingredient.Id,
                                                 Name = ingredient.Name,
                                                 Price = ingredient.Price
                                             }).ToList()
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public async Task<OrderResponse> CreateCustomAndSavePizzOrder(CreatePizzaRequest request) 
        {
            //create pizza
            var  pizza = await CreatePizza(request);
            
            //Save pizza order
            await _seedDataRepository.SaveAsync(pizza);
            
            return new OrderResponse()
            {
                OrderId = OrderId++,
                PizzId = pizza.Id,
                PizzaName = pizza.Name,
                NumberOfPizza = request.NumberOfPizza,
                Price = pizza.Price
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pizzaId"></param>
        /// <returns></returns>
        public async Task<OrderResponse> CreateAndSavePizzOrder(CreatePizzaRequest request, int pizzaId)
        {
            if (pizzaId == 0)
                throw new ArgumentNullException("pizzaId can not be zero");

            var selectdPizza = await _seedDataRepository.GetPizzaByIdAsync(pizzaId);
            if (selectdPizza == null)
                throw new PizzaNotFoundException("selected pizza  not found");

            //create pizza
            var pizza = await CreatePizza(request, selectdPizza);

            //Save pizza order
            await _seedDataRepository.SaveAsync(pizza);

            return new OrderResponse()
            {
                OrderId = OrderId++,
                PizzId = pizza.Id,
                PizzaName = pizza.Name,
                NumberOfPizza = request.NumberOfPizza,
                Price = pizza.Price
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pizza"></param>
        /// <returns></returns>
        private async Task<DataModel.Pizza> CreatePizza(CreatePizzaRequest request, DataModel.Pizza pizza =null)
        { 
            if(request == null)
                throw new ArgumentNullException("please select pizza");

            if (pizza == null)  {
                _pizzaBuilder.CreateCustomPizzaBase(request.Name);
            }
            else {
                _pizzaBuilder.CreateSelectdPizza(pizza);
            }

            if (request.Size != 0)
            {
                var size = await _seedDataRepository.GetSizeByIdAsync(request.Size);
                _pizzaBuilder.AddSize(size);
            }
            if (request.IsAddCheese)
            {
                _pizzaBuilder.AddCheese();
            }
            if (request.IsAddExtraCheese)
            {
                _pizzaBuilder.AddExtraCheese();
            }
            if (request.PizzaIngredientsId?.Any() == true) 
            {
                foreach (var item in request.PizzaIngredientsId) 
                {
                    var ingredient = await _seedDataRepository.GetIngredientByIdAsync(item);
                    _pizzaBuilder.AddIngredients(ingredient);

                }
            }
            if (request.NumberOfPizza != 0) {
                _pizzaBuilder.AddNumberOfPizza(request.NumberOfPizza);
            }
            return _pizzaBuilder.GetPizza();
        }
    }
}
