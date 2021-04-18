using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.HRMS_SUN
{
    public interface IHRMS_REPORT_SUN_HDR
    {
        public List<HRMS_REPORT_SUN_HDR_Model> Get_HRMS_REPORT_SUN_HDR_s();

        public Task Update_HRMS_REPORT_SUN_HDR(List<HRMS_REPORT_SUN_HDR_Model> hRMS_REPORT_SUN_HDR_s);

        public Task InsertRow(HRMS_REPORT_SUN_HDR_Model HRMS_REPORT_SUN_HDR);

        public Task UpdateRow(HRMS_REPORT_SUN_HDR_Model HRMS_REPORT_SUN_HDR);
        public Task DeleteRow(int Id);

        public Task LoadDefaults();

    }
}
