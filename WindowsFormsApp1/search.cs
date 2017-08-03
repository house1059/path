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
        List<string> orList = new List<string>();       //ﾃｷｽﾄChangeの時にしか検索しないようにする
        List<string> andList = new List<string>();
        List<string> resultList = new List<string>();   //現在決定済みの方

        public search()
        {
            InitializeComponent();
            p = new program();
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
            if (richTextBox1.Text == "" && richTextBox2.Text == "")
            {
                listBox1.DataSource = null;
                return;
            }

            //検索開始
            // Shutdown the painting of the ListBox as items are added.

            orList = p.TextSearch(richTextBox1.Text, richTextBox2.Text, true);
            andList = p.TextSearch(richTextBox1.Text, richTextBox2.Text ,false);
            ViewUpdate();   //再描画

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
            }

        }



        //clearボタン
        private void bt_clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
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
                resultList = orList;
            }
            else
            {
                resultList = andList;
            }
            listBox1.DataSource = resultList;

            // Allow the ListBox to repaint and display the new items.
            listBox1.EndUpdate();
        }



        ////データを選択した時
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            pathData src = p.getPathData(resultList[listBox1.SelectedIndex]);

            textBox2.Text = src.filePath;
            textBox3.Text = src.sheetName;
            textBox4.Text = src.address;
            textBox1.Text = src.layer;

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            TextFormSearch();   //検索
        }
    }
}
