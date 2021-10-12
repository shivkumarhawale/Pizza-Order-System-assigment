using Pizza_Order_System.Persistence.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Order_System.Persistence.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class SeedDataRepository : ISeedDataRepository
    {
        public List<Pizza> pizzas;
        public List<Size> sizes;
        public List<Ingredients> ingredients;

        public SeedDataRepository() {
            pizzas = new List<Pizza>();
            sizes = new List<Size>();
            ingredients = new List<Ingredients>();

            // load mock data
            CreatePizzaMockData();
            GetAllIngredientsAsync();
            GetAllIngredientTypesAsync();
            GetPizzasAsync();
            GetSizeAsync();
        }
        

        #region Ingredients
        public Task<IEnumerable<Ingredients>> GetAllIngredientsAsync()
        {
           return Task.FromResult(GetAllIngredients());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        public Task<Ingredients> GetIngredientByIdAsync(int ingredientId)
        {
            if (ingredientId == 0)
                throw new ArgumentNullException("ingredientId can not be null");

            var result = ingredients.Where(item => item.Id == ingredientId).FirstOrDefault();
            return Task.FromResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ingredients> GetAllIngredients()
        {
            ingredients =  new List<Ingredients>() {
             new Ingredients(){
                 Id = 1,
                 Name ="Grilled Mushrooms",
                 FoodType = FoodType.Veg,
                 IngredientTypeId = 3,
                 Price = 60,
             },
             new Ingredients(){
                 Id = 2,
                 Name ="Onion",
                 FoodType = FoodType.Veg,
                 IngredientTypeId = 3,
                 Price = 60,

             },
             new Ingredients(){
                 Id = 3,
                 Name ="Paneer",
                 FoodType = FoodType.Veg,
                 IngredientTypeId = 3,
                 Price = 60,

             },
             new Ingredients(){
                 Id = 3,
                 Name ="Red Pepper",
                 FoodType = FoodType.Veg,
                 IngredientTypeId = 3,
                 Price = 60,

             },
             new Ingredients(){
                 Id = 4,
                 Name ="Pepper Barbecue Chicken",
                 FoodType = FoodType.NonVeg,
                 IngredientTypeId = 3,
                Price = 90,

             },
             new Ingredients(){
                 Id = 4,
                 Name ="Peri Peri Chicken",
                 FoodType = FoodType.NonVeg,
                 IngredientTypeId = 3,
                 Price = 90,

             },
             new Ingredients(){
                 Id = 5,
                 Name ="Crust Cheese",
                 FoodType = FoodType.Veg,
                 IngredientTypeId = 1,
                 Price = 90,

             },
              new Ingredients(){
                 Id = 6,
                 Name ="Stuffed Crust",
                 FoodType = FoodType.Veg,
                 IngredientTypeId = 1,
                 Price = 90,

             },
            new Ingredients(){
                 Id = 7,
                 Name ="White Garlic Sauce",
                 FoodType = FoodType.Veg,
                 IngredientTypeId = 2,
                 Price = 90,

             }
           };
            return ingredients;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<IngredientType>> GetAllIngredientTypesAsync()
        {
            var result = new List<IngredientType>() {
             new IngredientType(){
                 Id = 1,
                 Name = "Crust"
             },
             new IngredientType(){
                 Id = 2,
                 Name = "Sauce"
             },
             new IngredientType(){
                 Id = 3,
                 Name = "Toppings"
             },
             new IngredientType(){
                 Id = 4,
                 Name = "Cheese"
             }
            };
            return Task.FromResult(result.AsEnumerable());
        }
        #endregion

        #region Pizza

        private void CreatePizzaMockData()
        {
            pizzas.Add(new Pizza
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
            });

            pizzas.Add(new Pizza
            {
                Id = 99,
                Name = "Custom Pizza",
                Description = "Custom Pizza for vegitarians",
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
            });
        }
        public Task<IEnumerable<Pizza>> GetPizzasAsync()
        {
           return Task.FromResult(pizzas.AsEnumerable());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pizzaId"></param>
        /// <returns></returns>
        public Task<Pizza> GetPizzaByIdAsync(int pizzaId)
        {
            if (pizzaId == 0)
                throw new ArgumentNullException("pizzaId can not be null");

            var result = pizzas.Where(item => item.Id == pizzaId).FirstOrDefault();
            return Task.FromResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns></returns>
        public Task<int> SaveAsync(Pizza pizza) {
            if (pizza == null)
                throw new AggregateException("Pizza can not be null");

            pizzas.Add(pizza);

            return Task.FromResult(pizza.Id);
        }

        #endregion

        #region Sizes
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Size>> GetSizeAsync()
        {
            sizes =  new List<Size>() {
             new Size() {
                  Id=1,
                  Name="Small",
                  Multiplier=1
             },
             new Size() {
                   Id = 2,
                Name ="Medium",
                Multiplier=2m
             },
             new Size() {
                  Id = 3,
                Name ="Large",
                Multiplier=3m
             }
            };
            return Task.FromResult(sizes.AsEnumerable());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sizeId"></param>
        /// <returns></returns>
        public Task<Size> GetSizeByIdAsync(int sizeId)
        {
            if (sizeId == 0)
                throw new ArgumentNullException("sizeId can not be null");

            var result = sizes.Where(item => item.Id == sizeId).FirstOrDefault();
            return Task.FromResult(result);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Categories> GetAllCategories()
        {
            return new List<Categories>()
            {
                new Categories {
                    Id =1,
                    Name = "Standard"
                },
                new Categories {
                    Id = 2,
                    Name = "Spcialities"
                }
            };
        }
    }
}
