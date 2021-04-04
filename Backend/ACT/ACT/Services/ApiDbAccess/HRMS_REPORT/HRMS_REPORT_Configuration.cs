using ACT.DataModels;
using ACT.DBContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.HRMS_REPORT
{
    public class HRMS_REPORT_Configuration : IHRMS_REPORT_Configuration
    {
        private ApiDbContext _apiDbContext;
        private string tableName = "HRMS_REPORT";
        public HRMS_REPORT_Configuration(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }


        public async Task UpdateColumns(List<HRMS_REPORT_Column_Model> hRMS_REPORT_Columns)
        {
            if (_apiDbContext.HRMS_Configurations.Count() > 0)
            {

                _apiDbContext.HRMS_Configurations.First().Columns = new List<HRMS_REPORT_Column_Model>();

                Log.Information("Deleting all " + tableName + " Columns.");

                _apiDbContext.HRMS_REPORT_Columns.RemoveRange(_apiDbContext.HRMS_REPORT_Columns);

                _apiDbContext.HRMS_Configurations.First().Columns = hRMS_REPORT_Columns;


                await _apiDbContext.SaveChangesAsync();



            }
            else
            {
                Log.Information("Creating new HRMS_Configuration_Model with an empty ConnectionString.");

                HRMS_Configuration_Model hRMS_Configuration_Model = new HRMS_Configuration_Model() { Columns = hRMS_REPORT_Columns, ConnectionsString = "", CycleTime = new DateTime() };

                await _apiDbContext.HRMS_Configurations.AddAsync(hRMS_Configuration_Model);

                Log.Information("Saving the new " + tableName + " Columns.");

                await _apiDbContext.SaveChangesAsync();

            }
        }

        public async Task<List<HRMS_REPORT_Column_Model>> GetColumns()
        {
            Log.Information("Retuning " + tableName + " Columns...");

            return _apiDbContext.HRMS_REPORT_Columns.ToList();

        }
    }
}
