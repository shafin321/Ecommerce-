using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceDemo.Models
{
	public class Order
	{
		public int Id { get; set; }

		
		public string Name{ get; set; }
			
				
		public string Address { get; set; }

		
		public string City { get; set; }

	
		public string PhoneNumber { get; set; }

		public IEnumerable<OrderDetail> OrderDetails { get; set; }

	
		public decimal OrderTotal { get; set; }

	
		public DateTime OrderPlaced { get; set; }
	}
}
