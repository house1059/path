using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public class pathData
    {
        public Excel.Workbook wb;
        public string filePath { get; set; }
        public string fileName { get; set; }
        public string sheetName { get; set; }
        public string address { get; set; }
        public string value { get; set; }

        public List<string> parentList;    //親リスト
        public List<string> childList;     //子リスト

        //ｺﾝｽﾄﾗｸﾀ
        public pathData()
        {
            parentList = new List<string>();
            childList = new List<string>();
        }
    }









}
