﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Data
{
	public class Expense
	{
		[Key]
		public int ExpenseId { get; set; }

		public Guid OwnerId { get; set; }

		[Required]
		public string Name { get; set; }

		public decimal Cost { get; set; }
		
		public string Description { get; set; }
	}
}
