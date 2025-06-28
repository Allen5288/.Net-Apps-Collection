using IMoocService;
using MoocModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace MoocUserService
{
    public class UserService : IUserService
    {

        private static readonly List<User>  _users = new List<User>();
        private static int _incrementId = 0;
        public bool AddUser(User user)
        {
            user.Id = _incrementId++;
            _users.Add(user);
            return true;
        }

        public bool DeleteUser(int id)
        {
            User findUser = null;
            foreach (var item in _users)
            {
                if (item.Id==id)
                {
                    findUser = item;    
                }
            }

            if (findUser == null)
            {
                return false;
            }

            _users.Remove(findUser);

            return true;    
        }

        public User GetUserById(int id)
        {
            User findUser = null;
            foreach (var item in _users)
            {
                if (item.Id == id)
                {
                    findUser = item;
                }
            }

            return findUser;
        }

        public IList<User> GetUsers()
        {
            return _users;
        }

        public bool UpdateUser(User user)
        {
            User findUser = null;
            foreach (var item in _users)
            {
                if (item.Id == user.Id)
                {
                    findUser = item;
                }
            }

            if (findUser == null)
            {
                return false;
            }

            findUser.UserName = user.UserName;  
            findUser.Email = user.Email;  
            findUser.Phone = user.Phone;  
            findUser.Adddress = user.Adddress;
            findUser.Password = user.Password;
            return true;
        }
    }
}
