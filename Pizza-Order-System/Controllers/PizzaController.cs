using Microsoft.AspNetCore.Mvc;
using Pizza_Order_System.Application;
using Pizza_Order_System.Application.Contract;
using Pizza_Order_System.Application.Contract.Request;
using Pizza_Order_System.Application.CustomException;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pizza_Order_System.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/pizza")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IPizzaRepository _pizzaRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pizzaRepository"></param>
        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            var result = await _pizzaRepository.GetPizzasAsync();
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pizzaId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pizzaId}")]
        public async Task<Pizza> GetPizzaById([FromRoute] int pizzaId)
        {
            var result = await _pizzaRepository.GetPizzaByIdAsync(pizzaId);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("order")]
        public async Task<IActionResult> CreateCustomPizzaOrder([FromBody] CreatePizzaRequest request)
        {
            try
            {
                var result = await _pizzaRepository.CreateCustomAndSavePizzOrder(request);
                return Ok(result);
            }
            catch (ArgumentNullException ex) {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pizzaId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("order/{pizzaId}")]
        public async Task<IActionResult> CreateSelectdPizzaOrder([FromBody] CreatePizzaRequest request, [FromRoute] int pizzaId)
        {
            try
            {
                var result = await _pizzaRepository.CreateAndSavePizzOrder(request, pizzaId);
                return Ok(result);
            }
            catch (PizzaNotFoundException)
            {
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
