using Pizza_Order_System.Application.Contract;
using Pizza_Order_System.Application.Contract.Request;
using Pizza_Order_System.Application.Contract.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza_Order_System.Application
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPizzaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Pizza>> GetPizzasAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pizzaId"></param>
        /// <returns></returns>
        Task<Pizza> GetPizzaByIdAsync(int pizzaId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OrderResponse> CreateCustomAndSavePizzOrder(CreatePizzaRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pizzaId"></param>
        /// <returns></returns>
        Task<OrderResponse> CreateAndSavePizzOrder(CreatePizzaRequest request, int pizzaId);
    }
}
