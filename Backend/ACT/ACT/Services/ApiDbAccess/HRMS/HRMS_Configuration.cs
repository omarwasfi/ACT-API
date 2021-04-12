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

        public async Task LoadDefault()
        {
            if (_apiDbContext.HRMS_Configurations.Count() > 0)
            {
                _apiDbContext.HRMS_Configurations.Remove(_apiDbContext.HRMS_Configurations.First());
                await _apiDbContext.SaveChangesAsync();
            }

            HRMS_Configuration_Model hRMS_Configuration_Model = new HRMS_Configuration_Model();

            hRMS_Configuration_Model.ConnectionsString = "Data source=(local);Database=ACT_HRMS_TRAIN;Trusted_Connection=True;user id=sa; password= fifinetech;";
            hRMS_Configuration_Model.CycleTime = new DateTime(1, 1, 1, hour: 1, 01, 59);





            hRMS_Configuration_Model.Columns = new List<HRMS_REPORT_Column_Model>()
                {
                    new HRMS_REPORT_Column_Model(){ ColumnName="JV_Report_Details_ID" , Type = "int" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="Property_ID" ,Type = "int" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="User_ID" , Type = "int" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="The_Year" ,Type = "int" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="The_Month" , Type = "int" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="Account_Number" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="Account_Number_JV_Description" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="Jornal_Type" , Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="JV_Type" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="Amount_D" ,Type = "float" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="Amount_C" ,Type = "float" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="T0" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="T1" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="T2" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="T3" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="T4" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="T5" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="T6" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="T7" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="T8" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="T9" ,Type = "string" },
                    new HRMS_REPORT_Column_Model(){ ColumnName="Cost_Center" ,Type = "string" }



                };


            if (_apiDbContext.HRMS_REPORT_Columns.Count() > 0)
            {
                _apiDbContext.HRMS_REPORT_Columns.RemoveRange(_apiDbContext.HRMS_REPORT_Columns);

            }


            foreach (HRMS_REPORT_Column_Model c in hRMS_Configuration_Model.Columns)
            {
                _apiDbContext.HRMS_REPORT_Columns.Add(c);
            }

            _apiDbContext.HRMS_Configurations.Add(hRMS_Configuration_Model);

            await _apiDbContext.SaveChangesAsync();



        }


    }
}
