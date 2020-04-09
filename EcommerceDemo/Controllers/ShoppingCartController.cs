using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceDemo.Models;
using EcommerceDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceDemo.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly IProduct _product;
		private readonly ShoppingCart _shoppingCart;

		public ShoppingCartController(IProduct product, ShoppingCart shoppingCart)
		{
			_product = product;
			_shoppingCart = shoppingCart;
		}
		public ViewResult Index()
		{
			_shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

			var shoppingCartViewModel = new ShoppingCartViewModel
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};

			return View(shoppingCartViewModel);
		}

		public RedirectToActionResult AddToShoppingCart(int id)
		{
			var selectedPrduct = _product.GetAll().FirstOrDefault(P => P.Id == id);

			if (selectedPrduct != null)
			{
				_shoppingCart.AddToCart(selectedPrduct, 1);
			}

			return RedirectToAction("Index");
		}

		public IActionResult RemoveFromShoppingCart(int id)
		{
			var selectedProduct = _product.GetAll().FirstOrDefault(p => p.Id == id);

			if (selectedProduct != null) //if slected product does exist
			{
				_shoppingCart.RemoveFromCart(selectedProduct);
			}

			return RedirectToAction("Index");
		}

	}
}