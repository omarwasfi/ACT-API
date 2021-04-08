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
                new SUN_HDR_Column_Model(){ColumnName = "PSTG_HDR_ID" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "UPDATE_COUNT" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "LAST_CHANGE_USER_ID" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "LAST_CHANGE_DATETIME" , Type ="DateTime" },
                new SUN_HDR_Column_Model(){ColumnName = "CREATED_BY" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "CREATED_DATETIME" , Type ="DateTime" },
                new SUN_HDR_Column_Model(){ColumnName = "CREATION_TYPE" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "DESCR" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "LAST_STATUS" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_TYPE" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_WRITE_TO_HOLD" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_ROUGH_BOOK" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_ALLOW_BAL_TRANS" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_SUSPENSE_ACNT" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_OTHER_ACNT" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_BAL_BY" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_DFLT_PERD" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_RPT_ERR_ONLY" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_SUPPRESS_SUB_MSG" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_RPT_FMT" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "JRNL_TYPE" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_RPT_ACNT" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_ORIG" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_REJECTED" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_BAL" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_REVERSALS" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_POSTED" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_SUBSTITUTED" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_PRINTED" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_LDG" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_ALLOW_OVER_BDGT" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_ALLOW_SUSPNS_ACNT" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_ZERO_VAL_ENTRIES" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "JNL_NUM" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "NUM_OF_IMBALANCES" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "DR_AMT_POSTED" , Type ="decimal" },
                new SUN_HDR_Column_Model(){ColumnName = "CR_AMT_POSTED" , Type ="decimal" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_TXN_REF_BAL" , Type ="short" }




            };

            if (_apiDbContext.SUN_HDR_Columns.Count() > 0)
            {
                _apiDbContext.SUN_HDR_Columns.RemoveRange(_apiDbContext.SUN_HDR_Columns);

            }

            foreach(SUN_HDR_Column_Model c in sUN_Configuration_Model.HDR_Columns)
            {
                _apiDbContext.SUN_HDR_Columns.Add(c);
            }

            _apiDbContext.SUN_Configurations.Add(sUN_Configuration_Model);
            await _apiDbContext.SaveChangesAsync();



        }



    }
}
