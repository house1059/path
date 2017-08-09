using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public class PathData
    {
        public string filePath { get; set; }
        public string fileName { get; set; }
        public string sheetName { get; set; }
        public string address { get; set; }
        public string value { get; set; }       //実名称
        public string wideValue { get; set; }   //全角＋大文字登録（検索用）
        public string layer { get; set; }       //レイヤー番号（文字列）も拾う

        public bool wbOK { get; set; }               //開くことが可能か否か　ファイルパス、シート名、ｱﾄﾞﾚｽがない場合はNG

        public List<string> parentList;    //親リスト
        public List<string> childList;     //子リスト

        //ｺﾝｽﾄﾗｸﾀ
        public PathData()
        {
            parentList = new List<string>();
            childList = new List<string>();

        }
    }



   








}
