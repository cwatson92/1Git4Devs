using CashFlow.Contracts;
using CashFlow.Data;
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
		ApplicationDbContext _ctx = new ApplicationDbContext();

		public UserServices(Guid userId)
		{
			_userId = userId;
		}

		public bool CreateUser(UserInfo model)
		{
			using (_ctx)
			{
				_ctx.UserInfos.Add(model);
				return _ctx.SaveChanges() == 1;
			}
		}

		public UserInfo GetUserInfo(int id)
		{
			using (_ctx)
			{
				var entity = 
					_ctx
						.UserInfos
						.Single(x => x.UserId == id && x.OwnerId == _userId);

				return entity;
			}
		}

		public bool UpdateUserInfo(UserInfo model)
		{
			using (_ctx)
			{
				var entity =
					_ctx
						.UserInfos
						.Single(x => x.UserId == model.UserId && x.OwnerId == _userId);

				entity.FirstName = model.FirstName;
				entity.LastName = model.LastName;
				entity.LastFour = model.LastFour;

				return _ctx.SaveChanges() == 1;
			}
		}
	}
}
