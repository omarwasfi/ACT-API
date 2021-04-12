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
            if (_apiDbContext.SUN_Configurations.Count() > 0)
            {

                _apiDbContext.SUN_Configurations.First().DETAIL_Columns = new List<SUN_DETAIL_Column_Model>();

                Log.Information("Deleting all "+ tableName + " Columns.");

                _apiDbContext.SUN_DETAIL_Columns.RemoveRange(_apiDbContext.SUN_DETAIL_Columns);

                _apiDbContext.SUN_Configurations.First().DETAIL_Columns = sUN_DETAIL_Columns;
                

                await _apiDbContext.SaveChangesAsync();
                


            }
            else
            {
                Log.Information("Creating new SUN_Configuration_Model with an empty ConnectionString.");

                SUN_Configuration_Model sUN_Configuration_Model = new SUN_Configuration_Model() { DETAIL_Columns = sUN_DETAIL_Columns, ConnectionsString = "" };

                await _apiDbContext.SUN_Configurations.AddAsync(sUN_Configuration_Model);
                
                Log.Information("Saving the new " + tableName + " Columns.");

                await _apiDbContext.SaveChangesAsync();

            }

            await regenerateTheMappingDefaults();

        }

        private async Task regenerateTheMappingDefaults()
        {
            if (_apiDbContext.HRMS_REPORT_SUN_DETAILS.Count() > 0)
            {
                _apiDbContext.HRMS_REPORT_SUN_DETAILS.RemoveRange(_apiDbContext.HRMS_REPORT_SUN_DETAILS);
            }

            if (_apiDbContext.OPERA_REPORT_SUN_DETAILS.Count() > 0)
            {
                _apiDbContext.OPERA_REPORT_SUN_DETAILS.RemoveRange(_apiDbContext.OPERA_REPORT_SUN_DETAILS);
            }

            List<OPERA_REPORT_SUN_DETAIL_Model> g_OPERA_REPORT_SUN_DETAIL_s = new List<OPERA_REPORT_SUN_DETAIL_Model>();
            List<HRMS_REPORT_SUN_DETAIL_Model> g_HRMS_REPORT_SUN_DETAIL_s = new List<HRMS_REPORT_SUN_DETAIL_Model>();

            foreach (SUN_DETAIL_Column_Model sUN_DETAIL_Column_Model in _apiDbContext.SUN_DETAIL_Columns)
            {
                switch (sUN_DETAIL_Column_Model.Type)
                {
                    case "int":
                        OPERA_REPORT_SUN_DETAIL_Model oPERA_REPORT_SUN_DETAIL_Model = new OPERA_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true , ValueType="int" , IntValue=0 };
                        g_OPERA_REPORT_SUN_DETAIL_s.Add(oPERA_REPORT_SUN_DETAIL_Model);
                        HRMS_REPORT_SUN_DETAIL_Model hRMS_REPORT_SUN_DETAIL_Model = new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "int", IntValue = 0 };
                        g_HRMS_REPORT_SUN_DETAIL_s.Add(hRMS_REPORT_SUN_DETAIL_Model);
                        break;
                    case "string":
                        OPERA_REPORT_SUN_DETAIL_Model oPERA_REPORT_SUN_DETAIL_Model2 = new OPERA_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "string", StringValue = "0" };
                        g_OPERA_REPORT_SUN_DETAIL_s.Add(oPERA_REPORT_SUN_DETAIL_Model2);
                        HRMS_REPORT_SUN_DETAIL_Model hRMS_REPORT_SUN_DETAIL_Model2 = new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "string", StringValue = "0" };
                        g_HRMS_REPORT_SUN_DETAIL_s.Add(hRMS_REPORT_SUN_DETAIL_Model2);
                        break;
                    case "decimal":
                        OPERA_REPORT_SUN_DETAIL_Model oPERA_REPORT_SUN_DETAIL_Model3 = new OPERA_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "decimal", DecimalValue = 0 };
                        g_OPERA_REPORT_SUN_DETAIL_s.Add(oPERA_REPORT_SUN_DETAIL_Model3);
                        HRMS_REPORT_SUN_DETAIL_Model hRMS_REPORT_SUN_DETAIL_Model3 = new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "decimal", DecimalValue = 0 };
                        g_HRMS_REPORT_SUN_DETAIL_s.Add(hRMS_REPORT_SUN_DETAIL_Model3);
                        break; 
                    case "datetime":
                        OPERA_REPORT_SUN_DETAIL_Model oPERA_REPORT_SUN_DETAIL_Model4 = new OPERA_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "datetime", DateTimeValue = new DateTime() };
                        g_OPERA_REPORT_SUN_DETAIL_s.Add(oPERA_REPORT_SUN_DETAIL_Model4);
                        HRMS_REPORT_SUN_DETAIL_Model hRMS_REPORT_SUN_DETAIL_Model4 = new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "datetime", DateTimeValue = new DateTime() };
                        g_HRMS_REPORT_SUN_DETAIL_s.Add(hRMS_REPORT_SUN_DETAIL_Model4);
                        break;
                    case "double":
                        OPERA_REPORT_SUN_DETAIL_Model oPERA_REPORT_SUN_DETAIL_Model5 = new OPERA_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "double", DoubleValue = 0 };
                        g_OPERA_REPORT_SUN_DETAIL_s.Add(oPERA_REPORT_SUN_DETAIL_Model5);
                        HRMS_REPORT_SUN_DETAIL_Model hRMS_REPORT_SUN_DETAIL_Model5 = new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "double", DoubleValue = 0 };
                        g_HRMS_REPORT_SUN_DETAIL_s.Add(hRMS_REPORT_SUN_DETAIL_Model5);
                        break;
                    case "short":
                        OPERA_REPORT_SUN_DETAIL_Model oPERA_REPORT_SUN_DETAIL_Model6 = new OPERA_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "short", ShortValue = 0 };
                        g_OPERA_REPORT_SUN_DETAIL_s.Add(oPERA_REPORT_SUN_DETAIL_Model6);
                        HRMS_REPORT_SUN_DETAIL_Model hRMS_REPORT_SUN_DETAIL_Model6 = new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = sUN_DETAIL_Column_Model.ColumnName, IsConst = true, ValueType = "short", ShortValue = 0 };
                        g_HRMS_REPORT_SUN_DETAIL_s.Add(hRMS_REPORT_SUN_DETAIL_Model6);
                        break;
                }
            }

            await _apiDbContext.OPERA_REPORT_SUN_DETAILS.AddRangeAsync(g_OPERA_REPORT_SUN_DETAIL_s);
            await _apiDbContext.HRMS_REPORT_SUN_DETAILS.AddRangeAsync(g_HRMS_REPORT_SUN_DETAIL_s);
            await _apiDbContext.SaveChangesAsync();

            Log.Information("Mapping with Sun Detail is ready");
        }

        public async Task<List<SUN_DETAIL_Column_Model>> GetColumns()
        {
            Log.Information("Retuning "+tableName+" Columns...");

            return _apiDbContext.SUN_DETAIL_Columns.ToList();

        }
    }
}
