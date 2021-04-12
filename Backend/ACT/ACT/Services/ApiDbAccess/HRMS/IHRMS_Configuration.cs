using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.HRMS
{
    public interface IHRMS_Configuration
    {
        /// <summary>
        /// HRMLS database connection string
        /// </summary>
        /// <param name="ConnectionString"></param>
        public Task UpdateConnectionString(string ConnectionString);

        public HRMS_Configuration_Model GetHRMSConfiguration();

        public Task UpdateCycleTime(DateTime cycleTime);

        public Task LoadDefault();


    }
}
