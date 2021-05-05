using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TweetApp.DAL.Models;

namespace TweetApp.Service.Interface
{
    public interface IUserService
    {
        List<UserData> GetUserById(int id);
        List<UserData> GetAllUsers();
        List<UserData> Login(UserData loginData);
        bool RegisterUser(UserData userData);
        bool ChangePassword(ChangePassword changePassword);
        bool ResetPassword(UserData userData);
    }
}
