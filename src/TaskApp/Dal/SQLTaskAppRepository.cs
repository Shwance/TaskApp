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
        private static Task Task;
        private ILogger _logger;

        public SQLTaskAppRepository(String connectionString, ILogger logger)
        {
            _connectionString = connectionString;
            _logger = logger;
            Task = new Task() { Id = 1, Name = "First Task", Description = "Task Description", DueDate = DateTime.Now, Completed = false };
            List<Task> subTasks = new List<Task>();
            subTasks.Add(new Task() { Id = 2, Name = "Second Task", Description = "2nd Description", DueDate = DateTime.Now, Completed = false, Tasks = new List<Task>() });
            
            List<Task> thirdLevel = new List<Task>();

            thirdLevel.Add(new Task() { Id = 4, Name = "Fourth Task", Description = "Fourth Description", DueDate = DateTime.Now, Completed = false, Tasks = new List<Task>() });
            thirdLevel.Add(new Task() { Id = 5, Name = "Fifth Task", Description = "Fifth Description", DueDate = DateTime.Now, Completed = true, Tasks = new List<Task>() });

            subTasks.Add(new Task() { Id = 3, Name = "Third Task", Description = "3rd Description", DueDate = DateTime.Now, Completed = false,Tasks = thirdLevel });

            Task.Tasks = subTasks;
        }

        public void Add(Task task)
        {
            Task.Tasks.Add(task);
        }

        public Task Find(int id)
        {
            _logger.Log("Got a Task", Microsoft.Extensions.Logging.LogLevel.Information);
            return Task.Tasks.Find(x => x.Id == id);
        }

        public Task GetAll()
        {
            _logger.Log("Got all the Tasks", Microsoft.Extensions.Logging.LogLevel.Information);
            return Task;
        }

        public Task Remove(int id)
        {
            var task = Task.Tasks.Find(x => x.Id == id);
            if (task != null)
                Task.Tasks.Remove(task);

            return task;
        }

        public void Update(Task task)
        {
            var oldTask = Task.Tasks.Find(x => x.Id == task.Id);
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
