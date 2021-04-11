using ACT.Services.ApiDbAccess.OPERA;
using ACT.Services.Execute;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Controllers
{
    [ApiController]
    [Route("Schedule")]
    [EnableCors("MyPolicy")]
    public class Schedule : ControllerBase
    {
        IOPERA_Configuration _oPERA_Configuration;
        private IExecuteOpera _executeOpera;
        private IExecuteOperaWorker _executeOperaWarker;

        IScheduler _scheduler;
        public Schedule(IOPERA_Configuration oPERA_Configuration , IScheduler scheduler, IExecuteOpera executeOpera, IExecuteOperaWorker executeOperaWarker)
        {
            this._oPERA_Configuration = oPERA_Configuration;
            this._scheduler = scheduler;
            this._executeOpera = executeOpera;
            this._executeOperaWarker = executeOperaWarker;
        }

        [HttpPost("StartOperaSchedule")]
        public async Task StartOperaSchedule()
        {
            DateTime startAt = new DateTime(
                year: DateTime.Now.Year,
                month: DateTime.Now.Month,
                day: DateTime.Now.Day,
                hour:_oPERA_Configuration.GetOperaConfiguration().CycleTime.Hour,
                minute: _oPERA_Configuration.GetOperaConfiguration().CycleTime.Minute,
                0
                );
            if(startAt < DateTime.Now)
            {
                startAt.AddDays(1);
            }

            await _executeOperaWarker.StartAsync(cancellationToken: new System.Threading.CancellationToken(false));
            
            
            //await _executeOperaWarker.StartAsync(cancellationToken:new System.Threading.CancellationToken(false));

            /*ITrigger trigger = TriggerBuilder.Create()
             .WithIdentity($"Opera-{DateTime.Now}")
             .StartAt(new DateTimeOffset(DateTime.Now))
             .WithSimpleSchedule(x=>x.WithIntervalInSeconds(1).RepeatForever())
             .WithPriority(1)
             .Build();

            IJobDetail job = JobBuilder.Create<ExecuteOpera>()
                        .WithIdentity("Opera")
                        .Build();

            await _scheduler.ScheduleJob(job, trigger);*/
        }
    }
}
