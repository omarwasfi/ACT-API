using ACT.DataModels;
using ACT.DBContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.OPERA
{
    public class OPERA_Configuration : IOPERA_Configuration
    {
        private ApiDbContext _apiDbContext;
        public OPERA_Configuration(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }

        public OPERA_Configuration_Model GetOperaConfiguration()
        {
            Log.Information("Returning OPERA's Configurations.");

            return _apiDbContext.OPERA_Configurations.First();
        }

        public async Task UpdateFilePath(string FilePath)
        {
            if (_apiDbContext.OPERA_Configurations.Count() > 0)
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = _apiDbContext.OPERA_Configurations.First();
                oPERA_Configuration_Model.FilePath = FilePath;
                _apiDbContext.OPERA_Configurations.Update(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's FilePath Has been Updated Successfully.");
            }
            else
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = new OPERA_Configuration_Model() { FilePath = FilePath };
                await _apiDbContext.OPERA_Configurations.AddAsync(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's FilePath Has been Added Successfully.");

            }
        }

        public async Task UpdateCycleTime(DateTime cycleTime)
        {
            if (_apiDbContext.OPERA_Configurations.Count() > 0)
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = _apiDbContext.OPERA_Configurations.First();
                oPERA_Configuration_Model.CycleTime = cycleTime;
                _apiDbContext.OPERA_Configurations.Update(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's CycleTime Has been Updated Successfully.");
            }
            else
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = new OPERA_Configuration_Model() { CycleTime = cycleTime };
                await _apiDbContext.OPERA_Configurations.AddAsync(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's CycleTime Has been Added Successfully.");

            }
        }
    }
}
