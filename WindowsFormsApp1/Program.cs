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
        List<pathData> partsList = new List<pathData>();    //パーソナルデータ
        List<string> filterList = new List<string>();       //filterのコレクション

        //パーツリストへのアクセサ
        public List<pathData> PartsList {
            get
            {
                return this.partsList;
            }
        }

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
                p.layer = Strings.StrConv( st1[st1.Length -1].ToString().ToUpper(),VbStrConv.Wide);   //レイヤー情報を取得


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


        //検索モジュール　（ここで一括で受けて子モジュールに流す）
        public List<string> TextSearch(string textBox1, string textBox2 ,bool b)
        {

            textBox1 = textBox1.Replace('　', ' ');  //全角スペースを一旦半角スペースに置換
            string[] s = textBox1.Split(' ');   //２語検索可能
            List<pathData> p = new List<pathData>();    //or検索の場合は0から増やす

            if (b == false){
                p = partsList;               //and検索の場合は最大値から減らす
            }
            List<string> amList = new List<string>();

            //検索
            for(int i = 0; i< s.Length; i++)
            {
                //or検索
                if (b == true)
                {
                    p.AddRange(PathDataSearch(s[i],this.partsList));    //ローカルのパーツリストを引数とする
                }
                else
                //and検索
                {
                    p = PathDataSearch(s[i],p);     //自身を引数として範囲を狭める
                }
            }

            //さらにlayer情報で範囲を狭める
            if (textBox2 != "")
            {
                p = PathDataSearchLayer(textBox2, p);
            }

            //指定範囲のvalueを返す
            foreach (pathData ps in p)
            {
                amList.Add(ps.value);
            }
            return amList;
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

        //pathDataのlayer番号検索
        private List<pathData> PathDataSearchLayer(string s, List<pathData> list)
        {
            List<pathData> p = new List<pathData>();
            foreach (pathData ps in list)  //ローカル優先
            {
                //layer nullがあるので事前にチェック
                if(ps.layer == null)
                {
                    continue;
                //全角+大文字で検索するように
                }else if (ps.layer.Equals(Strings.StrConv(s.ToUpper(), VbStrConv.Wide)))
                {
                    p.Add(ps);
                }
            }
            return p;
        }

    }











}
