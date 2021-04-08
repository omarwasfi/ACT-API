using ACT.Services.ApiDbAccess.OPERA;
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
    [Route("Opera")]
    [EnableCors("MyPolicy")]
    public class OPERA_Configuration : ControllerBase
    {

        private readonly IOPERA_Configuration _opera_Configuration;

        public class operaCycleTimeViewModel
        {
            [Required]
            public int Hour { get; set; }
            [Required]
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
        public operaCycleTimeViewModel GetCycleTime()
        {
            DateTime operaDateTime = _opera_Configuration.GetOperaConfiguration().CycleTime;
            operaCycleTimeViewModel cycleTimeViewModel = new operaCycleTimeViewModel() { Hour = operaDateTime.Hour, Min = operaDateTime.Minute };
            return cycleTimeViewModel;
        }

        [HttpPost("UpdateCycleTime")]
        public async Task UpdateCycleTime(operaCycleTimeViewModel cycleTimeViewModel)
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

        [HttpGet("GetNumberOfLinesToBeIgnoredAtTheBeginning")]
        public int GetNumberOfLinesToBeIgnoredAtTheBeginning()
        {
            return _opera_Configuration.GetOperaConfiguration().NumberOfLinesToBeIgnoredAtTheBeginning; 
        }


        [HttpPost("UpdateNumberOfLinesToBeIgnoredAtTheBeginning")]
        public async Task UpdateNumberOfLinesToBeIgnoredAtTheBeginning(int NumberOfLinesToBeIgnoredAtTheBeginning)
        {
            await _opera_Configuration.UpdateNumberOfLinesToBeIgnoredAtTheBeggining(NumberOfLinesToBeIgnoredAtTheBeginning);
        }

        [HttpPost("LoadDefaults")]
        public async Task LoadDefaults()
        {
           await _opera_Configuration.LoadDefault();
        }
    }


    
}
