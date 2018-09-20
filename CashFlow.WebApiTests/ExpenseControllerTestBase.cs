using System;
using CashFlow.Contracts;
using CashFlow.Data;
using CashFlow.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashFlow.WebApiTests
{
	[TestClass]
	public abstract class ExpenseControllerTestBase
	{
		protected ExpenseController _controller;
		protected FakeExpenseServices _fakeExpenseService;

		protected Expense _model = new Expense()
		{
			BudgetId = 1,
			ExpenseId = 1,
			Cost = 20.0m,
			Name = "YouTube",
			Description = "YouTube Premium"
		};

		[TestInitialize]
		public virtual void Arrange()
		{
			_fakeExpenseService = new FakeExpenseServices();

			_controller = new ExpenseController(
				new FakeExpenseServices());
		}
	}
}
