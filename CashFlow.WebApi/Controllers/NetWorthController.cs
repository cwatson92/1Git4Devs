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

		/// <summary>
		/// Get Your Net Worth for your given account (need login token)
		/// </summary>
		/// <param name="id"></param>
		/// <returns>
		/// returns a NetWorth Object
		/// </returns>
		public IHttpActionResult Get(int id)
		{
			var service = CreateNetWorthServices();
			var netWorth = service.GetNetWorth(id);
			return Ok(netWorth);

		}

		/// <summary>
		/// Get all net worths for your given account (need login token)
		/// </summary>
		/// <returns>
		/// returns a Collection of networth Objects 
		/// </returns>
		public IHttpActionResult GetAll()
		{
			var service = CreateNetWorthServices();
			var netWorth = service.GetNetWorths();
			return Ok(netWorth);
		}
	
		private NetWorthServices CreateNetWorthServices()
		{
			var userId = Guid.Parse(User.Identity.GetUserId());
			return new NetWorthServices(userId);
		}

		/// <summary>
		/// Post a new Net Worth to our database stored under your account
		/// </summary>
		/// <param name="model"></param>
		/// <returns>
		/// Returns Response code 200 if successful
		/// </returns>
		public IHttpActionResult Post(NetWorth model)
		{
			var service = CreateNetWorthServices();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!service.CreateNetWorth(model))
				return InternalServerError();

			return Ok();
		}

		/// <summary>
		/// Update a networth object
		/// </summary>
		/// <param name="model"></param>
		/// <returns>
		/// returns response code 200 if succuessfull
		/// </returns>
		public IHttpActionResult Put(NetWorth model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var service = CreateNetWorthServices();

			if (!service.UpdateNetWorth(model))

				return InternalServerError();

			return Ok();
		}

		/// <summary>
		/// remove a networth from our database (probably too embarrasing right?)
		/// </summary>
		/// <param name="id"></param>
		/// <returns>
		/// Returns status code 200 if successful
		/// </returns>
		public IHttpActionResult Delete(int id)
		{
			var service = CreateNetWorthServices();

			if (!service.DeleteNetWorth(id))
				return InternalServerError();

			return Ok();
		}
	}
}