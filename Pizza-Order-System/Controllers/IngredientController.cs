using Microsoft.AspNetCore.Mvc;
using Pizza_Order_System.Application;
using Pizza_Order_System.Application.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza_Order_System.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IIngredientRepository _ingredientRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredientRepository"></param>
        public IngredientController(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Ingredients>> GetAllIngredients()
        {
            var result = await _ingredientRepository.GetAllIngredientsAsync();
            return result;
        }

        [HttpGet]
        [Route("{ingredientId}")]
        public async Task<Ingredients> GetIngredientById([FromRoute] int ingredientId)
        {
            var result = await _ingredientRepository.GetIngredientsByIdAsync(ingredientId);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("types")]
        public async Task<IEnumerable<IngredientType>> GetAllIngredientType()
        {
            return await  _ingredientRepository.GetAllIngredientTypesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("type/{typeId}")]
        public async Task<IEnumerable<Ingredients>> GetIngredientType([FromRoute] int typeId)
        {
            return await  _ingredientRepository.GetIngredientsByTypeIdAsync(typeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("size")]
        public async Task<IEnumerable<Size>> GetSize()
        {
            return await _ingredientRepository.GetSizeAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Toppings")]
        public async Task<IEnumerable<Ingredients>> GetToppings()
        {
            return await _ingredientRepository.GetIngredientsByTypeIdAsync(3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Sauce")]
        public async Task<IEnumerable<Ingredients>> GetSauce()
        {
            return await _ingredientRepository.GetIngredientsByTypeIdAsync(2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Crust")]
        public async Task<IEnumerable<Ingredients>> GetCrust()
        {
            return await _ingredientRepository.GetIngredientsByTypeIdAsync(1);
        }
    }
}
