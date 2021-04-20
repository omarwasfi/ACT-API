using ACT.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.Services.HRMS.Reader
{
    public class Read_HRMS_REPORT : IRead_HRMS_REPORT
    {
        public DataTable ReadHRMS(HRMS_Configuration_Model hRMS_Configuration)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            string query = "SELECT * FROM JV_Report_Details_Tbl WHERE The_Year= 2015 and The_Month = 4 and User_ID = 1 ;";
            using (SqlConnection con = new SqlConnection(hRMS_Configuration.ConnectionsString))
            {
                using (var schemaCommand = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter Adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    Adapter.Fill(dt);
                    con.Close();
                    return dt;
                }
            }
        }
    }
}
