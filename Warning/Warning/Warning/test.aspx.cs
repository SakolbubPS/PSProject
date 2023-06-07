using DevExpress.Spreadsheet;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warning
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            fncExcelLoad();


        }
        void fncExcelLoad()
        {
            try
            {
                IWorkbook workbook = ASPxSpreadsheet1.Document;
                Worksheet worksheet = workbook.Worksheets[0];
                Range usedRange = worksheet.GetUsedRange();


                string DateNow = "";
                string lvID = "";
                string lvDepartment = "";
                string lvDate = "";
                string lvtype = "";
                string lvNum = "";
                string lvUnit = "";
                string lvName = "";
                string lvKa = "";


                int lvBreak = 0;
                for (int i = 0; i < usedRange.Count(); i++)
                {
                    DateNow = worksheet.Cells[i, 1].DisplayText;

                    lvID = worksheet.Cells[i, 2].DisplayText;
                    lvDepartment = worksheet.Cells[i, 3].DisplayText;
                    lvDate = worksheet.Cells[i, 4].DisplayText;
                    lvtype = worksheet.Cells[i, 5].DisplayText;
                    lvNum = worksheet.Cells[i, 6].DisplayText;
                    lvUnit = worksheet.Cells[i, 7].DisplayText;
                    lvName = worksheet.Cells[i, 8].DisplayText;
                    lvKa = worksheet.Cells[i, 9].DisplayText;
                    // DateNow = DateTime.Now.ToString("dd/MM/yyyy");













                }



            }
            catch { }
        }

    }
}