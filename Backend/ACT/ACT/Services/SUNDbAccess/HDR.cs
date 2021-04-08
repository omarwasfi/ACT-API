using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.SUNDbAccess
{
    public class HDR : IHDR
    {
        SUN_Configuration_Model _sUN_Configuration;
        public HDR(SUN_Configuration_Model sUN_Configuration)
        {
            this._sUN_Configuration = sUN_Configuration;
        }
        public int InsertToHDR(DataTable hdrDataRow)
        {

            // TODO - Insert the row to the databse and return the ID

            return 0;            
        }
    }
}
