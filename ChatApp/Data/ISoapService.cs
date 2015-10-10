using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp
{
	public interface ISoapService
	{
		Task<List<User>> RefreshDataAsync ();

		Task SaveUserAsync(User item, bool isNewItem);

		Task DeleteUserAsync(string id);

		User GetValidUserAsync(User user);

		void SendFriendRequest (FriendRequest friendRequest);

		void ApproveFriendRequest (FriendRequest friendRequest);

		List<User> GetMyRequests (string fromUserId);

		List<User> GetMyFriends (string userId);
	}
}
