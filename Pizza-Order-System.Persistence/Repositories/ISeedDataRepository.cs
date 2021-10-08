using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza_Order_System.Persistence.Repositories
{
    public interface ISeedDataRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Pizza>> GetPizzasAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Pizza> GetPizzaByIdAsync(int pizzaId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns></returns>
        Task<int> SaveAsync(Pizza pizza);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Ingredients> GetAllIngredients();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Ingredients>> GetAllIngredientsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        Task<Ingredients> GetIngredientByIdAsync(int ingredientId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IngredientType>> GetAllIngredientTypesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Size>> GetSizeAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Size> GetSizeByIdAsync(int sizeId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<Categories> GetAllCategories();
    }
}
