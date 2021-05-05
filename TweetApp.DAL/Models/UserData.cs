using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TweetApp.DAL.Models
{
    [Table("UserData")]
    public class UserData
    {
        [Key]
        public int userid { get; set; }
       // [Required(ErrorMessage = "Please provide First Name")]
        public string first_name { get; set; }
        public string last_name { get; set; }
       // [Required(ErrorMessage = "Please provide Gender")]
        public string gender { get; set; }
        public DateTime dob { get; set; }
       // [Required(ErrorMessage = "Please provide Email Id")]
        public string email { get; set; }
       // [Required(ErrorMessage = "Please provide Password")]
        public string password { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
