#define EXCEL_ON

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;


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
                if(!File.Exists(path.FilePath))
                {
                    MessageBox.Show("該当ファイルが見つかりません。\n" + path.FilePath, "wrong", MessageBoxButtons.OK);
                    return;
                }



                ex = new Excel.Application();
                wb = ex.Workbooks.Open(path.FilePath, true, true);
                sh = ex.Sheets[path.SheetName];
                sh.Select();

                rn = ex.Range[path.Address, path.Address];
                rn.Select();

                ex.Visible = true;
                //System.Threading.Thread.Sleep(1000);

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

            PathDB.PartsDic.Clear();


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
                    pathdata.FilePath = p.FilePath;
                    pathdata.SheetName = p.SheetName;
                    pathdata.Address = p.Address;
                    pathdata.Layer = p.Layer;
                    pathdata.Value = p.Value;
                    pathdata.WideValue = p.WideValue;
                }
                else
                {
                    PathDB.PartsDic.Add(p.WideValue, p);
                }
                RegistChild(st1[4].Split(','),  p);      //子どもを登録
            }

            //読込み完了した後にLayerListの作成
            PathDB.CreateLayerList();


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
    }
}
