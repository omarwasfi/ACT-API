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

            return _apiDbContext.SUN_Configurations.First();
        }

        public async Task UpdateConnectionString(string ConnectionString)
        {
            if(_apiDbContext.SUN_Configurations.Count() > 0)
            {
                SUN_Configuration_Model sUN_Configuration_Model = _apiDbContext.SUN_Configurations.First();
                sUN_Configuration_Model.ConnectionsString = ConnectionString;
                _apiDbContext.SUN_Configurations.Update(sUN_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("Sun's ConnectionString Has been Updated Successfully.");
            }
            else
            {
                SUN_Configuration_Model sUN_Configuration_Model = new SUN_Configuration_Model() { ConnectionsString = ConnectionString };
                await _apiDbContext.SUN_Configurations.AddAsync(sUN_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("Sun's ConnectionString Has been Added Successfully.");

            }
        }

        public async Task LoadDefault()
        {
            if (_apiDbContext.SUN_Configurations.Count() > 0)
            {
                 _apiDbContext.SUN_Configurations.RemoveRange(_apiDbContext.SUN_Configurations);

            }

            SUN_Configuration_Model sUN_Configuration_Model = new SUN_Configuration_Model();

            sUN_Configuration_Model.ConnectionsString = "Server=(localdb)\\mssqllocaldb;Database=SunSystemsData;Trusted_Connection=True;MultipleActiveResultSets=true";
            sUN_Configuration_Model.HDR_Columns = new List<SUN_HDR_Column_Model>() 
            {
                new SUN_HDR_Column_Model(){ColumnName = "PstgHdrId" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "UpdateCount" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "LastChangeUserId" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "LastChangeDatetime" , Type ="DateTime" },
                new SUN_HDR_Column_Model(){ColumnName = "CreatedBy" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "CreatedDatetime" , Type ="DateTime" }

            };

            if (_apiDbContext.SUN_HDR_Columns.Count() > 0)
            {
                _apiDbContext.SUN_HDR_Columns.RemoveRange(_apiDbContext.SUN_HDR_Columns);

            }

            foreach(SUN_HDR_Column_Model c in sUN_Configuration_Model.HDR_Columns)
            {
                _apiDbContext.SUN_HDR_Columns.Add(c);
            }

            await _apiDbContext.SaveChangesAsync();



        }



    }
}
