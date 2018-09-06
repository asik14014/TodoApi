﻿using NHibernate;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using TodoData.Models.Task;

namespace TodoData.Dao
{
    public class TaskDaoManager : BaseDaoManager<Task>
    {
        /// <summary>
        /// Вытащить все задачи по пользователю
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<Task> GetAllByUserId(long userId)
        {
            try
            {
                using (var session = NHibertnateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        return session.QueryOver<Task>()
                            .Where(t => t.UserId == userId)
                            .List();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Вытащить все задачи по группе
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public IList<Task> GetAllByGroupId(long groupId)
        {
            try
            {
                using (var session = NHibertnateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        return session.QueryOver<Task>()
                            .Where(t => t.UserId == groupId)
                            .List();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
