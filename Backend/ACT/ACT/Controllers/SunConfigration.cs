using ACT.DataModels;
using ACT.DBContext;
using ACT.Services.ApiDbAccess.SUN;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ACT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SunConfigration : ControllerBase
    {
        private readonly ISUN_Configuration _sun_Configuration;
        public SunConfigration(ISUN_Configuration sun_Configuration)
        {
            _sun_Configuration = sun_Configuration;
        }

        [HttpGet("GetConnectionString")]
        public string GetConnectionString()
        {
            return _sun_Configuration.GetSunConfiguration().ConnectionsString;
        }

        [HttpPost("UpdateConnectionString")]
        public void UpdateConnectionString(string ConnectionString)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                _sun_Configuration.UpdateConnectionString(ConnectionString);
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }


        }
    }
}
