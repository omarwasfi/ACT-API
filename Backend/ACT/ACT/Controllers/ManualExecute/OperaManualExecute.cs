using ACT.Services.Execute;
using Microsoft.AspNetCore.Cors;
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
    [Route("OperaManualExecute")]
    [EnableCors("MyPolicy")]
    public class OperaManualExecute : ControllerBase
    {
        private IExecuteOpera _executeOpera;
        public OperaManualExecute(IExecuteOpera executeOpera)
        {
            this._executeOpera = executeOpera;
        }

        [HttpPost("Execute")]
        public async Task Execute()
        {
           await _executeOpera.ManualExecute();
        }
    }
}
