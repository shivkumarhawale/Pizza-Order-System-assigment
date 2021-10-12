using Pizza_Order_System.Application.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza_Order_System.Application
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIngredientRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Ingredients>> GetAllIngredientsAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Ingredients> GetIngredientsByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        Task<IEnumerable<Ingredients>> GetIngredientsByTypeIdAsync(int typeId);

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
    }
}
