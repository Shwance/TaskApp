using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Model
{
    public class Task : BaseTask
    {
        public List<Task> Tasks { get; set; }
    }
}
