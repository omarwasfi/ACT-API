﻿using ACT.DataModels;
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
       
        public DataRow Map(DataTable operaReport, List<OPERA_REPORT_SUN_HDR_Model> oPERA_REPORT_SUN_HDR_s)
        {

            DataTable sunHDRResult = new DataTable();

            foreach (OPERA_REPORT_SUN_HDR_Model c in oPERA_REPORT_SUN_HDR_s)
            {

                sunHDRResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, dataType: System.Type.GetType(c.ValueType, true, true)));

            }

            // get fitst row of the operaReport
            // Create the HDR Row

            DataRow firstOperaRow = operaReport.Rows[1];

            DataRow dataRow = sunHDRResult.NewRow();

            foreach (DataColumn dataColumn in sunHDRResult.Columns)
            {
                string columnName = dataColumn.ColumnName;
                OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR = oPERA_REPORT_SUN_HDR_s.Find(x => x.SunAttribute == columnName);
                if (oPERA_REPORT_SUN_HDR.IsConst)
                {
                    // TODO - Complete all the cases
                    if (oPERA_REPORT_SUN_HDR.ValueType == "string")
                    {
                        dataRow[columnName] = oPERA_REPORT_SUN_HDR.StringValue;

                    }
                    else if (oPERA_REPORT_SUN_HDR.ValueType == "int")
                    {
                        dataRow[columnName] = oPERA_REPORT_SUN_HDR.IntValue;
                    }
                }
                else if(oPERA_REPORT_SUN_HDR.AutoGenerated)
                {

                }
                else
                {
                    dataRow[columnName] = firstOperaRow[oPERA_REPORT_SUN_HDR.MapWithOPERA];
                }
            }



            return dataRow;

        }

       
    }
}
