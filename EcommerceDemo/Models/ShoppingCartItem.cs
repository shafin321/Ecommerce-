using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceDemo.Models
{
	public class ShoppingCartItem
	{
		public int Id { get; set; }
		public string ShoppingCartId { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}
