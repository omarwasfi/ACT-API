using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.OPERA.Reader
{
    public interface IRead_OPERA_REPORT
    {
        public DataTable ReadOpera(OPERA_Configuration_Model oPERA_Configuration);
    }
}
