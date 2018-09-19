using CashFlow.Contracts;
using CashFlow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Services
{
	public class BudgetServices : IBudget
	{
		private readonly ApplicationDbContext _ctx;
		private readonly Guid _userId;

		public BudgetServices(Guid userId)
		{
			_userId = userId;
		}

		public bool CreateBudget(Budget model)
		{
			using (_ctx)
			{
				_ctx.Budgets.Add(model);
				return _ctx.SaveChanges() == 1;
			}
		}

		public bool DeleteBudget(int id)
		{
			using (_ctx)
			{

				var entity =
					_ctx
						.Budgets
						.Single(x => x.BudgetId == id && x.OwnerId == _userId);

				_ctx.Budgets.Remove(entity);
				return _ctx.SaveChanges() == 1;
			}
		}

		public Budget GetBudget(int id)
		{
			using (_ctx)
			{
				return _ctx.Budgets.Single(x => x.BudgetId == id && x.OwnerId == _userId);
			}
		}

		public IEnumerable<Budget> GetBudgets()
		{
			using (_ctx)
			{
				var query =
					_ctx
						.Budgets
						.Select
						(
							x =>
								new Budget
								{
									BudgetId = x.BudgetId,
									OwnerId = x.OwnerId,
									AvailableBalance = x.AvailableBalance,
									Expenses = x.Expenses,
									MonthlyIncome = x.MonthlyIncome
								}
						);

				return query.ToArray();
			}
		}

		public bool UpdateBudget(Budget model)
		{
			using (_ctx)
			{
				var entity =
					_ctx
						.Budgets
						.Single(x => x.OwnerId == _userId && x.BudgetId == model.BudgetId);

				entity.BudgetId = model.BudgetId;
				entity.Expenses = model.Expenses;
				entity.MonthlyIncome = model.MonthlyIncome;
				entity.OwnerId = model.OwnerId;
				entity.AvailableBalance = model.AvailableBalance;

				return _ctx.SaveChanges() == 1;
			}
		}
	}
}
