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
    public class TweetController : ControllerBase
    {
        #region DI and Constructor
        private ITweetService tweetService;
        private string ExceptionMessage;
        public TweetController(ITweetService tweetService)
        {
            this.tweetService = tweetService;
        }
        #endregion

        #region GetTweetById
        [HttpGet]
        [Route("api/GetTweetById/{id}")]
        public IActionResult GetTweetById(int id)
        {
            List<TweetData> tweetById = new List<TweetData>();
            try
            {
                tweetById = tweetService.GetTweetById(id);
                if (tweetById.Count != 0)
                {
                    return Ok(tweetById);
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

        #region GetTweetsByUserId
        [HttpGet]
        [Route("api/GetTweetsByUserId/{id}")]
        public IActionResult GetTweetsByUserId(int id)
        {
            List<TweetData> tweetsByUserId = new List<TweetData>();
            try
            {
                tweetsByUserId = tweetService.GetTweetsByUserId(id);
                if (tweetsByUserId.Count != 0)
                {
                    return Ok(tweetsByUserId);
                }
                return NotFound("No Tweets Founnd");
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return BadRequest();

        }
        #endregion

        #region LoadAllTweets
        [HttpGet]
        [Route("api/GetAllTweets")]
        public IActionResult GetAllTweets()
        {
            List<TweetData> allTweets = new List<TweetData>();
            try
            {
                allTweets = tweetService.GetAllTweets();
                if (allTweets.Count != 0)
                {
                    return Ok(allTweets);
                }
                return NotFound("No Tweets Found");
            }
            catch (Exception ex)
            {
                this.ExceptionMessage = "Meesage : " + ex.Message + " ,Stacktrace: " + ex.StackTrace;
            }
            return BadRequest();

        }
        #endregion

        #region PostNewTweet
        [HttpPost]
        [Route("api/PostTweet")]
        public IActionResult CreateTweet([FromBody] TweetData tweetData)
        {
            bool status = false;
            try
            {
                status = tweetService.CreateTweet(tweetData);
                if (status)
                {
                    return Ok("Tweet Posted");
                }
                return Ok("Unable to Post Tweet");
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
