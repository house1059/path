using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class search : Form
    {
        private const String PATH_VERSION = "◎PathV4";



        Dictionary<string, int> partsDic = new Dictionary<string, int>();   //パーソナルデータのインデックスを管理
        List<pathData> partsList = new List<pathData>();    //パーソナルデータ


        List<string> filterList = new List<string>();       //filterのコレクション
//        List<parentData> parentList = new List<parentData>();       //子の親リスト



        public search()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void search_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //検索開始
            // Shutdown the painting of the ListBox as items are added.
            listBox1.BeginUpdate();

            

            // Allow the ListBox to repaint and display the new items.
            listBox1.EndUpdate();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void bt_read_Click(object sender, EventArgs e)
        {

            //ダイアログボックスの表示
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "◎PathFile(*.txt)|*.txt;|全てのﾌｧｲﾙ(*.*)|*.*";
            fd.Title = "PathLinkﾃﾞｰﾀﾌｧｲﾙを選択してください";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                readPathFile(fd.FileName);
            }
            else
            {
                return;
            }

        }

        private void bt_check_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test");
        }


        //ﾌｧｲﾙﾊﾟｽを渡して読込む
        private void readPathFile(string filePath )
        {
            //◎pathﾃｷｽﾄを読込む　
            StreamReader stream = new StreamReader(filePath ,Encoding.GetEncoding("shift_jis"));
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



                //パーソナルデータが存在しない場合は作成
                if (partsDic.ContainsKey(p.value) == false)
                {
                    partsList.Add( new pathData());   //パーソナルパターンを追加
                    partsDic.Add(p.value, partsList.Count - 1);
                    partsList[partsDic[p.value]].value = p.value;   //自分自身の登録
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
        private void RegistChild( string[] pts , pathData p)
        {

            //pts～pteまでを登録
            foreach (string s in pts)
            {
                switch (s.ToUpper()) {
                    case "PTS":
                    case "PTE":
                    case "":
                        break;

                    default:
                        //子のパーソナルﾃﾞｰﾀが無い場合、作成して親の登録を行う
                        if (partsDic.ContainsKey(s) == false) { 
                            partsList.Add( new pathData());     //空のﾃﾞｰﾀを作成
                            partsDic.Add(s, partsList.Count -1);   //インデックス番号を登録
                            partsList[partsDic[s]].value = s;   //自分自身の登録
                        }
                        partsList[partsDic[s]].parentList.Add(p.value); //親を登録
                        p.childList.Add(s);                               //子の情報を貯める
                        break;
                }
            }
        }

        //検索モジュール
        private string[] textSearch()
        {


            return x;
        }



    }
}
