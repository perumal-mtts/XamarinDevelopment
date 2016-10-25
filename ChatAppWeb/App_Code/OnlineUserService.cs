using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatAppService.Models
{
    public static class OnlineUserService
    {
        public static List<OnlineUser> OnlineUsers = new List<OnlineUser>();
        
		public static void AddOnlineUser(string strConnectionId, string strUserName,string strUserId,string strSessionId)
        {
            OnlineUser user = new OnlineUser();
            user.ConnectionId = strConnectionId;
            user.UserName = strUserName;
            user.UserId = strUserId;
            user.NewStatus = true;
            user.SessionId = strSessionId;
			OnlineUsers.Add(user);
        }

        public static void RemoveOnlineUser(string strConnectionId, string strUserName,string strUserId)
        {
			var userRemove = (OnlineUser)OnlineUsers.Where(item => item.ConnectionId == strConnectionId && item.UserName == strUserName);
			OnlineUsers.Remove(userRemove);            
        }
    }
}
