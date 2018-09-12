using CashFlow.Contracts;
using CashFlow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Services
{
	public class CashFlowServices : INetWorthServices
	{
		private readonly Guid _userId;

		public CashFlowServices(Guid userId)
		{
			_userId = userId;
		}

		public bool CreateNetWorth(NetWorth model)
		{
			throw new NotImplementedException();
		}

		public bool DeleteNetWorth(int id)
		{
			throw new NotImplementedException();
		}

		public NetWorth GetNetWorth(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<NetWorth> GetNetWorths()
		{
			throw new NotImplementedException();
		}

		public bool UpdateNetWorth(NetWorth model)
		{
			throw new NotImplementedException();
		}
	}
}
