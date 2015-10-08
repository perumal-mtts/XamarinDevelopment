using System;

namespace ChatApp.Droid
{
	public static class Helper
	{
		public static ChatAppService.User ConvertToUser(User item)
		{
			return new ChatAppService.User
			{
				ID = item.ID,
				Name = item.Name,
				Password = item.Password,
				EmailId = item.EmailId
			};
		}

		public static User ConvertToUserModel(ChatAppService.User item)
		{
			return new User
			{
				ID = item.ID,
				Name = item.Name,
				Password = item.Password,
				EmailId = item.EmailId
			};
		}

		public static ChatAppService.FriendRequest ConvertToFriendRequest(FriendRequest request)
		{
			return new ChatAppService.FriendRequest
			{
				FromUserId = request.FromUserId,
				ToUserId = request.ToUserId
			};
		}
	}
}

