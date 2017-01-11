using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Dal
{
    public interface ITaskAppRepository
    {
        void Log(String message, Int32 logLevel);
    }
}
