﻿using System.Collections.Generic;
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

        public static List<PathData> OrList { get; protected set; } = null;
        public static List<PathData> AndList { get; protected set; } = null;
        public static List<string> LayerList { get;  set; } = null;



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






        }




        //OrListとAndListを同時に作成していたが、基本AndListしか使わないので使う時だけ検索するように処理を分けました。
        private static void CreateOrList(string body, string layer)
        {
            OrList = GetList(body);
            if (layer == "") return;
            OrList = GetList(OrList, layer);
        }

        private static void CreateAndList(string body, string layer)
        {
            AndList = GetList(body, PartsDic.Values.ToList());
            if (layer == "") return;
            AndList = GetList(AndList, layer);
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


        //範囲を縮小する（ListとList）
        private static List<PathData> GetList( List<PathData>list, string layer)
        {
            if (layer == "") return list;
            return list = list.FindAll(p => p.Layer == layer);
        }
    }
}
