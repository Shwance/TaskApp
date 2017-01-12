using System;
using System.Collections.Generic;
using System.Linq;
using TaskApp.Model;

namespace TaskApp.Dal
{
    public interface ITaskAppRepository
    {
        void Add(Task task);
        IEnumerable<Task> GetAll();
        Task Find(Int32 id);
        Task Remove(Int32 id);
        void Update(Task task);
    }
}
