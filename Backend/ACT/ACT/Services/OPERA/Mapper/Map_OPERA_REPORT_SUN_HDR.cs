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
       
        public DataTable Map(DataTable operaReport, List<OPERA_REPORT_SUN_HDR_Model> oPERA_REPORT_SUN_HDR_s)
        {

            DataTable sunHDRResult = new DataTable();

            foreach (OPERA_REPORT_SUN_HDR_Model c in oPERA_REPORT_SUN_HDR_s)
            {
                switch (c.ValueType.ToLower())
                {
                    case "int":
                        sunHDRResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(int)));
                        break;
                    case "string":
                        sunHDRResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(String)));
                        break;
                    case "decimal":
                        sunHDRResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(Decimal)));
                        break;
                    case "datetime":
                        sunHDRResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(DateTime)));
                        break;
                    case "double":
                        sunHDRResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(Double)));
                        break;
                    case "short":
                        sunHDRResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(short)));
                        break;
                }

            }


            DataRow firstOperaRow = operaReport.Rows[0];

            DataRow dataRow = sunHDRResult.NewRow();

            foreach (DataColumn dataColumn in sunHDRResult.Columns)
            {
                string columnName = dataColumn.ColumnName;
                OPERA_REPORT_SUN_HDR_Model oPERA_REPORT_SUN_HDR = oPERA_REPORT_SUN_HDR_s.Find(x => x.SunAttribute == columnName);
                if (oPERA_REPORT_SUN_HDR.IsConst)
                {
                    switch (oPERA_REPORT_SUN_HDR.ValueType.ToLower())
                    {
                        case "int":
                            dataRow[columnName] = oPERA_REPORT_SUN_HDR.IntValue;
                            break;
                        case "string":
                            dataRow[columnName] = oPERA_REPORT_SUN_HDR.StringValue;
                            break;
                        case "decimal":
                            dataRow[columnName] = oPERA_REPORT_SUN_HDR.DecimalValue;
                            break;
                        case "datetime":
                            dataRow[columnName] = oPERA_REPORT_SUN_HDR.DateTimeValue;
                            break;
                        case "double":
                            dataRow[columnName] = oPERA_REPORT_SUN_HDR.DoubleValue;
                            break;
                        case "short":
                            dataRow[columnName] = oPERA_REPORT_SUN_HDR.ShortValue;
                            break;
                    }
                 
                }
                else if(oPERA_REPORT_SUN_HDR.AutoGenerated)
                {
                    //dataRow[columnName] = DBNull;
                }
                else
                {
                    dataRow[columnName] = firstOperaRow[oPERA_REPORT_SUN_HDR.MapWithOPERA];
                }

            }

            sunHDRResult.Rows.Add(dataRow);


            return sunHDRResult;

        }

       
    }
}
