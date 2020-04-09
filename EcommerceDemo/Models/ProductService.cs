using EcommerceDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceDemo.Models
{
	public class ProductService:IProduct
	{
		private readonly ApplicationDbContext _context;
		public ProductService(ApplicationDbContext context)
		{
			_context = context;
		}
		public IEnumerable<Product> GetAll()
		{
			return _context.ProductItems;
		}

		public Product GetById(int id)
		{
			return _context.ProductItems.FirstOrDefault(p => p.Id == id);
		}
	}
}
