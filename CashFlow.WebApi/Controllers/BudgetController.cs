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
	public class BudgetController : ApiController
	{
		public IHttpActionResult Get(int id)
		{
			var service = CreateBudgetServices();
			var budget = service.GetBudget(id);
			return Ok(budget);
		}

		public IHttpActionResult Post(Budget model)
		{
			var service = CreateBudgetServices();

			if (!ModelState.IsValid) return BadRequest(ModelState);

			if (!service.CreateBudget(model)) return InternalServerError();

			return Ok();
		}

		public IHttpActionResult Put(Budget model)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var service = CreateBudgetServices();

			if (!service.UpdateBudget(model)) return InternalServerError();

			return Ok();
		}

		public IHttpActionResult GetAll()
		{
			var service = CreateBudgetServices();
			var budget = service.GetBudgets();
			return Ok(budget);
		}

		public IHttpActionResult Delete(int id)
		{
			var service = CreateBudgetServices();

			if (!service.DeleteBudget(id)) return InternalServerError();

			return Ok();
		}

		private BudgetServices CreateBudgetServices()
		{
			var userId = Guid.Parse(User.Identity.GetUserId());
			return new BudgetServices(userId);
		}
	}
}
