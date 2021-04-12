using ACT.DataModels;
using ACT.Services.ApiDbAccess;
using ACT.Services.SUNDbAccess;
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
    [Route("ExecutionHistory")]
    [EnableCors("MyPolicy")]
    public class ExecutionHistory : ControllerBase
    {
        private readonly IExecutionHistory _executionHistory;





        public ExecutionHistory(IExecutionHistory executionHistory)
        {
            this._executionHistory = executionHistory;
 
        }

        [HttpGet("Get")]
        public async Task<List<ExecutionHistory_Model>> Get()
        {
            return await _executionHistory.GetExecutionHistory();
        }


        [HttpPost("Delete")]
        public async Task Get(int executionHistoryId)
        {

            await _executionHistory.DeleteExecution(executionHistoryId);
        }
    }
}
