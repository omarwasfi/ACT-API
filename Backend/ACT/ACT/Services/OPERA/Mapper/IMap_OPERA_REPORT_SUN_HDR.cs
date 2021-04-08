using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.OPERA.Mapper
{
    public interface IMap_OPERA_REPORT_SUN_HDR
    {
        public DataTable Map(DataTable operaReport,List<OPERA_REPORT_SUN_HDR_Model> oPERA_REPORT_SUN_HDR_s);
    }
}
