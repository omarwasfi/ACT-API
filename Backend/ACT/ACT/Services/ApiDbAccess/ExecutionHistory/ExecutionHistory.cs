using ACT.DataModels;
using ACT.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess
{
    public class ExecutionHistory : IExecutionHistory
    {
        ApiDbContext _apiDbContext;
        public ExecutionHistory(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }
        public async Task AddAnExecutionHistory(ExecutionHistory_Model executionHistory)
        {
            await _apiDbContext.ExecutionHistories.AddAsync(executionHistory);

            await _apiDbContext.SaveChangesAsync();
        }

        public async Task<List<ExecutionHistory_Model>> GetExecutionHistory()
        {
            return _apiDbContext.ExecutionHistories.ToList();
        }
    }
}
