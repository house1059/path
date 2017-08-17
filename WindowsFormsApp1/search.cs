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
    public partial class Search : Form
    {

        //子フォームからアクセスできるプロパティを作成
        public string recentReceive { get; set; } = "";

        Recent re;
        program p;
        //List<string> resultList  = new List<string>();   //listBox1の結果
        BindingSource parsonalSrc { get; } = new BindingSource();   //メイン画面用のバインディングデータ
        BindingSource bindingSrc { get; } = new BindingSource();  //layer用 cmdboxなので
        BindingSource pListParentSrc { get; } = new BindingSource();      //親の一時リスト
        BindingSource pListChildSrc { get; } = new BindingSource();       //子の一時リスト



        public Search()
        {
            InitializeComponent();
            p = new program();
            re = new Recent();

            re.SearchRichTextBox = this.richTextBox1;    //子フォームに親のインスタンスを通知
            re.Visible = false;
            
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

                bindingSrc.DataSource = p.resultLayer;
                bindingSrc.Insert(0,"");
                comboBox1.DataSource = bindingSrc;
                comboBox1.SelectedIndex = 0;
                TextFormSearch();   //検索

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

            listBox1.ValueMember = "value";
            listBox1.DisplayMember = "wideValue";

            if (radioButton1.Checked == true)
            {
                listBox1.DataSource = program.orList;
            }
            else
            {
                listBox1.DataSource = program.andList;
            }
           
            // Allow the ListBox to repaint and display the new items.
            listBox1.EndUpdate();
        }



        ////データを選択した時
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

    

            if (listBox1.SelectedIndex == -1)
            {
                return;
            }

            PathData src = program.getPathData(listBox1.SelectedValue.ToString());

            textBox2.Text = src.filePath;
            textBox3.Text = src.sheetName;
            textBox4.Text = src.address;
            textBox1.Text = src.layer;


            //親リストにバインディング
            pListParentSrc.DataSource = src.parentList;
            listBox_pList.DisplayMember = "wideValue";
            listBox_pList.ValueMember = "value";
            listBox_pList.DataSource = pListParentSrc;


            //子リストにバインディング
            pListChildSrc.DataSource = src.childList;
            listBox_cList.DisplayMember = "wideValue";
            listBox_cList.ValueMember = "value";
            listBox_cList.DataSource = pListChildSrc;



        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            //TextFormSearch();   //検索
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
            re.recentDataInsert(program.getPathData(listBox1.SelectedValue.ToString()));
            re.Visible = true;  //MyListを開く   

        }

        private void search_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Excelで該当ファイルを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            program.ExcelOpen(listBox1.SelectedValue.ToString());

        }

        private void 履歴RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

     

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// メイン検索リストのツールStripメニュー変化
        /// </summary>
        private void MainToolStrip()
        {
            contextMenuStrip1.Items[0].Enabled = false;      //開くNG
            contextMenuStrip1.Items[3].Enabled = false;  //親リストNG
            contextMenuStrip2.Items[3].Enabled = false;  //親リストで右クリック親リスト切り離しNG


            if (listBox1.SelectedIndex == -1)
            {
                return;
            }


            PathData src = program.getPathData(listBox1.SelectedValue.ToString());
            if (src.wbOK)
                contextMenuStrip1.Items[0].Enabled = true;  //開くOK

            if (src.parentList.Count > 0)
            {
                contextMenuStrip1.Items[3].Enabled = true;  //親リストOK
                contextMenuStrip2.Items[3].Enabled = true;  //親リストでの右クリック親リスト切り離しOK
            }


        }

        /// <summary>
        /// 子リストのツールStripメニュー変化
        /// </summary>
        private void CListToolStrip()
        {
            contextMenuStrip2.Items[0].Enabled = false;     //開くNG
            contextMenuStrip2.Items[2].Enabled = false;     //MyListNG

            if (listBox_cList.SelectedIndex == -1)
                return;


            //open可能
            if (program.getPathData(listBox_cList.SelectedValue.ToString()).wbOK)
                contextMenuStrip2.Items[0].Enabled = true;     //開くNG

            //MyListOK
            contextMenuStrip2.Items[2].Enabled = true;     //MyListOK
        }


        /// <summary>
        /// 親リストのツールStripメニュー変化
        /// </summary>
        private void PListToolStrip()
        {
            contextMenuStrip2.Items[0].Enabled = false;     //開くNG
            contextMenuStrip2.Items[2].Enabled = false;     //MyListNG

            if (listBox_pList.SelectedIndex == -1)
                return;


            //open可能
            if (program.getPathData(listBox_pList.SelectedValue.ToString()).wbOK)
                contextMenuStrip2.Items[0].Enabled = true;     //開くNG

            //MyListOK
            contextMenuStrip2.Items[2].Enabled = true;     //MyListOK
        }




        /// <summary>
        /// 親リストの選択を変えた場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_pList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PListToolStrip();
        }
        /// <summary>
        /// 子リストの選択を変えた場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_cList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CListToolStrip();
        }



        //子リスト切り離し
        private void list切り離しCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                CustomList pForm = new CustomList(program.orList, richTextBox1.Text);
                pForm.SearchRichTextBox = this.richTextBox1;
            }
            else
            {
                CustomList pForm = new CustomList(program.andList, richTextBox1.Text);
                pForm.SearchRichTextBox = this.richTextBox1;
            }

        }

        //MyListへDBクリックと同じ処理
        private void myListへMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            re.recentDataInsert(program.getPathData(listBox1.SelectedValue.ToString()));
            re.Visible = true;
        }

        private void myListの表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            re.Visible = true;
        }



        private void myListの表示ToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            re.Visible = true;
        }



        /// <summary>
        /// 親プレビュー側のコンテキスト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 開くOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            program.ExcelOpen(listBox_pList.SelectedValue.ToString());
        }

        private void myListの表示ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            re.Visible = true;
        }
        //親リストを切り離す
        private void list切り離しCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PathData path = program.getPathData(listBox1.SelectedValue.ToString());
            CustomList pForm = new CustomList(path.parentList,path.value);
            pForm.SearchRichTextBox = this.richTextBox1;
        }

        private void myListへMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            re.recentDataInsert(program.getPathData(listBox_pList.SelectedValue.ToString()));
        }

        private void listBox_pList_DoubleClick(object sender, EventArgs e)
        {
            //親リストをダブルクリックした場合のみ、検索対象とする
            if ((ListBox)sender != null)
            {
                ListBox list = (ListBox)sender;
                this.richTextBox1.Text = list.Text;
            }

        }


        private void listBox_cList_DoubleClick(object sender, EventArgs e)
        {

            //子リストをダブルクリックした場合、検索対象とする
            if ((ListBox)sender != null)
            {
                ListBox list = (ListBox)sender;
                this.richTextBox1.Text = list.Text;
            }


        }

        private void listBox_pList_MouseMove(object sender, MouseEventArgs e)
        {
            PListToolStrip();
        }

        private void listBox_cList_MouseMove(object sender, MouseEventArgs e)
        {
            CListToolStrip();
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MainToolStrip();
        }
    }
}
