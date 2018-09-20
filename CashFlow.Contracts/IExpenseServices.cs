using CashFlow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Contracts
{
	public interface IExpenseServices
	{
		bool CreateExpense(Expense model);
		bool DeleteExpense(int id);
		bool UpdateExpense(Expense model);
		IEnumerable<Expense> GetExpenses();
		Expense GetExpense(int id);
	}
}
