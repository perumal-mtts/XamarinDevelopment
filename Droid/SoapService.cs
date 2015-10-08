using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace ChatApp.Droid
{
	public class SoapService : ISoapService
	{
		ChatAppService.UserService userService;

		public List<User> Items
		{
			get;
			private set;
		}

		public SoapService()
		{
			userService = new ChatAppService.UserService();
		}

		public async Task<List<User>> RefreshDataAsync()
		{
			Items = new List<User>();

			try
			{
				var Users = await Task.Factory.FromAsync<ChatAppService.User[]>(userService.BeginGetUsers, userService.EndGetUsers,null, TaskCreationOptions.None);

				foreach (var item in Users)
				{
					Items.Add(Helper.ConvertToUserModel(item));
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}

			return Items;
		}

		public async Task SaveUserAsync(User item, bool isNewItem = false)
		{
			try
			{
				var User = Helper.ConvertToUser(item);
				if (isNewItem)
				{
					await Task.Factory.FromAsync(userService.BeginCreateUser, userService.EndCreateUser, User, TaskCreationOptions.None);
				}
				else
				{
					await Task.Factory.FromAsync(userService.BeginEditUser, userService.EndEditUser, User, TaskCreationOptions.None);
				}
			}
			catch (SoapException se)
			{
				Debug.WriteLine(@"				{0}", se.Message);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
		}

		public async Task DeleteUserAsync(string id)
		{
			try
			{
				await Task.Factory.FromAsync(userService.BeginDeleteUser, userService.EndDeleteUser, id, TaskCreationOptions.None);
			}
			catch (SoapException se)
			{
				Debug.WriteLine(@"				{0}", se.Message);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
		}

		public User GetValidUserAsync(User user)
		{
			try
			{
				var returnUser = userService.GetValidUser(Helper.ConvertToUser(user));

				if(returnUser == null)
					return null;
				
				return Helper.ConvertToUserModel(returnUser);
			}
			catch (SoapException se)
			{
				Debug.WriteLine(@"				{0}", se.Message);
				throw se;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
				throw ex;
			}
		}

		public void SendFriendRequest(FriendRequest friendRequest)
		{
			try
			{
				userService.SendFriendRequest(Helper.ConvertToFriendRequest(friendRequest));
			}
			catch (SoapException se)
			{
				Debug.WriteLine(@"				{0}", se.Message);
				throw se;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
				throw ex;
			}
		}

		public List<User> GetMyRequests(string fromUserId)
		{
			try
			{
				List<User> myRequests = new List<User>();

				var requests  = userService.GetMyRequests(fromUserId);

				foreach (var item in requests)
				{
					myRequests.Add(Helper.ConvertToUserModel(item));
				}

				return myRequests;
			}
			catch (SoapException se)
			{
				Debug.WriteLine(@"				{0}", se.Message);
				throw se;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
				throw ex;
			}
		}
	}
}
