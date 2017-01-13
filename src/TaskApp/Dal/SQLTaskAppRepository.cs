using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using TaskApp.Model;
using TaskApp.Logging;

namespace TaskApp.Dal
{
    public class SQLTaskAppRepository : ITaskAppRepository
    {

        private String _connectionString = "data source=sql5028.smarterasp.net;initial catalog=DB_A09B09_GeoLocation;User Id=DB_A09B09_GeoLocation_admin;Password=jjuuddee1133;integrated security=false";
        private static List<Task> Tasks;
        private ILogger _logger;

        public SQLTaskAppRepository(String connectionString, ILogger logger)
        {
            _connectionString = connectionString;
            _logger = logger;
            Tasks = new List<Task>();
            Tasks.Add(new Task() { Id=1,Name="First Task",Description="Task Description", DueDate = DateTime.Now ,Completed=false});
        }

        public void Add(Task task)
        {
            Tasks.Add(task);
        }

        public Task Find(int id)
        {
            _logger.Log("Got a Task", Microsoft.Extensions.Logging.LogLevel.Information);
            return Tasks.Find(x => x.Id == id);
        }

        public IEnumerable<Task> GetAll()
        {
            _logger.Log("Got all the Tasks", Microsoft.Extensions.Logging.LogLevel.Information);
            return Tasks;
        }

        public Task Remove(int id)
        {
            var task = Tasks.Find(x => x.Id == id);
            if (task != null)
                Tasks.Remove(task);

            return task;
        }

        public void Update(Task task)
        {
            var oldTask = Tasks.Find(x => x.Id == task.Id);
            if (oldTask != null)
            {
                oldTask.Name = task.Name;
                oldTask.Description = task.Description;
                oldTask.DueDate = task.DueDate;
                oldTask.Completed = task.Completed;
            }
               
        }
    }
}
