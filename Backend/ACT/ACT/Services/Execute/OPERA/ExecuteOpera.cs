using ACT.DataModels;
using ACT.DBContext;
using ACT.Services.ApiDbAccess.OPERA;
using ACT.Services.ApiDbAccess.OPERA_SUN;
using ACT.Services.ApiDbAccess.SUN;
using ACT.Services.OPERA.Mapper;
using ACT.Services.OPERA.Reader;
using ACT.Services.SUNDbAccess;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ACT.Services.Execute
{
    public class ExecuteOpera : IExecuteOpera 
    {
        private ApiDbContext _apiDbContext;

        private IMap_OPERA_REPORT_SUN_HDR _map_OPERA_REPORT_SUN_HDR;
        private IMap_OPERA_REPORT_SUN_DERAIL _map_OPERA_REPORT_SUN_DERAIL;
        private IRead_OPERA_REPORT _read_OPERA_REPORT;
        
        private IOPERA_Configuration _opera_Configuration;
        private ISUN_Configuration _sun_Configuration;

        private IOPERA_REPORT_SUN_HDR _oPERA_REPORT_SUN_HDR;
        private IOPERA_REPORT_SUN_DETAIL _oPERA_REPORT_SUN_DETAIL;

        private IHDR _hDR;
        private IDETAIL _dETAIL;



        public ExecuteOpera(ApiDbContext apiDbContext)
        {
            _map_OPERA_REPORT_SUN_HDR = new Map_OPERA_REPORT_SUN_HDR();
            _map_OPERA_REPORT_SUN_DERAIL = new Map_OPERA_REPORT_SUN_DETAIL();
          
            _read_OPERA_REPORT = new Read_OPERA_REPORT();
           
            _opera_Configuration = new OPERA_Configuration(apiDbContext);
            _sun_Configuration = new SUN_Configuration(apiDbContext);
            
            _oPERA_REPORT_SUN_HDR = new OPERA_REPORT_SUN_HDR(apiDbContext);
            _oPERA_REPORT_SUN_DETAIL = new OPERA_REPORT_SUN_DETAIL(apiDbContext);
            
            _hDR = new HDR(_sun_Configuration.GetSunConfiguration());
            _dETAIL = new DETAIL(_sun_Configuration.GetSunConfiguration());
        }

     


        public async Task ManualExecute()
        {
            Log.Information("Reading Opera file.");
            DataTable operaReportTable = readOpera();
            
            
            DataTable sun_HDR_Table = mapOperaWithSunHDR(operaReportTable);

            Log.Information("Inserting to Sun HDR.");
            int PSTG_HDR_ID = _hDR.InsertToHDR(sun_HDR_Table);

            DataTable sun_DETAIL_Rows = mapOperaWithSunDETAIL(operaReportTable,PSTG_HDR_ID);

            Log.Information("Inserting to Sun DETAIL.");
            _dETAIL.InsertToDetail(sun_DETAIL_Rows);

            Log.Information("Opera has been executed successfully.");

        }

        public async Task WorkerExecute()
        {
           

            await ManualExecute();

            Log.Information("Opera has been executed successfully.");
            
        }

        public DateTime GetOperaNextStartTime()
        {
            DateTime startAt = new DateTime(
              year: DateTime.Now.Year,
              month: DateTime.Now.Month,
              day: DateTime.Now.Day,
              hour: _opera_Configuration.GetOperaConfiguration().CycleTime.Hour,
              minute: _opera_Configuration.GetOperaConfiguration().CycleTime.Minute,
              0
              );
            
            int result = DateTime.Compare(startAt, DateTime.Now);

            if (result < 0 )
            {
                startAt = startAt.AddDays(1);
            }
            else if (result == 0)
            {
                startAt = startAt.AddSeconds(5);
            }

                return startAt;
        }

        
        private DataTable readOpera()
        {
            return _read_OPERA_REPORT.ReadOpera(_opera_Configuration.GetOperaConfiguration());
        }

        private DataTable mapOperaWithSunHDR(DataTable operaReportTable)
        {
            return _map_OPERA_REPORT_SUN_HDR.Map(operaReportTable, _oPERA_REPORT_SUN_HDR.Get_OPERA_REPORT_SUN_HDR_s());
        }

        private DataTable mapOperaWithSunDETAIL(DataTable operaReportTable , int PSTG_HDR_ID)
        {
            return _map_OPERA_REPORT_SUN_DERAIL.Map(operaReportTable, _oPERA_REPORT_SUN_DETAIL.Get_OPERA_REPORT_SUN_DETAIL_s(), PSTG_HDR_ID);
        }

       
    }
}
