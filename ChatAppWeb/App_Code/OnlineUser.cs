using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAppService.Models
{
	public class OnlineUser
	{
		private string connectionId;
		public string ConnectionId
		{
			get
			{
				return connectionId;
			}
			set
			{
				connectionId = value;
			}
		}

		private string userName;
		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				userName = value;
			}
		}

		private string userId;
		public string UserId
		{
			get
			{
				return userId;
			}
			set
			{
				userId = value;
			}
		}

		private bool newStatus = false;
		public bool NewStatus
		{
			get
			{
				return newStatus;
			}
			set
			{
				newStatus = value;
			}
		}
		
		private string sessionId;
		public string SessionId
		{
			get
			{
				return sessionId;
			}
			set
			{
				sessionId = value;
			}
		}
	}
}