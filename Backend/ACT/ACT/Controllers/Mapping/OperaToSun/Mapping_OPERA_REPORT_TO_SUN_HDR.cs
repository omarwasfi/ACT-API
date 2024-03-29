﻿using ACT.DataModels;
using ACT.Services.ApiDbAccess.OPERA_SUN;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Controllers
{
    [ApiController]
    [Route("Mapping/OperaToSun/ReportToHDR")]
    [EnableCors("MyPolicy")]
    public class Mapping_OPERA_REPORT_TO_SUN_HDR : ControllerBase
    {
        private IOPERA_REPORT_SUN_HDR _oPERA_REPORT_SUN_HDR;
        public class OPERA_REPORT_SUN_HDR_ViewModel
        {
            public int Id { get; set; }

            [Required]
            public string SunAttribute { get; set; }
            [Required]
            public bool IsConst { get; set; }
            [Required]
            public bool AutoGenerated { get; set; }
            [Required]
            public string ValueType { get; set; }
            public string StringValue { get; set; }

            public int? IntValue { get; set; }

            public short? ShortValue { get; set; }

            public DateTime? DateTimeValue { get; set; }

            public decimal? DecimalValue { get; set; }

            public double? DoubleValue { get; set; }

            public string MapWithOPERA { get; set; }
        }

        public class OPERA_REPORT_SUN_HDR_InsertModel
        {

            [Required]
            public string SunAttribute { get; set; }
            [Required]
            public bool IsConst { get; set; }
            [Required]
            public bool AutoGenerated { get; set; }
            [Required]
            public string ValueType { get; set; }
            public string StringValue { get; set; }

            public int? IntValue { get; set; }

            public short? ShortValue { get; set; }

            public DateTime? DateTimeValue { get; set; }

            public decimal? DecimalValue { get; set; }

            public double? DoubleValue { get; set; }

            public string MapWithOPERA { get; set; }
        }
        public Mapping_OPERA_REPORT_TO_SUN_HDR(IOPERA_REPORT_SUN_HDR oPERA_REPORT_SUN_HDR)
        {
            this._oPERA_REPORT_SUN_HDR = oPERA_REPORT_SUN_HDR;
        }


        [HttpGet("GetOperaReportSunHdr")]
        public List<OPERA_REPORT_SUN_HDR_ViewModel> GetOperaReportSunHdr()
        {
            List<OPERA_REPORT_SUN_HDR_ViewModel> oPERA_REPORT_SUN_HDR_ViewModels = new List<OPERA_REPORT_SUN_HDR_ViewModel>();

            foreach (OPERA_REPORT_SUN_HDR_Model o in _oPERA_REPORT_SUN_HDR.Get_OPERA_REPORT_SUN_HDR_s())
            {
                OPERA_REPORT_SUN_HDR_ViewModel oPERA_REPORT_SUN_HDR_ViewModel = new OPERA_REPORT_SUN_HDR_ViewModel()
                {
                    Id = o.Id,
                    SunAttribute = o.SunAttribute,
                    IsConst = o.IsConst,
                    AutoGenerated = o.AutoGenerated,
                    ValueType = o.ValueType,
                    StringValue = o.StringValue,
                    IntValue = o.IntValue,
                    ShortValue = o.ShortValue,
                    DateTimeValue = o.DateTimeValue,
                    DecimalValue = o.DecimalValue,
                    DoubleValue = o.DoubleValue,
                    MapWithOPERA = o.MapWithOPERA
                };
                oPERA_REPORT_SUN_HDR_ViewModels.Add(oPERA_REPORT_SUN_HDR_ViewModel);
            }

            return oPERA_REPORT_SUN_HDR_ViewModels;
        }

        [HttpPost("UpdateOperaReportSunHdr")]
        public async Task UpdateOperaReportSunHdr(List<OPERA_REPORT_SUN_HDR_ViewModel> oPERA_REPORT_SUN_HDR_ViewModels)
        {
            List<OPERA_REPORT_SUN_HDR_Model> oPERA_REPORT_SUN_HDR_s = new List<OPERA_REPORT_SUN_HDR_Model>();
            
            foreach (OPERA_REPORT_SUN_HDR_ViewModel o in oPERA_REPORT_SUN_HDR_ViewModels)
            {
                OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR = new OPERA_REPORT_SUN_HDR_Model()
                {
                    SunAttribute = o.SunAttribute,
                    IsConst = o.IsConst,
                    AutoGenerated = o.AutoGenerated,
                    ValueType = o.ValueType,
                    StringValue = o.StringValue,
                    IntValue = o.IntValue,
                    ShortValue = o.ShortValue,
                    DateTimeValue = o.DateTimeValue,
                    DecimalValue = o.DecimalValue,
                    DoubleValue = o.DoubleValue,
                    MapWithOPERA = o.MapWithOPERA
                };
                oPERA_REPORT_SUN_HDR_s.Add(oPERA_REPORT_SUN_HDR);
            }
            await _oPERA_REPORT_SUN_HDR.Update_OPERA_REPORT_SUN_HDR(oPERA_REPORT_SUN_HDR_s);
        }

        [HttpPost("InsertRow")]
        public async Task InsertRow(OPERA_REPORT_SUN_HDR_InsertModel oPERA_REPORT_SUN_HDR_InsertModel)
        {
            OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR_Model = new OPERA_REPORT_SUN_HDR_Model()
            {
                SunAttribute = oPERA_REPORT_SUN_HDR_InsertModel.SunAttribute,
                IsConst = oPERA_REPORT_SUN_HDR_InsertModel.IsConst,
                AutoGenerated = oPERA_REPORT_SUN_HDR_InsertModel.AutoGenerated,
                ValueType = oPERA_REPORT_SUN_HDR_InsertModel.ValueType,
                StringValue = oPERA_REPORT_SUN_HDR_InsertModel.StringValue,
                IntValue = oPERA_REPORT_SUN_HDR_InsertModel.IntValue,
                ShortValue = oPERA_REPORT_SUN_HDR_InsertModel.ShortValue,
                DateTimeValue = oPERA_REPORT_SUN_HDR_InsertModel.DateTimeValue,
                DecimalValue = oPERA_REPORT_SUN_HDR_InsertModel.DecimalValue,
                DoubleValue = oPERA_REPORT_SUN_HDR_InsertModel.DoubleValue,
                MapWithOPERA = oPERA_REPORT_SUN_HDR_InsertModel.MapWithOPERA
            };
            await _oPERA_REPORT_SUN_HDR.InsertRow(oPERA_REPORT_SUN_HDR_Model);
        }

        [HttpPatch("UpdateRow")]
        public async Task UpdateRow(OPERA_REPORT_SUN_HDR_ViewModel oPERA_REPORT_SUN_HDR_ViewModel)
        {
            OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR_Model = new OPERA_REPORT_SUN_HDR_Model()
            {
                Id = oPERA_REPORT_SUN_HDR_ViewModel.Id,
                SunAttribute = oPERA_REPORT_SUN_HDR_ViewModel.SunAttribute,
                IsConst = oPERA_REPORT_SUN_HDR_ViewModel.IsConst,
                AutoGenerated = oPERA_REPORT_SUN_HDR_ViewModel.AutoGenerated,
                ValueType = oPERA_REPORT_SUN_HDR_ViewModel.ValueType,
                StringValue = oPERA_REPORT_SUN_HDR_ViewModel.StringValue,
                IntValue = oPERA_REPORT_SUN_HDR_ViewModel.IntValue,
                ShortValue = oPERA_REPORT_SUN_HDR_ViewModel.ShortValue,
                DateTimeValue = oPERA_REPORT_SUN_HDR_ViewModel.DateTimeValue,
                DecimalValue = oPERA_REPORT_SUN_HDR_ViewModel.DecimalValue,
                DoubleValue = oPERA_REPORT_SUN_HDR_ViewModel.DoubleValue,
                MapWithOPERA = oPERA_REPORT_SUN_HDR_ViewModel.MapWithOPERA
            };
            await _oPERA_REPORT_SUN_HDR.UpdateRow(oPERA_REPORT_SUN_HDR_Model);
        }

        [HttpDelete("DeleteRow")]
        public async Task DeleteRow(int Id)
        {
            await _oPERA_REPORT_SUN_HDR.DeleteRow(Id);
        }

        [HttpPost("LoadDefaults")]
        public async Task LoadDefaults()
        {
           
            await _oPERA_REPORT_SUN_HDR.LoadDefaults();
        }


    }
}

