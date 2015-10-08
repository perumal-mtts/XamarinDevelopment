using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAppService.Models
{
	[Serializable]
	public class UserFriend
	{
		public string UserId
		{
			get;
			set;
		}

		public string FriendId
		{
			get;
			set;
		}
	}
}