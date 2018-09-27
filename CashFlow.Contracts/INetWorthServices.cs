using CashFlow.Data;
using CashFlow.Models;
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
		NetWorthWithTotals GetNetWorth(int id);
		IEnumerable<NetWorthWithTotals> GetNetWorths();
		bool UpdateNetWorth(NetWorth model);
		bool DeleteNetWorth(int id);
	}
}
