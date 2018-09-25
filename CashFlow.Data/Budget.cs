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

		[Required]
		public decimal MonthlyIncome { get; set; }

		[Required]
		public decimal EstimatedAvailableBalance { get; set; }

		[Required]
		public decimal SavingsAmount { get; set; }

	}
}
