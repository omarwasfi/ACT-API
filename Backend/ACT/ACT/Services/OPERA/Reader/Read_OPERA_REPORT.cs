using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.OPERA.Reader
{
    public class Read_OPERA_REPORT : IRead_OPERA_REPORT
    {
        public DataTable ReadOpera(OPERA_Configuration_Model oPERA_Configuration)
        {
            DataTable OperaTable = new DataTable(tableName: "OperaTable");
            // Read the textFile
            foreach (var o in oPERA_Configuration.Columns)
            {
                OperaTable.Columns.Add(new DataColumn(columnName: o.ColumnName, dataType: System.Type.GetType(o.Type, true, true)));
            }

            foreach (string line in readLines(oPERA_Configuration.FilePath, oPERA_Configuration.NumberOfLinesToIgnore))
            {
                DataRow row = OperaTable.NewRow();

                foreach (DataColumn column in OperaTable.Columns)
                {
                    int startPOS = oPERA_Configuration.Columns.Find(x => x.ColumnName == column.ColumnName).StartPOS;
                    int endPOS = oPERA_Configuration.Columns.Find(x => x.ColumnName == column.ColumnName).EndPOS;

                    row[column.ColumnName] = line.Substring(startPOS - 1, endPOS - 1);
                }
            }

            return OperaTable;
        }

        private List<string> readLines(string filePath, int numberOfLinesToIgnore)
        {
            // TODO - add code to read txt file lines and ignore fisrt {numberOfLinesToIgnore}
            throw new NotImplementedException();
        }
    }
}
