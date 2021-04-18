﻿using ACT.DataModels;
using ACT.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.HRMS_SUN
{
    public class HRMS_REPORT_SUN_DETAIL : IHRMS_REPORT_SUN_DETAIL
    {
        private ApiDbContext _apiDbContext;

        public HRMS_REPORT_SUN_DETAIL(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }

        public List<HRMS_REPORT_SUN_DETAIL_Model> Get_HRMS_REPORT_SUN_DETAIL_s()
        {
            return _apiDbContext.HRMS_REPORT_SUN_DETAILS.ToList();
        }



        public async Task Update_HRMS_REPORT_SUN_DETAIL(List<HRMS_REPORT_SUN_DETAIL_Model> hRMS_REPORT_SUN_DETAIL_s)
        {
            if (_apiDbContext.HRMS_REPORT_SUN_DETAILS.Count() > 0)
            {
                _apiDbContext.HRMS_REPORT_SUN_DETAILS.RemoveRange(_apiDbContext.HRMS_REPORT_SUN_DETAILS);
            }

            foreach (HRMS_REPORT_SUN_DETAIL_Model hRMS_REPORT_SUN_DETAIL_Model in hRMS_REPORT_SUN_DETAIL_s)
            {
                _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(hRMS_REPORT_SUN_DETAIL_Model);
            }

            await _apiDbContext.SaveChangesAsync();
        }

        public async Task InsertRow(HRMS_REPORT_SUN_DETAIL_Model HRMS_REPORT_SUN_DETAIL)
        {
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(HRMS_REPORT_SUN_DETAIL);
            await _apiDbContext.SaveChangesAsync();
        }


        public async Task UpdateRow(HRMS_REPORT_SUN_DETAIL_Model HRMS_REPORT_SUN_DETAIL)
        {
            _apiDbContext.Update(HRMS_REPORT_SUN_DETAIL);
            await _apiDbContext.SaveChangesAsync();
        }

        public async Task DeleteRow(int Id)
        {
            HRMS_REPORT_SUN_DETAIL_Model HRMS_REPORT_SUN_DETAIL_Model = _apiDbContext.HRMS_REPORT_SUN_DETAILS.Where(x => x.Id == Id).FirstOrDefault();
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Remove(HRMS_REPORT_SUN_DETAIL_Model);
            await _apiDbContext.SaveChangesAsync();
        }

        public async Task LoadDefaults()
        {
            if (_apiDbContext.HRMS_REPORT_SUN_DETAILS.Count() > 0)
            {
                _apiDbContext.HRMS_REPORT_SUN_DETAILS.RemoveRange(_apiDbContext.HRMS_REPORT_SUN_DETAILS);
            }

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "PSTG_DETAIL_ID", IsConst = false, AutoGenerated = true, ValueType = "int" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "LINE_NUM", IsConst = false, AutoGenerated = true, ValueType = "int" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "UPDATE_COUNT", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "LAST_CHANGE_USER_ID", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "OFS" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "LAST_CHANGE_DATETIME", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "GETDATE()" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ACNT_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "PERD", IsConst = true, AutoGenerated = false, ValueType = "int",IntValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "JNL_NUM", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "JNL_LINE_NUM", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "JNL_TYPE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "JNL_SRCE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "TXN_REF", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "DESCR", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "AMT", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "DR_CR_IND", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CONV_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });


            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CONV_RATE", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "TXN_AMT", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "TXN_DEC_PL", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "BASE_RATE", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "BASE_OPR", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CONV_OPR", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "RPT_RATE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "RPT_OPR", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "RPT_AMT", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "MEMO_AMT", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ALLOCN_IND", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ALLOCN_REF", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ALLOCN_PERD", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ALLOCN_IN_PROGRESS", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ENTRY_PERD", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ASSET_IND", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ASSET_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ASSET_SUB_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CLEARDOWN", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "REVERSAL", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });






            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "LOSS_GAIN", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ROUGH_FLAG", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "IN_USE_FLAG", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "EXCL_BAL", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ANL_CODE_T0", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ANL_CODE_T1", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ANL_CODE_T2", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ANL_CODE_T3", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ANL_CODE_T4", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ANL_CODE_T5", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ANL_CODE_T6", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ANL_CODE_T7", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ANL_CODE_T8", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "ANL_CODE_T9", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "HOLD_REF", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "HOLD_OPR_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "DOC_NUM_1", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "DOC_NUM_2", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "DOC_NUM_3", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "DOC_NUM_4", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "DISC_PCENT_1", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "DISC_PCENT_2", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "INTEREST_PCENT", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "LATE_PYMT_PCENT", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "PYMT_REF", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "BANK_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });




            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "SRCE_REF", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "MODULE_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "STD_TEXT_CLASS_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "STD_TEXT_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });


            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CV4_CONV_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CV4_AMT", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CV4_CONV_RATE", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CV4_OPERATOR", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CV4_DP", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });





            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CV5_CONV_CODE", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CV5_AMT", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CV5_CONV_RATE", IsConst = true, AutoGenerated = false, ValueType = "decimal", DecimalValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CV5_OPERATOR", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "CV5_DP", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });



            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "SPLIT_ORIG_LINE", IsConst = true, AutoGenerated = false, ValueType = "int", IntValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "BINDER_STATUS", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "1" });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "AGREED_STATUS", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "TRUE_RATED", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "SUPPLMNTRY_EXTSN", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "APRVLS_EXTSN", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "MAN_PAY_OVER", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "AUTHORISTN_IN_PROGRESS", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });
            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "SPLIT_IN_PROGRESS", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "JNL_REVERSAL_TYPE", IsConst = true, AutoGenerated = false, ValueType = "short", ShortValue = 0 });

            _apiDbContext.HRMS_REPORT_SUN_DETAILS.Add(new HRMS_REPORT_SUN_DETAIL_Model() { SunAttribute = "SIGNING_DETAILS", IsConst = true, AutoGenerated = false, ValueType = "string", StringValue = "00" });


            await _apiDbContext.SaveChangesAsync();
        }
    }
}
