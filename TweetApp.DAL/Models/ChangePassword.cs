using System;
using System.Collections.Generic;
using System.Text;

namespace TweetApp.DAL.Models
{
    public class ChangePassword : UserData
    {
        public string newPassword { get; set; }
    }
}
