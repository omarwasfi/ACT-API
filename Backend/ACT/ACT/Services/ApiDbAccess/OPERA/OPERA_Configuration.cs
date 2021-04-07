using ACT.DataModels;
using ACT.DBContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.OPERA
{
    public class OPERA_Configuration : IOPERA_Configuration
    {
        private ApiDbContext _apiDbContext;
        public OPERA_Configuration(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }

        public OPERA_Configuration_Model GetOperaConfiguration()
        {
            Log.Information("Returning OPERA's Configurations.");

            return _apiDbContext.OPERA_Configurations.First();
        }

        public async Task UpdateFilePath(string FilePath)
        {
            if (_apiDbContext.OPERA_Configurations.Count() > 0)
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = _apiDbContext.OPERA_Configurations.First();
                oPERA_Configuration_Model.FilePath = FilePath;
                _apiDbContext.OPERA_Configurations.Update(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's FilePath Has been Updated Successfully.");
            }
            else
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = new OPERA_Configuration_Model() { FilePath = FilePath, CycleTime = new DateTime()};
                await _apiDbContext.OPERA_Configurations.AddAsync(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's FilePath Has been Added Successfully.");

            }
        }

        public async Task UpdateCycleTime(DateTime cycleTime)
        {
            if (_apiDbContext.OPERA_Configurations.Count() > 0)
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = _apiDbContext.OPERA_Configurations.First();
                oPERA_Configuration_Model.CycleTime = cycleTime;
                _apiDbContext.OPERA_Configurations.Update(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's CycleTime Has been Updated Successfully.");
            }
            else
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = new OPERA_Configuration_Model() { CycleTime = cycleTime, FilePath = ""};
                await _apiDbContext.OPERA_Configurations.AddAsync(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's CycleTime Has been Added Successfully.");

            }
        }

        public async Task UpdateNumberOfLinesToBeIgnoredAtTheBeggining(int numberOfLinesToBeIgnoredAtTheBeginning) 
        {
            if (_apiDbContext.OPERA_Configurations.Count() > 0)
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = _apiDbContext.OPERA_Configurations.First();
                oPERA_Configuration_Model.NumberOfLinesToBeIgnoredAtTheBeginning = numberOfLinesToBeIgnoredAtTheBeginning;
                _apiDbContext.OPERA_Configurations.Update(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's lined to be ignored Has been Updated Successfully.");
            }
            else
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = new OPERA_Configuration_Model() { NumberOfLinesToBeIgnoredAtTheBeginning = numberOfLinesToBeIgnoredAtTheBeginning, CycleTime = new DateTime(), FilePath = "" };
                await _apiDbContext.OPERA_Configurations.AddAsync(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's lined to be ignored Has been Added Successfully.");

            }
        }

        public async Task UpdateNumberOfLinesToBeIgnoredAtTheEnd(int numberOfLinesToBeIgnoredAtTheEnd)
        {
            if (_apiDbContext.OPERA_Configurations.Count() > 0)
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = _apiDbContext.OPERA_Configurations.First();
                oPERA_Configuration_Model.NumberOfLinesToBeIgnoredAtTheEnd = numberOfLinesToBeIgnoredAtTheEnd;
                _apiDbContext.OPERA_Configurations.Update(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's lined to be ignored Has been Updated Successfully.");
            }
            else
            {
                OPERA_Configuration_Model oPERA_Configuration_Model = new OPERA_Configuration_Model() { NumberOfLinesToBeIgnoredAtTheEnd = numberOfLinesToBeIgnoredAtTheEnd, CycleTime = new DateTime(), FilePath = "" };
                await _apiDbContext.OPERA_Configurations.AddAsync(oPERA_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("OPERA's lined to be ignored Has been Added Successfully.");

            }
        }


        public async Task LoadDefault()
        {
            if (_apiDbContext.OPERA_Configurations.Count() > 0)
            {
                _apiDbContext.OPERA_Configurations.Remove(_apiDbContext.OPERA_Configurations.First());
                await _apiDbContext.SaveChangesAsync();
            }

            OPERA_Configuration_Model oPERA_Configuration_Model = new OPERA_Configuration_Model();

            oPERA_Configuration_Model.FilePath = "./wwwroot/Opera/RV0301.SUN";
            oPERA_Configuration_Model.CycleTime = new DateTime(1, 1, 1, hour: 1, 01, 59);

            oPERA_Configuration_Model.NumberOfLinesToBeIgnoredAtTheBeginning = 1;
            oPERA_Configuration_Model.NumberOfLinesToBeIgnoredAtTheEnd = 1;

         

            oPERA_Configuration_Model.Columns = new List<OPERA_REPORT_Column_Model>()
                {
                    new OPERA_REPORT_Column_Model(){ ColumnName="AccountCode" , StartPOS = 1 , EndPOS = 15 ,Type = "int" },
                    new OPERA_REPORT_Column_Model(){ ColumnName="From" , StartPOS = 16 , EndPOS = 23 ,Type = "string" },
                    new OPERA_REPORT_Column_Model(){ ColumnName="To" , StartPOS = 23 , EndPOS = 31 ,Type = "string" },
                    new OPERA_REPORT_Column_Model(){ ColumnName="C" , StartPOS = 33 , EndPOS = 34 ,Type = "string" },
                    new OPERA_REPORT_Column_Model(){ ColumnName="Amount" , StartPOS = 49 , EndPOS = 66 ,Type = "decimal" },
                    new OPERA_REPORT_Column_Model(){ ColumnName="D_C" , StartPOS = 66 , EndPOS = 67 ,Type = "string" },
                    new OPERA_REPORT_Column_Model(){ ColumnName="T" , StartPOS = 68 , EndPOS = 78 ,Type = "string" },
                    new OPERA_REPORT_Column_Model(){ ColumnName="GL" , StartPOS = 78 , EndPOS = 93 ,Type = "string" },
                    new OPERA_REPORT_Column_Model(){ ColumnName="Description" , StartPOS = 93 , EndPOS = 332 ,Type = "string" }

                };


            if (_apiDbContext.OPERA_REPORT_Columns.Count() > 0)
            {
                _apiDbContext.OPERA_REPORT_Columns.RemoveRange(_apiDbContext.OPERA_REPORT_Columns);

            }

            
            foreach (OPERA_REPORT_Column_Model c in oPERA_Configuration_Model.Columns)
            {
                _apiDbContext.OPERA_REPORT_Columns.Add(c);
            }

            _apiDbContext.OPERA_Configurations.Add(oPERA_Configuration_Model);

            await _apiDbContext.SaveChangesAsync();



        }
    }
}
