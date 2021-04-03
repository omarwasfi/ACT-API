using ACT.DataModels;
using ACT.DBContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.SUN_DETAIL
{
    public class SUN_DETAIL_Configuration : ISUN_DETAIL_Configuration
    {
        private ApiDbContext _apiDbContext;
        private string tableName = "SUN_DETAIL";
        public SUN_DETAIL_Configuration(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }


        public async Task UpdateColumns(List<SUN_DETAIL_Column_Model> sUN_DETAIL_Columns)
        {
            if (_apiDbContext.SUN_Configuration_Models.Count() > 0)
            {

                _apiDbContext.SUN_Configuration_Models.First().DETAIL_Columns = new List<SUN_DETAIL_Column_Model>();

                Log.Information("Deleting all "+ tableName + " Columns.");

                _apiDbContext.SUN_DETAIL_Columns.RemoveRange(_apiDbContext.SUN_DETAIL_Columns);

                _apiDbContext.SUN_Configuration_Models.First().DETAIL_Columns = sUN_DETAIL_Columns;
                

                await _apiDbContext.SaveChangesAsync();
                


            }
            else
            {
                Log.Information("Creating new SUN_Configuration_Model with an empty ConnectionString.");

                SUN_Configuration_Model sUN_Configuration_Model = new SUN_Configuration_Model() { DETAIL_Columns = sUN_DETAIL_Columns, ConnectionsString = "" };

                await _apiDbContext.SUN_Configuration_Models.AddAsync(sUN_Configuration_Model);
                
                Log.Information("Saving the new " + tableName + " Columns.");

                await _apiDbContext.SaveChangesAsync();

            }
        }

        public async Task<List<SUN_DETAIL_Column_Model>> GetColumns()
        {
            Log.Information("Retuning "+tableName+" Columns...");

            return _apiDbContext.SUN_DETAIL_Columns.ToList();

        }
    }
}
