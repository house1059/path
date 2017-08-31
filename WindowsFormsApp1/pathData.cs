using System.Collections.Generic;

namespace PathLink
{
    public class PathData
    {

        public string FilePath { get; set; }
        public string SheetName { get; set; }
        public string Address { get; set; }
        public string Value { get; set; }       //実名称
        public string WideValue { get; set; }   //全角＋大文字登録（検索用）
        public string Layer { get; set; }       //レイヤー番号（文字列）も拾う

        public bool WbOK { get; set; }               //開くことが可能か否か　ファイルパス、シート名、ｱﾄﾞﾚｽがない場合はNG

        public List<PathData> parentList;    //親リスト
        public List<PathData> childList;     //子リスト

        private Dictionary<string, PathData> parentDic;
        private Dictionary<string, PathData> childDic;


        public string bindingData;

        //ｺﾝｽﾄﾗｸﾀ
        public PathData()
        {
            parentList = new List<PathData>();
            childList = new List<PathData>();

            parentDic = new Dictionary<string, PathData>();     //→リストをDicに変えてみる
            childDic = new Dictionary<string, PathData>();

        }

        /// <summary>
        /// 子リストにデータを追加（２重登録しないようにチェック）
        /// </summary>
        /// <param name="s">子どもの名前</param>
        /// <param name="p">子どものPathData</param>
        public void AddChild( string s , PathData p)
        {
            if( childDic.ContainsKey(s) == false)
            {
                childDic.Add(s, p);
            }
        }

        public void AddParent( string s, PathData p)
        {
            if (parentDic.ContainsKey(s) == false)
            {
                parentDic.Add(s, p);
            }
        }


        public ICollection<PathData> GetChildData()
        {
            return childDic.Values;
        }





    }
    

}
