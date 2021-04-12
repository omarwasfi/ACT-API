using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess
{
    public interface IExecutionHistory
    {
        public Task<List<ExecutionHistory_Model>> GetExecutionHistory();

        public Task AddAnExecutionHistory(ExecutionHistory_Model executionHistory);
    }
}
