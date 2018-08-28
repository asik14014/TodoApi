using NHibernate;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using TodoData.Models.Task;

namespace TodoData.Dao
{
    public class TaskDaoManager : BaseDaoManager<Task>
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    }
}
