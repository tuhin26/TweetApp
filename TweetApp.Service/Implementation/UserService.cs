using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetApp.DAL.Models;
using TweetApp.Repository;
using TweetApp.Service.Interface;
using TweetApp.Repository.Interface;

namespace TweetApp.Service.Implementation
{
    public class UserService:IUserService
    {
        private readonly IBaseRepository<UserData> userRepository;
        private string ExceptionMessage;
        public UserService(IBaseRepository<UserData> baseRepository)
        {
            this.userRepository = baseRepository;
        }

        public bool ChangePassword(ChangePassword changePassword)
        {
            try
            {
                UserData user = new UserData();
                user = userRepository.FindByCondition(x => x.email.Equals(changePassword.email) && x.password.Equals(changePassword.password)).FirstOrDefault();
                if (user != null)
                {
                    user.password = changePassword.newPassword;
                    user.updatedAt = DateTime.Now;
                    userRepository.Update(user);
                    return true;
                }
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return false;
        }

        public List<UserData> GetAllUsers()
        {
            List<UserData> allUsers = new List<UserData>();
            try
            {
                allUsers = userRepository.FindAll().ToList();
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }

            return allUsers;
        }

        public List<UserData> GetUserById(int id)
        {
            List<UserData> userById = new List<UserData>();
            try
            {
                userById = userRepository.FindByCondition(x => x.userid.Equals(id)).ToList();
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return userById;
        }

        public List<UserData> Login(UserData loginData)
        {
            List<UserData> vaildUser = new List<UserData>();
            try
            {
                vaildUser = userRepository.FindByCondition(x => x.email.Equals(loginData.email)).Where(x => x.password == loginData.password).ToList();
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return vaildUser;
        }

        public bool RegisterUser(UserData userData)
        {
            bool status = false;
            try
            {
                userData.createdAt = DateTime.Now;
                userData.updatedAt = DateTime.Now;
                status = userRepository.Create(userData);
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return status;
        }

        public bool ResetPassword(UserData userData)
        {
            bool status = false;
            try
            {
                UserData updateUser = new UserData();
                updateUser = userRepository.FindByCondition(x => x.email.Equals(userData.email)).FirstOrDefault();
                if (userData.dob.ToString("MM/dd/yyyy") == updateUser.dob.ToString("MM/dd/yyyy") && updateUser != null)
                {
                    updateUser.password = userData.password;
                    updateUser.updatedAt = DateTime.Now;
                    userRepository.Update(updateUser);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return status;
        }
    }
}
