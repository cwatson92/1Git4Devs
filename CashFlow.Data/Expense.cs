using System;
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

		public int BudgetId { get; set; }

		public string Name { get; set; }

		public decimal Cost { get; set; }
		
		public string Description { get; set; }

		public virtual Budget Budget { get; set; }
	}
}
