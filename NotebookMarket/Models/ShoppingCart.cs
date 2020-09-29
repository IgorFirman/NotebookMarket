using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookMarket.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationContext _applicationContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToShoppingCart(Laptop laptop, int amount)
        {
            var shoppingCartItem =
                    _applicationContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Laptop.LaptopId == laptop.LaptopId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Laptop = laptop,
                    Amount = 1
                };

                _applicationContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _applicationContext.SaveChanges();
        }

        public int RemoveFromShoppingCart(Laptop laptop)
        {
            var shoppingCartItem =
                   _applicationContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Laptop.LaptopId == laptop.LaptopId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _applicationContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _applicationContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _applicationContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Laptop)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _applicationContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _applicationContext.ShoppingCartItems.RemoveRange(cartItems);

            _applicationContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _applicationContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Laptop.Price * c.Amount).Sum();
            return total;
        }

    }
}
