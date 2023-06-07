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
    public partial class WarningSearch : System.Web.UI.Page
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
        //private void ASPxGridLookup()
        //{
        //   var Data  = ASPxGridLookup1.ToInvariantString();
        //}
        private void ShowData()
        {
            DataTable TD = new DataTable();
            string lvSQL = "SELECT * FROM showwaring WHERE UsreID = '" + ASPxGridLookup1.Text + "' ";
            TD = GsysSQL.fncGetQueryData(lvSQL, TD);
            DataTable Eevent = new DataTable();
            Eevent.Columns.Add("L_UsreID");
            Eevent.Columns.Add("L_UsreName");
            Eevent.Columns.Add("L_Department");
            Eevent.Columns.Add("L_Date_Blame");
            Eevent.Columns.Add("L_Quantity");
            Eevent.Columns.Add("L_Blame");
            Eevent.Columns.Add("L_QuantityNum");
            int lvSecurities = TD.Rows.Count;
            for (int i = 0; i < lvSecurities; i++)
            {
                string L_UsreID = TD.Rows[i]["UsreID"].ToString();
                string L_UsreName = TD.Rows[i]["UsreName"].ToString();
                string L_Department = TD.Rows[i]["Department"].ToString();
                string L_Date_Blame = TD.Rows[i]["Date_Blame"].ToString();
                string L_Quantity = TD.Rows[i]["Quantity"].ToString();
                string L_Blame = TD.Rows[i]["Blame"].ToString();
                string L_QuantityNum = TD.Rows[i]["QuantityNum"].ToString();
                Eevent.Rows.Add(new object[] { L_UsreID, L_UsreName, L_Department, L_Date_Blame, L_Quantity, L_Blame, L_QuantityNum });
            }
            ASPxGridView1.DataSource = Eevent;
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridLookup1_ButtonClick(object source, DevExpress.Web.ButtonEditClickEventArgs e)
        {

        }

        protected void ASPxGridLookup1_TextChanged(object sender, EventArgs e)
        {
            //var lvSQL = "Select";
        }
    }
}