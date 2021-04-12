using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.HRMS.Reader
{
    public interface IRead_HRMS_REPORT
    {
        public DataTable ReadHRMS(HRMS_Configuration_Model hRMS_Configuration);

    }
}
