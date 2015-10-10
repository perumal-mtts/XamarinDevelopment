using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp
{
	public class UserManager
	{
		ISoapService soapService;

		public UserManager (ISoapService service)
		{
			soapService = service;
		}

		public Task<List<User>> GetUsersAsync ()
		{
			return soapService.RefreshDataAsync ();
		}

		public Task SaveUserAsync (User item, bool isNewItem = false)
		{
			return soapService.SaveUserAsync (item, isNewItem);
		}

		public Task DeleteUserAsync (User item)
		{
			return soapService.DeleteUserAsync (item.ID);
		}

		public User GetValidUser(User user)
		{
			return soapService.GetValidUserAsync(user);
		}

		public void SendFriendRequest(FriendRequest request)
		{
			soapService.SendFriendRequest (request);
		}

		public void ApproveFriendRequest(FriendRequest request)
		{
			soapService.ApproveFriendRequest (request);
		}

		public List<User> GetRequests(string fromUserId)
		{
			return soapService.GetMyRequests (fromUserId);
		}

		public List<User> GetMyFriends(string userId)
		{
			return soapService.GetMyFriends (userId);
		}
	}
}
