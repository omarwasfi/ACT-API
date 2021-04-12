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
    public class DETAIL : IDETAIL
    {
        SUN_Configuration_Model _sUN_Configuration;
        public DETAIL(SUN_Configuration_Model sUN_Configuration)
        {
            this._sUN_Configuration = sUN_Configuration;
        }

        public void InsertToDetail(DataTable sun_DETAIL_Rows)
        {
            int Id = new int();
            string tablename = "PK1_PSTG_DETAIL";
            List<string> columnNames = new List<string>();
            List<string> multiInsertion = new List<string>();

            //string nInsert = string.Join(",", values);


            foreach (DataRow dataRow in sun_DETAIL_Rows.Rows)
            {
                List<object> values = new List<object>();

                foreach (DataColumn dataColumn in sun_DETAIL_Rows.Columns)
                {

                    if(dataRow == sun_DETAIL_Rows.Rows[0]) { columnNames.Add(dataColumn.ColumnName); }
                    

                    object v = dataRow[dataColumn];

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

                string rowInsertion = string.Format(string.Join(",", values));
                multiInsertion.Add(rowInsertion);
            }

           



            string InsertQuery = string.Format("insert into " + tablename + " ({0}) VALUES ({1})  ;", string.Join(",", columnNames), string.Join("),(",multiInsertion));

            using (SqlConnection con = new SqlConnection(_sUN_Configuration.ConnectionsString))
            {
                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {

                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();
                }

            }
        }

        public async Task DeleteRecords(int hdrId)
        {
            string InsertQuery = "Delete from PK1_PSTG_DETAIL where PSTG_HDR_ID = " + hdrId + ";";
            try
            {
                using (SqlConnection con = new SqlConnection(_sUN_Configuration.ConnectionsString))
                {
                    using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                    {

                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                    }

                }
                Log.Information("All PK1_PSTG_DETAIL records with the PSTG_HDR_ID : " + hdrId + " Has been deleted");

            }
            catch (SqlException ex)
            {
                Log.Error(ex.ToString());
            }
        }
    }
}
