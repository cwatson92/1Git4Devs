using System;
using System.Web.Http;
using System.Web.Http.Results;
using CashFlow.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashFlow.WebApiTests
{
	[TestClass]
	public class CreateExpenseTests : ExpenseControllerTestBase
	{
		[TestInitialize]
		public override void Arrange()
		{
			base.Arrange();

			_fakeExpenseService.ReturnValue = true;
			_model = new Expense();
		}

		private IHttpActionResult Act()
		{
			var post = _controller.Post(_model);
			return post;
		}

		[TestMethod]
		public void ExpenseController_Post_ShouldReturnIHttpActionResult()
		{
			var result = Act();

			Assert.IsInstanceOfType(result, typeof(IHttpActionResult));
		}
	}
}
