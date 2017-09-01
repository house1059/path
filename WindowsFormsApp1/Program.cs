//#define EXCEL_ON

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;

#if EXCEL_ON
using Excel = Microsoft.Office.Interop.Excel;           //とりあえずのCOMオブジェクト  ClosedXMLに移行できればそのうち
using System.Runtime.InteropServices;
#endif

namespace PathLink
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
            Application.Run(new Search());
        }
    }

    public class Proc
    {
        private const String PATH_VERSION = "◎PathV4";

        //partsDicもいらないのでは？ Listかどちらかで賄えるのでは？　Dictionaryの方がkeyでhashを持てるのでデータ追加を考えるとDictionaryかな
        //public  Dictionary<string, PathData> PartsDic { get; } = new Dictionary<string, PathData>();   //パーソナルデータのインデックスを管理
        

        //アクセサ
        //public List<PathData> OrList { get; private set; } = new List<PathData>();       //ﾃｷｽﾄChangeの時にしか検索しないようにする
        //public List<PathData> AndList { get; private set; } = new List<PathData>();


        //レイヤーリストに関しては後程リファクタ
        //オブジェクトで管理するように変更します。
        public List<PathData> LayerList { get; private set; } = new List<PathData>();  //全体から読込んだlayer番号リスト
        public List<string> ResultLayer { get; private set; } = new List<string>();    //
       

        List<PathData> PartsList { get; set; } = new List<PathData>();    //パーソナルデータ
       


        //パーツ単品問い合わせ
        //public PathData GetPathData( string s)
        //{
        //    s = Strings.StrConv(s, VbStrConv.Wide | VbStrConv.Uppercase);
        //    if(PartsDic.ContainsKey(s))
        //    {
        //        return PartsDic[s];
        //    }
        //    return new PathData();  //辞書にない場合は空データを返す
        //}

        //Excelオープン
        public void ExcelOpen(PathData path)
        {
            _ExcelOpen(path);
        }

        public void ExcelOpen(string s)
        {
            s = Strings.StrConv(s, VbStrConv.Uppercase | VbStrConv.Wide);
            if (PathDB.PartsDic.ContainsKey(s))
            {
                _ExcelOpen(PathDB.PartsDic[s]);
            }
            else
            {
                //データベースに無いファイルを開こうとしている throw
            }
        }


        private static void _ExcelOpen(PathData path)
        {


#if EXCEL_ON
            Excel._Application ex = null; ;
            Excel._Workbook wb = null;
            Excel.Worksheet sh = null;
            Excel.Range rn = null;

            try
            {
                ex = new Excel.Application();
                wb = ex.Workbooks.Open(path.FilePath, true, true);
                sh = ex.Sheets[path.SheetName];
                sh.Select();

                rn = ex.Range[path.Address, path.Address];
                rn.Select();

                ex.Visible = true;
                System.Threading.Thread.Sleep(1000);

                Marshal.ReleaseComObject(rn);
                Marshal.ReleaseComObject(sh);
                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(ex);
            }
            finally
            {
                GC.Collect();
            }
#else
            MessageBox.Show("Excelを機能を切っているので起動はしませんがここを通ります");
#endif
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

            string[] st1, st2;

            //コレクション作成の処理
            while (!stream.EndOfStream)
            {
                st1 = stream.ReadLine().Split('\t');   //タブでカット
                st2 = st1[0].Split('\\');              //配列の０番目を\でファイル名を取り出す

                PathData p = new PathData()
                {   //初期化子
                    FilePath = st1[0],
                    SheetName = st1[1],
                    Address = st1[2],
                    Value = st1[3],
                    WideValue = Strings.StrConv(st1[3].ToUpper(), VbStrConv.Wide | VbStrConv.Uppercase)
                };


                //◎PathVer4.1.4.vbsだとサウンド設定ファイルの出力が悪いのでここで弾く
                if (int.TryParse(st1[st1.Length - 1], out int layer))
                {
                    p.Layer = Strings.StrConv(st1[st1.Length - 1].ToUpper(), VbStrConv.Narrow); //数値に変換したいので小文字
                }

                //パーソナルデータが既に存在している場合は子が先に登録しているので情報のみ追加してあげる
                if(PathDB.PartsDic.ContainsKey(p.WideValue))
                {
                    PathData pathdata = PathDB.PartsDic[p.WideValue];
                    pathdata = (PathData)p.Clone();     
                    pathdata.Value = p.Value;
                    pathdata.WideValue = p.WideValue;
                }
                else
                {
                    PathDB.PartsDic.Add(p.WideValue, p);
                }
                RegistChild(st1[4].Split(','),  p);      //子どもを登録
            }
        }

        //子どもの情報を追加
        private void RegistChild(string[] pts,  PathData p)
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

                        string key = Strings.StrConv(s, VbStrConv.Wide | VbStrConv.Uppercase).ToUpper();
                        
                        //子のパーソナルﾃﾞｰﾀが無い場合、作成して親の登録を行う
                        if (PathDB.PartsDic.ContainsKey(key) == false)
                        {
                            PathData child = new PathData()
                            {
                                Value = s,
                                WideValue = key
                            };
                            PathDB.PartsDic.Add(key,child) ;           //子のﾃﾞｰﾀを追加
                        }
                        PathData registP = PathDB.PartsDic[key];  //子データを取得
                        registP.AddParent(p);                   //子どもに親（自分）を登録
                        p.AddChild(registP);                    //自分に子供を追加
                        break;
                }
            }
        }



        /// <summary>
        /// 検索モジュール　ここで一括で受ける
        /// </summary>
        /// <param name="txt1">検索フィールド</param>
        /// <param name="txt2">レイヤーフィールド</param>
        //public void TextSearch(string txt1, string txt2 )
        //{

        //    //全体から検索した情報
        //    OrList = TextSearchPathData(txt1);
        //    AndList = TextSearchPathData(txt1 , PartsList);

        //    //layerも加味した検索
        //    OrList = PathDataSearchLayer(txt2, OrList);
        //    AndList = PathDataSearchLayer(txt2, AndList);

        //    ResultLayer = PathDataSearchLayerList(PartsList);

        //}

        /// <summary>
        /// 検索フィールドの情報を渡してpathDataを返す
        /// overLoad　pathがあればpathの範囲内で減らす検索を行う
        /// </summary>
        /// <param name="txt1">検索フィールドの情報</param>
        /// <param name="path"></param>
        /// <returns>pathDataのList</returns>
        /// 
        private List<PathData> TextSearchPathData(string txt1, List<PathData> p)
        {
            //デフォルトでは全て返却
            if (txt1 == "") return PartsList;

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
        private List<PathData> TextSearchPathData( string txt1)
        {
            //デフォルトでは全て返却
            if ( txt1 == "") return PartsList;

            txt1 = txt1.Replace('　', ' ');  //全角スペースを一旦半角スペースに置換
            string[] s = txt1.Split(' ');   //２語検索可能
            List<PathData> p = new List<PathData>();    //or検索の場合は0から増やす

            //検索
            for (int i = 0; i < s.Length; i++)
            {
            //or検索
                p.AddRange(PathDataSearch(s[i], PartsList));    //ローカルのパーツリストを引数とする                }
            }
            return p;
        }


        //pathDataの検索
        private List<PathData> PathDataSearch(string s, List<PathData> list )
        {
            List<PathData> p = new List<PathData>();
            foreach (PathData pList in list)  //ローカル優先
            {
                //全角+大文字で検索するように
                if (pList.WideValue.Contains(Strings.StrConv(s.ToUpper(), VbStrConv.Wide | VbStrConv.Uppercase)))
                {
                    p.Add(pList);
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
        private List<PathData> PathDataSearchLayer(string s ,List<PathData> ptlist)
        {

            if (s == "") return ptlist;

            List<PathData> p = new List<PathData>();
            foreach (PathData pList in ptlist)  //指定リストから
            {
                //layer nullがあるので事前にチェック
                if(pList.Layer == null)
                {
                    continue;
                //数字の検索（完全一致）
                }else if ( pList.Layer.Equals(Strings.StrConv(s.ToUpper(),VbStrConv.Narrow)))
                {
                    p.Add(pList);
                }
            }
            return p;
        }

        //与えられたpathDataリストからユニークなlayer番号を抽出　一旦数値変換⇒ソートしてstringで返す
        private List<string> PathDataSearchLayerList(List<PathData> pList)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<int> intList = new List<int>();


            foreach (PathData psList in pList)  //ローカル優先
            {
                if ( psList.Layer != null &&  dic.ContainsKey(psList.Layer) == false)
                {
                    dic.Add( psList.Layer, null);
                    intList.Add(int.Parse(psList.Layer));
                }
            }
            intList.Sort();
            return intList.ConvertAll(s => s.ToString());
        }



    }











}
