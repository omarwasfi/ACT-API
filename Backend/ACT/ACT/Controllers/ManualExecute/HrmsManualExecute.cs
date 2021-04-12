using ACT.Services.Execute;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Controllers
{
    [ApiController]
    [Route("HrmsManualExecute")]
    [EnableCors("MyPolicy")]
    public class HrmsManualExecute : ControllerBase
    {
        private IExecuteHRMS _executeHrms;

        public HrmsManualExecute(IExecuteHRMS executeHrms)
        {
            this._executeHrms = executeHrms;
        }

        [HttpPost("Execute")]
        public async Task Execute()
        {
            await _executeHrms.ManualExecute();
        }
    }
}
