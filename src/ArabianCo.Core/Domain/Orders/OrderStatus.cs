using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Domain.Orders
{
	public enum OrderStatus
	{
		Pending = 0,
		Shipped = 1,
		Completed = 2,
		Cancelled = 3
	}
}
