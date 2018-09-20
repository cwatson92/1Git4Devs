using System;
using CashFlow.Contracts;
using CashFlow.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashFlow.WebApiTests
{
	[TestClass]
	public abstract class ExpenseControllerTestBase
	{
		protected ExpenseController _controller;
		protected FakeExpenseServices _expenseService;

		[TestInitialize]
		public virtual void Arrange()
		{
			_expenseService = new FakeExpenseServices();

			_controller = new ExpenseController(
				new Lazy<IExpenseServices>(() => _expenseService));
		}
	}
}
