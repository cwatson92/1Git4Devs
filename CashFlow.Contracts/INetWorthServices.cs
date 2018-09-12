using CashFlow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Contracts
{
	public interface INetWorthServices
	{
		bool CreateNetWorth(NetWorth model);
		NetWorth GetNetWorth(int id);
		IEnumerable<NetWorth> GetNetWorths();
		bool UpdateNetWorth(NetWorth model);
		bool DeleteNetWorth(int id);
	}
}
