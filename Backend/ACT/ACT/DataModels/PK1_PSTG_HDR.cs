using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.DataModels
{
    public class PK1_PSTG_HDR
    {
        public int PSTG_HDR_ID { get; set; }

        public int UPDATE_COUNT { get; set; }

        public string LAST_CHANGE_USER_ID { get; set; }

        public DateTime LAST_CHANGE_DATETIME { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime CREATED_DATETIME { get; set; }

        public string CREATION_TYPE { get; set; }

        public string DESCR { get; set; }

        public int LAST_STATUS { get; set; }

        public int POST_TYPE { get; set; }

        public int POST_WRITE_TO_HOLD { get; set; }

        public int POST_ROUGH_BOOK { get; set; }

        public int POST_ALLOW_BAL_TRANS { get; set; }

        public string POST_SUSPENSE_ACNT { get; set; }

        public string POST_OTHER_ACNT { get; set; }

        public string POST_BAL_BY { get; set; }

        public int POST_DFLT_PERD { get; set; }

        public int POST_RPT_ERR_ONLY { get; set; }

        public int POST_SUPPRESS_SUB_MSG { get; set; }

        public string POST_RPT_FMT { get; set; }

        public string JRNL_TYPE { get; set; }

        public string POST_RPT_ACNT { get; set; }

        public int CNT_ORIG { get; set; }

        public int CNT_REJECTED { get; set; }

        public int CNT_BAL { get; set; }

        public int CNT_REVERSALS { get; set; }

        public int CNT_POSTED { get; set; }

        public int CNT_SUBSTITUTED { get; set; }

        public int CNT_PRINTED { get; set; }

        public string POST_LDG { get; set; }

        public int POST_ALLOW_OVER_BDGT { get; set; }

        public int POST_ALLOW_SUSPNS_ACNT { get; set; }

        public int CNT_ZERO_VAL_ENTRIES { get; set; }

        public int JNL_NUM { get; set; }

        public int NUM_OF_IMBALANCES { get; set; }

        public decimal DR_AMT_POSTED { get; set; }

        public decimal CR_AMT_POSTED { get; set; }

        public int POST_TXN_REF_BAL { get; set; }

    }
}
