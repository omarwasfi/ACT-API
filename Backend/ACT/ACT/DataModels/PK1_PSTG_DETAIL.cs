using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.DataModels
{
    public class PK1_PSTG_DETAIL
    {
        public int PSTG_HDR_ID { get; set; }

        public int LINE_NUM { get; set; }

        public int UPDATE_COUNT { get; set; }

        public string LAST_CHANGE_USER_ID { get; set; }

        public DateTime LAST_CHANGE_DATETIME { get; set; }

        public string ACNT_CODE { get; set; }

        public int PERD { get; set; }

        public DateTime TXN_DATETIME { get; set; }

        public int JNL_NUM { get; set; }

    }
}
