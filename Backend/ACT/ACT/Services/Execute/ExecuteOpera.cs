using ACT.DataModels;
using ACT.DBContext;
using ACT.Services.ApiDbAccess.OPERA;
using ACT.Services.ApiDbAccess.OPERA_SUN;
using ACT.Services.ApiDbAccess.SUN;
using ACT.Services.OPERA.Mapper;
using ACT.Services.OPERA.Reader;
using ACT.Services.SUNDbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        /// <summary>
        /// ReadOpera - get operaDataTable
        /// MapOperaToSunHDR - Get DataTable with one row 
        /// Call HDR And Get the id
        /// MapOperaToSunDETAIL(HDR_Id) - Get DataTable with the number of rows in the operaDataTable
        /// Call DETAIL To insert operaDataTable
        /// </summary>
        public async Task Execute()
        {
            DataTable operaReportTable = readOpera();
            
            DataRow sun_HDR_Row = mapOperaWithSunHDR(operaReportTable);

            int PSTG_HDR_ID = _hDR.InsertToHDR(sun_HDR_Row);

            DataTable sun_DETAIL_Rows = mapOperaWithSunDETAIL(operaReportTable,PSTG_HDR_ID);

            _dETAIL.InsertToDetail(sun_DETAIL_Rows);

        }

        private DataTable readOpera()
        {
            return _read_OPERA_REPORT.ReadOpera(_opera_Configuration.GetOperaConfiguration());
        }

        private DataRow mapOperaWithSunHDR(DataTable operaReportTable)
        {
            return _map_OPERA_REPORT_SUN_HDR.Map(operaReportTable, _oPERA_REPORT_SUN_HDR.GetOPERA_REPORT_SUN_HDR_s());
        }

        private DataTable mapOperaWithSunDETAIL(DataTable operaReportTable , int PSTG_HDR_ID)
        {
            return _map_OPERA_REPORT_SUN_DERAIL.Map(operaReportTable, _oPERA_REPORT_SUN_DETAIL.GetOPERA_REPORT_SUN_DETAIL_s(), PSTG_HDR_ID);
        }

    }
}
