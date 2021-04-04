using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.HRMS_REPORT
{
    public interface IHRMS_REPORT_Configuration
    {
        public Task UpdateColumns(List<HRMS_REPORT_Column_Model> hRMS_OPERA_Columns);

        public Task<List<HRMS_REPORT_Column_Model>> GetColumns();
    }
}
