using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<string> Get()
        {
            return new List<string>(){"Dummy Data", "Dummy Data"};
        }

        /// <summary>
        /// Filter logs by from to date
        /// </summary>
        /// <param name="from">Start date</param>
        /// <param name="To">End date</param>
        /// <returns></returns>
        [HttpGet( "{From}/{To}")]

        public List<string> GetLogsWithDate(DateTime from, DateTime To)
        {
            return new List<string>(){"Dummy Data", "Dummy Data"};
        }
    }
}