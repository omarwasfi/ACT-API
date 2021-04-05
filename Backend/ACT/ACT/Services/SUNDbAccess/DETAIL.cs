using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.SUNDbAccess
{
    public class DETAIL : IDETAIL
    {
        SUN_Configuration_Model _sUN_Configuration;
        public DETAIL(SUN_Configuration_Model sUN_Configuration)
        {
            this._sUN_Configuration = sUN_Configuration;
        }

        public void InsertToDetail(DataTable sun_DETAIL_Rows)
        {
            string connectionString = _sUN_Configuration.ConnectionsString;

            // TODO - Insert the rows to the database

            throw new NotImplementedException();
        }
    }
}
