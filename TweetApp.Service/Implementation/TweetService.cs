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
    public class TweetService:ITweetService
    {
        private readonly IBaseRepository<TweetData> TweetRepository;
        private string ExceptionMessage;
        public TweetService(IBaseRepository<TweetData> baseRepository)
        {
            this.TweetRepository = baseRepository;
        }

        public bool CreateTweet(TweetData tweetData)
        {
            bool status = false;
            try
            {
                tweetData.createdAt = DateTime.Now;
                tweetData.updatedAt = DateTime.Now;
                status = TweetRepository.Create(tweetData);
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return status;
        }

        public List<TweetData> GetAllTweets()
        {
            List<TweetData> AllTweets = new List<TweetData>();
            try
            {
                AllTweets = TweetRepository.FindAll().ToList();
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return AllTweets;
        }

        public List<TweetData> GetTweetById(int id)
        {
            List<TweetData> TweetById = new List<TweetData>();
            try
            {
                TweetById = TweetRepository.FindByCondition(x => x.tweetid.Equals(id)).ToList();
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return TweetById;
        }

        public List<TweetData> GetTweetsByUserId(int id)
        {
            List<TweetData> TweetsByUserId = new List<TweetData>();
            try
            {
                TweetsByUserId = TweetRepository.FindByCondition(x => x.userid.Equals(id)).ToList();
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return TweetsByUserId;
        }
    }
}
