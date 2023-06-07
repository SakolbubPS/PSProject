using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace Warning
{
    public partial class WebForm1 : System.Web.UI.Page
    {


        
        protected void Page_Load(object sender, EventArgs e)
        {
            FncLoadprint();
            this.Title = "PS Warning Online System.";
        }

        public class Wa

        {
            public string W_IDUser { get; set; }
            public string W_IDDepartment { get; set; }
            public string W_UName { get; set; }
            public string W_Date { get; set; }
            public string W_IDka { get; set; }
            public string W_Nameka { get; set; }
            public string W_Timein { get; set; }
            public string W_Timeout { get; set; }
            public string W_IDType { get; set; }
            public string W_Type { get; set; }
            public string W_Num { get; set; }
            public string W_HOUR { get; set; }
            public string W_MINUTE { get; set; }
            public string W_DateNow { get; set; }


        }
        List<Wa> PSWarning = new List<Wa>();
        //       public object ASPxGridView1 { get; private set; }
        public class USer
        {
            public string W_IDUser { get; set; }
            public string W_IDDepartment { get; set; }
            public string W_UName { get; set; }
            public string W_Date { get; set; }
            public string W_IDka { get; set; }
            public string W_Nameka { get; set; }
            public string W_Timein { get; set; }
            public string W_Timeout { get; set; }
            public string W_IDType { get; set; }
            public string W_Type { get; set; }
            public string W_Num { get; set; }
            public string W_HOUR { get; set; }
            public string W_DateNow { get; set; }
            public string C_Waring { get; set; }
            public string W_Blame { get; set; }
            public string Result { get; set; }

        }

        //ฟังก์ชั่นปุ่มบันทึก
        protected void BTSave1_Click(object sender, EventArgs e)
        {
            string[] lvArr = Request.Form["confirm_value"].Split(',');
            string lvConfirm = lvArr[lvArr.Count() - 1];
            if (lvConfirm == "No")
            {
                return;
            }
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(FileUpload1.PostedFile.InputStream))
                {
                    var ws = workbook.Worksheet(1);
                    int count = ws.RowsUsed().Count();

                    for (int i = 2; i <= count; i++)
                    {
                        var W_IDUser = ws.Cell("B" + i.ToString()).GetValue<string>();
                        var W_IDDepartment = ws.Cell("C" + i.ToString()).GetValue<string>();
                        var W_UName = ws.Cell("D" + i.ToString()).GetValue<string>();
                        var W_Date = ws.Cell("E" + i.ToString()).GetValue<string>();
                        var W_IDka = ws.Cell("F" + i.ToString()).GetValue<string>();
                        var W_Nameka = ws.Cell("G" + i.ToString()).GetValue<string>();
                        var W_Timein = ws.Cell("H" + i.ToString()).GetValue<string>();
                        var W_Timeout = ws.Cell("I" + i.ToString()).GetValue<string>();
                        var W_IDType = ws.Cell("J" + i.ToString()).GetValue<string>();
                        var W_Type = ws.Cell("K" + i.ToString()).GetValue<string>();
                        var W_Num = ws.Cell("L" + i.ToString()).GetValue<string>();
                        var W_Late = ws.Cell("M" + i.ToString()).GetValue<string>();
                        W_Date = DatetoThai(W_Date, "dd-MM-yyyy");
                        var split_time = W_Late.Split('.');
                        var W_HOUR = Convert.ToInt32(split_time[0]);
                        var W_MINUTE = split_time.Length > 1 ? Convert.ToInt32(split_time[1]) : 0;
                        string Resultwaring = "";
                        if (W_HOUR == 0 && W_MINUTE >= 1 && W_MINUTE <= 5)
                        {
                            Resultwaring = "สายเกิน5นาที";
                        }
                        else if (W_HOUR == 0 && W_MINUTE >= 6 && W_MINUTE <= 15)
                        {
                            Resultwaring = "สายเกิน15นาที";
                        }
                        else if (W_HOUR == 0 && W_MINUTE > 15)
                        {
                            Resultwaring = "สายเกิน30นาที";
                        }
                        else if (W_HOUR >= 1)
                        {
                            Resultwaring = "สายเป็นช.ม.";
                        }
                        var datenow = DateTime.Now;
                       // MessageBox.Show("Date"+ W_Date);
                        string consString = ConfigurationManager.ConnectionStrings["MysqlPSConnection"].ConnectionString;
                        MySqlConnection c = new MySqlConnection(consString);
                        MySqlDataAdapter cmd = new MySqlDataAdapter();
                        // ตรวจสอบว่ามีข้อมูลชื่อ W_IDUser, W_Date  อยู่ในฐานข้อมูลแล้วหรือไม่
                        //  MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*)as countps FROM ps_warning WHERE W_IDUser=@W_IDUser AND W_Date=@W_Date  ", c);
                        string LvSQL1 = "SELECT COUNT(*)as countps FROM ps_warning WHERE W_IDUser='"+W_IDUser+"' AND W_Date='"+W_Date+"'  ";
                       
                        DataTable DT = new DataTable();
                        DT = GsysSQL.fncGetQueryData(LvSQL1, DT);
                        int lvNumRow = DT.Rows.Count;
                       
                        string CK_Count = DT.Rows[0]["countps"].ToString();

                       // MessageBox.Show(CK_Count);
                        // ถ้า count เป็น 0 แสดงว่าไม่มีข้อมูลนี้อยู่แล้ว จึงจะเพิ่มข้อมูลลงในฐานข้อมูลได้
                        if (CK_Count == "0" || CK_Count==null)
                        {
                            // เพิ่มข้อมูลลงในฐานข้อมูล
                            MySqlCommand insertCmd = new MySqlCommand("INSERT INTO ps_warning ( W_IDUser, W_IDDepartment, W_UName, W_Date, W_IDka, W_Nameka, W_Timein,W_Timeout, W_IDType, W_Type, W_Num,W_Late,W_DateNow,W_Blame,W_HOUR,W_MINUTE) VALUES ( '" + W_IDUser + "', '" + W_IDDepartment + "', '" + W_UName + "', '" + W_Date + "', '" + W_IDka + "', '" + W_Nameka + "', '" + W_Timein.Substring(0, 5) + "', '" + W_Timeout.Substring(0, 5) + "', '" + W_IDType + "', '" + W_Type + "', '" + W_Num + "', '" + W_Late + "', '" + datenow + "', '" + Resultwaring + "', '" + W_HOUR + "', '" + W_MINUTE + "')");
                           // MessageBox.Show("SQL=="+insertCmd);
                            insertCmd.Connection = c;
                            c.Open();
                            insertCmd.ExecuteNonQuery();
                            c.Close(); 
                        }
                        else
                        {
                            //แสดงข้อมูลซ้ำ
                            MessageBox.Show("ข้อมูลซ้ำ");
                            // string Check_Status2 = "Dupicate";

                            // แสดงข้อความว่ามีข้อมูลนี้อยู่แล้ว
                            // หรือทำการอัพเดทข้อมูล หากต้องการอัพเดทแทนที่จะเพิ่ม
                        }
                       // MessageBox.Show("มีข้อมูลซ้ำ");
                    }                                   

                 FncLoadprint();
                }
                //แสดงการบันทึก
                MessageBox.Show("บันทึกข้อมูลสำเร็จ");


            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert is not  : " + ex.Message);
            }         
        }
    
        //ฟังก์ชั่นบนกิตวิวแสดงข้อมูลเมื่อกดบันทึก
         protected void FncLoadprint()
        {                                 
            try
            {

                string lvSQL = "SELECT W_IDUser, W_IDDepartment, DM.D_Names, W_UName AS UserName, W_DateNow, W_Blame, COUNT(W_IDUser) AS Wcount FROM ps_warning AS Wn LEFT JOIN ps_department AS Dm ON Wn.W_IDDepartment = DM.D_DID GROUP BY W_IDUser, W_IDDepartment, DM.D_Names, W_UName,  W_Blame ,Month(STR_TO_DATE(W_Date,'%Y/%m/%d'))";
                DataTable DT = new DataTable();
                DT = GsysSQL.fncGetQueryData(lvSQL, DT);
                DataTable DTnew = new DataTable();
                DTnew.Columns.Add("WIDUser");
                DTnew.Columns.Add("WIDDepartment");
                DTnew.Columns.Add("WUName");
                DTnew.Columns.Add("DName");
                DTnew.Columns.Add("Wcount");
                DTnew.Columns.Add("WcType");
                //int lvNumrow = 1;

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    string WIDUser = DT.Rows[i]["W_IDUser"].ToString();
                    string WIDDepartment = DT.Rows[i]["W_IDDepartment"].ToString();
                    string WUName = DT.Rows[i]["UserName"].ToString();
                    string DName = DT.Rows[i]["D_Names"].ToString();
                    string Wcount = DT.Rows[i]["Wcount"].ToString();
                    string WcType = DT.Rows[i]["W_Blame"].ToString();
                    DTnew.Rows.Add(new object[] { WIDUser, WIDDepartment, WUName, DName, Wcount, WcType });
                }
                // แสดงข้อมูล บน GridView   
                ASPxGridView1.DataSource = DTnew;
                ASPxGridView1.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Load data is not : " + ex.Message);
            }
        }    
         // ฟังช์ชั่นปริ้นทั้งหมดที่ทำไว้ 14-03-66
        protected void BT_Print_Click(object sender, EventArgs e)
        {
            //ฟังก์ชั่น ลูป
            
            string lvSQL = "DELETE FROM reportwarning ";
            string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);
            DataTable DT = new DataTable();
            lvSQL = "SELECT W_IDUser,SUM(W_HOUR) AS S_HOURS,SUM(W_MINUTE) AS S_Min, W_Date, W_IDDepartment, DM.D_Names, W_UName AS UserName, W_DateNow, W_Blame, COUNT(W_IDUser) AS C_ID  FROM ps_warning AS Wn LEFT JOIN ps_department AS Dm ON Wn.W_IDDepartment = DM.D_DID where Month(str_to_date(Wn.W_Date, '%Y-%m-%d')) = 1 GROUP BY W_IDUser, W_IDDepartment, DM.D_Names, W_UName, W_Blame";
           // MessageBox.Show(lvSQL);
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);
            int lvNumRow = DT.Rows.Count;
            DataTable Dtnew = new DataTable();
            for (int i = 0; i < lvNumRow; i++)
           // foreach (DataRow row in DTP.Rows)
            {
                //ประกาศตัวแปร แปลงเป็นintจากtext
                int CID = Gstr.fncToInt(DT.Rows[i]["C_ID"].ToString());
                string CID1 = DT.Rows[i]["W_Blame"].ToString();
                string UsreID_ = DT.Rows[i]["W_IDUser"].ToString();
                string UsreName_ = DT.Rows[i]["UserName"].ToString();
                string DepartmentID_ = DT.Rows[i]["W_IDDepartment"].ToString();
                string Department_ = DT.Rows[i]["D_Names"].ToString();
                string Date_ = DatetoThai(DT.Rows[i]["W_Date"].ToString(), " MMMM yyyy");
                string Quantity_ = DT.Rows[i]["C_ID"].ToString();
                string Hours_ = DT.Rows[i]["S_HOURS"].ToString();
                string Minute_ = DT.Rows[i]["S_Min"].ToString();
                string Blame_ = DT.Rows[i]["W_Blame"].ToString();
                string User_N = DT.Rows[i]["UserName"].ToString();
                string DateNow = DatetoThai(DT.Rows[i]["W_DateNow"].ToString(), "dd MMMM yyyy");
                string Date_Check = DatetoEng(DT.Rows[i]["W_Date"].ToString(), "dd-MM-yyyy");
                               
                //ฟังก์ชั่น ลูป สาย 5 นาที
                if ((CID >= 5) && CID1 == "สายเกิน5นาที")
                {
                  
                    // บันทึกเพื่อแสดงหน้าพิมพ์
                    lvSQL = "INSERT INTO reportwarning (UsreID, UsreName, DepartmentID, Department, Date_Blame, Quantity, Hours, Minute, Blame, Date_now, UserN) ";
                    lvSQL += "VALUES ('" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "')";
                                     

                    //บันทึก Data เพื่อแสดงข้อมูลปริ้น/มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO reportwarning1 (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,UserN,Date_Check) ";
                    lvSQL += "SELECT '" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM reportwarning1 WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";

                    //บันทึก Data เพื่อแสดงข้อมูลในกิต//มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO showwaring (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,Date_Check)";
                    lvSQL += " SELECT '" + UsreID_ + "','" + User_N + "','" + DepartmentID_ + "','" + Department_ + "','" + Date_ + "','" + Quantity_ + "','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM showwaring WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    string lvResault1 = GsysSQL.fncExecuteQueryData(lvSQL);
                

                }
                //ฟังก์ชั่น ลูป 15 นาที
                else if ((CID >= 3) && CID1 == "สายเกิน15นาที")
                {
                   
                    // บันทึกเพื่อแสดงหน้าพิมพ์
                    lvSQL = "INSERT INTO reportwarning (UsreID, UsreName, DepartmentID, Department, Date_Blame, Quantity, Hours, Minute, Blame, Date_now, UserN) ";
                    lvSQL += "VALUES ('" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลปริ้น/มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO reportwarning1 (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,UserN,Date_Check) ";
                    lvSQL += "SELECT '" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM reportwarning1 WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลในกิต//มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO showwaring (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,Date_Check)";
                    lvSQL += " SELECT '" + UsreID_ + "','" + User_N + "','" + DepartmentID_ + "','" + Department_ + "','" + Date_ + "','" + Quantity_ + "','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM showwaring WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    string lvResault1 = GsysSQL.fncExecuteQueryData(lvSQL);
               
                }
                //ฟังก์ชั่น ลูป 30 นาที
                else if ((CID >= 1) && CID1 == "สายเกิน30นาที")
                {
 
                    // บันทึกเพื่อแสดงหน้าพิมพ์
                    lvSQL = "INSERT INTO reportwarning (UsreID, UsreName, DepartmentID, Department, Date_Blame, Quantity, Hours, Minute, Blame, Date_now, UserN) ";
                    lvSQL += "VALUES ('" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลปริ้น/มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO reportwarning1 (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,UserN,Date_Check) ";
                    lvSQL += "SELECT '" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM reportwarning1 WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลในกิต//มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO showwaring (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,Date_Check)";
                    lvSQL += " SELECT '" + UsreID_ + "','" + User_N + "','" + DepartmentID_ + "','" + Department_ + "','" + Date_ + "','" + Quantity_ + "','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM showwaring WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    string lvResault1 = GsysSQL.fncExecuteQueryData(lvSQL);
                  


                }
                //ฟังก์ชั่น ลูป ช.ม.
                else if ((CID >= 1) && CID1 == "สายเป็นช.ม.")
                {
 
                    // บันทึกเพื่อแสดงหน้าพิมพ์
                    lvSQL = "INSERT INTO reportwarning (UsreID, UsreName, DepartmentID, Department, Date_Blame, Quantity, Hours, Minute, Blame, Date_now, UserN) ";
                    lvSQL += "VALUES ('" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลปริ้น/มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO reportwarning1 (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,UserN,Date_Check) ";
                    lvSQL += "SELECT '" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM reportwarning1 WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลในกิต//มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO showwaring (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,Date_Check)";
                    lvSQL += " SELECT '" + UsreID_ + "','" + User_N + "','" + DepartmentID_ + "','" + Department_ + "','" + Date_ + "','" + Quantity_ + "','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM showwaring WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    string lvResault1 = GsysSQL.fncExecuteQueryData(lvSQL);
                  //  GVar.VarUserID = UsreID_;               

                }

            }
            //ฟังชั่นคลิ๊กปริ้น
            //FncPrintReport();
            
           // Response.Redirect("WarningPinter.aspx");
        }

        //ฟังชั่นเปลี่ยน Date
        public static string DatetoThai(string s, string format)
        {
            string str_changdate = "";
            System.Globalization.CultureInfo _cultureTHInfo = new System.Globalization.CultureInfo("th-TH");
            if (s != "")
            {

                str_changdate = Convert.ToDateTime(s).ToString(format, _cultureTHInfo);
            }

            return str_changdate;
        }
        public static string DatetoEng(string s, string format)
        {
            string str_changdate = "";
            System.Globalization.CultureInfo _cultureTHInfo = new System.Globalization.CultureInfo("en-US");
            if (s != "")
            {

                str_changdate = Convert.ToDateTime(s).ToString(format, _cultureTHInfo);
            }

            return str_changdate;
        }

        protected void ASPxFormLayout1_E1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WarningSearch.aspx");
        }

        protected void ASPxFormLayout1_E2_Click(object sender, EventArgs e)
        {
            ASPxPopupControl1.ShowOnPageLoad = true;
            BindDataToDdlWarning();            
          FncLoadprint();
        }

        protected void BT_Can_Click(object sender, EventArgs e)
        {
            ASPxPopupControl1.ShowOnPageLoad = false;
        }

        protected void BT_UPSave_Click(object sender, EventArgs e)
        {
            string lvSQL = "UPDATE  ps_warning set W_UName='" + T_Name.Text + "',W_IDDepartment='" + T_IDDepartment.Text + "',W_Date='" + T_Datein.Text +
                    "',W_HOUR='" + T_HOUR.Text + "',W_MINUTE='" + T_MINUTE.Text + "' Where W_ID = '"+ CmdWUser.SelectedValue + "' ";
            string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);


        }

        protected void BindDataToDdlWarning()
        {
            string constr = ConfigurationManager.ConnectionStrings["MysqlPSConnection"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(constr))
            {
                connection.Open();

                MySqlCommand cmdWarning = new MySqlCommand("SELECT W_ID,W_IDUser FROM ps_warning", connection); // เพิ่มเงื่อนไขใน WHERE ตามที่ต้องการ
                MySqlDataAdapter adapterCarRental = new MySqlDataAdapter(cmdWarning);
                DataTable dtWarning = new DataTable();
                adapterCarRental.Fill(dtWarning);

                CmdWUser.DataSource = dtWarning;
                CmdWUser.DataValueField="W_ID";
                CmdWUser.DataTextField= "W_IDUser"; // เพิ่มส่วนนี้เพื่อกำหนดค่าให้เป็นข้อความที่จะแสดงใน DropDown
                CmdWUser.DataBind();

                CmdWUser.Items.Insert(0, new ListItem("--Select--", ""));
               // CmdWUser.Attributes.Add("onchange", "javascript:__doPostBack('" + CmdWUser.UniqueID + "', '');");
            }
        }

        private DataTable FncExecuteDataTable(string strSql)
        {
            string constr = ConfigurationManager.ConnectionStrings["MysqlPSConnection"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(constr))
            {
                using (MySqlCommand command = new MySqlCommand(strSql, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected void CmdWUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSql = "SELECT * FROM ps_warning WHERE W_ID='" + CmdWUser.SelectedValue + "' ";         
            DataTable dt = FncExecuteDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                CmdWUser.SelectedValue = dt.Rows[0]["W_ID"].ToString(); //รหัสพนักงาน
                T_Name.Text = dt.Rows[0]["W_UName"].ToString();                //ชื่อพนักงาน
                T_IDDepartment.Text = dt.Rows[0]["W_IDDepartment"].ToString();//รหัสแผนก
                T_Datein.Text = dt.Rows[0]["W_Date"].ToString();//วันที่สาย
                T_HOUR.Text = dt.Rows[0]["W_HOUR"].ToString();//ชม.สาย
                T_MINUTE.Text = dt.Rows[0]["W_MINUTE"].ToString();//นาทีที่สาย
            }
        }

        protected void BT_Del_Click(object sender, EventArgs e)
        {
            string lvSQL = "DELETE FROM  ps_warning Where W_ID = '" + CmdWUser.SelectedValue + "' ";
            string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);
        }

        protected void ASPxGridView1_RowCommand1(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
          
            if (e.CommandArgs.CommandName == "Print")
            {
                    int index = Convert.ToInt32(e.VisibleIndex);
                    GVar.VarUserID = ASPxGridView1.GetRowValues(index, "WIDUser").ToString();
                    GVar.VarCount = ASPxGridView1.GetRowValues(index, "Wcount").ToString();
                    GVar.VarBleam = ASPxGridView1.GetRowValues(index, "WcType").ToString();
                    GVar.doc_CreateDate = DateTime.Now.ToString("dd-MM-yyyy");                

                Response.Redirect("WarningPinter.aspx?WIDUser='" + GVar.VarUserID + "'");
            }
        }

        protected void BT_Call_Click(object sender, EventArgs e)
        {
            //ฟังก์ชั่น ลูป

           // string lvSQL = "DELETE FROM reportwarning ";
          //  string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);

            DataTable DT = new DataTable();
            string lvSQL = "SELECT W_IDUser,SUM(W_HOUR) AS S_HOURS,SUM(W_MINUTE) AS S_Min, W_Date, W_IDDepartment, DM.D_Names, W_UName AS UserName, W_DateNow, W_Blame, COUNT(W_IDUser) AS C_ID  FROM ps_warning AS Wn LEFT JOIN ps_department AS Dm ON Wn.W_IDDepartment = DM.D_DID where Month(str_to_date(Wn.W_Date, '%Y-%m-%d')) = 1 GROUP BY W_IDUser, W_IDDepartment, DM.D_Names, W_UName, W_Blame";
            // MessageBox.Show(lvSQL);
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);
            int lvNumRow = DT.Rows.Count;
            DataTable Dtnew = new DataTable();
            for (int i = 0; i < lvNumRow; i++)
            // foreach (DataRow row in DTP.Rows)
            {
                //ประกาศตัวแปร แปลงเป็นintจากtext
                int CID = Gstr.fncToInt(DT.Rows[i]["C_ID"].ToString());
                string CID1 = DT.Rows[i]["W_Blame"].ToString();
                string UsreID_ = DT.Rows[i]["W_IDUser"].ToString();
                string UsreName_ = DT.Rows[i]["UserName"].ToString();
                string DepartmentID_ = DT.Rows[i]["W_IDDepartment"].ToString();
                string Department_ = DT.Rows[i]["D_Names"].ToString();
                string Date_ = DatetoThai(DT.Rows[i]["W_Date"].ToString(), " MMMM yyyy");
                string Quantity_ = DT.Rows[i]["C_ID"].ToString();
                string Hours_ = DT.Rows[i]["S_HOURS"].ToString();
                string Minute_ = DT.Rows[i]["S_Min"].ToString();
                string Blame_ = DT.Rows[i]["W_Blame"].ToString();
                string User_N = DT.Rows[i]["UserName"].ToString();
                string DateNow = DatetoThai(DT.Rows[i]["W_DateNow"].ToString(), "dd MMMM yyyy");
                string Date_Check = DatetoEng(DT.Rows[i]["W_Date"].ToString(), "dd-MM-yyyy");

                //ฟังก์ชั่น ลูป สาย 5 นาที
                if ((CID >= 5) && CID1 == "สายเกิน5นาที")
                {

                    // บันทึกเพื่อแสดงหน้าพิมพ์
                    lvSQL = "INSERT INTO reportwarning (UsreID, UsreName, DepartmentID, Department, Date_Blame, Quantity, Hours, Minute, Blame, Date_now, UserN) ";
                    lvSQL += "VALUES ('" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "')";


                    //บันทึก Data เพื่อแสดงข้อมูลปริ้น/มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO reportwarning1 (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,UserN,Date_Check) ";
                    lvSQL += "SELECT '" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM reportwarning1 WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";

                    //บันทึก Data เพื่อแสดงข้อมูลในกิต//มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO showwaring (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,Date_Check)";
                    lvSQL += " SELECT '" + UsreID_ + "','" + User_N + "','" + DepartmentID_ + "','" + Department_ + "','" + Date_ + "','" + Quantity_ + "','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM showwaring WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    string lvResault1 = GsysSQL.fncExecuteQueryData(lvSQL);


                }
                //ฟังก์ชั่น ลูป 15 นาที
                else if ((CID >= 3) && CID1 == "สายเกิน15นาที")
                {

                    // บันทึกเพื่อแสดงหน้าพิมพ์
                    lvSQL = "INSERT INTO reportwarning (UsreID, UsreName, DepartmentID, Department, Date_Blame, Quantity, Hours, Minute, Blame, Date_now, UserN) ";
                    lvSQL += "VALUES ('" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลปริ้น/มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO reportwarning1 (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,UserN,Date_Check) ";
                    lvSQL += "SELECT '" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM reportwarning1 WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลในกิต//มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO showwaring (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,Date_Check)";
                    lvSQL += " SELECT '" + UsreID_ + "','" + User_N + "','" + DepartmentID_ + "','" + Department_ + "','" + Date_ + "','" + Quantity_ + "','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM showwaring WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    string lvResault1 = GsysSQL.fncExecuteQueryData(lvSQL);

                }
                //ฟังก์ชั่น ลูป 30 นาที
                else if ((CID >= 1) && CID1 == "สายเกิน30นาที")
                {

                    // บันทึกเพื่อแสดงหน้าพิมพ์
                    lvSQL = "INSERT INTO reportwarning (UsreID, UsreName, DepartmentID, Department, Date_Blame, Quantity, Hours, Minute, Blame, Date_now, UserN) ";
                    lvSQL += "VALUES ('" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลปริ้น/มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO reportwarning1 (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,UserN,Date_Check) ";
                    lvSQL += "SELECT '" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM reportwarning1 WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลในกิต//มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO showwaring (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,Date_Check)";
                    lvSQL += " SELECT '" + UsreID_ + "','" + User_N + "','" + DepartmentID_ + "','" + Department_ + "','" + Date_ + "','" + Quantity_ + "','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM showwaring WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    string lvResault1 = GsysSQL.fncExecuteQueryData(lvSQL);



                }
                //ฟังก์ชั่น ลูป ช.ม.
                else if ((CID >= 1) && CID1 == "สายเป็นช.ม.")
                {

                    // บันทึกเพื่อแสดงหน้าพิมพ์
                    lvSQL = "INSERT INTO reportwarning (UsreID, UsreName, DepartmentID, Department, Date_Blame, Quantity, Hours, Minute, Blame, Date_now, UserN) ";
                    lvSQL += "VALUES ('" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลปริ้น/มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO reportwarning1 (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,UserN,Date_Check) ";
                    lvSQL += "SELECT '" + UsreID_ + "','" + UsreName_ + " หมายเลขประจำตัว " + UsreID_ + " รหัสกลุ่มงาน " + DepartmentID_ + " กลุ่มงาน " + Department_ + " ','รหัสกลุ่มงาน" + " : " + DepartmentID_ + "','ชื่อกลุ่มงาน" + " : " + Department_ + "','" + Date_ + "  โดยมาทำงาน" + "  " + Blame_ + " จำนวน','" + Quantity_ + " ครั้ง  เป็นเวลา  " + Hours_ + " : " + Minute_ + "  ช.ม.','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + User_N + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM reportwarning1 WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    //บันทึก Data เพื่อแสดงข้อมูลในกิต//มีการเช็คซ้ำ
                    lvSQL += "; INSERT INTO showwaring (UsreID,UsreName,DepartmentID,Department,Date_Blame,Quantity,Hours,Minute,Blame,Date_now,Date_Check)";
                    lvSQL += " SELECT '" + UsreID_ + "','" + User_N + "','" + DepartmentID_ + "','" + Department_ + "','" + Date_ + "','" + Quantity_ + "','" + Hours_ + "','" + Minute_ + "','" + Blame_ + "','" + DateNow + "','" + Date_Check + "'";
                    lvSQL += " WHERE NOT EXISTS (SELECT * FROM showwaring WHERE UsreID='" + UsreID_ + "' AND Date_Check='" + Date_Check + "')";
                    string lvResault1 = GsysSQL.fncExecuteQueryData(lvSQL);
                    //  GVar.VarUserID = UsreID_;               

                }

            }
            //ฟังชั่นคลิ๊กปริ้น
            //FncPrintReport();
        }
    }
}