using CashFlow.Contracts;
using CashFlow.Data;
using CashFlow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Services
{
	public class UserServices : IUserServices
	{
		private readonly Guid _userId;
		private readonly ApplicationDbContext _ctx;

		public bool CreateUser(UserInfo model)
		{
			using (_ctx)
			{
				_ctx.Users.Add(model);
				return _ctx.SaveChanges() == 1;
			}
		}

		public UserInfo GetUserInfo(int userId)
		{
			using (_ctx)
			{
				var entity = 
					_ctx
						.Users
						.Single(x => x.UserId == userId && x.OwnerId == _userId);

				return entity;
			}
		}

		public bool UpdateUserServices(int userId)
		{
			throw new NotImplementedException();
		}
	}
}
