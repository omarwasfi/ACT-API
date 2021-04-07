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
        public List<OPERA_REPORT_SUN_HDR_Model> Get_OPERA_REPORT_SUN_HDR_s()
        {
            return _apiDbContext.OPERA_REPORT_SUN_HDRS.ToList();
        }

        public async Task Update_OPERA_REPORT_SUN_HDR(List<OPERA_REPORT_SUN_HDR_Model> oPERA_REPORT_SUN_HDR_s)
        {
            if(_apiDbContext.OPERA_REPORT_SUN_HDRS.Count() > 0)
            {
                _apiDbContext.OPERA_REPORT_SUN_HDRS.RemoveRange(_apiDbContext.OPERA_REPORT_SUN_HDRS);
            }

            foreach (OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR_Model in oPERA_REPORT_SUN_HDR_s)
            {
                _apiDbContext.OPERA_REPORT_SUN_HDRS.Add(oPERA_REPORT_SUN_HDR_Model);
            }

            await _apiDbContext.SaveChangesAsync();
        }


    }
}
