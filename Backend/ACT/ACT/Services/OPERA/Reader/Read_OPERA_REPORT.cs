using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
                switch (o.Type.ToLower())
                {
                    case "int":
                        OperaTable.Columns.Add(new DataColumn(columnName: o.ColumnName, dataType: typeof(int)));
                        break;
                    case "string":
                        OperaTable.Columns.Add(new DataColumn(columnName: o.ColumnName, dataType: typeof(String) ));
                        break;
                    case "decimal":
                        OperaTable.Columns.Add(new DataColumn(columnName: o.ColumnName, dataType: typeof(Decimal)));
                        break;
                    case "datetime":
                        OperaTable.Columns.Add(new DataColumn(columnName: o.ColumnName, dataType: typeof(DateTime)));
                        break;
                    case "double":
                        OperaTable.Columns.Add(new DataColumn(columnName: o.ColumnName, dataType: typeof(Double)));
                        break;
                    case "short":
                        OperaTable.Columns.Add(new DataColumn(columnName: o.ColumnName, dataType: typeof(short)));
                        break;
                }
            }

            foreach (string line in readLines(oPERA_Configuration.FilePath, oPERA_Configuration.NumberOfLinesToBeIgnoredAtTheBeginning,oPERA_Configuration.NumberOfLinesToBeIgnoredAtTheEnd))
            {
                DataRow row = OperaTable.NewRow();

                foreach (DataColumn column in OperaTable.Columns)
                {
                    int startPOS = oPERA_Configuration.Columns.Find(x => x.ColumnName == column.ColumnName).StartPOS;
                    int length =  oPERA_Configuration.Columns.Find(x => x.ColumnName == column.ColumnName).EndPOS - startPOS;

                    row[column.ColumnName] = line.Substring(startPOS - 1, length );
                }

                OperaTable.Rows.Add(row);
            }

            return OperaTable;
        }

        private List<string> readLines(string filePath, int numberOfLinesToBeIgnoredAtTheBeginning, int numberOfLinesToBeIgnoredAtTheEnd)
        {
            IEnumerable<string> lines = System.IO.File.ReadLines(filePath, Encoding.UTF8);
            List<string> LinesRead = lines.ToList<string>();
            int count = 0;
            for (int i = 0; i < numberOfLinesToBeIgnoredAtTheBeginning; i++)
            {
                LinesRead.RemoveAt(i - count);
                count++;
            }
            for (int i = 0; i < numberOfLinesToBeIgnoredAtTheEnd; i++)
            {
                LinesRead.RemoveAt(LinesRead.Count - 1);
            }

            return LinesRead;
        }
    }
}
