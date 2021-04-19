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
            if (_apiDbContext.SUN_Configurations.Count() > 0)
            {

                _apiDbContext.SUN_Configurations.First().HDR_Columns = new List<SUN_HDR_Column_Model>();

                Log.Information("Deleting all " + tableName + " Columns.");

                _apiDbContext.SUN_HDR_Columns.RemoveRange(_apiDbContext.SUN_HDR_Columns);

                _apiDbContext.SUN_Configurations.First().HDR_Columns = sUN_HDR_Columns;

                Log.Information("Saving the new " + tableName + " Columns.");

                await _apiDbContext.SaveChangesAsync();
              
            }
            else
            {

                Log.Information("Creating new SUN_Configuration_Model with an empty ConnectionString.");

                SUN_Configuration_Model sUN_Configuration_Model = new SUN_Configuration_Model() {HDR_Columns = sUN_HDR_Columns, ConnectionsString="" } ;

                await _apiDbContext.SUN_Configurations.AddAsync(sUN_Configuration_Model);

                Log.Information("Saving the new " + tableName + " Columns.");

                await _apiDbContext.SaveChangesAsync();

            }

        }

        private async Task regenerateTheMappingDefaults()
        {
            if (_apiDbContext.HRMS_REPORT_SUN_HDRS.Count() > 0)
            {
                _apiDbContext.HRMS_REPORT_SUN_HDRS.RemoveRange(_apiDbContext.HRMS_REPORT_SUN_HDRS);
            }

            if (_apiDbContext.OPERA_REPORT_SUN_HDRS.Count() > 0)
            {
                _apiDbContext.OPERA_REPORT_SUN_HDRS.RemoveRange(_apiDbContext.OPERA_REPORT_SUN_HDRS);
            }

            List<OPERA_REPORT_SUN_HDR_Model> g_OPERA_REPORT_SUN_HDR_s = new List<OPERA_REPORT_SUN_HDR_Model>();
            List<HRMS_REPORT_SUN_HDR_Model> g_HRMS_REPORT_SUN_HDR_s = new List<HRMS_REPORT_SUN_HDR_Model>();

            foreach (SUN_HDR_Column_Model sUN_HDR_Column_Model in _apiDbContext.SUN_HDR_Columns)
            {
                switch (sUN_HDR_Column_Model.Type.ToLower())
                {
                    case "int":
                        OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR_Model = new OPERA_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "int", IntValue = 0 };
                        g_OPERA_REPORT_SUN_HDR_s.Add(oPERA_REPORT_SUN_HDR_Model);
                        HRMS_REPORT_SUN_HDR_Model hRMS_REPORT_SUN_HDR_Model = new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "int", IntValue = 0 };
                        g_HRMS_REPORT_SUN_HDR_s.Add(hRMS_REPORT_SUN_HDR_Model);
                        break;
                    case "string":
                        OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR_Model2 = new OPERA_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "string", StringValue = "0" };
                        g_OPERA_REPORT_SUN_HDR_s.Add(oPERA_REPORT_SUN_HDR_Model2);
                        HRMS_REPORT_SUN_HDR_Model hRMS_REPORT_SUN_HDR_Model2 = new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "string", StringValue = "0" };
                        g_HRMS_REPORT_SUN_HDR_s.Add(hRMS_REPORT_SUN_HDR_Model2);
                        break;
                    case "decimal":
                        OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR_Model3 = new OPERA_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "decimal", DecimalValue = 0 };
                        g_OPERA_REPORT_SUN_HDR_s.Add(oPERA_REPORT_SUN_HDR_Model3);
                        HRMS_REPORT_SUN_HDR_Model hRMS_REPORT_SUN_HDR_Model3 = new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "decimal", DecimalValue = 0 };
                        g_HRMS_REPORT_SUN_HDR_s.Add(hRMS_REPORT_SUN_HDR_Model3);
                        break;
                    case "datetime":
                        OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR_Model4 = new OPERA_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "string", StringValue = "GETDATE()" };
                        g_OPERA_REPORT_SUN_HDR_s.Add(oPERA_REPORT_SUN_HDR_Model4);
                        HRMS_REPORT_SUN_HDR_Model hRMS_REPORT_SUN_HDR_Model4 = new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "string", StringValue = "GETDATE()" };
                        g_HRMS_REPORT_SUN_HDR_s.Add(hRMS_REPORT_SUN_HDR_Model4);
                        break;
                    case "double":
                        OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR_Model5 = new OPERA_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "double", DoubleValue = 0 };
                        g_OPERA_REPORT_SUN_HDR_s.Add(oPERA_REPORT_SUN_HDR_Model5);
                        HRMS_REPORT_SUN_HDR_Model hRMS_REPORT_SUN_HDR_Model5 = new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "double", DoubleValue = 0 };
                        g_HRMS_REPORT_SUN_HDR_s.Add(hRMS_REPORT_SUN_HDR_Model5);
                        break;
                    case "short":
                        OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR_Model6 = new OPERA_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "short", ShortValue = 0 };
                        g_OPERA_REPORT_SUN_HDR_s.Add(oPERA_REPORT_SUN_HDR_Model6);
                        HRMS_REPORT_SUN_HDR_Model hRMS_REPORT_SUN_HDR_Model6 = new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "short", ShortValue = 0 };
                        g_HRMS_REPORT_SUN_HDR_s.Add(hRMS_REPORT_SUN_HDR_Model6);
                        break;
                    default:
                        OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR_Model7 = new OPERA_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "string", StringValue = "0" };
                        g_OPERA_REPORT_SUN_HDR_s.Add(oPERA_REPORT_SUN_HDR_Model7);
                        HRMS_REPORT_SUN_HDR_Model hRMS_REPORT_SUN_HDR_Model7 = new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = sUN_HDR_Column_Model.ColumnName, IsConst = true, ValueType = "string", StringValue = "0" };
                        g_HRMS_REPORT_SUN_HDR_s.Add(hRMS_REPORT_SUN_HDR_Model7);
                        break;
                }
            }

            await _apiDbContext.OPERA_REPORT_SUN_HDRS.AddRangeAsync(g_OPERA_REPORT_SUN_HDR_s);
            await _apiDbContext.HRMS_REPORT_SUN_HDRS.AddRangeAsync(g_HRMS_REPORT_SUN_HDR_s);
            await _apiDbContext.SaveChangesAsync();

            Log.Information("Mapping with Sun HDR is ready");
        }

        public async Task<List<SUN_HDR_Column_Model>> GetColumns()
        {
            Log.Information("Retuning " + tableName + " Columns...");

            return _apiDbContext.SUN_HDR_Columns.ToList();
        }
    }
}
