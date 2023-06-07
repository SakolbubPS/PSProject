using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Warning
{
    public partial class _XtraReport3 : DevExpress.XtraReports.UI.XtraReport
    {
        public _XtraReport3()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {           

            string lvSQL = "SELECT * FROM reportwarning1 WHERE UsreID Like '%" + GVar.VarUserID + "%'";
            MessageBox.Show("SQL111" + lvSQL);
            DataTable DT = new DataTable();

            DT = GsysSQL.fncGetQueryData(lvSQL, DT);
            int lvNumRow = DT.Rows.Count;

             
            for (int i = 0; i < lvNumRow; i++)
            {
                MessageBox.Show("FOR 111" + DT.Rows[i]["Date_now"].ToString());
                xrLabel44.Text = DT.Rows[i]["Date_now"].ToString();
                xrLabel49.Text = DT.Rows[i]["Blame"].ToString() + " จำนวน " + DT.Rows[i]["Quantity"].ToString() + " ครั้ง";
                xrLabel52.Text = "เตือนวาจา";
                xrLabel8.Text = DT.Rows[i]["Date_Blame"].ToString();
                xrLabel5.Text = DT.Rows[i]["UsreName"].ToString();
                xrLabel10.Text = DT.Rows[i]["Quantity"].ToString();
                xrLabel3.Text = DT.Rows[i]["Date_Check"].ToString();

            }
        }
                                    
    }
}
