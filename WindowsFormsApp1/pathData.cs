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
        public static List<PathData> PartsList { get; set; } = new List<PathData>();


        public static List<PathData> OrList { get; protected set; } = null;
        public static List<PathData> AndList { get; } = null;



        public static List<PathData> parentList { get; protected set; } = null;
        public static List<PathData> childList { get; protected set; } = null;    //LINQでExists使えるならば早そう





        ////ｱｸｾｻ
        //public ICollection<PathData> GetOrList()
        //{

        //    return PathLinkDB.Values;
        //}


        //パーツ単品問い合わせ
        public static PathData GetPathData(string s)
        {
            s = Strings.StrConv(s, VbStrConv.Wide | VbStrConv.Uppercase);
            if(PartsList.Exists(p => p.WideValue == s)){
                return PartsList.Find(p => p.WideValue == s);
            }
            return new PathData();  //一致しない場合はからデータを返す
        }



        ////パーツ単品問い合わせ
        //public static PathData GetPathData(string s)
        //{
        //    s = Strings.StrConv(s, VbStrConv.Wide | VbStrConv.Uppercase);
        //    if (PartsDic.ContainsKey(s))
        //    {
        //        return PartsDic[s];
        //    }
        //    return new PathData();  //辞書にない場合は空データを返す
        //}



        /// <summary>
        /// 検索Windowからの問い合わせ
        /// </summary>
        /// <param name="body">検索フィールド</param>
        /// <param name="layer">レイヤーフィールド</param>
        public static void TextSearch(string body, string layer)
        {

            //partsDicから全ての情報を取り出す
            Dictionary<string,PathData>.ValueCollection parts = PartsDic.Values;
            OrList = GetOrList(body, parts);

            

        }





        private static List<PathData> GetOrList( string body, Dictionary<string, PathData>.ValueCollection parts)
        {
            List<PathData> result = new List<PathData>();
            body = Strings.StrConv(body, VbStrConv.Uppercase | VbStrConv.Wide);     //全角＋大文字に変換
            string[] split = body.Split('　');   

            foreach( string s in split)
            {
                result.AddRange(PartsDic.Values.ToList().FindAll(p => p.WideValue.Contains(s)));
            }

            return result;
        }






        ///// <summary>
        ///// 検索モジュール　ここで一括で受ける
        ///// </summary>
        ///// <param name="txt1">検索フィールド</param>
        ///// <param name="txt2">レイヤーフィールド</param>
        //public void TextSearch(string txt1, string txt2)
        //{

        //    //全体から検索した情報
        //    OrList = TextSearchPathData(txt1);
        //    AndList = TextSearchPathData(txt1, PartsList);

        //    //layerも加味した検索
        //    OrList = PathDataSearchLayer(txt2, OrList);
        //    AndList = PathDataSearchLayer(txt2, AndList);

        //    ResultLayer = PathDataSearchLayerList(PartsList);

        //}

        ///// <summary>
        ///// 検索フィールドの情報を渡してpathDataを返す
        ///// overLoad　pathがあればpathの範囲内で減らす検索を行う
        ///// </summary>
        ///// <param name="txt1">検索フィールドの情報</param>
        ///// <param name="path"></param>
        ///// <returns>pathDataのList</returns>
        ///// 
        //private List<PathData> TextSearchPathData(string txt1, List<PathData> p)
        //{
        //    //デフォルトでは全て返却
        //    if (txt1 == "") return PartsList;

        //    txt1 = txt1.Replace('　', ' ');  //全角スペースを一旦半角スペースに置換
        //    string[] s = txt1.Split(' ');   //２語検索可能

        //    //検索
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        //and検索
        //        p = PathDataSearch(s[i], p);     //自身を引数として範囲を狭める
        //    }
        //    return p;
        //}


        ///// <summary>
        ///// 検索フィールドの情報を渡してpathDataを返す
        ///// overLoad　pathがなければ追加していく検索を行う
        ///// </summary>
        ///// <param name="txt1">フィールド</param>
        ///// <returns></returns>
        //private List<PathData> TextSearchPathData(string txt1)
        //{
        //    //デフォルトでは全て返却
        //    if (txt1 == "") return PartsList;

        //    txt1 = txt1.Replace('　', ' ');  //全角スペースを一旦半角スペースに置換
        //    string[] s = txt1.Split(' ');   //２語検索可能
        //    List<PathData> p = new List<PathData>();    //or検索の場合は0から増やす

        //    //検索
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        //or検索
        //        p.AddRange(PathDataSearch(s[i], PartsList));    //ローカルのパーツリストを引数とする                }
        //    }
        //    return p;
        //}


        ////pathDataの検索
        //private List<PathData> PathDataSearch(string s, List<PathData> list)
        //{
        //    List<PathData> p = new List<PathData>();
        //    foreach (PathData pList in list)  //ローカル優先
        //    {
        //        //全角+大文字で検索するように
        //        if (pList.WideValue.Contains(Strings.StrConv(s.ToUpper(), VbStrConv.Wide | VbStrConv.Uppercase)))
        //        {
        //            p.Add(pList);
        //        }
        //    }
        //    return p;
        //}



    }







}
