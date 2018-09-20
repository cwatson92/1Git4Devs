using CashFlow.Contracts;
using CashFlow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.WebApiTests
{
	public class FakeExpenseServices : IExpenseServices
	{
		public int CallCount { get; private set; }
		public bool ReturnValue { private get; set; }

		public bool CreateExpense(Expense model)
		{
			CallCount++;

			return ReturnValue;
		}

		public bool DeleteExpense(int id)
		{
			CallCount--;

			return ReturnValue;
		}

		public Expense GetExpense(int id)
		{
			if (id != 1)
			{
				throw new Exception();
			}

			return new Expense();
		}

		public IEnumerable<Expense> GetExpenses()
		{
			CallCount++;

			return new List<Expense>();
		}

		public bool UpdateExpense(Expense model)
		{
			CallCount++;

			return ReturnValue;
		}
	}
}
