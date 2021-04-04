using ACT.DataModels;
using ACT.Services.ApiDbAccess.OPERA_REPORT;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
namespace ACT.Controllers
{
    [ApiController]
    [Route("Opera/Report")]
    public class OPERA_REPORT_Configuration : ControllerBase
    {
        private readonly IOPERA_REPORT_Configuration _oPERA_REPORT_Configuration;
        public class OPERA_REPORT_ColumnViewModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Type { get; set; }
            [Required]
            public int StartPOS { get; set; }
            [Required]
            public int EndPOS { get; set; }
        }
        public OPERA_REPORT_Configuration(IOPERA_REPORT_Configuration oPERA_REPORT_Configuration)
        {
            _oPERA_REPORT_Configuration = oPERA_REPORT_Configuration;
        }



        [HttpGet("GetColumns")]
        public async Task<List<OPERA_REPORT_ColumnViewModel>> GetColumns()
        {
            List<OPERA_REPORT_Column_Model> oPERA_REPORT_Column_Models = await _oPERA_REPORT_Configuration.GetColumns();
            List<OPERA_REPORT_ColumnViewModel> operaRportColumnsResult = new List<OPERA_REPORT_ColumnViewModel>();
            foreach (var c in oPERA_REPORT_Column_Models)
            {
                operaRportColumnsResult.Add(
                    new OPERA_REPORT_ColumnViewModel { Name = c.ColumnName, Type = c.Type ,StartPOS = c.StartPOS , EndPOS = c.EndPOS}
                    );
            }

            return operaRportColumnsResult;

        }

        [HttpPost("UpdateColumns")]
        public async Task UpdateColumns(List<OPERA_REPORT_ColumnViewModel> operaReportColumns)
        {

            if (operaReportColumns.Count > 0)
            {
                List<OPERA_REPORT_Column_Model> OPERA_REPORT_Columns = new List<OPERA_REPORT_Column_Model>();
                foreach (var s in operaReportColumns)
                {
                    OPERA_REPORT_Columns.Add(new OPERA_REPORT_Column_Model() { ColumnName = s.Name, Type = s.Type , StartPOS = s.StartPOS,EndPOS = s.EndPOS });
                }

                await _oPERA_REPORT_Configuration.UpdateColumns(OPERA_REPORT_Columns);
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }


        }
    }
}
