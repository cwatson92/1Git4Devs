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
		ApplicationDbContext _ctx = new ApplicationDbContext();
		private Guid _userId;

		public BudgetServices(Guid userId)
		{
			_userId = userId;
		}

		public bool CreateBudget(Budget model)
		{
			model.OwnerId = _userId;

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
				var entity =
					_ctx
						.Budgets
						.Single(x => x.OwnerId == _userId && x.BudgetId == id);

				return new Budget
				{
					BudgetId = entity.BudgetId,
					OwnerId = entity.OwnerId,
					MonthlyIncome = entity.MonthlyIncome,
					EstimatedAvailableBalance = entity.EstimatedAvailableBalance,
					SavingsAmount = entity.SavingsAmount
				};
			}
		}

		public IEnumerable<Budget> GetBudgets()
		{
			using (_ctx)
			{
				//var query =
				//	_ctx
				//		.Budgets
				//		.Where(x => x.OwnerId == _userId)
				//		.Select
				//		(
				//			x =>
				//				new Budget
				//				{
				//					BudgetId = x.BudgetId,
				//					OwnerId = x.OwnerId,
				//					MonthlyIncome = x.MonthlyIncome,
				//					EstimatedAvailableBalance = x.EstimatedAvailableBalance,
				//					SavingsAmount = x.SavingsAmount
				//				}
				//		);

				//return query.ToArray();

				var query = from b in _ctx.Budgets
					   where b.OwnerId == _userId
					   select b;

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
				entity.MonthlyIncome = model.MonthlyIncome;
				entity.OwnerId = model.OwnerId;
				entity.SavingsAmount = model.SavingsAmount;
				entity.EstimatedAvailableBalance = model.EstimatedAvailableBalance;

				return _ctx.SaveChanges() == 1;
			}
		}
	}
}
