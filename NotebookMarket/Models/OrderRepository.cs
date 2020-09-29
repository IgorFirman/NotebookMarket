using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookMarket.Models
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationContext _applicationContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ApplicationContext applicationContext, ShoppingCart shoppingCart)
        {
            _applicationContext = applicationContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetails>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetails
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Laptop.LaptopId,
                    Price = shoppingCartItem.Laptop.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _applicationContext.Orders.Add(order);

            _applicationContext.SaveChanges();
        }

    }
}
