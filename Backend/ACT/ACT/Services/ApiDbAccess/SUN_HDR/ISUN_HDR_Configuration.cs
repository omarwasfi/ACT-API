using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.SUN_HDR
{
    public interface ISUN_HDR_Configuration
    {

        public Task UpdateColumns(List<SUN_HDR_Column_Model> sUN_HDR_Columns);

        public Task<List<SUN_HDR_Column_Model>> GetColumns();


    }
}
