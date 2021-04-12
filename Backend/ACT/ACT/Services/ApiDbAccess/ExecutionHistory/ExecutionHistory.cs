using ACT.DataModels;
using ACT.DBContext;
using ACT.Services.ApiDbAccess.SUN;
using ACT.Services.SUNDbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess
{
    public class ExecutionHistory : IExecutionHistory
    {
        ApiDbContext _apiDbContext;

        private ISUN_Configuration _sun_Configuration;

        private readonly IHDR _hDR;

        private readonly IDETAIL _dETAIL;

        public ExecutionHistory(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;

            _sun_Configuration = new SUN_Configuration(apiDbContext);


            _hDR = new HDR(_sun_Configuration.GetSunConfiguration());
            _dETAIL = new DETAIL(_sun_Configuration.GetSunConfiguration());
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

        public async Task DeleteExecution(int executionHistoryId)
        {
            ExecutionHistory_Model executionHistory = _apiDbContext.ExecutionHistories.SingleOrDefault(x=>x.Id == executionHistoryId);
            
            await _dETAIL.DeleteRecords(executionHistory.HDRId);

            await _hDR.DeleteRecords(executionHistory.HDRId);



            _apiDbContext.ExecutionHistories.Remove(executionHistory);

            await _apiDbContext.SaveChangesAsync();
        }

    }
}
