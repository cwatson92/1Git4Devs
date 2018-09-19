using CashFlow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Contracts
{
	public interface IBudget
	{
		bool CreateBudget(Budget model);
		bool DeleteBudget(int id);
		bool UpdateBudget(Budget model);
		IEnumerable<Budget> GetBudgets();
		Budget GetBudget(int id);
	}
}
