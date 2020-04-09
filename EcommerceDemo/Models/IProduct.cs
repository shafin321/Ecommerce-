using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceDemo.Models
{
	public interface IProduct
	{
		IEnumerable<Product> GetAll();
		Product GetById(int id);
	}
}
