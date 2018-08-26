using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using TodoData.Dao.Interface;

namespace TodoData.Dao
{
    public class BaseDaoManager<T> : IBaseDaoManager<T>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public BaseDaoManager()
        {
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> GetByExample(T exampleInstance, string[] propertiesToExclude)
        {
            throw new NotImplementedException();
        }

        public T GetById(object id, bool shouldLock)
        {
            throw new NotImplementedException();
        }

        public T SaveOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
