using ACT.DataModels;
using ACT.DBContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.SUN
{
    public class SUN_Configuration : ISUN_Configuration
    {
        private ApiDbContext _apiDbContext;
        public SUN_Configuration(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }

        public SUN_Configuration_Model GetSunConfiguration()
        {
            Log.Information("Returning sun's ConnectionString.");

            return _apiDbContext.SUN_Configuration_Models.First();
        }

        public async Task UpdateConnectionString(string ConnectionString)
        {
            if(_apiDbContext.SUN_Configuration_Models.Count() > 0)
            {
                SUN_Configuration_Model sUN_Configuration_Model = _apiDbContext.SUN_Configuration_Models.First();
                sUN_Configuration_Model.ConnectionsString = ConnectionString;
                _apiDbContext.SUN_Configuration_Models.Update(sUN_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("Sun's ConnectionString Has been Updated Successfully.");
            }
            else
            {
                SUN_Configuration_Model sUN_Configuration_Model = new SUN_Configuration_Model() { ConnectionsString = ConnectionString };
                await _apiDbContext.SUN_Configuration_Models.AddAsync(sUN_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("Sun's ConnectionString Has been Added Successfully.");

            }
        }

     
       
    }
}
