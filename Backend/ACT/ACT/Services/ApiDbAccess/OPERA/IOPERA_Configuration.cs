using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.ApiDbAccess.OPERA
{
    public interface IOPERA_Configuration
    {
        public Task UpdateFilePath(string FilePath);

        public OPERA_Configuration_Model GetOperaConfiguration();

        public Task UpdateCycleTime(DateTime cycleTime);

    }
}
