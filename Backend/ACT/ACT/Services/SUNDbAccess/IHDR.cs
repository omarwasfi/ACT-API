using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.SUNDbAccess
{
    public interface IHDR
    {
        
        public int InsertToHDR(DataTable hdrDataRow);

        public Task DeleteRecords(int hdrId);

    }
}
