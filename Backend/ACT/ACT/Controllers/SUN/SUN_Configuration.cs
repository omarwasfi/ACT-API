using ACT.Services.ApiDbAccess.SUN;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ACT.Controllers
{
    [ApiController]
    [Route("Sun")]
    public class SUN_Configuration : ControllerBase
    {
        private readonly ISUN_Configuration _sun_Configuration;

        public SUN_Configuration(ISUN_Configuration sun_Configuration)
        {
            _sun_Configuration = sun_Configuration;
        }

        [HttpGet("GetConnectionString")]
        public string GetConnectionString()
        {
            return _sun_Configuration.GetSunConfiguration().ConnectionsString;
        }

        [HttpPost("UpdateConnectionString")]
        public async Task UpdateConnectionString(string ConnectionString)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                await _sun_Configuration.UpdateConnectionString(ConnectionString);
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }


        }

        [HttpPost("LoadDefaults")]
        public async Task LoadDefaults()
        {
            await _sun_Configuration.LoadDefault();
        }



    }
}
