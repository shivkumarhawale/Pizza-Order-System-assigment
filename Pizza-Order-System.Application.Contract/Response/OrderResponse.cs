namespace Pizza_Order_System.Application.Contract.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PizzId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PizzaName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NumberOfPizza { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }
    }
}
