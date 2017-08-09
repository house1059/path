#define EXCEL_ON

//Excelがある場合のみ
#if EXCEL_ON
using Excel = Microsoft.Office.Interop.Excel;           //とりあえずのCOMオブジェクト  ClosedXMLに移行できればそのうち
#endif





using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public class PathData
    {
#if EXCEL_ON

        public Excel._Application ex;
        public Excel.Workbook wb;
        public Excel.Worksheet sheet;
#endif
        public string filePath { get; set; }
        public string fileName { get; set; }
        public string sheetName { get; set; }
        public string address { get; set; }
        public string value { get; set; }       //実名称
        public string wideValue { get; set; }   //全角＋大文字登録（検索用）
        public string layer { get; set; }       //レイヤー番号（文字列）も拾う

        public List<string> parentList;    //親リスト
        public List<string> childList;     //子リスト

        //ｺﾝｽﾄﾗｸﾀ
        public PathData()
        {
            parentList = new List<string>();
            childList = new List<string>();

        }

        public void WorkBooksOpen()
        {
            //    ex = new Excel.Application();
            //  wb = ex.Workbooks.Open(this.filePath, true, true);
#if EXCEL_ON
            ex.Workbooks.Open(this.filePath, true, true);
            ex.OnSheetActivate = this.sheetName;

            ex.Visible = true;
#endif

        }


    }



   








}
