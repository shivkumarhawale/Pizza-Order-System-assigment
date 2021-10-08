using System.Collections.Generic;

namespace Pizza_Order_System.Application.Contract.Request
{
    public class CreatePizzaRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NumberOfPizza { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAddCheese { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAddExtraCheese { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> PizzaIngredientsId { get; set; }
    }
}
