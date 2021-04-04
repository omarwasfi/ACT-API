using ACT.DataModels;
using ACT.DBContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.OPERA_REPORT
{
    public class OPERA_REPORT_Configuration : IOPERA_REPORT_Configuration
    {
        private ApiDbContext _apiDbContext;
        private string tableName = "OPERA_REPORT";
        public OPERA_REPORT_Configuration(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }


        public async Task UpdateColumns(List<OPERA_REPORT_Column_Model> oPERA_REPORT_Columns)
        {
            if (_apiDbContext.OPERA_Configurations.Count() > 0)
            {

                _apiDbContext.OPERA_Configurations.First().Columns = new List<OPERA_REPORT_Column_Model>();

                Log.Information("Deleting all " + tableName + " Columns.");

                _apiDbContext.OPERA_REPORT_Columns.RemoveRange(_apiDbContext.OPERA_REPORT_Columns);

                _apiDbContext.OPERA_Configurations.First().Columns = oPERA_REPORT_Columns;


                await _apiDbContext.SaveChangesAsync();



            }
            else
            {
                Log.Information("Creating new OPERA_Configuration_Model with an empty ConnectionString.");

                OPERA_Configuration_Model oPERA_Configuration_Model = new OPERA_Configuration_Model() { Columns = oPERA_REPORT_Columns, FilePath = "", CycleTime = new DateTime() };

                await _apiDbContext.OPERA_Configurations.AddAsync(oPERA_Configuration_Model);

                Log.Information("Saving the new " + tableName + " Columns.");

                await _apiDbContext.SaveChangesAsync();

            }
        }

        public async Task<List<OPERA_REPORT_Column_Model>> GetColumns()
        {
            Log.Information("Retuning " + tableName + " Columns...");

            return _apiDbContext.OPERA_REPORT_Columns.ToList();

        }
    }
}
