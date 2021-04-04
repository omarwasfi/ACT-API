using ACT.Services.ApiDbAccess.OPERA;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ACT.Controllers
{
    [ApiController]
    [Route("Opera")]
    public class OPERA_Configuration : ControllerBase
    {

        private readonly IOPERA_Configuration _opera_Configuration;

        public class cycleTimeViewModel
        {
            public int Hour { get; set; }
            public int Min { get; set; }

        }

        public OPERA_Configuration(IOPERA_Configuration opera_Configuration)
        {
            _opera_Configuration = opera_Configuration;
        }

        [HttpGet("GetFilePath")]
        public string GetFilePath()
        {
            return _opera_Configuration.GetOperaConfiguration().FilePath;
        }

        [HttpPost("UpdateFilePath")]
        public async Task UpdateFilePath(string FilePath)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                await _opera_Configuration.UpdateFilePath(FilePath);
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("GetCycleTime")]
        public cycleTimeViewModel GetCycleTime()
        {
            DateTime operaDateTime = _opera_Configuration.GetOperaConfiguration().CycleTime;
            cycleTimeViewModel cycleTimeViewModel = new cycleTimeViewModel() { Hour = operaDateTime.Hour, Min = operaDateTime.Minute };
            return cycleTimeViewModel;
        }

        [HttpPost("UpdateCycleTime")]
        public async Task UpdateCycleTime(cycleTimeViewModel cycleTimeViewModel)
        {
            if (cycleTimeViewModel.Hour != 0 && cycleTimeViewModel.Min != 0)
            {
                DateTime cycleTime = new DateTime(1,1,1,hour: cycleTimeViewModel.Hour, minute: cycleTimeViewModel.Min,1);
                await _opera_Configuration.UpdateCycleTime(cycleTime);
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }


        }
    }


    
}
