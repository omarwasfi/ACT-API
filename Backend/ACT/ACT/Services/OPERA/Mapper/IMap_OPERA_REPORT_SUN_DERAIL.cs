using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.OPERA.Mapper
{
    public interface IMap_OPERA_REPORT_SUN_DERAIL
    {
        public DataTable Map(DataTable operaReport, List<OPERA_REPORT_SUN_DETAIL_Model> oPERA_REPORT_SUN_DETAIL_s, int PSTG_HDR_ID);

    }
}
