using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.OPERA_SUN
{
    public interface IOPERA_REPORT_SUN_HDR
    {
        public List<OPERA_REPORT_SUN_HDR_Model> Get_OPERA_REPORT_SUN_HDR_s();

        public Task Update_OPERA_REPORT_SUN_HDR(List<OPERA_REPORT_SUN_HDR_Model> oPERA_REPORT_SUN_HDR_s);

        public Task InsertRow(OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR);

        public Task UpdateRow(OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR);
        public Task DeleteRow(int Id);


        public Task LoadDefaults();

    }
}
