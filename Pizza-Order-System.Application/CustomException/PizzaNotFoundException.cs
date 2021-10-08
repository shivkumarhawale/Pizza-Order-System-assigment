using System;

namespace Pizza_Order_System.Application.CustomException
{
    [Serializable]
    public class PizzaNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public PizzaNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public PizzaNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
