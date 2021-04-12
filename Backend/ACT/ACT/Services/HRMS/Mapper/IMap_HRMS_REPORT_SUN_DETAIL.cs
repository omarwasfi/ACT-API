using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.HRMS.Mapper
{
    public interface IMap_HRMS_REPORT_SUN_DETAIL
    {
        public DataTable Map(DataTable hrmsReport, List<HRMS_REPORT_SUN_DETAIL_Model> hRMS_REPORT_SUN_DETAIL_s, int PSTG_HDR_ID);

    }
}
