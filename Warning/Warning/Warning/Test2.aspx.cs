using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace Warning
{
    public partial class Test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            //Upload and save the file
            string excelPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(excelPath);

            string conString = string.Empty;
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07 or higher
                    conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                    break;

            }
            conString = string.Format(conString, excelPath);
            using (OleDbConnection excel_con = new OleDbConnection(conString))
            {
                excel_con.Open();
                string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                DataTable dtExcelData = new DataTable();
                int i = 0;
                int ii = 1;
                //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                dtExcelData.Columns.AddRange(new DataColumn[13] {
                new DataColumn("i", typeof(string)),
                new DataColumn("ii", typeof(string)),
                new DataColumn("รหัส", typeof(string)),
                new DataColumn("รหัสแผนก", typeof(string)),
                new DataColumn("ชื่อพนักงาน", typeof(string)),
                new DataColumn("วันที่", typeof(string)),
                new DataColumn("รหัสกะ", typeof(string)),
                new DataColumn("ชื่อกะ", typeof(string)),
                new DataColumn("รายละเอียดเวลารูดบัตร", typeof(string)),
                new DataColumn("ประเภทเงินหัก", typeof(string)),
                new DataColumn("ประเภท", typeof(string)),
                new DataColumn("จำนวน", typeof(string)),
                new DataColumn("หน่วยนาที", typeof(string)),


                });

                using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                {
                    oda.Fill(dtExcelData);
                }
                excel_con.Close();

                string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.tblPersons";

                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("i", "W_ID");
                        sqlBulkCopy.ColumnMappings.Add("ii", "W_DateNow");
                        sqlBulkCopy.ColumnMappings.Add("รหัส", "W_IDUser");
                        sqlBulkCopy.ColumnMappings.Add("รหัสแผนก", "W_Department");
                        sqlBulkCopy.ColumnMappings.Add("วันที่", "W_Date");
                        sqlBulkCopy.ColumnMappings.Add("ประเภท", "W_Type");
                        sqlBulkCopy.ColumnMappings.Add("จำนวน", "W_Num");
                        sqlBulkCopy.ColumnMappings.Add("หน่วย", "W_Unit");
                        sqlBulkCopy.ColumnMappings.Add("ชื่อพนักงาน", "W_Name");
                        sqlBulkCopy.ColumnMappings.Add("รหัสแผนก", "W_IDDepartment");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dtExcelData);
                        con.Close();
                    }
                }
            }
        }
    }
}