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
	public class UserInfoController : ApiController
	{
		public IHttpActionResult Get(int id)
		{
			var service = CreateUserServices();
			var userInfo = service.GetUserInfo(id);
			return Ok(userInfo);
		}

		public IHttpActionResult Post(UserInfo model)
		{
			var service = CreateUserServices();

			if (!ModelState.IsValid) return BadRequest(ModelState);

			if (!service.CreateUser(model)) return InternalServerError();

			return Ok();
		}

		public IHttpActionResult Put(UserInfo model)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var service = CreateUserServices();

			if (!service.UpdateUserInfo(model)) return InternalServerError();

			return Ok();
		}

		private UserServices CreateUserServices()
		{
			var userId = Guid.Parse(User.Identity.GetUserId());
			return new UserServices(userId);
		}
	}
}
