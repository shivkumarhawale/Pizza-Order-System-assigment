using Pizza_Order_System.Persistence;

namespace Pizza_Order_System.Application
{
    /// <summary>
    /// class is used to build pizza
    /// </summary>
    public class PizzaBuilder : IPizzaBuilder
    {
        Pizza pizza;
        private static int Id = 100;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void CreateCustomPizzaBase(string name)
        {
            pizza = new Pizza();
            pizza.Name = name;
            pizza.Id = Id++;
            pizza.Price = 100;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_pizza"></param>
        public void CreateSelectdPizza(Pizza _pizza)
        {
            if (_pizza == null)
                return;

            pizza = _pizza;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredients"></param>
        public void AddSize(Size size)
        {
            if (size == null)
                return;

            pizza.SizeId = size.Id;
            pizza.Price = pizza.Price * size.Multiplier;
        }

        /// <summary>
        /// 
        /// </summary>

        public void AddCheese()
        {
            pizza.IsAddCheese = true;
            pizza.Price = pizza.Price + PizzaOrderConstant.CheesePrice;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddExtraCheese()
        {
            pizza.IsAddCheese = true;
            pizza.Price = pizza.Price + PizzaOrderConstant.ExtraCheesePrice;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredients"></param>
        public void AddIngredients(Ingredients ingredients)
        {
            if (ingredients == null)
                return;

            pizza.Ingredients.Add(new PizzaIngredients()
            {
                PizzaId = pizza.Id,
                IngredientId = ingredients.Id
            });
            pizza.Price = pizza.Price + ingredients.Price;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        public void AddNumberOfPizza(int number)
        {
            if (number == 0)
                return;

            pizza.Price = pizza.Price * number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Pizza GetPizza()
        {
            return pizza;
        }
    }
}
