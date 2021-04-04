using ACT.DataModels;
using ACT.Services.ApiDbAccess.SUN_DETAIL;
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
    [Route("Sun/Detail")]
    public class SUN_DETAIL_Configuration : ControllerBase
    {
        private readonly ISUN_DETAIL_Configuration _sUN_DETAIL_Configuration;
        public class SUN_DETAIL_ColumnViewModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Type { get; set; }
        }
        public SUN_DETAIL_Configuration(ISUN_DETAIL_Configuration sun_Configuration)
        {
            _sUN_DETAIL_Configuration = sun_Configuration;
        }

      

        [HttpGet("GetColumns")]
        public async Task<List<SUN_DETAIL_ColumnViewModel>> GetColumns()
        {
            List<SUN_DETAIL_Column_Model> sUN_Column_Models = await _sUN_DETAIL_Configuration.GetColumns();
            List<SUN_DETAIL_ColumnViewModel> sunColumnsResult = new List<SUN_DETAIL_ColumnViewModel>();
            foreach (var c in sUN_Column_Models)
            {
                sunColumnsResult.Add(
                    new SUN_DETAIL_ColumnViewModel { Name = c.ColumnName, Type = c.Type }
                    );
            }

            return sunColumnsResult;

        }

        [HttpPost("UpdateColumns")]
        public async Task UpdateColumns(List<SUN_DETAIL_ColumnViewModel> sunDETAILColumns)
        {

            if (sunDETAILColumns.Count > 0)
            {
                List<SUN_DETAIL_Column_Model> SUN_DETAIL_Columns = new List<SUN_DETAIL_Column_Model>();
                foreach (var s in sunDETAILColumns)
                {
                    SUN_DETAIL_Columns.Add(new SUN_DETAIL_Column_Model() { ColumnName = s.Name, Type = s.Type });
                }

                await _sUN_DETAIL_Configuration.UpdateColumns(SUN_DETAIL_Columns);
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }


        }
    }
}
