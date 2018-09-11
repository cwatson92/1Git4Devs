using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Data
{
	public class AdminUsers
	{
		[Key]
		public int RoleId { get; set; }

		public Guid UserId { get; set; }
	}
}
