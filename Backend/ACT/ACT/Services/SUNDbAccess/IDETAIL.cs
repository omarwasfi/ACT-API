using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.SUNDbAccess
{
    public interface IDETAIL
    {
        public void InsertToDetail(DataTable sun_DETAIL_Rows);

        public Task DeleteRecords(int hdrId);

    }
}
