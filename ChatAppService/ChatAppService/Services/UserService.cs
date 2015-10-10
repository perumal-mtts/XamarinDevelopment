using System;
using System.Collections.Generic;
using ChatAppService.Models;

namespace ChatAppService.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _repository;

		public UserService(IUserRepository repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}

			_repository = repository;
		}

		public bool DoesItemExist(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new ArgumentNullException(id);
			}

			return _repository.DoesItemExist(id);
		}

		public User Find(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new ArgumentNullException("id");
			}

			return _repository.Find(id);
		}

		public IEnumerable<User> GetData()
		{
			return _repository.All;
		}

		public void InsertData(User user)
		{
			if (user == null)
			{
				throw new ArgumentNullException("user");
			}

			if (string.IsNullOrEmpty(user.Name))
			{
				throw new InvalidOperationException("User name is required");
			}

			if (string.IsNullOrEmpty(user.EmailId))
			{
				throw new InvalidOperationException("EmailId is required");
			}

			if (string.IsNullOrEmpty(user.Password))
			{
				throw new InvalidOperationException("Password is required");
			}

			_repository.Insert(user);
		}

		public void UpdateData(User user)
		{
			if (user == null)
			{
				throw new ArgumentNullException("user");
			}

			_repository.Update(user);
		}

		public void DeleteData(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				throw new ArgumentNullException("id");
			}

			_repository.Delete(id);
		}

		public void SendFriendRequest(FriendRequest friendRequest)
		{
			friendRequest.Status = FriendRequestStatus.None;
			_repository.SendFriendRequest(friendRequest);
		}

		public void ApproveFriendRequest(FriendRequest friendRequest)
		{
			friendRequest.Status = FriendRequestStatus.Approved;
			_repository.UpdateFriendRequest(friendRequest);
		}

		public void RejectFriendRequest(FriendRequest friendRequest)
		{
			friendRequest.Status = FriendRequestStatus.Rejected;
			_repository.UpdateFriendRequest(friendRequest);
		}

		public User IsValidUser(string emailId, string password)
		{
			return _repository.IsValidUser(emailId, password);
		}

		public List<User> GetRequests(string fromUserId)
		{
			return _repository.GetRequests(fromUserId);
		}

		public List<User> GetMyFriends(string userId)
		{
			return _repository.GetMyFriends(userId);
		}
	}
}
