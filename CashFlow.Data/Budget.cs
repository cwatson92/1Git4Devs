using System;
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

		public List<Expense> Expenses { get; set; }

		public decimal MonthlyIncome { get; set; }	

		public decimal AvailableBalance { get; set; }
	}
}
