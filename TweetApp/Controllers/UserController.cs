using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApp.Service.Interface;
using TweetApp.DAL.Models;

namespace TweetApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        #region DI and Constructor
        private readonly IUserService userService;
        private string ExceptionMessage;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        #endregion

        #region GetUserById
        [HttpGet]
        [Route("api/GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            List<UserData> userById = new List<UserData>();
            try
            {
                userById = userService.GetUserById(id);
                if (userById.Count != 0)
                {
                    return Ok(userById);
                }
                return NotFound("No Data Found");
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }

            return BadRequest();
        }
        #endregion

        #region GetAllUsers
        [HttpGet]
        [Route("api/GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            List<UserData> allUsers = new List<UserData>();
            try
            {
                allUsers = userService.GetAllUsers().ToList();
                if (allUsers.Count != 0)
                {
                    return Ok(allUsers);
                }
                return Ok("No Data Found");
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }

            return BadRequest();
        }
        #endregion

        #region Register Users 
        [HttpPost]
        [Route("api/RegisterUser")]
        public IActionResult RegisterUser([FromBody] UserData userData)
        {
            bool status = false;
            try
            {
                status = userService.RegisterUser(userData);
                if (status)
                {
                    return Ok("User Registered Successfully");
                }
                return Ok("User already exist");
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return BadRequest();

        }
        #endregion

        #region ChangePassword
        [HttpPost]
        [Route("api/ChangePassword")]
        public IActionResult ChangePassword([FromBody] ChangePassword changePassword)
        {
            bool status = false;
            try
            {
                status = userService.ChangePassword(changePassword);
                if (status)
                {
                    return Ok("Password Changed Sucessfully");
                }
                return Ok("Incorrect Old Password Given");
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return BadRequest();

        }
        #endregion

        #region Login
        [HttpPost]
        [Route("api/UserLogin")]
        public IActionResult UserLogin([FromBody] UserData loginData)
        {
            List<UserData> vailduser = new List<UserData>();
            try
            {
                vailduser = userService.Login(loginData);
                if (vailduser.Count != 0)
                {
                    return Ok(vailduser);
                }
                return Ok("Incorrect Email/Password");
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return BadRequest();

        }
        #endregion

        #region Reset Password
        [HttpPut]
        [Route("api/ResetPassword")]
        public IActionResult ResetPassword([FromBody] UserData userData)
        {
            bool valid = false;
            try
            {
                valid = userService.ResetPassword(userData);
                if (valid)
                {
                    return Ok("Password reset successfull");
                }
                return Ok("Password reset unsuccessfull");
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return BadRequest();

        }
        #endregion
    }
}
