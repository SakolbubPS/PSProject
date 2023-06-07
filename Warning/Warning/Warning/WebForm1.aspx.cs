using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Configuration;

namespace Warning
{
    public partial class WebForm1 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public class test {
            public string id { get; set; } 
        }



        List<test> test2 = new List<test>();
        public class USer{
         public string user { get; set; }
      //  public string 


}

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {



                using (XLWorkbook workbook = new XLWorkbook(FileUpload1.PostedFile.InputStream))
                {
                    //string consString = ConfigurationManager.ConnectionStrings["PSConnection"].ConnectionString;
                    //SqlConnection c = new SqlConnection(consString);                   
                    //SqlDataAdapter cmd = new SqlDataAdapter();
                    //cmd.InsertCommand = new SqlCommand("INSERT INTO Warning (W_ID) VALUES (3)");
                    //cmd.InsertCommand.Connection = c;
                    //c.Open();
                    //cmd.InsertCommand.ExecuteNonQuery();
                    //c.Close();
                    ////                c.Open();
                    //                using (SqlCommand cmd = new SqlCommand("INSERT INTO Warning (W_ID) VALUES (3)"))
                    //                {
                    //                    cmd.Parameters.AddWithValue("@field1","3");


                    //cmd.ExecuteNonQuery();
                    //                }



                    IXLWorksheet sheet = workbook.Worksheet(1);
                    DataTable dt = new DataTable();
                    bool firstRow = true;
                    foreach (IXLRow row in sheet.Rows())
                    {
                        if (firstRow)
                        {

                            foreach (IXLCell cell in row.Cells())

                            {


                                // string result = dt.Columns.Add(cell.Value.ToString()).ToString();
                                dt.Columns.Add(cell.Value.ToString());
                                //Add Columns
                                //dt.Columns.Add("ID", typeof(int));
                                //dt.Columns.Add("Name", typeof(string));
                                //dt.Columns.Add("City", typeof(string));
                                ////Add Rows in DataTable
                                //dt.Rows.Add(1, "Anoop Kumar Sharma", "Delhi");
                                //dt.Rows.Add(2, "Andrew", "U.P.");
                                //dt.AcceptChanges();
                                //Start insert into

                                //string consString = ConfigurationManager.ConnectionStrings["PSConnection"].ConnectionString;
                                //SqlConnection c = new SqlConnection(consString);
                                //SqlDataAdapter cmd = new SqlDataAdapter();
                                //cmd.InsertCommand = new SqlCommand("INSERT INTO Warning (W_ID) VALUES (3)");
                                //cmd.InsertCommand.Connection = c;
                                //c.Open();
                                //cmd.InsertCommand.ExecuteNonQuery();
                                //c.Close();

                                //End insert into

                            }
                            firstRow = false;
                        }
                        else
                        {
                            dt.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())

                            {




                                (test2.Add(new test()
                                {
                                    id = cell.Value.ToString();
                          
                            }



                            i++;

                        }


                 

                            //Start insert into

                            //string consString = ConfigurationManager.ConnectionStrings["PSConnection"].ConnectionString;
                            //SqlConnection c = new SqlConnection(consString);
                            //SqlDataAdapter cmd = new SqlDataAdapter();
                            //cmd.InsertCommand = new SqlCommand("INSERT INTO Warning (W_ID) VALUES (3)");
                            //cmd.InsertCommand.Connection = c;
                            //c.Open();
                            //cmd.InsertCommand.ExecuteNonQuery();
                            //c.Close();

                            //End insert into


                        
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();



                }

            
            



                }
            catch (Exception ex)
            {

            }
        }
    }
}