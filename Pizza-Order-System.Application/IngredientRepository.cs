using Pizza_Order_System.Application.Contract;
using Pizza_Order_System.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Order_System.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class IngredientRepository: IIngredientRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ISeedDataRepository _seedDataRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seedDataRepository"></param>
        public IngredientRepository(
            ISeedDataRepository seedDataRepository)
        {
            _seedDataRepository = seedDataRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Ingredients>> GetAllIngredientsAsync()
        {
            return (from ingredient in await _seedDataRepository.GetAllIngredientsAsync()
                    select new Contract.Ingredients()
                    {
                        Id = ingredient.Id,
                        Name = ingredient.Name,
                        Price = ingredient.Price
                        
                    }).AsEnumerable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Ingredients>> GetIngredientsByTypeIdAsync(int typeId)
        {
            if(typeId == 0)
                throw new ArgumentNullException("typeId can not be zero");

            return (from ingredient in await _seedDataRepository.GetAllIngredientsAsync()
                    where ingredient.IngredientTypeId == typeId
                    select new Ingredients() 
                    {
                        Id = ingredient.Id,
                        Name = ingredient.Name,
                        Price = ingredient.Price
                    }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IngredientType>> GetAllIngredientTypesAsync()
        {
            return  (from ingredientType in await _seedDataRepository.GetAllIngredientTypesAsync()
                    select new IngredientType()
                    { 
                        Id =  ingredientType.Id,
                        Name = ingredientType.Name
                    }).ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Size>> GetSizeAsync()
        {
            return (from size in await _seedDataRepository.GetSizeAsync()
                    select new Size()
                    {
                        Id = size.Id,
                        Name = size.Name
                    }).ToList();

        }
    }
}
