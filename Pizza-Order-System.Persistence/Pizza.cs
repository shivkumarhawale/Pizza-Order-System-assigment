using System.Collections.Generic;

namespace Pizza_Order_System.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public class Pizza: BaseModel
    {
        public Pizza()
        {
            Ingredients = new List<PizzaIngredients>();
        }

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
        public int SizeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CategoriesId { get; set; }

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
        public  IList<PizzaIngredients> Ingredients { get; set; }

    }
}
