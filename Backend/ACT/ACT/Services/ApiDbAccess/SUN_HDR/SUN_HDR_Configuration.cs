using ACT.DataModels;
using ACT.DBContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.SUN_HDR
{
    public class SUN_HDR_Configuration : ISUN_HDR_Configuration
    {
        private ApiDbContext _apiDbContext;

        private string tableName = "SUN_HDR";

        public SUN_HDR_Configuration(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }

             
        public async Task UpdateColumns(List<SUN_HDR_Column_Model> sUN_HDR_Columns)
        {
            if (_apiDbContext.SUN_Configuration_Models.Count() > 0)
            {

                _apiDbContext.SUN_Configuration_Models.First().HDR_Columns = new List<SUN_HDR_Column_Model>();

                Log.Information("Deleting all " + tableName + " Columns.");

                _apiDbContext.SUN_HDR_Columns.RemoveRange(_apiDbContext.SUN_HDR_Columns);

                _apiDbContext.SUN_Configuration_Models.First().HDR_Columns = sUN_HDR_Columns;

                Log.Information("Saving the new " + tableName + " Columns.");

                await _apiDbContext.SaveChangesAsync();
              
            }
            else
            {

                Log.Information("Creating new SUN_Configuration_Model with an empty ConnectionString.");

                SUN_Configuration_Model sUN_Configuration_Model = new SUN_Configuration_Model() {HDR_Columns = sUN_HDR_Columns, ConnectionsString="" } ;

                await _apiDbContext.SUN_Configuration_Models.AddAsync(sUN_Configuration_Model);

                Log.Information("Saving the new " + tableName + " Columns.");

                await _apiDbContext.SaveChangesAsync();

            }
        }

        public async Task<List<SUN_HDR_Column_Model>> GetColumns()
        {
            Log.Information("Retuning " + tableName + " Columns...");

            return _apiDbContext.SUN_HDR_Columns.ToList();
        }
    }
}
