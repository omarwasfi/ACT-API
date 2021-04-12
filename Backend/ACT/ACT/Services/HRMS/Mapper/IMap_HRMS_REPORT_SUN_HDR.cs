using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.HRMS.Mapper
{
    public interface IMap_HRMS_REPORT_SUN_HDR
    {
        public DataTable Map(DataTable operaReport, List<HRMS_REPORT_SUN_HDR_Model> hRMS_REPORT_SUN_HDR_s);

    }
}
