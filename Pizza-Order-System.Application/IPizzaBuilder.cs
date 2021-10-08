using Pizza_Order_System.Persistence;

namespace Pizza_Order_System.Application
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPizzaBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        void CreateCustomPizzaBase(string Name);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pizza"></param>
        void CreateSelectdPizza(Pizza pizza);

        /// <summary>
        /// 
        /// </summary>
        void AddCheese();

        /// <summary>
        /// 
        /// </summary>
        void AddExtraCheese();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        void AddSize(Size size);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredients"></param>
        void AddIngredients(Ingredients ingredients);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        void AddNumberOfPizza(int number);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Pizza GetPizza();

    }
}
