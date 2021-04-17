using ACT.DataModels;
using ACT.DBContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.SUN
{
    public class SUN_Configuration : ISUN_Configuration
    {
        private ApiDbContext _apiDbContext;
        public SUN_Configuration(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }

        public SUN_Configuration_Model GetSunConfiguration()
        {
            Log.Information("Returning sun's ConnectionString.");

            return _apiDbContext.SUN_Configurations.First();
        }

        public async Task UpdateConnectionString(string ConnectionString)
        {
            if(_apiDbContext.SUN_Configurations.Count() > 0)
            {
                SUN_Configuration_Model sUN_Configuration_Model = _apiDbContext.SUN_Configurations.First();
                sUN_Configuration_Model.ConnectionsString = ConnectionString;
                _apiDbContext.SUN_Configurations.Update(sUN_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("Sun's ConnectionString Has been Updated Successfully.");
            }
            else
            {
                SUN_Configuration_Model sUN_Configuration_Model = new SUN_Configuration_Model() { ConnectionsString = ConnectionString };
                await _apiDbContext.SUN_Configurations.AddAsync(sUN_Configuration_Model);
                await _apiDbContext.SaveChangesAsync();
                Log.Information("Sun's ConnectionString Has been Added Successfully.");

            }
        }

        public async Task LoadDefault()
        {
            if (_apiDbContext.SUN_Configurations.Count() > 0)
            {
                 _apiDbContext.SUN_Configurations.RemoveRange(_apiDbContext.SUN_Configurations);

            }

            SUN_Configuration_Model sUN_Configuration_Model = new SUN_Configuration_Model();

            sUN_Configuration_Model.ConnectionsString = "Data source=(local);Database=SunSystemsData;Trusted_Connection=True;user id=sa; password= fifinetech;";
            
            sUN_Configuration_Model.HDR_Columns = new List<SUN_HDR_Column_Model>() 
            {
                new SUN_HDR_Column_Model(){ColumnName = "PSTG_HDR_ID" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "UPDATE_COUNT" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "LAST_CHANGE_USER_ID" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "LAST_CHANGE_DATETIME" , Type ="DateTime" },
                new SUN_HDR_Column_Model(){ColumnName = "CREATED_BY" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "CREATED_DATETIME" , Type ="DateTime" },
                new SUN_HDR_Column_Model(){ColumnName = "CREATION_TYPE" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "DESCR" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "LAST_STATUS" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_TYPE" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_WRITE_TO_HOLD" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_ROUGH_BOOK" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_ALLOW_BAL_TRANS" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_SUSPENSE_ACNT" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_OTHER_ACNT" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_BAL_BY" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_DFLT_PERD" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_RPT_ERR_ONLY" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_SUPPRESS_SUB_MSG" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_RPT_FMT" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "JRNL_TYPE" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_RPT_ACNT" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_ORIG" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_REJECTED" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_BAL" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_REVERSALS" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_POSTED" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_SUBSTITUTED" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_PRINTED" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_LDG" , Type ="string" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_ALLOW_OVER_BDGT" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_ALLOW_SUSPNS_ACNT" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "CNT_ZERO_VAL_ENTRIES" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "JNL_NUM" , Type ="int" },
                new SUN_HDR_Column_Model(){ColumnName = "NUM_OF_IMBALANCES" , Type ="short" },
                new SUN_HDR_Column_Model(){ColumnName = "DR_AMT_POSTED" , Type ="decimal" },
                new SUN_HDR_Column_Model(){ColumnName = "CR_AMT_POSTED" , Type ="decimal" },
                new SUN_HDR_Column_Model(){ColumnName = "POST_TXN_REF_BAL" , Type ="short" }




            };

            sUN_Configuration_Model.DETAIL_Columns = new List<SUN_DETAIL_Column_Model>()
            {
                  new SUN_DETAIL_Column_Model() { ColumnName = "PSTG_HDR_ID",   Type = "int" },
            new SUN_DETAIL_Column_Model() { ColumnName = "LINE_NUM",   Type = "int" },
            new SUN_DETAIL_Column_Model() { ColumnName = "UPDATE_COUNT",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "LAST_CHANGE_USER_ID",    Type = "string"},
            new SUN_DETAIL_Column_Model() { ColumnName = "LAST_CHANGE_DATETIME",    Type = "string" },
            new SUN_DETAIL_Column_Model() { ColumnName = "ACNT_CODE",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "PERD",  Type = "int" },

            new SUN_DETAIL_Column_Model() { ColumnName = "JNL_NUM",    Type = "int"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "JNL_LINE_NUM",    Type = "int"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "JNL_TYPE",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "JNL_SRCE",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "TXN_REF",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "DESCR",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "AMT",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "DR_CR_IND",    Type = "string" },
            new SUN_DETAIL_Column_Model() { ColumnName = "CONV_CODE",    Type = "string"  },


            new SUN_DETAIL_Column_Model() { ColumnName = "CONV_RATE",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "TXN_AMT",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "TXN_DEC_PL",    Type = "string" },

            new SUN_DETAIL_Column_Model() { ColumnName = "BASE_RATE",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "BASE_OPR",    Type = "string" },

            new SUN_DETAIL_Column_Model() { ColumnName = "CONV_OPR",    Type = "string" },
            new SUN_DETAIL_Column_Model() { ColumnName = "RPT_RATE",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "RPT_OPR",    Type = "string" },
            new SUN_DETAIL_Column_Model() { ColumnName = "RPT_AMT",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "MEMO_AMT",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "ALLOCN_IND",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "ALLOCN_REF",    Type = "int"  },

            new SUN_DETAIL_Column_Model() { ColumnName = "ALLOCN_PERD",    Type = "int"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ALLOCN_IN_PROGRESS",    Type = "string"  },

            new SUN_DETAIL_Column_Model() { ColumnName = "ENTRY_PERD",    Type = "int"  },

            new SUN_DETAIL_Column_Model() { ColumnName = "ASSET_IND",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ASSET_CODE",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ASSET_SUB_CODE",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "CLEARDOWN",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "REVERSAL",    Type = "short" },






            new SUN_DETAIL_Column_Model() { ColumnName = "LOSS_GAIN",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "ROUGH_FLAG",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "IN_USE_FLAG",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "EXCL_BAL",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "ANL_CODE_T0",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ANL_CODE_T1",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ANL_CODE_T2",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ANL_CODE_T3",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ANL_CODE_T4",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ANL_CODE_T5",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ANL_CODE_T6",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ANL_CODE_T7",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ANL_CODE_T8",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "ANL_CODE_T9",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "HOLD_REF",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "HOLD_OPR_CODE",    Type = "string"  },

            new SUN_DETAIL_Column_Model() { ColumnName = "DOC_NUM_1",    Type = "int"  },

            new SUN_DETAIL_Column_Model() { ColumnName = "DOC_NUM_2",    Type = "int"  },

            new SUN_DETAIL_Column_Model() { ColumnName = "DOC_NUM_3",    Type = "int"  },

            new SUN_DETAIL_Column_Model() { ColumnName = "DOC_NUM_4",    Type = "int"  },

            new SUN_DETAIL_Column_Model() { ColumnName = "DISC_PCENT_1",    Type = "decimal",   },

            new SUN_DETAIL_Column_Model() { ColumnName = "DISC_PCENT_2",    Type = "decimal",   },

            new SUN_DETAIL_Column_Model() { ColumnName = "INTEREST_PCENT",    Type = "decimal",   },

            new SUN_DETAIL_Column_Model() { ColumnName = "LATE_PYMT_PCENT",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "PYMT_REF",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "BANK_CODE",    Type = "string"  },




            new SUN_DETAIL_Column_Model() { ColumnName = "SRCE_REF",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "MODULE_CODE",    Type = "string" },
            new SUN_DETAIL_Column_Model() { ColumnName = "STD_TEXT_CLASS_CODE",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "STD_TEXT_CODE",    Type = "string"  },


            new SUN_DETAIL_Column_Model() { ColumnName = "CV4_CONV_CODE",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "CV4_AMT",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "CV4_CONV_RATE",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "CV4_OPERATOR",    Type = "string" },
            new SUN_DETAIL_Column_Model() { ColumnName = "CV4_DP",    Type = "string" },





            new SUN_DETAIL_Column_Model() { ColumnName = "CV5_CONV_CODE",    Type = "string"  },
            new SUN_DETAIL_Column_Model() { ColumnName = "CV5_AMT",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "CV5_CONV_RATE",    Type = "decimal",   },
            new SUN_DETAIL_Column_Model() { ColumnName = "CV5_OPERATOR",    Type = "string" },
            new SUN_DETAIL_Column_Model() { ColumnName = "CV5_DP",    Type = "string" },



            new SUN_DETAIL_Column_Model() { ColumnName = "SPLIT_ORIG_LINE",    Type = "int"  },

            new SUN_DETAIL_Column_Model() { ColumnName = "BINDER_STATUS",    Type = "string" },
            new SUN_DETAIL_Column_Model() { ColumnName = "AGREED_STATUS",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "TRUE_RATED",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "SUPPLMNTRY_EXTSN",    Type = "short" },

            new SUN_DETAIL_Column_Model() { ColumnName = "APRVLS_EXTSN",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "MAN_PAY_OVER",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "AUTHORISTN_IN_PROGRESS",    Type = "short" },
            new SUN_DETAIL_Column_Model() { ColumnName = "SPLIT_IN_PROGRESS",    Type = "short" },

            new SUN_DETAIL_Column_Model() { ColumnName = "JNL_REVERSAL_TYPE",    Type = "short" },

            new SUN_DETAIL_Column_Model() { ColumnName = "SIGNING_DETAILS",    Type = "string"  }
            };

            if (_apiDbContext.SUN_HDR_Columns.Count() > 0)
            {
                _apiDbContext.SUN_HDR_Columns.RemoveRange(_apiDbContext.SUN_HDR_Columns);
            }

                if (_apiDbContext.SUN_DETAIL_Columns.Count() > 0)
                {
                    _apiDbContext.SUN_DETAIL_Columns.RemoveRange(_apiDbContext.SUN_DETAIL_Columns);

                }

                foreach (SUN_HDR_Column_Model c in sUN_Configuration_Model.HDR_Columns)
            {
                _apiDbContext.SUN_HDR_Columns.Add(c);
            }

            foreach (SUN_DETAIL_Column_Model c in sUN_Configuration_Model.DETAIL_Columns)
            {
                _apiDbContext.SUN_DETAIL_Columns.Add(c);
            }

            _apiDbContext.SUN_Configurations.Add(sUN_Configuration_Model);
           
            await _apiDbContext.SaveChangesAsync();



        }



    }
}
