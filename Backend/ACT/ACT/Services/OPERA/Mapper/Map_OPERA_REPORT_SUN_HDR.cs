using ACT.DataModels;
using ACT.Services.OPERA.Reader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.OPERA.Mapper
{
    public class Map_OPERA_REPORT_SUN_HDR : IMap_OPERA_REPORT_SUN_HDR
    {
        private IRead_OPERA_REPORT _operaReportReader;
        public Map_OPERA_REPORT_SUN_HDR(IRead_OPERA_REPORT operaReportReader)
        {
            this._operaReportReader = operaReportReader;
        }
        public DataTable Map(List<OPERA_REPORT_SUN_HDR_Model> oPERA_REPORT_SUN_HDR_s, OPERA_Configuration_Model oPERA_Configuration, SUN_Configuration_Model sUN_Configuration)
        {

            DataTable operaReport = _operaReportReader.ReadOpera(oPERA_Configuration);
            DataTable sunResult = new DataTable();

            foreach (OPERA_REPORT_SUN_HDR_Model c in oPERA_REPORT_SUN_HDR_s)
            {

                sunResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, dataType: System.Type.GetType(c.ValueType, true, true)));

            }

            foreach(DataRow d in operaReport.Rows)
            {
                DataRow dataRow = operaReport.NewRow();
                foreach(DataColumn dataColumn in sunResult.Columns)
                {
                    string columnName = dataColumn.ColumnName;
                    OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR = oPERA_REPORT_SUN_HDR_s.Find(x => x.SunAttribute == columnName);
                    if (oPERA_REPORT_SUN_HDR.IsConst)
                    {
                        if (oPERA_REPORT_SUN_HDR.ValueType == "string")
                        {
                            dataRow[columnName] = oPERA_REPORT_SUN_HDR.StringValue;

                        }
                        else if (oPERA_REPORT_SUN_HDR.ValueType == "int")
                        {
                            dataRow[columnName] = oPERA_REPORT_SUN_HDR.IntValue;
                        }
                    }
                    else 
                    {
                        dataRow[columnName] = d[oPERA_REPORT_SUN_HDR.MapWithOPERA];
                    }
                }
            }

            return sunResult;

        }

       
    }
}
