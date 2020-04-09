using EcommerceDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceDemo.Models
{
	public class OderService : IOrder
	{
		private readonly ApplicationDbContext _context;
		private readonly ShoppingCart _shoppingCart;

		public OderService(ApplicationDbContext context, ShoppingCart shoppingCart)
		{
			_context = context;
			_shoppingCart = shoppingCart;
		}

		public void CreatOrder(Order order)
		{
			order.OrderPlaced = DateTime.Now;
			order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
			_context.Orders.Add(order);
			_context.SaveChanges();

			var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

			foreach(var shoppingCartItem in shoppingCartItems)
			{
				var oderDetail = new OrderDetail
				{
					Quanitity = shoppingCartItem.Quantity,
					Price = shoppingCartItem.Product.Price,
					ProductId = shoppingCartItem.Product.Id,
					OrderId = order.Id

				};
				_context.OrderDetails.Add(oderDetail);
			}
			_context.SaveChanges();
			
		}
	}
}
