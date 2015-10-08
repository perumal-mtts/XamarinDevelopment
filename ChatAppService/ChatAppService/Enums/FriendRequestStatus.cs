using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppService
{
	public enum FriendRequestStatus
	{
		None = 0,
		Approved = 1,
		Rejected = 2,
		PendingAction = 3
	}
}
