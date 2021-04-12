using System.Threading;
using System.Threading.Tasks;

namespace ACT.Services.Execute
{
    public interface IExecuteOperaWorker
    {
        public Task StartAsync(CancellationToken cancellationToken);
        public Task StopAsync(CancellationToken cancellationToken);
    }
}