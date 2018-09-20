using CashFlow.Contracts;
using CashFlow.Data;
using CashFlow.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CashFlow.WebApi.Controllers
{
	[Authorize]
	public class ExpenseController : ApiController
	{
		private readonly IExpenseServices _expenseServices;

		public ExpenseController()
		{
			//_expenseServices = new Lazy<IExpenseServices>(() => CreateExpenseServices());
		}

		public ExpenseController(IExpenseServices expenseServices)
		{
			_expenseServices = expenseServices;
		}

		public IHttpActionResult Get(int id)
		{
			var expense = _expenseServices.GetExpense(id);
			return Ok(expense);
		}

		public IHttpActionResult Post(Expense model)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			if (!_expenseServices.CreateExpense(model)) return InternalServerError();

			return Ok();
		}

		public IHttpActionResult Put(Expense model)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			if (!_expenseServices.UpdateExpense(model)) return InternalServerError();

			return Ok();
		}

		public IHttpActionResult GetAll()
		{
			var expenses = _expenseServices.GetExpenses();
			return Ok(expenses);
		}

		public IHttpActionResult Delete(int id)
		{
			if (!_expenseServices.DeleteExpense(id)) return InternalServerError();

			return Ok();
		}
	}
}
