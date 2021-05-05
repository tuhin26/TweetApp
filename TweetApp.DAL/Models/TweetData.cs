using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TweetApp.DAL.Models
{
    [Table("TweetData")]
    public class TweetData
    {
        [Key]
        public int tweetid { get; set; }
        public int userid { get; set; }
        public string tweetdesc { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
