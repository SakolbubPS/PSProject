using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Warning
{
    public class Gstr
    {

        public static string Right(string str, int Length)
        {
            if (Length > 0 && str.Length >= Length)
            {
                return str.Substring(str.Length - Length, Length);
            }
            else
            {
                return str;
            }
        }

        public static string Left(string str, int Length)
        {
            if (Length > 0 && str.Length >= Length)
            {
                return str.Substring(0, Length);
            }
            else
            {
                return str;
            }
        }

        public static string Mid(string str, int strStart, int strLength)
        {
            return str.Substring(strStart - 1, strLength);
        }

        public static string fncChangeSDate(string strDate)
        {
            //--เก็บประเภทของปฏิทิน
            var myCal = DateTimeFormatInfo.CurrentInfo.Calendar;

            string lvYear = Left(strDate, 4);

            //--แปลงปีให้อยู่ในรูปแบบของตัวเลข
            int lvYear2 = fncToInt(lvYear);
            int lvYear3 = lvYear2;

            if (lvYear2 < 2500)
            {
                //--ตรวจว่าปฎิทินของเครื่องเป็นแบบปี พ.ศ. หรือไม่ ถ้าใช่ให้เปลี่ยนก่อนแสดงผล
                if (myCal.ToString() == "System.Globalization.ThaiBuddhistCalendar" || lvYear3 < 2500)
                {
                    lvYear3 = lvYear2 + 543;
                }
            }
            else if (lvYear2 > 3000)
            {
                lvYear2 -= 543;
            }


            //ฟังก์ชั่น Show Date รูปแบบ dd/MM/yyyy
            if (strDate.Length == 8)
            {
                string lvDay = Right(strDate, 2);
                string lvMonth = Mid(strDate, 5, 2);

                return lvDay + "/" + lvMonth + "/" + lvYear3;
            }
            else
            {
                return strDate;
            }
        }

        public static string fncChangeTDate(string strDate)
        {
            //--เก็บประเภทของปฏิทิน
            var myCal = DateTimeFormatInfo.CurrentInfo.Calendar;

            //ฟังก์ชั่น แปลงวันที่ เป็นรูปแบบบ Text  รูปแบบ yyyyMMdd
            if (strDate.Length == 10)
            {
                string lvDay = Left(strDate, 2);
                string lvMonth = Mid(strDate, 4, 2);
                string lvYear = Right(strDate, 4);

                int lvNumYear = int.Parse(lvYear);

                if (lvNumYear > 2500)
                {
                    //--ตรวจว่าปฎิทินของเครื่องเป็นแบบปี พ.ศ. หรือไม่ ถ้าใช่ให้เปลี่ยนก่อนแสดงผล
                    if (myCal.ToString() == "System.Globalization.ThaiBuddhistCalendar")
                    {
                        lvNumYear = lvNumYear - 543;
                        lvYear = lvNumYear.ToString();
                    }
                }
                else if (lvNumYear > 3000)
                {
                    lvNumYear -= 543;
                }

                return lvYear + lvMonth + lvDay;
            }
            else
            {
                return strDate;
            }
        }

        public static string fncGetDataCode(string pvSCode, string lvSyntax)
        {
            try
            {
                string lvCode = "";
                for (int i = 1; i <= pvSCode.Length; i++)
                {
                    if (Mid(pvSCode, i, 1) != lvSyntax)
                        lvCode = lvCode + Mid(pvSCode, i, 1);
                    else
                        break;
                }
                return lvCode.Trim();
            }
            catch //(Exception ex)
            {
                return "";
            }
        }

        public static int fncToInt(string strNumber)
        {//ฟังก์ชั่นแปลงตัวเลขใน string ให้เป็นเลขจำนวนเต็ม  (+-2,147,483,647) 
            //แปลงค่าว่างได้ ,แปลงค่าที่มี comma ได้ เช่น 123,456
            //แปลงมีค่าลบได้ทั้งหน้าและหลัง เช่น 123,456.00-
            //แปลงค่าติดลบที่เป็นวงเล็บได้ เช่น (123,456.00) --> -123456
            try
            {
                int lvPosition = strNumber.IndexOf("."); //ค้นหาตำแหน่งจุดทศนิยม
                if (lvPosition > 0) strNumber = Left(strNumber, lvPosition); //เอาเฉพาะจำนวนเต็ม ตัดจุดทศนิยมออก

                return int.Parse(strNumber.Trim(), System.Globalization.NumberStyles.Any);
            }
            catch //(Exception ex)
            {
                return 0;
            }
        }

        public static double fncToDouble(string strNumber)
        {//ฟังก์ชั่นแปลงตัวเลขใน string ให้เป็นตัวเลข 
            //แปลงค่าว่างได้ ,แปลงค่าที่มี comma ได้ เช่น 123,456.00
            //แปลงมีค่าลบได้ทั้งหน้าและหลัง เช่น 123,456.00-
            //แปลงค่าติดลบที่เป็นวงเล็บได้ เช่น (123,456.00) --> -123456

            try
            {
                return double.Parse(strNumber.Trim(), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture);
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }
    }
}