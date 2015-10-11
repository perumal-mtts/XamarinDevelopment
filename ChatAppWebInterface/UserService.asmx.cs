using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using ChatAppService.Models;
using ChatAppService.Services;

namespace ChatAppService
{
    [WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class UserService : System.Web.Services.WebService
	{
		static readonly IUserService userService = new Services.UserService(new UserRepository());

		[WebMethod]
		public List<User> GetUsers()
		{
			return userService.GetData().ToList();
		}

		[WebMethod]
		public void CreateUser(User item)
		{
			try
			{
				// Determine if the ID already exists
				var itemExists = userService.DoesItemExist(item.ID);
				if (itemExists)
				{
					throw new SoapException("User ID is in use", SoapException.ClientFaultCode);
				}

				userService.InsertData(item);
			}
			catch (Exception ex)
			{
				throw new SoapException(ex.Message, SoapException.ServerFaultCode, ex);
			}
		}

		[WebMethod]
		public void EditUser(User item)
		{
			try
			{
				if (item == null ||
					string.IsNullOrWhiteSpace(item.Name))
				{
					throw new SoapException("User name and notes fields are required", SoapException.ClientFaultCode);
				}

				var User = userService.Find(item.ID);
				if (User != null)
				{
					userService.UpdateData(item);
				}
				else
				{
					throw new SoapException("User not found", SoapException.ClientFaultCode);
				}
			}
			catch (Exception ex)
			{
				throw new SoapException("Error", SoapException.ServerFaultCode, ex);
			}
		}

		[WebMethod]
		public void DeleteUser(string id)
		{
			try
			{
				var User = userService.Find(id);
				if (User != null)
				{
					userService.DeleteData(id);
				}
				else
				{
					throw new SoapException("User not found", SoapException.ClientFaultCode);
				}
			}
			catch (Exception ex)
			{
				throw new SoapException("Error", SoapException.ServerFaultCode, ex);
			}
		}

		[WebMethod]
		public void SendFriendRequest(FriendRequest request)
		{
			try
			{
				userService.SendFriendRequest(request);
			}
			catch (Exception ex)
			{
				throw new SoapException("Error", SoapException.ServerFaultCode, ex);
			}
		}

		[WebMethod]
		public void ApproveFriendRequest(FriendRequest request)
		{
			try
			{
				userService.ApproveFriendRequest(request);
			}
			catch (Exception ex)
			{
				throw new SoapException("Error", SoapException.ServerFaultCode, ex);
			}
		}

		[WebMethod]
		public User GetValidUser(User user)
		{
			try
			{
				return userService.IsValidUser(user.EmailId, user.Password);
			}
			catch (Exception ex)
			{
				throw new SoapException("Error", SoapException.ServerFaultCode, ex);
			}
		}

		[WebMethod]
		public List<User> GetMyRequests(string fromUserId)
		{
			try
			{
				return userService.GetRequests(fromUserId); 
			}
			catch (Exception ex)
			{
				throw new SoapException("Error", SoapException.ServerFaultCode, ex);
			}
		}

		[WebMethod]
		public List<User> GetMyFriends(string id)
		{
			try
			{
				return userService.GetMyFriends(id);
			}
			catch (Exception ex)
			{
				throw new SoapException("Error", SoapException.ServerFaultCode, ex);
			}
		}
	}
}
