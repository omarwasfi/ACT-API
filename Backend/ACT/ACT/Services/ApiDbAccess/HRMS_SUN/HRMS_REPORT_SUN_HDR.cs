﻿using ACT.DataModels;
using ACT.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.HRMS_SUN
{
    public class HRMS_REPORT_SUN_HDR : IHRMS_REPORT_SUN_HDR
    {

        private ApiDbContext _apiDbContext;

        public HRMS_REPORT_SUN_HDR(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }
        public List<HRMS_REPORT_SUN_HDR_Model> Get_HRMS_REPORT_SUN_HDR_s()
        {
            return _apiDbContext.HRMS_REPORT_SUN_HDRS.ToList();
        }



        public async Task Update_HRMS_REPORT_SUN_HDR(List<HRMS_REPORT_SUN_HDR_Model> HRMS_REPORT_SUN_HDR_s)
        {
            if (_apiDbContext.HRMS_REPORT_SUN_HDRS.Count() > 0)
            {
                _apiDbContext.HRMS_REPORT_SUN_HDRS.RemoveRange(_apiDbContext.HRMS_REPORT_SUN_HDRS);
            }

            foreach (HRMS_REPORT_SUN_HDR_Model HRMS_REPORT_SUN_HDR_Model in HRMS_REPORT_SUN_HDR_s)
            {
                _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(HRMS_REPORT_SUN_HDR_Model);
            }

            await _apiDbContext.SaveChangesAsync();
        }

        public async Task InsertRow(HRMS_REPORT_SUN_HDR_Model HRMS_REPORT_SUN_HDR)
        {
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(HRMS_REPORT_SUN_HDR);
            await _apiDbContext.SaveChangesAsync();
        }


        public async Task UpdateRow(HRMS_REPORT_SUN_HDR_Model HRMS_REPORT_SUN_HDR)
        {
            _apiDbContext.Update(HRMS_REPORT_SUN_HDR);
            await _apiDbContext.SaveChangesAsync();
        }

        public async Task DeleteRow(int Id)
        {
            HRMS_REPORT_SUN_HDR_Model HRMS_REPORT_SUN_HDR_Model = _apiDbContext.HRMS_REPORT_SUN_HDRS.Where(x => x.Id == Id).FirstOrDefault();
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Remove(HRMS_REPORT_SUN_HDR_Model);
            await _apiDbContext.SaveChangesAsync();
        }

        public async Task LoadDefaults()
        {
            if (_apiDbContext.HRMS_REPORT_SUN_HDRS.Count() > 0)
            {
                _apiDbContext.HRMS_REPORT_SUN_HDRS.RemoveRange(_apiDbContext.HRMS_REPORT_SUN_HDRS);
            }

            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "PSTG_HDR_ID", IsConst = false, AutoGenerated = true, ValueType = "int" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "UPDATE_COUNT", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "LAST_CHANGE_USER_ID", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "OFS" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "LAST_CHANGE_DATETIME", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "GETDATE()" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CREATED_BY", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "OFS" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CREATED_DATETIME", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "GETDATE()" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CREATION_TYPE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "LI" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "DESCR", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "(ActAPI)PMS" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "LAST_STATUS", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_TYPE", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 2 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_WRITE_TO_HOLD", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 1 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_ROUGH_BOOK", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_ALLOW_BAL_TRANS", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_SUSPENSE_ACNT", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "999999999" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_OTHER_ACNT", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "999999999" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_BAL_BY", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "0" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_DFLT_PERD", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_RPT_ERR_ONLY", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 1 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_SUPPRESS_SUB_MSG", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 1 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_RPT_FMT", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "LIALL" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "JRNL_TYPE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "PMS" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_RPT_ACNT", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "999999999" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CNT_ORIG", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CNT_REJECTED", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CNT_BAL", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CNT_REVERSALS", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CNT_POSTED", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CNT_SUBSTITUTED", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CNT_PRINTED", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_LDG", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "A" });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_ALLOW_OVER_BDGT", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_ALLOW_SUSPNS_ACNT", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CNT_ZERO_VAL_ENTRIES", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "JNL_NUM", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "NUM_OF_IMBALANCES", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "DR_AMT_POSTED", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "CR_AMT_POSTED", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_HDRS.Add(new HRMS_REPORT_SUN_HDR_Model() { SunAttribute = "POST_TXN_REF_BAL", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });


            await _apiDbContext.SaveChangesAsync();

        }
    }
}
