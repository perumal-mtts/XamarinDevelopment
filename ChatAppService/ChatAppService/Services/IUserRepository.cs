using System.Collections.Generic;
using ChatAppService.Models;

namespace ChatAppService.Services
{
	public interface IUserRepository
	{
		bool DoesItemExist(string id);
		IEnumerable<User> All
		{
			get;
		}
		User Find(string id);
		void Insert(User item);
		void Update(User item);
		void Delete(string id);

		void SendFriendRequest(FriendRequest friendRequest);
		void UpdateFriendRequest(FriendRequest friendRequest);
		User IsValidUser(string emailId, string password);
		List<User> GetRequests (string fromUserId);
	}
}
