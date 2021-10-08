using Pizza_Order_System.Persistence.Enum;

namespace Pizza_Order_System.Persistence
{
    public class Ingredients: BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IngredientTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FoodType FoodType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }
    }
}
