using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Logs : ControllerBase
    {
        /// <summary>
        /// Get all the logs 
        /// </summary>
        [HttpGet]
        public string Get()
        {
            string logs;

            using (var fs = new FileStream("wwwroot/App_Data/Log.json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                logs = sr.ReadToEnd();
            }

            return logs;
        }

      
    }
}