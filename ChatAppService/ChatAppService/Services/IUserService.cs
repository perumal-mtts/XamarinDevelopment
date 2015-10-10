using System.Collections.Generic;
using ChatAppService.Models;

namespace ChatAppService.Services
{
	public interface IUserService
	{
		bool DoesItemExist(string id);
		User Find(string id);
		IEnumerable<User> GetData();
		void InsertData(User item);
		void UpdateData(User item);
		void DeleteData(string id);


		void SendFriendRequest(FriendRequest friendRequest);
		void ApproveFriendRequest(FriendRequest friendRequest);
		void RejectFriendRequest(FriendRequest friendRequest);

		User IsValidUser(string emailId, string password);
		List<User> GetRequests(string fromUserId);

		List<User> GetMyFriends (string userId);
	}
}
