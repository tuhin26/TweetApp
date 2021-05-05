using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using TweetApp.Repository.Interface;
using System.Linq;
using System.Linq.Expressions;

namespace TweetApp.Repository.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region DI and Constructor
        private readonly ApplicationContext context;
        public BaseRepository(ApplicationContext context)
        {
            try
            {
                this.context = context;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

        }
        #endregion

        #region GetAll
        public IQueryable<T> FindAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }
        #endregion

        #region FindByFilter
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression).AsNoTracking();
        }
        #endregion

        #region PostNew
        public bool Create(T entity)
        {
            try
            {
                this.context.Set<T>().Add(entity);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return false;
        }
        #endregion

        #region Update
        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
            this.context.SaveChanges();
        }
        #endregion

        #region Remove
        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

       
        #endregion
    }
}
