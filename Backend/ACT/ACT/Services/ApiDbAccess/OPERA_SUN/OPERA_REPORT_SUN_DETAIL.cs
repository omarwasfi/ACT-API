using ACT.DataModels;
using ACT.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.OPERA_SUN
{
    public class OPERA_REPORT_SUN_DETAIL : IOPERA_REPORT_SUN_DETAIL
    {
        private ApiDbContext _apiDbContext;

        public OPERA_REPORT_SUN_DETAIL(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext;
        }

        public List<OPERA_REPORT_SUN_DETAIL_Model> GetOPERA_REPORT_SUN_DETAIL_s()
        {
            return _apiDbContext.OPERA_REPORT_SUN_DETAILS.ToList();

        }


    }
}
