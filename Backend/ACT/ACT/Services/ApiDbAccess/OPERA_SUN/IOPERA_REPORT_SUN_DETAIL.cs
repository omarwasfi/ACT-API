using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.OPERA_SUN
{
    public interface IOPERA_REPORT_SUN_DETAIL
    {
        public List<OPERA_REPORT_SUN_DETAIL_Model> Get_OPERA_REPORT_SUN_DETAIL_s();

        public Task Update_OPERA_REPORT_SUN_DETAIL(List<OPERA_REPORT_SUN_DETAIL_Model> oPERA_REPORT_SUN_DETAIL_s);

        public Task InsertRow(OPERA_REPORT_SUN_DETAIL_Model oPERA_REPORT_SUN_DETAIL);

        public Task UpdateRow(OPERA_REPORT_SUN_DETAIL_Model oPERA_REPORT_SUN_DETAIL);
        public Task DeleteRow(int Id);

        public Task LoadDefaults();
    }
}
