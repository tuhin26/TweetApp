using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TweetApp.DAL.Models;


namespace TweetApp.Service.Interface
{
   public interface ITweetService
    {
        List<TweetData> GetTweetById(int id);
        List<TweetData> GetTweetsByUserId(int id);
        List<TweetData> GetAllTweets();
        bool CreateTweet(TweetData tweetData);
    }
}
