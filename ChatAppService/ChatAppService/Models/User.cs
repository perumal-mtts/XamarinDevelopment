using System;

namespace ChatAppService.Models
{
	[Serializable]
	public class User
	{
		public string ID
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string EmailId
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}
	}
}
