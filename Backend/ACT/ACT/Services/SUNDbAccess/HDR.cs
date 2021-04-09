using ACT.DataModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.SUNDbAccess
{
    public class HDR : IHDR
    {
        SUN_Configuration_Model _sUN_Configuration;
        public HDR(SUN_Configuration_Model sUN_Configuration)
        {
            this._sUN_Configuration = sUN_Configuration;
        }
        public int InsertToHDR(DataTable hdrDataRow)
        {



            int Id = new int();
            string tablename = "PK1_PSTG_HDR";
            List<string> columnNames = new List<string>();
            List<object> values = new List<object>();

            foreach(DataColumn dataColumn in hdrDataRow.Columns)
            {
                if(dataColumn.ColumnName != "PSTG_HDR_ID")
                {
                    columnNames.Add(dataColumn.ColumnName);

                    object v = hdrDataRow.Rows[0][dataColumn];

                    if (v.GetType() == typeof(String))
                    {
                        string currentValue = (string)v;
                        if (currentValue.Contains("GETDATE()"))
                        {
                            values.Add(currentValue);
                        }
                        else
                        {
                            currentValue = "'" + currentValue + "'";
                            values.Add(currentValue);
                        }

                    }
                    else
                    {
                        values.Add(v);
                    }
                }
            }

           
            string InsertQuery = string.Format("insert into " + tablename + " ({0}) VALUES ({1}) ; Select SCOPE_IDENTITY() AS [SCOPE_IDENTITY] SELECT @@IDENTITY AS[@@IDENTITY];", string.Join(",", columnNames), string.Join(",", values));
            
            try
            {
                using (SqlConnection con = new SqlConnection(_sUN_Configuration.ConnectionsString))
                {
                    using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                    {

                        con.Open();
                        Id = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.Error(ex.ToString());
            }
            return Id;
        }
    }
}
