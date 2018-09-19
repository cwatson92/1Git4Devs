using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Data
{
	public class NetWorth
	{
		[Key]
		public int NetWorthId { get; set; }

		public Guid OwnerId { get; set; }

		public decimal SavingsAccount { get; set; }

		public decimal CheckingAccount { get; set; }

		public decimal MoneyMarketAccount { get; set; }

		public decimal SavingsBonds { get; set; }

		public decimal CertificateOfDeposits { get; set; }

		public decimal IRA { get; set; }

		public decimal RothIRA { get; set; }

		public decimal Retirement401K { get; set; }

		public decimal SepIRA { get; set; }

		public decimal Pension { get; set; }

		public decimal Annuity { get; set; }

		public decimal RealEstate { get; set; }

		public decimal PrincipalHome { get; set; }

		public decimal VacationHome { get; set; }

		public decimal CarsTrucksBoats { get; set; }

		public decimal HomeFurnishings { get; set; }

		public decimal OtherAssets { get; set; }

		public decimal TotalAssets
		{
			get => SavingsAccount + CheckingAccount + MoneyMarketAccount + SavingsBonds +
				CertificateOfDeposits + IRA + RothIRA + Retirement401K + SepIRA + Pension +
				Annuity + RealEstate + PrincipalHome + VacationHome + CarsTrucksBoats +
				HomeFurnishings + OtherAssets;
			set { }
		}

		public decimal CreditCardBalance { get; set; }

		public decimal EstimatedIncomeTaxOwed { get; set; }

		public decimal OtherOutstandingBills { get; set; }

		public decimal HomeMortgage { get; set; }

		public decimal HomeEquityLoan { get; set; }

		public decimal MortgagesOnRentals { get; set; }

		public decimal CarLoans { get; set; }

		public decimal StudentLoans { get; set; }

		public decimal LifeInsurancePolicyLoans { get; set; }

		public decimal OtherLongTermDebt { get; set; }

		public decimal TotalLiabilities
		{
			get => CreditCardBalance + EstimatedIncomeTaxOwed +
				OtherOutstandingBills + HomeMortgage + HomeEquityLoan + MortgagesOnRentals +
				CarLoans + StudentLoans + LifeInsurancePolicyLoans + OtherLongTermDebt;
			set { }
		}

		public decimal TotalNetWorth
		{
			get => TotalAssets - TotalLiabilities;
			set { }
		}
	}
}
