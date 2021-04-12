using ACT.DBContext;
using ACT.Services.ApiDbAccess.HRMS;
using ACT.Services.ApiDbAccess.HRMS_SUN;
using ACT.Services.ApiDbAccess.SUN;
using ACT.Services.HRMS.Mapper;
using ACT.Services.HRMS.Reader;
using ACT.Services.SUNDbAccess;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.Execute
{
    public class ExecuteHRMS : IExecuteHRMS
    {
        private IHRMS_Configuration _hRMS_Configuration;
        private ISUN_Configuration _sun_Configuration;
        private IRead_HRMS_REPORT _read_HRMS_REPORT;

        private IMap_HRMS_REPORT_SUN_HDR _map_HRMS_REPORT_SUN_HDR;
        private IMap_HRMS_REPORT_SUN_DETAIL _map_HRMS_REPORT_SUN_DETAIL;

        private IHRMS_REPORT_SUN_HDR _hRMS_REPORT_SUN_HDR;
        private IHRMS_REPORT_SUN_DETAIL _hRMS_REPORT_SUN_DETAIL;



        private IHDR _hDR;
        private IDETAIL _dETAIL;

        public ExecuteHRMS(ApiDbContext apiDbContext)
        {
            this._hRMS_Configuration = new HRMS_Configuration(apiDbContext);
            _sun_Configuration = new SUN_Configuration(apiDbContext);
            _hRMS_REPORT_SUN_HDR = new HRMS_REPORT_SUN_HDR(apiDbContext);
            _hRMS_REPORT_SUN_DETAIL = new HRMS_REPORT_SUN_DETAIL(apiDbContext);

            _read_HRMS_REPORT = new Read_HRMS_REPORT();

            _map_HRMS_REPORT_SUN_DETAIL = new Map_HRMS_REPORT_SUN_DETAIL();
            _map_HRMS_REPORT_SUN_HDR = new Map_HRMS_REPORT_SUN_HDR();



            _hDR = new HDR(_sun_Configuration.GetSunConfiguration());
            _dETAIL = new DETAIL(_sun_Configuration.GetSunConfiguration());
        }
        public DateTime GetHRMSNextStartTime()
        {
            DateTime startAt = new DateTime(
              year: DateTime.Now.Year,
              month: DateTime.Now.Month,
              day: _hRMS_Configuration.GetHRMSConfiguration().CycleTime.Day,
              hour: _hRMS_Configuration.GetHRMSConfiguration().CycleTime.Hour,
              minute: _hRMS_Configuration.GetHRMSConfiguration().CycleTime.Minute,
              0
              );

            int result = DateTime.Compare(startAt, DateTime.Now);

            if (result < 0)
            {
                startAt = startAt.AddMonths(1);
            }
            else if (result == 0)
            {
                startAt = startAt.AddSeconds(5);
            }

            return startAt;
        }

        public async Task ManualExecute()
        {
            Log.Information("Reading HRMS Table.");
            DataTable hrmsDataTable = _read_HRMS_REPORT.ReadHRMS(_hRMS_Configuration.GetHRMSConfiguration());

            DataTable sun_HDR_Table = mapHrmsWithSunHDR(hrmsDataTable);

            Log.Information("Inserting to Sun HDR.");
            int PSTG_HDR_ID = _hDR.InsertToHDR(sun_HDR_Table);

            DataTable sun_DETAIL_Rows = mapHrmsWithSunDETAIL(hrmsDataTable, PSTG_HDR_ID);

            Log.Information("Inserting to Sun DETAIL.");

            _dETAIL.InsertToDetail(sun_DETAIL_Rows);

            Log.Information("HRMS has been executed successfully.");

        }

        public async Task WorkerExecute()
        {

            await ManualExecute();

            Log.Information("HRMS has been executed successfully.");
        }


        private DataTable mapHrmsWithSunHDR(DataTable hrmsReportTable)
        {
            return _map_HRMS_REPORT_SUN_HDR.Map(hrmsReportTable, _hRMS_REPORT_SUN_HDR.Get_HRMS_REPORT_SUN_HDR_s());
        }

        private DataTable mapHrmsWithSunDETAIL(DataTable hrmsDataTable, int PSTG_HDR_ID)
        {
             return _map_HRMS_REPORT_SUN_DETAIL.Map(hrmsDataTable, _hRMS_REPORT_SUN_DETAIL.Get_HRMS_REPORT_SUN_DETAIL_s(), PSTG_HDR_ID);
        }


    }
}
