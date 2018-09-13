using CashFlow.Data;
using CashFlow.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CashFlow.WebApi.Controllers
{
	[Authorize]
	public class NetWorthController : ApiController
	{
		public IHttpActionResult Get(int id)
		{
			var service = CreateCashFlowService();
			var netWorth = service.GetNetWorth(id);
			return Ok(netWorth);

		}

		private NetWorthServices CreateCashFlowService()
		{
			var userId = Guid.Parse(User.Identity.GetUserId());
			return new NetWorthServices(userId);
		}


		public IHttpActionResult Post(NetWorth model)
		{
			var service = CreateCashFlowService();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!service.CreateNetWorth(model))
				return InternalServerError();

			return Ok();
		}


		public IHttpActionResult Put(NetWorth model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var service = CreateCashFlowService();

			if (!service.UpdateNetWorth(model))

				return InternalServerError();

			return Ok();
		}

		public IHttpActionResult GetAll()
		{
			var networthService = CreateCashFlowService();
			var networth = networthService.GetNetWorths();
			return Ok(networth);
		}

		public IHttpActionResult Delete(int id)
		{
			var service = CreateCashFlowService();

			if (!service.DeleteNetWorth(id))
				return InternalServerError();

			return Ok();
		}
	}
}