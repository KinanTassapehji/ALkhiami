﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.Domain.Orders
{
	public enum OrderStatus
	{
		Pending = 0,
		Paid = 1,
		Shipped = 2,
		Completed = 3,
		Cancelled = 4,
		Refunded = 5
	}
}
