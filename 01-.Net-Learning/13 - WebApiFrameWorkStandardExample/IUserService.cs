using MoocModel;
using System.ComponentModel;

namespace IMoocService
{
    public interface IUserService
    {
        bool AddUser(User user);
        bool UpdateUser(User user);

        bool DeleteUser(int id);

        IList<User> GetUsers();
        User GetUserById(int id);

    }
}
