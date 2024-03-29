﻿using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.HRMS.Mapper
{
    public class Map_HRMS_REPORT_SUN_DETAIL : IMap_HRMS_REPORT_SUN_DETAIL
    {
        public DataTable Map(DataTable hrmsReport, List<HRMS_REPORT_SUN_DETAIL_Model> hRMS_REPORT_SUN_DETAIL_s, int PSTG_HDR_ID)
        {
            DataTable sunDetailResult = new DataTable();

            foreach (HRMS_REPORT_SUN_DETAIL_Model c in hRMS_REPORT_SUN_DETAIL_s)
            {

                switch (c.ValueType.ToLower())
                {
                    case "int":
                        sunDetailResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(int)));
                        break;
                    case "string":
                        sunDetailResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(String)));
                        break;
                    case "decimal":
                        sunDetailResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(Decimal)));
                        break;
                    case "datetime":
                        sunDetailResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(DateTime)));
                        break;
                    case "double":
                        sunDetailResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(Double)));
                        break;
                    case "short":
                        sunDetailResult.Columns.Add(new DataColumn(columnName: c.SunAttribute, typeof(short)));
                        break;
                }
            }

            int LINE_NUM = 0;
            foreach (DataRow hrmsReportRow in hrmsReport.Rows)
            {
                DataRow dataRow = sunDetailResult.NewRow();

                LINE_NUM++;

                foreach (DataColumn dataColumn in sunDetailResult.Columns)
                {
                    string columnName = dataColumn.ColumnName;
                    HRMS_REPORT_SUN_DETAIL_Model hRMS_REPORT_SUN_DETAIL = hRMS_REPORT_SUN_DETAIL_s.Find(x => x.SunAttribute == columnName);
                    if (hRMS_REPORT_SUN_DETAIL.IsConst)
                    {
                        switch (hRMS_REPORT_SUN_DETAIL.ValueType.ToLower())
                        {
                            case "int":
                                dataRow[columnName] = hRMS_REPORT_SUN_DETAIL.IntValue;
                                break;
                            case "string":
                                dataRow[columnName] = hRMS_REPORT_SUN_DETAIL.StringValue;
                                break;
                            case "decimal":
                                dataRow[columnName] = hRMS_REPORT_SUN_DETAIL.DecimalValue;
                                break;
                            case "datetime":
                                dataRow[columnName] = hRMS_REPORT_SUN_DETAIL.DateTimeValue;
                                break;
                            case "double":
                                dataRow[columnName] = hRMS_REPORT_SUN_DETAIL.DoubleValue;
                                break;
                            case "short":
                                dataRow[columnName] = hRMS_REPORT_SUN_DETAIL.ShortValue;
                                break;
                        }

                    }
                    else if (hRMS_REPORT_SUN_DETAIL.AutoGenerated)
                    {
                        if (hRMS_REPORT_SUN_DETAIL.SunAttribute == "PSTG_HDR_ID")
                        {
                            dataRow[columnName] = PSTG_HDR_ID;
                        }
                        else if (hRMS_REPORT_SUN_DETAIL.SunAttribute == "LINE_NUM")
                        {
                            dataRow[columnName] = LINE_NUM;
                        }
                    }
                    else
                    {
                        dataRow[columnName] = hrmsReportRow[hRMS_REPORT_SUN_DETAIL.MapWithHRMS];
                    }
                }

                sunDetailResult.Rows.Add(dataRow);
            }

            return sunDetailResult;
        }
    }
}
