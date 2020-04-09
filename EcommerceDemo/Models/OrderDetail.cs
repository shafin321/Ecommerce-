using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceDemo.Models
{
	public class OrderDetail
	{
		public int Id { get; set; }

		public int OrderId { get; set; }

		[ForeignKey("OrderId")]
		public Order Order { get; set; }

		public int ProductId { get; set; }

		[ForeignKey("ProductId ")]
		public Product Product { get; set; }
		public int Quanitity { get; set; }
		public decimal Price { get; set; }
		
	}
}
