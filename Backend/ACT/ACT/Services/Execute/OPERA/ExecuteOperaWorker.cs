using ACT.DBContext;
using ACT.Services.ApiDbAccess.OPERA;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ACT.Services.Execute
{
    public class ExecuteOperaWorker : IHostedService, IDisposable
    {
        private readonly IServiceProvider _provider;
        private IExecuteOpera _executeOpera;


        private Timer _timer;

        public ExecuteOperaWorker(IServiceProvider provider )
        {
            this._provider = provider;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            using (IServiceScope scope = _provider.CreateScope())
            {
                DateTime startAt;
                try
                {
                    _executeOpera = new ExecuteOpera(scope.ServiceProvider.GetRequiredService<ApiDbContext>());

                    startAt = _executeOpera.GetOperaNextStartTime();

                    TimeSpan timeLeftToStart = startAt.Subtract(DateTime.Now);
                    Log.Information("Time Left to execute Hrms is : " + timeLeftToStart.Days.ToString() + " Days , " + timeLeftToStart.Hours.ToString() + " Hours And " + timeLeftToStart.Minutes.ToString() + " Minutes.");

                    _timer = new Timer(DoWork, null, timeLeftToStart,
                     TimeSpan.FromDays(28));
                }
                catch
                {

                    Log.Error("The Configurations has not been completed.. ");
                    Log.Information("Please Complete the configurations and restart the API.");
                }

                return Task.CompletedTask;
            }
           
         
       

        }

        private void DoWork(object state)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                try
                {
                    Log.Information("Executing Opera..");

                    _executeOpera = new ExecuteOpera(scope.ServiceProvider.GetRequiredService<ApiDbContext>());

                    _executeOpera.WorkerExecute();
                }
                catch
                {

                    Log.Error("Configutaions error !! ");
                    Log.Information("Please setup the configurations again and restart the API.");
                }
              
            }


        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information("auto Execute opera stoped");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

    }
}
