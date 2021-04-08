using ACT.DataModels;
using ACT.Services.ApiDbAccess.HRMS_REPORT;
using Microsoft.AspNetCore.Cors;
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
    [Route("Hrms/Report")]
    [EnableCors("MyPolicy")]
    public class HRMS_REPORT_Configuration : ControllerBase
    {
        private readonly IHRMS_REPORT_Configuration _hRMS_REPORT_Configuration;
        public class HRMS_REPORT_ColumnViewModel
        {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Type { get; set; }

        }
        public HRMS_REPORT_Configuration(IHRMS_REPORT_Configuration hRMS_REPORT_Configuration)
        {
            _hRMS_REPORT_Configuration = hRMS_REPORT_Configuration;
        }



        [HttpGet("GetColumns")]
        public async Task<List<HRMS_REPORT_ColumnViewModel>> GetColumns()
        {
            List<HRMS_REPORT_Column_Model> hRMS_REPORT_Column_Models = await _hRMS_REPORT_Configuration.GetColumns();
            List<HRMS_REPORT_ColumnViewModel> hrmsRportColumnsResult = new List<HRMS_REPORT_ColumnViewModel>();
            foreach (var c in hRMS_REPORT_Column_Models)
            {
                hrmsRportColumnsResult.Add(
                    new HRMS_REPORT_ColumnViewModel {Id = c.Id, Name = c.ColumnName, Type = c.Type }
                    );
            }

            return hrmsRportColumnsResult;

        }

        [HttpPost("UpdateColumns")]
        public async Task UpdateColumns(List<HRMS_REPORT_ColumnViewModel> hrmsReportColumns)
        {

            if (hrmsReportColumns.Count > 0)
            {
                List<HRMS_REPORT_Column_Model> HRMS_REPORT_Columns = new List<HRMS_REPORT_Column_Model>();
                foreach (var s in hrmsReportColumns)
                {
                    HRMS_REPORT_Columns.Add(new HRMS_REPORT_Column_Model() { ColumnName = s.Name, Type = s.Type });
                }

                await _hRMS_REPORT_Configuration.UpdateColumns(HRMS_REPORT_Columns);
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }


        }
    }
}
