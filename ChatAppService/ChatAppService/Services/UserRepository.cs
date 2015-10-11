using System.Collections.Generic;
using System.Linq;
using ChatAppService.Models;
using MySql.Data.MySqlClient;
using System;

namespace ChatAppService.Services
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private List<User> _userList;

        public UserRepository()
        {
            InitializeData();
        }

        public IEnumerable<User> All
        {
            get
            {
                return _userList;
            }
        }

        public bool DoesItemExist(string id)
        {
            return _userList.Any(item => item.ID == id);
        }

        public User Find(string id)
        {
            return _userList.Where(item => item.ID == id).FirstOrDefault();
        }

        public void Insert(User item)
        {
            try
            {
                _userList.Add(item);
                connection.Open();
                command = new MySqlCommand("INSERT INTO user (Id, Name, EmailId, Password) VALUES ('" + item.ID + "', '" + item.Name + "', '" + item.EmailId + "', '" + item.Password + "')", connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null
                    && reader.IsClosed == false)
                {
                    reader.Close();
                }
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void Update(User item)
        {
            var User = Find(item.ID);
            var index = _userList.IndexOf(User);
            _userList.RemoveAt(index);
            _userList.Insert(index, item);

            try
            {
                connection.Open();
                command = new MySqlCommand("update user set Name = " + item.Name + ", EmailId = " + item.EmailId + ", Password = " + item.Password + " where Id = " + item.ID + "", connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void Delete(string id)
        {
            _userList.Remove(Find(id));
        }

        private void InitializeData()
        {
            try
            {
                _userList = new List<User>();
                connection.Open();
                command = new MySqlCommand("select *from user", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = reader.GetString("ID");
                    user.Name = reader.GetString("Name");
                    user.Password = reader.GetString("Password");
                    user.EmailId = reader.GetString("EmailId");
                    _userList.Add(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null
                    && reader.IsClosed == false)
                {
                    reader.Close();
                }
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void SendFriendRequest(FriendRequest friendRequest)
        {
            try
            {
                connection.Open();
                command = new MySqlCommand("INSERT INTO friendrequest (FromUserId, ToUserId, Status) VALUES ('" + friendRequest.FromUserId + "', '" + friendRequest.ToUserId + "', " + (int)friendRequest.Status + ");", connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null
                        && reader.IsClosed == false)
                {
                    reader.Close();
                }
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void UpdateFriendRequest(FriendRequest friendRequest)
        {
            try
            {
                connection.Open();
                command = new MySqlCommand("UPDATE friendrequest SET Status = " + (int)friendRequest.Status + " WHERE friendrequest.FromUserId = '" + friendRequest.FromUserId + "' AND friendrequest.ToUserId = '" + friendRequest.ToUserId + "'; ", connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null
                    && reader.IsClosed == false)
                {
                    reader.Close();
                }
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public User IsValidUser(string emailId, string password)
        {
            try
            {
                connection.Open();
                command = new MySqlCommand("select *from user where password='" + password + "' and EmailId = '" + emailId + "'", connection);
                reader = command.ExecuteReader();
                User user = new User();

                while (reader.Read())
                {
                    user.Name = reader.GetString("Name");
                    user.ID = reader.GetString("Id");
                    user.EmailId = reader.GetString("EmailId");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null
                    && reader.IsClosed == false)
                {
                    reader.Close();
                }
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public List<User> GetRequests(string fromUserId)
        {
            try
            {
                List<FriendRequest> requests = new List<FriendRequest>();
                List<User> requestedUsers = new List<User>();

                connection.Open();
                command = new MySqlCommand("select *from friendrequest where  Status = 0 and ToUserId = '" + fromUserId + "'", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FriendRequest request = new FriendRequest();
                    request.FromUserId = reader.GetString("FromUserId");
                    request.ToUserId = reader.GetString("ToUserId");
                    requests.Add(request);
                    requestedUsers.Add(_userList.FirstOrDefault(x => x.ID == request.FromUserId));
                }

                return requestedUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null
                    && reader.IsClosed == false)
                {
                    reader.Close();
                }
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public List<User> GetMyFriends(string userId)
        {
            try
            {
                List<FriendRequest> requests = new List<FriendRequest>();
                List<User> requestedUsers = new List<User>();

                connection.Open();
                command = new MySqlCommand("select *from friendrequest where Status =" + (int)FriendRequestStatus.Approved + " and FromUserId = '" + userId + "'", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FriendRequest request = new FriendRequest();
                    request.FromUserId = reader.GetString("FromUserId");
                    request.ToUserId = reader.GetString("ToUserId");
                    requests.Add(request);
                    requestedUsers.Add(_userList.FirstOrDefault(x => x.ID == request.ToUserId));
                }

                reader.Close();

                command = new MySqlCommand("select *from friendrequest where Status =" + (int)FriendRequestStatus.Approved + " and ToUserId = '" + userId + "'", connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FriendRequest request = new FriendRequest();
                    request.FromUserId = reader.GetString("FromUserId");
                    request.ToUserId = reader.GetString("ToUserId");
                    requests.Add(request);
                    requestedUsers.Add(_userList.FirstOrDefault(x => x.ID == request.FromUserId));
                }

                return requestedUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null
                    && reader.IsClosed == false)
                {
                    reader.Close();
                }
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
