using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.Execute
{
    public interface IExecuteHRMS 
    {
        public Task ManualExecute();
        public Task WorkerExecute();

        public DateTime GetHRMSNextStartTime();
    }
}
