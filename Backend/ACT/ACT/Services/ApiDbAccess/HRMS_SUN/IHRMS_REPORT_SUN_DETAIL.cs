using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.HRMS_SUN
{
    public interface IHRMS_REPORT_SUN_DETAIL
    {
        public List<HRMS_REPORT_SUN_DETAIL_Model> Get_HRMS_REPORT_SUN_DETAIL_s();

        public Task Update_HRMS_REPORT_SUN_DETAIL(List<HRMS_REPORT_SUN_DETAIL_Model> hRMS_REPORT_SUN_DETAIL_s);

        public Task InsertRow(HRMS_REPORT_SUN_DETAIL_Model HRMS_REPORT_SUN_DETAIL);

        public Task UpdateRow(HRMS_REPORT_SUN_DETAIL_Model HRMS_REPORT_SUN_DETAIL);
        public Task DeleteRow(int Id);

        public Task LoadDefaults();
    }
}
