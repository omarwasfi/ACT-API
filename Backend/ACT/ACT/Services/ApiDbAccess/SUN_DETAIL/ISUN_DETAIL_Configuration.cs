using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.SUN_DETAIL
{
    public interface ISUN_DETAIL_Configuration
    {
        public Task UpdateColumns(List<SUN_DETAIL_Column_Model> sUN_DETAIL_Columns);

        public Task<List<SUN_DETAIL_Column_Model>> GetColumns();
    }
}
