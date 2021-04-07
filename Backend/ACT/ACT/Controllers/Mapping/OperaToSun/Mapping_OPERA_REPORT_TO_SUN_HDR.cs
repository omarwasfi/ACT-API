using ACT.Services.ApiDbAccess.OPERA_SUN;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Controllers
{
    [ApiController]
    [Route("Mapping/OperaToSun/ReportToHDR")]
    public class Mapping_OPERA_REPORT_TO_SUN_HDR : ControllerBase
    {
        private IOPERA_REPORT_SUN_HDR _oPERA_REPORT_SUN_HDR;
        public  class OPERA_REPORT_SUN_HDR_ViewModel
        {

        }
        public Mapping_OPERA_REPORT_TO_SUN_HDR(IOPERA_REPORT_SUN_HDR oPERA_REPORT_SUN_HDR)
        {
            this._oPERA_REPORT_SUN_HDR = oPERA_REPORT_SUN_HDR;
        }

        [HttpPost("Execute")]
        public async Task UpdateOperaReportSunHdr()
        {
            //await _executeOpera.Execute();
        }
    }
}
