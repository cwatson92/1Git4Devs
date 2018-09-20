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
		public IHttpActionResult Get(int id)
		{
			var expense = service.GetExpense(id);
			return Ok(expense);
		}

		public IHttpActionResult Post(Expense model)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			if (!service.CreateExpense(model)) return InternalServerError();

			return Ok();
		}

		public IHttpActionResult Put(Expense model)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			if (!service.UpdateExpense(model)) return InternalServerError();

			return Ok();
		}

		public IHttpActionResult GetAll()
		{
			var expenses = service.GetExpenses();
			return Ok(expenses);
		}

		public IHttpActionResult Delete(int id)
		{
			if (!service.DeleteExpense(id)) return InternalServerError();

			return Ok();
		}

		private ExpenseServices CreateExpenseService()
		{
			return new ExpenseServices(Guid.Parse(User.Identity.GetUserId()));
		}
	}
}
