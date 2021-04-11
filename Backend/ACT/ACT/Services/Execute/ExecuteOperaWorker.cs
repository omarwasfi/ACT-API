﻿using ACT.DBContext;
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
                _executeOpera = new ExecuteOpera(scope.ServiceProvider.GetRequiredService<ApiDbContext>());

                DateTime startAt = _executeOpera.GetOperaNextStartTime();
                TimeSpan timeLeftToStart = startAt.Subtract(DateTime.Now);
                Log.Information("Time Left to execute opera is : " + timeLeftToStart.ToString());

                _timer = new Timer(DoWork, null, TimeSpan.Zero,
                 TimeSpan.FromDays(1));

                return Task.CompletedTask;
            }
           
         
       

        }

        private void DoWork(object state)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                Log.Information("Executing Opera..");
               
                _executeOpera = new ExecuteOpera(scope.ServiceProvider.GetRequiredService<ApiDbContext>());

                _executeOpera.WorkerExecute();
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
