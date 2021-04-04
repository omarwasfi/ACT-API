using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.OPERA_REPORT
{
    public interface IOPERA_REPORT_Configuration
    {
        public Task UpdateColumns(List<OPERA_REPORT_Column_Model> oPERA_DETAIL_Columns);

        public Task<List<OPERA_REPORT_Column_Model>> GetColumns();
    }
}
