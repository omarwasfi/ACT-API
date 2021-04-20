using ACT.Services.ApiDbAccess.OPERA;
using ACT.Services.Execute;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Controllers
{
    [ApiController]
    [Route("Shutdown")]
    [EnableCors("MyPolicy")]
    public class Shutdown : ControllerBase
    {
        IApplicationLifetime applicationLifetime;


        public Shutdown(IApplicationLifetime appLifetime)
        {
            applicationLifetime = appLifetime;
        }

        [HttpGet("blow-me-up")]
        public IActionResult BlowMeUp()
        {
            System.Threading.Thread.Sleep(1000);

            applicationLifetime.StopApplication();
            return new EmptyResult();
        }
    }
}
