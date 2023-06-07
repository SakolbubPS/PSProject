using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Warning
{
    public partial class WarningUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void ASPxFormLayout1_E3_Click(object sender, EventArgs e)
        {
            Response.Redirect("PSWarning.aspx");
        }

        protected void ASPxFormLayout1_E2_Click(object sender, EventArgs e)
        {
            if (ASPxGridLookup1.Text != "")
            {
                ASPxGridView1.Visible = true;
            }
            else
            {
                ASPxGridView1.Visible = false;
            }

        }
        private void ShowData()
        {
            DataTable TD = new DataTable();
            string lvSQL = "SELECT * FROM PS_warning WHERE W_UName = '" + ASPxGridLookup1.Text + "' ";
            TD = GsysSQL.fncGetQueryData(lvSQL, TD);
            DataTable Eevent = new DataTable();
            Eevent.Columns.Add("IDUser");
            Eevent.Columns.Add("IDDepartment");
            Eevent.Columns.Add("UName");
            Eevent.Columns.Add("Date");
            Eevent.Columns.Add("HOUR");
            Eevent.Columns.Add("MINUTE");

            int lvSecurities = TD.Rows.Count;
            for (int i = 0; i < lvSecurities; i++)
            {
                string IDUser = TD.Rows[i]["W_IDUser"].ToString();
                string IDDepartment = TD.Rows[i]["W_IDDepartment"].ToString();
                string UName = TD.Rows[i]["W_UName"].ToString();
                string Date = TD.Rows[i]["W_Date"].ToString();
                string HOUR = TD.Rows[i]["W_HOUR"].ToString();
                string MINUTE = TD.Rows[i]["W_MINUTE"].ToString();

                Eevent.Rows.Add(new object[] { IDUser, IDDepartment, UName, Date, HOUR, MINUTE });

                // เพิ่มโค้ดเพื่ออัปเดตหรือแก้ไขข้อมูลในฐานข้อมูล
                string consString = ConfigurationManager.ConnectionStrings["MysqlPSConnection"].ConnectionString;
                using (MySqlConnection connection = new MySqlConnection(consString))
                {
                    connection.Open();

                    string sql = "UPDATE PS_warning SET W_IDUser = @IDUser, W_IDDepartment = @IDDepartment, W_Date = @Date, W_HOUR = @HOUR, W_MINUTE = @MINUTE WHERE W_UName = @UName";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@IDUser", IDUser);
                    command.Parameters.AddWithValue("@IDDepartment", IDDepartment);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@HOUR", HOUR);
                    command.Parameters.AddWithValue("@MINUTE", MINUTE);
                    command.Parameters.AddWithValue("@UName", UName);

                    command.ExecuteNonQuery();
                }
            }

            ASPxGridView1.DataSource = Eevent;
            ASPxGridView1.DataBind();
        }

        //private void ShowData()
        //{
        //    DataTable TD = new DataTable();
        //    string lvSQL = "SELECT * FROM PS_warning WHERE W_UName = '" + ASPxGridLookup1.Text + "' ";//เลือกใช้จากชื่อพนักงาน
        //    TD = GsysSQL.fncGetQueryData(lvSQL, TD);
        //    DataTable Eevent = new DataTable();
        //    Eevent.Columns.Add("IDUser");//รหัสพนักงาน
        //    Eevent.Columns.Add("IDDepartment");//รหัสแผนก
        //    Eevent.Columns.Add("UName");//ชื่อพนักงาน
        //    Eevent.Columns.Add("Date");//วันที่สาย
        //    Eevent.Columns.Add("HOUR");//ชม.สาย
        //    Eevent.Columns.Add("MINUTE");//นาทีที่สาย

        //    int lvSecurities = TD.Rows.Count;
        //    for (int i = 0; i < lvSecurities; i++)
        //    {
        //        string IDUser = TD.Rows[i]["W_IDUser"].ToString();
        //        string IDDepartment = TD.Rows[i]["W_IDDepartment"].ToString();
        //        string UName = TD.Rows[i]["W_UName"].ToString();
        //        string Date = TD.Rows[i]["W_Date"].ToString();
        //        string HOUR = TD.Rows[i]["W_HOUR"].ToString();
        //        string MINUTE = TD.Rows[i]["W_MINUTE"].ToString();

        //        Eevent.Rows.Add(new object[] { IDUser, IDDepartment, UName, Date, HOUR, MINUTE });
        //    }
        //    ASPxGridView1.DataSource = Eevent;
        //    ASPxGridView1.DataBind();
        //}

        protected void ASPxGridLookup1_ButtonClick(object source, DevExpress.Web.ButtonEditClickEventArgs e)
        {

        }

        protected void ASPxGridLookup1_TextChanged(object sender, EventArgs e)
        {
            //var lvSQL = "Select";
        }




    }
}