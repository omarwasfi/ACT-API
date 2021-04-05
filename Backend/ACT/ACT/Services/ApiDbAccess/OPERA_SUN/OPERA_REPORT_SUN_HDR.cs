using ACT.DataModels;
using ACT.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.OPERA_SUN
{
    public class OPERA_REPORT_SUN_HDR : IOPERA_REPORT_SUN_HDR
    {
        private ApiDbContext _apiDbContext;

        public OPERA_REPORT_SUN_HDR(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }
        public List<OPERA_REPORT_SUN_HDR_Model> GetOPERA_REPORT_SUN_HDR_s()
        {
            return _apiDbContext.OPERA_REPORT_SUN_HDRS.ToList();
        }
    }
}
