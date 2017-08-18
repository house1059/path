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

        CustomList pForm;

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
                bindingSrc.Insert(0,"");
                comboBox1.DataSource = bindingSrc;
                comboBox1.SelectedIndex = 0;

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

            MainToolStrip();

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
            //現在の表示しているテキストをMyListへ送る
            if(listBox1.SelectedIndex == -1)
            {
                return;
            }

            //メイン画面はダブルクリックで開く仕様に変更
            PathData p = program.partsDic[listBox1.SelectedValue.ToString()];
            if(p.wbOK)
                program.ExcelOpen(p.value);

            /*
            re.recentDataInsert(program.getPathData(listBox1.SelectedValue.ToString()));
            re.Visible = true;  //MyListを開く   
            */
        }

        private void search_Load(object sender, EventArgs e)
        {

        }

   

     

        /// <summary>
        /// メイン検索リストのツールStripメニュー変化
        /// </summary>
        private void MainToolStrip()
        {
            //メインメニュー（パーソナル）時のStrip
            contextMainMenuStrip.Items[0].Enabled = false;        //開くNG
            contextMainMenuStrip.Items[2].Enabled = false;        //MyListへNG
            contextMainMenuStrip.Items[3].Enabled = true;        //List切り離しOK
            contextMainMenuStrip.Items[5].Enabled = true;         //MyListの表示OK



            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            PathData src = program.getPathData(listBox1.SelectedValue.ToString());

            if (src.wbOK)
                contextMainMenuStrip.Items[0].Enabled = true;  //開くOK
            
            contextMainMenuStrip.Items[2].Enabled = true;     //MyListへOK

        }

        /// <summary>
        /// 子リストのツールStripメニュー変化
        /// </summary>
        private void CListToolStrip()
        {
            contextChildMenuStrip.Items[0].Enabled = false;     //開くNG
            contextChildMenuStrip.Items[2].Enabled = false;     //MyListNG
            contextChildMenuStrip.Items[3].Enabled = false;     //List切り離しNG

            if (listBox_cList.SelectedIndex == -1)
                return;


            //open可能
            if (program.getPathData(listBox_cList.SelectedValue.ToString()).wbOK)
                contextChildMenuStrip.Items[0].Enabled = true;     //開くOK

            //MyListOK
            contextChildMenuStrip.Items[2].Enabled = true;     //MyListOK
            contextChildMenuStrip.Items[3].Enabled = true;     //List切り離しOK
        }


        /// <summary>
        /// 親リストのツールStripメニュー変化
        /// </summary>
        private void PListToolStrip()
        {
            contextParentMenuStrip.Items[0].Enabled = false;     //開くNG
            contextParentMenuStrip.Items[2].Enabled = false;     //MyListNG
            contextParentMenuStrip.Items[3].Enabled = false;     //List切り離しNG

            if (listBox_pList.SelectedIndex == -1)
                return;


            //open可能
            if (program.getPathData(listBox_pList.SelectedValue.ToString()).wbOK)
                contextParentMenuStrip.Items[0].Enabled = true;     //開くOK

            //MyListOK
            contextParentMenuStrip.Items[2].Enabled = true;     //MyListOK
            contextParentMenuStrip.Items[3].Enabled = true;     //List切り離しOK
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextFormSearch();
        }



        private void MainToolStripMenuOpen_Click(object sender, EventArgs e)
        {
            program.ExcelOpen(listBox1.SelectedValue.ToString());
        }

        private void MainToolStripToMyList_Click(object sender, EventArgs e)
        {
            re.recentDataInsert(program.getPathData(listBox1.SelectedValue.ToString()));
            re.Visible = true;
        }

        private void MainToolStripSplit_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                pForm = new CustomList(program.orList);
            }
            else
            {
                pForm = new CustomList(program.andList);
            }
            pForm.titleLabel.Text = this.listBox1.Text;
            pForm.parentChildLabel.Text = "本";
            pForm.SearchRichTextBox = this.richTextBox1;
            pForm.re = re;
            pForm.Show();
        }

        private void MainToolStripMyListView_Click(object sender, EventArgs e)
        {
            re.Visible = true;
        }

        private void ChildStripMenuOpen_Click(object sender, EventArgs e)
        {
            program.ExcelOpen(listBox_cList.SelectedValue.ToString());
        }

        private void ChildToolStripMenuToMyList_Click(object sender, EventArgs e)
        {
            re.recentDataInsert(program.getPathData(listBox_cList.SelectedValue.ToString()));
            re.Visible = true;
        }

        private void ChildToolStripMenuSplit_Click(object sender, EventArgs e)
        {
            PathData path = program.getPathData(listBox1.SelectedValue.ToString());
            pForm = new CustomList( path.childList );
            pForm.titleLabel.Text = this.listBox1.SelectedValue.ToString();
            pForm.parentChildLabel.Text = "子";
            pForm.SearchRichTextBox = this.richTextBox1;
            pForm.re = re;
            pForm.Show();
        }

        private void ChildToolStripMenuListView_Click(object sender, EventArgs e)
        {
            re.Visible = true;
        }

        private void ParentToolStripMenuOpen_Click(object sender, EventArgs e)
        {
            program.ExcelOpen(listBox_pList.SelectedValue.ToString());
        }

        private void ParentToolStripMenuToMyList_Click(object sender, EventArgs e)
        {
            re.recentDataInsert(program.getPathData(listBox_pList.SelectedValue.ToString()));
            re.Visible = true;
        }

        private void ParentToolStripMenuSplit_Click(object sender, EventArgs e)
        {
            PathData path = program.getPathData(listBox1.SelectedValue.ToString());
            pForm = new CustomList(path.parentList);
            pForm.titleLabel.Text = this.listBox1.SelectedValue.ToString();
            pForm.parentChildLabel.Text = "親";
            pForm.SearchRichTextBox = this.richTextBox1;
            pForm.re = re;
            pForm.Show();
        }

        private void ParentToolStripMenuListView_Click(object sender, EventArgs e)
        {
            re.Visible = true;
        }

    }
}
