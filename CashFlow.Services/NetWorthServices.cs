using CashFlow.Contracts;
using CashFlow.Data;
using CashFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Services
{
	public class NetWorthServices : INetWorthServices
	{
		private Guid _userId;
		ApplicationDbContext _ctx = new ApplicationDbContext();

		public NetWorthServices(Guid userId)
		{
			_userId = userId;
		}

		public bool CreateNetWorth(NetWorth model)
		{
			model.OwnerId = _userId;

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

		public NetWorthWithTotals GetNetWorth(int id)
		{
			using (_ctx)
			{
				var entity = 
					_ctx
						.NetWorths
						.Single(x => x.OwnerId == _userId && x.NetWorthId == id);

				var dto = new NetWorthWithTotals
				{
					NetWorthId = entity.NetWorthId,
					OwnerId = entity.OwnerId,
					SavingsAccount = entity.SavingsAccount,
					CheckingAccount = entity.CheckingAccount,
					MoneyMarketAccount = entity.MoneyMarketAccount,
					SavingsBonds = entity.SavingsBonds,
					CertificateOfDeposits = entity.CertificateOfDeposits,
					IRA = entity.IRA,
					RothIRA = entity.RothIRA,
					Retirement401K = entity.Retirement401K,
					SepIRA = entity.SepIRA,
					Pension = entity.Pension,
					Annuity = entity.Annuity,
					RealEstate = entity.RealEstate,
					PrincipalHome = entity.PrincipalHome,
					VacationHome = entity.VacationHome,
					CarsTrucksBoats = entity.CarsTrucksBoats,
					HomeFurnishings = entity.HomeFurnishings,
					OtherAssets = entity.OtherAssets,
					CreditCardBalance = entity.CreditCardBalance,
					EstimatedIncomeTaxOwed = entity.EstimatedIncomeTaxOwed,
					OtherOutstandingBills = entity.OtherOutstandingBills,
					HomeMortgage = entity.HomeMortgage,
					HomeEquityLoan = entity.HomeEquityLoan,
					MortgagesOnRentals = entity.MortgagesOnRentals,
					CarLoans = entity.CarLoans,
					StudentLoans = entity.StudentLoans,
					LifeInsurancePolicyLoans = entity.LifeInsurancePolicyLoans,
					OtherLongTermDebt = entity.OtherLongTermDebt,
					TotalAssets = entity.SavingsAccount + entity.CheckingAccount + entity.MoneyMarketAccount + entity.SavingsBonds + entity.CertificateOfDeposits + entity.CertificateOfDeposits +
						entity.IRA + entity.RothIRA + entity.Retirement401K + entity.SepIRA + entity.Pension + entity.Annuity + entity.RealEstate + entity.PrincipalHome + entity.VacationHome +
						entity.CarsTrucksBoats + entity.HomeFurnishings + entity.OtherAssets,
					TotalLiabilities = entity.CreditCardBalance + entity.EstimatedIncomeTaxOwed + entity.OtherOutstandingBills + entity.HomeMortgage + entity.HomeMortgage + entity.HomeEquityLoan + 
						entity.MortgagesOnRentals + entity.CarLoans + entity.StudentLoans + entity.LifeInsurancePolicyLoans + entity.OtherLongTermDebt,
				};

				dto.TotalNetWorth = dto.TotalAssets - dto.TotalLiabilities;

				return dto;
			}
		}

		public IEnumerable<NetWorthWithTotals> GetNetWorths()	
		{
			using (_ctx)
			{
				var query =
					_ctx
						.NetWorths
						.Where(x => x.OwnerId == _userId)
						.Select(
							x =>
								new NetWorthWithTotals
								{
									NetWorthId = x.NetWorthId,
									OwnerId = x.OwnerId,
									SavingsAccount = x.SavingsAccount,
									CheckingAccount = x.CheckingAccount,
									MoneyMarketAccount = x.MoneyMarketAccount,
									SavingsBonds = x.SavingsBonds,
									CertificateOfDeposits = x.CertificateOfDeposits,
									IRA = x.IRA,
									RothIRA = x.RothIRA,
									Retirement401K = x.Retirement401K,
									SepIRA = x.SepIRA,
									Pension = x.Pension,
									Annuity = x.Annuity,
									RealEstate = x.RealEstate,
									PrincipalHome = x.PrincipalHome,
									VacationHome = x.VacationHome,
									CarsTrucksBoats = x.CarsTrucksBoats,
									HomeFurnishings = x.HomeFurnishings,
									OtherAssets = x.OtherAssets,
									CreditCardBalance = x.CreditCardBalance,
									EstimatedIncomeTaxOwed = x.EstimatedIncomeTaxOwed,
									OtherOutstandingBills = x.OtherOutstandingBills,
									HomeMortgage = x.HomeMortgage,
									HomeEquityLoan = x.HomeEquityLoan,
									MortgagesOnRentals = x.MortgagesOnRentals,
									CarLoans = x.CarLoans,
									StudentLoans = x.StudentLoans,
									LifeInsurancePolicyLoans = x.LifeInsurancePolicyLoans,
									OtherLongTermDebt = x.OtherLongTermDebt,
									TotalAssets = x.SavingsAccount + x.CheckingAccount + x.MoneyMarketAccount + x.SavingsBonds
										+ x.CertificateOfDeposits + x.IRA + x.RothIRA + x.Retirement401K + x.SepIRA + x.Pension +
										x.Annuity + x.RealEstate + x.PrincipalHome + x.VacationHome + x.CarsTrucksBoats + x.HomeFurnishings
										+ x.OtherAssets,
									TotalLiabilities = x.CreditCardBalance + x.EstimatedIncomeTaxOwed + x.OtherOutstandingBills + x.HomeMortgage + 
									x.HomeEquityLoan + x.MortgagesOnRentals + x.CarLoans + x.StudentLoans + x.LifeInsurancePolicyLoans + x.OtherLongTermDebt,
								}

						);

				foreach(var a in query)
				{
					a.TotalNetWorth = a.TotalAssets - a.TotalLiabilities;
				}

				return query.ToArray();
			}
		}

		public bool UpdateNetWorth(NetWorth model)
		{
			model.OwnerId = _userId;

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


				return _ctx.SaveChanges() == 1;
			}
		}
	}
}
