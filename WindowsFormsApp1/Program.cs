using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;


namespace WindowsFormsApp1
{
    

    static class Program
    {

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new search());
        }
    }

    public class program
    {
        private const String PATH_VERSION = "◎PathV4";

        Dictionary<string, int> partsDic = new Dictionary<string, int>();   //パーソナルデータのインデックスを管理
       
        //アクセサ
        public List<pathData> partsList { get; } = new List<pathData>();    //パーソナルデータ
        public List<string> filterList { get; } = new List<string>();       //filterのコレクション

        public List<pathData> orList { get; private set; } = new List<pathData>();       //ﾃｷｽﾄChangeの時にしか検索しないようにする
        public List<pathData> andList { get; private set; } = new List<pathData>();
        public List<pathData> layerList { get; private set; } = new List<pathData>();  //全体から読込んだlayser番号リスト
        public List<string> resultList1 { get; private set; } = new List<string>();    //
        public List<string> resultList2 { get; private set; } = new List<string>();    //
        public List<string> resultLayer { get; private set; } = new List<string>();    //


        //パーツ単品問い合わせ
        public pathData getPathData( string s)
        {
            return partsList[partsDic[s]];
        }


        //ﾌｧｲﾙﾊﾟｽを渡して読込む
        public void ReadPathFile(string filePath)
        {
            //◎pathﾃｷｽﾄを読込む　
            StreamReader stream = new StreamReader(filePath, Encoding.GetEncoding("shift_jis"));
            string str = stream.ReadLine();     //日付

            if (stream.ReadLine() != PATH_VERSION)
            {
                MessageBox.Show("◎PathV4のファイルではありません", "注意!", MessageBoxButtons.OK);
                stream.Close();
                return;
            }
            str = stream.ReadLine();     //'//制御タグ

            string[] st1, st2, strFilter;

            //コレクション作成の処理
            while (!stream.EndOfStream)
            {
                st1 = stream.ReadLine().Split('\t');   //タブでカット
                st2 = st1[0].Split('\\');              //配列の０番目を\でファイル名を取り出す
                strFilter = st1[3].Split('：');        //全角デリミット　部品名の取り出し

                pathData p = new pathData();
                p.filePath = st1[0];
                p.sheetName = st1[1];
                p.address = st1[2];
                p.value = st1[3];
                p.wideValue = Strings.StrConv( st1[3].ToUpper(),VbStrConv.Wide);

                //◎PathVer4.1.4.vbsだとサウンド設定ファイルの出力が悪いのでここで弾く
                int layer;
                if( int.TryParse(st1[st1.Length - 1],out layer)){
                    p.layer = Strings.StrConv( st1[st1.Length - 1].ToUpper(),VbStrConv.Wide);
                }

                //パーソナルデータが存在しない場合は作成
                if (partsDic.ContainsKey(p.value) == false)
                {
                    partsList.Add(new pathData());   //パーソナルパターンを追加
                    partsDic.Add(p.value, partsList.Count - 1);
                    partsList[partsDic[p.value]].value = p.value;   //自分自身の登録
                    partsList[partsDic[p.value]].wideValue = Strings.StrConv(p.value,VbStrConv.Wide);   //自分自身の登録

                }

                RegistChild(st1[4].Split(','), p);      //子どもを登録

                int i = partsDic[p.value];  //Listのインデックスを取得
                partsList[i].parentList.AddRange(p.parentList); //親の情報を加算
                p.parentList = partsList[i].parentList;
                partsList[i] = p;                       //上書き（子は上書きでＯＫ）

                if (strFilter.Count() > 0 && filterList.Contains(strFilter[0]))
                {
                    filterList.Add(strFilter[0]);   //フィルターを登録
                }


            }
        }

        //子どもの情報を追加
        private void RegistChild(string[] pts, pathData p)
        {

            //pts～pteまでを登録
            foreach (string s in pts)
            {
                switch (s.ToUpper())
                {
                    case "PTS":
                    case "PTE":
                    case "":
                        break;

                    default:
                        //子のパーソナルﾃﾞｰﾀが無い場合、作成して親の登録を行う
                        if (partsDic.ContainsKey(s) == false)
                        {
                            partsList.Add(new pathData());     //空のﾃﾞｰﾀを作成
                            partsDic.Add(s, partsList.Count - 1);   //インデックス番号を登録
                            partsList[partsDic[s]].value = s;   //自分自身の登録
                            partsList[partsDic[s]].wideValue =Strings.StrConv( s,VbStrConv.Wide);   //自分自身の登録
                        }
                        partsList[partsDic[s]].parentList.Add(p.value); //親を登録
                        p.childList.Add(s);                               //子の情報を貯める
                        break;
                }
            }
        }



        /// <summary>
        /// 検索モジュール　ここで一括で受ける
        /// </summary>
        /// <param name="txt1">検索フィールド</param>
        /// <param name="txt2">レイヤーフィールド</param>
        public void TextSearch(string txt1, string txt2 )
        {

            //全体から検索した情報

            orList = TextSearchPathData(txt1);
            andList = TextSearchPathData(txt1 , partsList);

            //layerも加味した検索
            orList = PathDataSearchLayer(txt2, orList);
            andList = PathDataSearchLayer(txt2, andList);
            layerList = PathDataSearchLayer("", partsList);


            resultList1 = PathDataSearchValueList(orList);
            resultList2 = PathDataSearchValueList(andList);
            resultLayer = PathDataSearchLayerList(layerList);



        }

        /// <summary>
        /// 検索フィールドの情報を渡してpathDataを返す
        /// overLoad　pathがあればpathの範囲内で減らす検索を行う
        /// </summary>
        /// <param name="txt1">検索フィールドの情報</param>
        /// <param name="path"></param>
        /// <returns>pathDataのList</returns>
        /// 
        private List<pathData> TextSearchPathData(string txt1, List<pathData> p)
        {

            //デフォルトでは全て返却
            if (txt1 == "") return partsList;

            txt1 = txt1.Replace('　', ' ');  //全角スペースを一旦半角スペースに置換
            string[] s = txt1.Split(' ');   //２語検索可能

            //検索
            for (int i = 0; i < s.Length; i++)
            {
                //and検索
                p = PathDataSearch(s[i], p);     //自身を引数として範囲を狭める
            }
            return p;
        }


        /// <summary>
        /// 検索フィールドの情報を渡してpathDataを返す
        /// overLoad　pathがなければ追加していく検索を行う
        /// </summary>
        /// <param name="txt1">フィールド</param>
        /// <returns></returns>
        private List<pathData> TextSearchPathData( string txt1)
        {
            //デフォルトでは全て返却
            if (txt1 == "") return partsList;

            txt1 = txt1.Replace('　', ' ');  //全角スペースを一旦半角スペースに置換
            string[] s = txt1.Split(' ');   //２語検索可能
            List<pathData> p = new List<pathData>();    //or検索の場合は0から増やす

            //検索
            for (int i = 0; i < s.Length; i++)
            {
            //or検索
                p.AddRange(PathDataSearch(s[i], this.partsList));    //ローカルのパーツリストを引数とする                }
            }
            return p;
        }


        //pathDataの検索
        private List<pathData> PathDataSearch(string s, List<pathData> list )
        {
            List<pathData> p = new List<pathData>();
            foreach (pathData ps in list)  //ローカル優先
            {
                //全角+大文字で検索するように
                if (ps.wideValue.Contains(Strings.StrConv(s.ToUpper(), VbStrConv.Wide)))
                {
                    p.Add(ps);
                }
            }
            return p;
        }

        //pathDataのlayer番号を含むpathDataを返す
        /// <summary>
        /// レイヤー番号を含むpathDataを返す
        /// </summary>
        /// <param name="s"></param>
        /// <returns>List</returns>
        private List<pathData> PathDataSearchLayer(string s ,List<pathData> ptlist)
        {

            if (s == "") return ptlist;

            List<pathData> p = new List<pathData>();
            foreach (pathData ps in ptlist)  //指定リストから
            {
                //layer nullがあるので事前にチェック
                if(ps.layer == null)
                {
                    continue;
                //数字の検索（完全一致）
                }else if ( ps.layer.Equals(Strings.StrConv(s.ToUpper(),VbStrConv.Wide)))
                {
                    p.Add(ps);
                }
            }
            return p;
        }

        //与えられたpathDataリストからユニークなlayer番号を抽出
        private List<string> PathDataSearchLayerList(List<pathData> pList)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<string> list = new List<string>();
            foreach (pathData ps in pList)  //ローカル優先
            {
                if ( ps.layer != null &&  dic.ContainsKey(ps.layer) == false)
                {
                    dic.Add( ps.layer , null);
                    list.Add(ps.layer);
                }
            }
            return list;
        }

        //与えられたpathDataリストからvalueを返す
        private List<string> PathDataSearchValueList(List<pathData> pList)
        {
            List<string> list = new List<string>();
            foreach (pathData ps in pList)  //ローカル優先
            {
                    list.Add(ps.value);
            }
            return list;
        }



    }











}
