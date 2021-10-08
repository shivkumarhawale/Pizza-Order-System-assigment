using System.Collections.Generic;

namespace Pizza_Order_System.Application.Contract
{
    /// <summary>
    /// 
    /// </summary>
    public class Pizza
    {
        public Pizza()
        {
            Ingredients = new List<Ingredients>();
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Ingredients> Ingredients { get; set; }

    }
}
