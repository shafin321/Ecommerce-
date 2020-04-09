using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceDemo.Controllers
{
    public class OrderController : Controller
    {
		private readonly IOrder _order;
		private readonly ShoppingCart _shoppingCart;
		public OrderController(IOrder order, ShoppingCart shoppingCart)
		{
			_order = order;
			_shoppingCart = shoppingCart;
		}
		[HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }

		[HttpPost]
		public IActionResult CheckOut(Order order)
		{
			_shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

			if (_shoppingCart.ShoppingCartItems.Count() == 0)
			{
				ModelState.AddModelError("", "Your cart is empty");
			}

			if (ModelState.IsValid)
			{
				_order.CreatOrder(order);
				_shoppingCart.ClearCart();
				return RedirectToAction("CheckoutComplete");
			}

			return View(order);
		}

		public IActionResult CheckoutComplete()
		{
			ViewBag.CheckoutCompleteMessage = "Thank you for your order. Enjoy your Product";
			return View();
		}
	}
}