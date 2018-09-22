﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Data
{
	public class Budget
	{
		[Key]
		public int BudgetId { get; set; }

		public Guid OwnerId { get; set; }

		public virtual ICollection<Expense> Expenses { get; set; }

		[Required]
		public decimal MonthlyIncome { get; set; }

		public decimal AvailableBalance
		{
			get
			{
				decimal totalCosts = 0;
				foreach (var e in Expenses)
				{
					totalCosts += e.Cost;
				}
				return MonthlyIncome - totalCosts;
			}
			set { }
		}
	}
}
