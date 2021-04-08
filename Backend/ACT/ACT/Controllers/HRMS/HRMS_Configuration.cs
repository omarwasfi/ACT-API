using ACT.Services.ApiDbAccess.HRMS;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ACT.Controllers
{
    [ApiController]
    [Route("Hrms")]
    [EnableCors("MyPolicy")]
    public class HRMS_Configuration : ControllerBase
    {
        private readonly IHRMS_Configuration _hrms_Configuration;

        public class hrmsCycleTimeViewModel
        {
            [Required]
            public int Day { get; set; }
            
            [Required]
            public int Hour { get; set; }
            [Required]
            public int Min { get; set; }

        }

        public HRMS_Configuration(IHRMS_Configuration hrms_Configuration)
        {
            _hrms_Configuration = hrms_Configuration;
        }

        [HttpGet("GetConnectionString")]
        public string GetConnectionString()
        {
            return _hrms_Configuration.GetHRMSConfiguration().ConnectionsString;
        }

        [HttpPost("UpdateConnectionString")]
        public async Task UpdateConnectionString(string ConnectionString)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                await _hrms_Configuration.UpdateConnectionString(ConnectionString);
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("GetCycleTime")]
        public hrmsCycleTimeViewModel GetCycleTime()
        {
            DateTime hrmsDateTime = _hrms_Configuration.GetHRMSConfiguration().CycleTime;
            hrmsCycleTimeViewModel cycleTimeViewModel = new hrmsCycleTimeViewModel() { Day = hrmsDateTime.Day, Hour = hrmsDateTime.Hour, Min = hrmsDateTime.Minute };
            return cycleTimeViewModel;
        }


        [HttpPost("UpdateCycleTime")]
        public async Task UpdateCycleTime(hrmsCycleTimeViewModel cycleTimeViewModel)
        {
            if (cycleTimeViewModel.Day != 0 && cycleTimeViewModel.Hour != 0 && cycleTimeViewModel.Min != 0)
            {
                DateTime cycleTime = new DateTime(1, 1, day: cycleTimeViewModel.Day, hour: cycleTimeViewModel.Hour, minute: cycleTimeViewModel.Min, 1);
                await _hrms_Configuration.UpdateCycleTime(cycleTime);
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }


        }
    }
}
