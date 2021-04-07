using ACT.DataModels;
using ACT.DBContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.HRMS
{
    public class HRMS_Configuration : IHRMS_Configuration
    {
        private ApiDbContext _apiDbContext;
        public HRMS_Configuration(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }

        public HRMS_Configuration_Model GetHRMSConfiguration()
        {
            Log.Information("Returning sun's ConnectionString.");

            return _apiDbContext.HRMS_Configurations.First();
        }

        public async Task UpdateConnectionString(string ConnectionString)
        {
            if (_apiDbContext.HRMS_Configurations.Count() > 0)
            {
                HRMS_Configuration_Model hRMS_Configuration_Model = _apiDbContext.HRMS_Configurations.First();
                hRMS_Configuration_Model.ConnectionsString = ConnectionString;
                _apiDbContext.HRMS_Configurations.Update(hRMS_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("HRMS's ConnectionString Has been Updated Successfully.");
            }
            else
            {
                HRMS_Configuration_Model hRMS_Configuration_Model = new HRMS_Configuration_Model() { ConnectionsString = ConnectionString };
                await _apiDbContext.HRMS_Configurations.AddAsync(hRMS_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("HRMS's ConnectionString Has been Added Successfully.");

            }
        }


        public async Task UpdateCycleTime(DateTime cycleTime)
        {
            if (_apiDbContext.HRMS_Configurations.Count() > 0)
            {
                HRMS_Configuration_Model hRMS_Configuration_Model = _apiDbContext.HRMS_Configurations.First();
                hRMS_Configuration_Model.CycleTime = cycleTime;
                _apiDbContext.HRMS_Configurations.Update(hRMS_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's CycleTime Has been Updated Successfully.");
            }
            else
            {
                HRMS_Configuration_Model hRMS_Configuration_Model = new HRMS_Configuration_Model() { CycleTime = cycleTime };
                await _apiDbContext.HRMS_Configurations.AddAsync(hRMS_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("HRMS's CycleTime Has been Added Successfully.");

            }
        }


    }
}
