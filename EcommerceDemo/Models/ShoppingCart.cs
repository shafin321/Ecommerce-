using EcommerceDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceDemo.Models
{
	public class ShoppingCart
	{
		private readonly ApplicationDbContext _context;
		public string ShoppingCartId { get; set; }
		public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

		public ShoppingCart(ApplicationDbContext context)
		{
			_context=context;
		}

		public static ShoppingCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

			var context = services.GetService<ApplicationDbContext>();
			string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
			session.SetString("CartId", cartId);

			return new ShoppingCart(context) { ShoppingCartId = cartId };
		}

		public void AddToCart(Product product, int quanitiy)
		{
			var shoppingCartItem = _context.CartItems.SingleOrDefault(
				s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

			if (shoppingCartItem == null)
			{
				shoppingCartItem = new ShoppingCartItem
				{
					ShoppingCartId = ShoppingCartId,
					Product = product,
					Quantity = quanitiy
				};

				_context.CartItems.Add(shoppingCartItem);
			}
			else
			{
				shoppingCartItem.Quantity++;
			}

			_context.SaveChanges();
			
		}

		public int RemoveFromCart(Product product)
		{
			var shoppingCartItem = _context.CartItems.
				SingleOrDefault(t => t.Product.Id == product.Id && t.ShoppingCartId == ShoppingCartId);

			var loalAmount = 0;

			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Quantity > 1)
				{
					shoppingCartItem.Quantity--;
					loalAmount = shoppingCartItem.Quantity;
				}
				else
				{
					_context.CartItems.Remove(shoppingCartItem);
				}

			}
			_context.SaveChanges();
			return loalAmount;
		}
		public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
		{
			return ShoppingCartItems ?? (ShoppingCartItems = _context.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
				.Include(s => s.Product)
				.ToList());
		}

		public void ClearCart()
		{
			var cartitems = _context.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId);
			_context.CartItems.RemoveRange(cartitems);
			_context.SaveChanges();
		}

		public decimal GetShoppingCartTotal()
		{
			var total = _context.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
				.Select(c => c.Product.Price * c.Quantity).Sum();

			return total;
		}
	}
}
