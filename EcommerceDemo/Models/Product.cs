using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceDemo.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		
	
		public bool IsInStock { get; set; }
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public Category Category { get; set; }
	}
}
