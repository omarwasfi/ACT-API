using ACT.DBContext;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ACT.Services.Execute
{
    public interface IExecuteOpera
    {
        public Task ManualExecute();
        public Task WorkerExecute();

        public DateTime GetOperaNextStartTime();




    }
}
