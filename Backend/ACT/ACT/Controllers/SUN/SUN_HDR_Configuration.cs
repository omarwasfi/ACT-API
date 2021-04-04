using ACT.DataModels;
using ACT.DBContext;
using ACT.Services.ApiDbAccess.SUN_HDR;
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
    [Route("Sun/HDR")]
    public class SUN_HDR_Configuration : ControllerBase
    {
        private readonly ISUN_HDR_Configuration _sUN_HDR_Configuration;
        public class SUN_HDR_ColumnViewModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Type { get; set; }
        }
        public SUN_HDR_Configuration(ISUN_HDR_Configuration sun_hdr_Configuration)
        {
            _sUN_HDR_Configuration = sun_hdr_Configuration;
        }

       

        [HttpGet("GetColumns")]
        public async Task<List<SUN_HDR_ColumnViewModel>> GetColumns()
        {
            List<SUN_HDR_Column_Model> sUN_Column_Models = await _sUN_HDR_Configuration.GetColumns();
            List<SUN_HDR_ColumnViewModel> sunColumnsResult = new List<SUN_HDR_ColumnViewModel>();
            foreach (var c in sUN_Column_Models) 
            {
                sunColumnsResult.Add(
                    new SUN_HDR_ColumnViewModel { Name = c.ColumnName , Type =  c.Type }
                    );
            }

            return sunColumnsResult;

        }

        [HttpPost("UpdateColumns")]
        public async Task UpdateColumns(List<SUN_HDR_ColumnViewModel> sunHDRColumns)
        {

            if (sunHDRColumns.Count > 0)
            {
                List<SUN_HDR_Column_Model> SUN_Columns = new List<SUN_HDR_Column_Model>();
                foreach (var s in sunHDRColumns)
                {
                    SUN_Columns.Add(new SUN_HDR_Column_Model() { ColumnName = s.Name, Type = s.Type });
                }

                await _sUN_HDR_Configuration.UpdateColumns(SUN_Columns);
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }


        }
    }
}
