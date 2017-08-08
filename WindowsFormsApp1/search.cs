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
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class search : Form
    {
     
        program p;
        recent re;
        List<string> resultList  = new List<string>();   //listBox1の結果
        BindingSource bindingSrc { get; } = new BindingSource();  //listBox1（検索結果に対するbindingSrc）




        public search()
        {
            InitializeComponent();
            p = new program();
            re = new recent();
            re.Show();
            
        }

  
        private void search_DragOver(object sender, DragEventArgs e)
        {
            
        }


        //即時検索のイベント
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        //検索の実態
        private void TextFormSearch( )
        {


            p.TextSearch(richTextBox1.Text, comboBox1.Text);
            if (richTextBox1.Text == "" && comboBox1.Text == "")
            {
                listBox1.DataSource = null;
                return;
            }

            //検索開始
            // Shutdown the painting of the ListBox as items are added.
            ViewUpdate();   //再描画

        }


        //画面クリア
        private void ViewClear()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
            comboBox1.Text = "";
            textBox1.Text = ""; //レイヤー
            textBox2.Text = ""; //ファイルパス
            textBox3.Text = ""; //シート名
            textBox4.Text = ""; //ｱﾄﾞﾚｽ


        }





        //pathﾌｧｲﾙの読込
        private void bt_read_Click(object sender, EventArgs e)
        {
            //ダイアログボックスの表示
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "◎PathFile(*.txt)|*.txt;|全てのﾌｧｲﾙ(*.*)|*.*";
            fd.Title = "PathLinkﾃﾞｰﾀﾌｧｲﾙを選択してください";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                p.ReadPathFile(fd.FileName);
                label4.Text = fd.SafeFileName;

                TextFormSearch();   //検索
                bindingSrc.DataSource = p.resultLayer;
                bindingSrc.Add("");
                comboBox1.DataSource = bindingSrc;

            }
            
            ViewUpdate();   //再描画

        }



        //clearボタン
        private void bt_clear_Click(object sender, EventArgs e)
        {
            ViewClear();
        }

        private void bt_check_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ViewUpdate();   //再描画
        }

  

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            TextFormSearch();   //検索
        }

        private void ViewUpdate()   //再描画の処理
        {
            listBox1.BeginUpdate();
            if (radioButton1.Checked == true)
            {
                resultList = p.resultList1; //なんかもったいないのでリファクタ対象
            }
            else
            {
                resultList = p.resultList2;
            }
            listBox1.DataSource = resultList;
             //comboBox1.DataSource = resultList;　⇒　これで出ないのでDataSourceの使い方が間違っている？

            //comboBox1.DisplayMember = "layer";
            //comboBox1.DataSource = null;
            //comboBox1.DataSource = p.resultLayer;


            // Allow the ListBox to repaint and display the new items.
            listBox1.EndUpdate();
        }



        ////データを選択した時
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(listBox1.SelectedIndex == -1)
            {
                return;
            }


            pathData src = p.getPathData(resultList[listBox1.SelectedIndex]);

            textBox2.Text = src.filePath;
            textBox3.Text = src.sheetName;
            textBox4.Text = src.address;
            textBox1.Text = src.layer;

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            //TextFormSearch();   //検索
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            TextFormSearch();   //検索
        }


        /// <summary>
        /// 検索結果をDBCした場合、現在の表示を検索履歴をAddして窓に検索結果を反映
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //現在の表示しているテキストを検索履歴へ送る
            re.recentDataInsert(listBox1.SelectedItem.ToString());
            
            //Excelをオープンさせる
            p.partsList.Contains( )



        }

        private void search_Load(object sender, EventArgs e)
        {

        }
    }
}
