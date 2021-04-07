using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.SUN
{
    public interface ISUN_Configuration
    {
        /// <summary>
        /// Sun database connection string
        /// </summary>
        /// <param name="ConnectionString"></param>
        public Task UpdateConnectionString(string ConnectionString);

        public SUN_Configuration_Model GetSunConfiguration();

        public Task LoadDefault();

    }
}
