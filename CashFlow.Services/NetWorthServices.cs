using CashFlow.Contracts;
using CashFlow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Services
{
	public class NetWorthServices : INetWorthServices
	{
		private readonly Guid _userId;
		ApplicationDbContext _ctx = new ApplicationDbContext();

		public NetWorthServices(Guid userId)
		{
			_userId = userId;
		}

		public bool CreateNetWorth(NetWorth model)
		{
			using (_ctx)
			{
				_ctx.NetWorths.Add(model);
				return _ctx.SaveChanges() == 1;
			}
		}

		public bool DeleteNetWorth(int id)
		{
			using (_ctx)
			{
				var entity =
					_ctx
						.NetWorths
						.Single(x => x.NetWorthId == id && x.OwnerId == _userId);

				_ctx.NetWorths.Remove(entity);
				return _ctx.SaveChanges() == 1;
			}
		}

		public NetWorth GetNetWorth(int id)
		{
			using (_ctx)
			{
				return _ctx.NetWorths.Single(x => x.NetWorthId == id && x.OwnerId == _userId);
			}
		}

		public IEnumerable<NetWorth> GetNetWorths()	
		{
			using (_ctx)
			{
				var query =
					_ctx
						.NetWorths
						.Select
						(
							x =>
								new NetWorth
								{
									NetWorthId = x.NetWorthId,
									OwnerId = x.OwnerId,
									TotalAssets = x.TotalAssets,
									TotalLiabilities = x.TotalLiabilities,
									TotalNetWorth = x.TotalNetWorth
								}
						);

				return query.ToArray();
			}
		}

		public bool UpdateNetWorth(NetWorth model)
		{
			using (_ctx)
			{
				var entity = 
					_ctx
						.NetWorths
						.Single(x => x.OwnerId == _userId && x.NetWorthId == model.NetWorthId);

				entity.NetWorthId = model.NetWorthId;
				entity.OwnerId = model.OwnerId;
				entity.SavingsAccount = model.SavingsAccount;
				entity.CheckingAccount = model.CheckingAccount;
				entity.MoneyMarketAccount = model.MoneyMarketAccount;
				entity.SavingsBonds = model.SavingsBonds;
				entity.CertificateOfDeposits = model.CertificateOfDeposits;
				entity.IRA = model.IRA;
				entity.RothIRA = model.RothIRA;
				entity.Retirement401K = model.Retirement401K;
				entity.SepIRA = model.SepIRA;
				entity.Pension = model.Pension;
				entity.Annuity = model.Annuity;
				entity.RealEstate = model.RealEstate;
				entity.PrincipalHome = model.PrincipalHome;
				entity.VacationHome = model.VacationHome;
				entity.CarsTrucksBoats = model.CarsTrucksBoats;
				entity.HomeFurnishings = model.HomeFurnishings;
				entity.OtherAssets = model.OtherAssets;
				entity.TotalAssets = model.TotalAssets;
				entity.CreditCardBalance = model.CreditCardBalance;
				entity.EstimatedIncomeTaxOwed = model.EstimatedIncomeTaxOwed;
				entity.OtherOutstandingBills = model.OtherOutstandingBills;
				entity.HomeMortgage = model.HomeMortgage;
				entity.HomeEquityLoan = model.HomeEquityLoan;
				entity.MortgagesOnRentals = model.MortgagesOnRentals;
				entity.CarLoans = model.CarLoans;
				entity.StudentLoans = model.StudentLoans;
				entity.LifeInsurancePolicyLoans = model.LifeInsurancePolicyLoans;
				entity.OtherLongTermDebt = model.OtherLongTermDebt;
				entity.TotalLiabilities = model.TotalLiabilities;
				entity.TotalNetWorth = model.TotalNetWorth;

				return _ctx.SaveChanges() == 1; //TODO: See if this works without setting all the properties
				//TODO: Can't See Log in or Register views but endpoints are there
			}
		}
	}
}
