using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using System.Data;
using System.Windows.Forms;
using System.Web;
 

namespace Warning
{
    public partial class XtraReport3 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport3()
        {
            InitializeComponent();
        }

        
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
                      
            if (GVar.VarUserID != "")
            {



                LCounter.Text = GsysSQL.CountWarningNum(GVar.VarUserID, GVar.VarBleam);//นับจำนวน ที่ ได้รับใบเตือน

                string lvSQL = "SELECT * FROM reportwarning1 WHERE UsreID ='" + GVar.VarUserID + "' AND Blame='"+GVar.VarBleam+"'";
                //MessageBox.Show(lvSQL);
                DataTable DT = new DataTable();

                DT = GsysSQL.fncGetQueryData(lvSQL, DT);
                int lvNumRow = DT.Rows.Count;
                for (int i = 0; i < lvNumRow; i++)
                {
                 
                    LDate1.Text = DT.Rows[i]["Date_now"].ToString();
                    LBlame1.Text = DT.Rows[i]["Blame"].ToString() + " จำนวน " + DT.Rows[i]["Quantity"].ToString() + " ครั้ง";
                    LBleme_Type1.Text = "เตือนวาจา";
                    xrLabel8.Text = DT.Rows[i]["Date_Blame"].ToString();
                    xrLabel5.Text = DT.Rows[i]["UsreName"].ToString();
                    xrLabel10.Text = DT.Rows[i]["Quantity"].ToString();

                    LCreate_doc.Text = GVar.doc_CreateDate;
                    LEmployee.Text = DT.Rows[i]["UserN"].ToString();
                   // LCounter.Text = GVar.VarCount;

                }

            }
        } 
      



    }
}
