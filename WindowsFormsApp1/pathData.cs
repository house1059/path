using System.Collections.Generic;
using Microsoft.VisualBasic;
using System;
using System.Linq;


namespace PathLink
{
    public class PathData:ICloneable
    {

        public string FilePath { get; set; }
        public string SheetName { get; set; }
        public string Address { get; set; }
        public string Value { get; set; }       //実名称
        public string WideValue { get; set; }   //全角＋大文字登録（検索用）
        public string Layer { get; set; }       //レイヤー番号（文字列）も拾う

        public bool WbOK { get {
                //開くことが可能か否か　ファイルパス、シート名、ｱﾄﾞﾚｽがない場合はNG
                if (this.FilePath != "" && this.SheetName != "" && this.Address != "")
                    return true;

                return false;
            } }              

        private Dictionary<string, PathData> parentDic = new Dictionary<string, PathData>();
        private Dictionary<string, PathData> childDic = new Dictionary<string, PathData>();


        private List<PathData> parentList = new List<PathData>();
        private List<PathData> childList = new List<PathData>();    //LINQでExists使えるならば早そう

        


        public string bindingData;


        /// <summary>
        /// 子リストにデータを追加（２重登録しないようにチェック）
        /// </summary>
        /// <param name="p">子どものPathData</param>
        public void AddChild(  PathData p)
        {
            if( childDic.ContainsKey(p.WideValue) == false)
            {
                childDic.Add(p.WideValue, p);
            }
        }

        public void AddParent( PathData p)
        {
            if (parentDic.ContainsKey(p.WideValue) == false)
            {
                parentDic.Add(p.WideValue, p);
            }
        }


        public ICollection<PathData> GetChildList()
        {
            return childDic.Values;
        }

        public ICollection<PathData> GetParentList()
        {
            return parentDic.Values;
        }


        //ｲﾝﾀｰﾌｪｲｽ
        public object Clone()
        {
            //valueとWideValue以外をｺﾋﾟｰ
            PathData p = new PathData()
            {
                FilePath = this.FilePath,
                SheetName = this.SheetName,
                Address = this.Address,
                Layer = this.Layer,
            };
            return p;
        }
        //違いを確認する
        public object Clone( int x)
        {
            return MemberwiseClone();
        }


    }



    public class PathDB
    {


        public static Dictionary<string, PathData> PartsDic { get; set; } = new Dictionary<string, PathData>();
//        public static List<PathData> PartsList { get; set; } = new List<PathData>();


        public static List<PathData> OrList { get; protected set; } = null;
        public static List<PathData> AndList { get; protected set; } = null;
        public static List<string> LayerList { get; protected set; } = null;


        //public static List<PathData> parentList { get; protected set; } = null;
        //public static List<PathData> childList { get; protected set; } = null;    //LINQでExists使えるならば早そう





        ////ｱｸｾｻ
        //public ICollection<PathData> GetOrList()
        //{

        //    return PathLinkDB.Values;
        //}


        //パーツ単品問い合わせ
        //public static PathData GetPathData(string s)
        //{
        //    s = Strings.StrConv(s, VbStrConv.Wide | VbStrConv.Uppercase);
        //    if(PartsList.Exists(p => p.WideValue == s)){
        //        return PartsList.Find(p => p.WideValue == s);
        //    }
        //    return new PathData();  //一致しない場合はからデータを返す
        //}



        //パーツ単品問い合わせ
        public static PathData GetPathData(string s)
        {
            s = Strings.StrConv(s, VbStrConv.Wide | VbStrConv.Uppercase);
            if (PartsDic.ContainsKey(s))
            {
                return PartsDic[s];
            }
            return new PathData();  //辞書にない場合は空データを返す
        }



        /// <summary>
        /// 検索Windowからの問い合わせ
        /// </summary>
        /// <param name="body">検索フィールド</param>
        /// <param name="layer">レイヤーフィールド</param>
        public static void TextSearch(string body, string layer)
        {

            //partsDicから全ての情報を取り出す
            OrList = GetList(body);
            AndList = GetList(body, PartsDic.Values.ToList());

            LayerList = GetLayerList();

        }




        //範囲を拡大する
        private static List<PathData> GetList( string body)
        {
            if (body == "") return PartsDic.Values.ToList();

            List<PathData> result = new List<PathData>();
            body = Strings.StrConv(body, VbStrConv.Uppercase | VbStrConv.Wide);     //全角＋大文字に変換
            string[] split = body.Split('　');   

            foreach( string s in split)
            {
                result.AddRange(PartsDic.Values.ToList().FindAll(p => p.WideValue.Contains(s)));
            }

            return result;
        }

        //範囲を縮小する
        private static List<PathData> GetList(string body, List<PathData> list)
        {
            if (body == "") return PartsDic.Values.ToList();

            body = Strings.StrConv(body, VbStrConv.Uppercase | VbStrConv.Wide);     //全角＋大文字に変換
            string[] split = body.Split('　');

            foreach (string s in split)
            {
                list = list.FindAll(p => p.WideValue.Contains(s));
            }

            return list;
        }


        /// <summary>
        /// ユニークなレイヤー番号を返す
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        private static List<string> GetLayerList( )
        {
            //nullが大量にあるので nullを除外
            //ユニークなテーブルを作成するためhashsetを使用
            //Listに変換
            List<PathData> result = PartsDic.Values.ToList().FindAll(p => p.Layer != null).ToList();

            HashSet<string> hash = new HashSet<string>();
            foreach( PathData p in result)
            {
                hash.Add(p.Layer);
            }

            return hash.ToList<string>();
        }




    }







}
