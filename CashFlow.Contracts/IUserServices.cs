using CashFlow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Contracts
{
	public interface IUserServices
	{
		bool CreateUser(UserInfo model);
		bool GetUserInfo(int userId);
		bool UpdateUserServices(int userId);
	}
}
