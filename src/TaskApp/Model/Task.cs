using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Model
{
    public class Task
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime DueDate { get; set; }
        public Boolean Completed { get; set; }
    }
}
