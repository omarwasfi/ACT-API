using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ACT.Services.Execute
{
    public interface IExecuteHRMSWorker
    {
        public Task StartAsync(CancellationToken cancellationToken);
        public Task StopAsync(CancellationToken cancellationToken);
    }
}
