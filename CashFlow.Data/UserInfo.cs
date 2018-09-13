using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Data
{
	public class UserInfo
	{
		[Key]
		public int UserId { get; set; }

		public Guid OwnerId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int LastFour { get; set; }

		public string Username { get; set; }
		//TODO: Add Profile Pics
	}
}
