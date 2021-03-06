﻿using CashFlow.Contracts;
using CashFlow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Services
{
	public class ExpenseServices : IExpenseServices
	{
		private ApplicationDbContext _ctx = new ApplicationDbContext();
		private Guid _userId;

		public ExpenseServices(Guid userId)
		{
			_userId = userId;
		}

		public bool CreateExpense(Expense model)
		{
			model.OwnerId = _userId;
			using (_ctx)
			{
				_ctx.Expenses.Add(model);
				return _ctx.SaveChanges() == 1;
			}
		}

		public bool DeleteExpense(int id)
		{
			using (_ctx)
			{
				var entity = 
					_ctx
						.Expenses
						.Single(x => x.ExpenseId == id && x.OwnerId == _userId);

				_ctx.Expenses.Remove(entity);

				return _ctx.SaveChanges() == 1;
			}
		}

		public Expense GetExpense(int id)
		{
			using (_ctx)
			{
				return _ctx.Expenses.Single(x => x.ExpenseId == id && x.OwnerId == _userId);
			}
		}

		public IEnumerable<Expense> GetExpenses()
		{
			using (_ctx)
			{
				var query =
					_ctx
						.Expenses
						.Where(x => x.OwnerId == _userId);

				return query.ToArray();
			}
		}

		public bool UpdateExpense(Expense model)
		{
			model.OwnerId = _userId;

			using (_ctx)
			{
				var entity = 
					_ctx
						.Expenses
						.Single(x => x.ExpenseId == model.ExpenseId && x.OwnerId == _userId);

				entity.OwnerId = model.OwnerId;
				entity.Name = model.Name;
				entity.ExpenseId = model.ExpenseId;
				entity.Cost = model.Cost;
				entity.Description = model.Description;

				return _ctx.SaveChanges() == 1;
			}
		}
	}
}
