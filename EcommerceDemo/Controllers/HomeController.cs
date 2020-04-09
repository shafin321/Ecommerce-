using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceDemo.Models;

namespace EcommerceDemo.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProduct _product;
		public HomeController(IProduct product)
		{
			_product = product;
		}
		public IActionResult Index()
		{
			var model = _product.GetAll();
			return View(model);
		}

		public IActionResult Detail(int id)
		{
			var model = _product.GetById(id);


			return View(model);
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
