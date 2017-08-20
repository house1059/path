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

        //他のフォームとの連携用
        Proc proc;
        MyList myList;
        CustomList customList;



        BindingSource searchSrc { get; } = new BindingSource();             //メイン画面用のバインディングデータ
        BindingSource searchLayerSrc { get; } = new BindingSource();        //layer用 cmdboxなので
        BindingSource pListParentSrc { get; } = new BindingSource();        //親の一時リスト
        BindingSource pListChildSrc { get; } = new BindingSource();         //子の一時リスト


        public Search()
        {
            InitializeComponent();
            proc = new Proc();
            myList = new MyList();
            myList.proc = this.proc;


            myList.SearchRichTextBox = this.richTextBox1;    //子フォームに親のインスタンスを通知
            myList.Visible = false;

            
        }
        


        //検索の実態
        private void TextFormSearch( )
        {
            proc.TextSearch(richTextBox1.Text, comboBox1.Text);
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
                proc.ReadPathFile(fd.FileName);
                label4.Text = fd.SafeFileName;

                TextFormSearch();   //検索
                searchLayerSrc.DataSource = proc.resultLayer;
                searchLayerSrc.Insert(0,"");
                comboBox1.DataSource = searchLayerSrc;
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
                listBox1.DataSource = proc.orList;
            }
            else
            {
                listBox1.DataSource = proc.andList;
            }
            listBox_cList.DataSource = null;
            listBox_pList.DataSource = null;

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


            //マルチ選択の場合はMyListへ保存のみ許可する
            if( listBox1.SelectedItems.Count > 1)
            {
                textBox2.Text = "non";
                textBox3.Text = "non";
                textBox4.Text = "non";
                textBox1.Text = "non";
                listBox_cList.DataSource = null;
                listBox_pList.DataSource = null;
                MainToolStrip(true);
            }else {
                PathData p = proc.getPathData(listBox1.SelectedValue.ToString());

                textBox2.Text = p.filePath;
                textBox3.Text = p.sheetName;
                textBox4.Text = p.address;
                textBox1.Text = p.layer;


                //親リストにバインディング
                pListParentSrc.DataSource = p.parentList;
                listBox_pList.DisplayMember = "wideValue";
                listBox_pList.ValueMember = "value";
                listBox_pList.DataSource = pListParentSrc;


                //子リストにバインディング
                pListChildSrc.DataSource = p.childList;
                listBox_cList.DisplayMember = "wideValue";
                listBox_cList.ValueMember = "value";
                listBox_cList.DataSource = pListChildSrc;


                MainToolStrip(false);
            }

        }


        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            TextFormSearch();   //検索
        }


        /// <summary>
        /// 検索結果をDBCした場合、ExcelOpen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
            {
                return;
            }

            //メイン画面はダブルクリックで開く仕様に変更
            PathData p = proc.getPathData(listBox1.SelectedValue.ToString());
            if(p.wbOK)
                proc.ExcelOpen(p.value);

        }

   

        /// <summary>
        /// メイン検索リストのツールStripメニュー変化　
        /// 引数：マルチ選択時 true
        /// </summary>
        private void MainToolStrip(bool multi)
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

            if( !multi)
            {
                PathData src = proc.getPathData(listBox1.SelectedValue.ToString());
                if (src.wbOK)
                    contextMainMenuStrip.Items[0].Enabled = true;  //開くOK
            }
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
            if (proc.getPathData(listBox_cList.SelectedValue.ToString()).wbOK)
                contextChildMenuStrip.Items[0].Enabled = true;     //開くOK




            //MyListOK
            contextChildMenuStrip.Items[2].Enabled = true;     //MyListOK
            contextChildMenuStrip.Items[3].Enabled = true;     //List切り離しOK
        }


        /// <summary>
        /// 親リストのツールStripメニュー変化
        /// </summary>
        private void PListToolStrip(bool multi)
        {
            contextParentMenuStrip.Items[0].Enabled = false;     //開くNG
            contextParentMenuStrip.Items[2].Enabled = false;     //MyListNG
            contextParentMenuStrip.Items[3].Enabled = false;     //List切り離しNG

            if (listBox_pList.SelectedIndex == -1)
                return;

            if (!multi)
            {
                //open可能
                if (proc.getPathData(listBox_pList.SelectedValue.ToString()).wbOK)
                    contextParentMenuStrip.Items[0].Enabled = true;     //開くOK
            }
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
            if (listBox_pList.SelectedItems.Count > 1)
            {
                PListToolStrip(true);
            }
            else
            {
                PListToolStrip(false);
            }
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

                //open可能か判定
                PathData p = proc.getPathData(list.Text);
                if (p.wbOK)
                    proc.ExcelOpen(p);
            }

        }


        private void listBox_cList_DoubleClick(object sender, EventArgs e)
        {
            //子リストをダブルクリックした場合、検索対象とする
            if ((ListBox)sender != null)
            {
                ListBox list = (ListBox)sender;

                //open可能か判定
                PathData p = proc.getPathData(list.Text);
                if (p.wbOK)
                    proc.ExcelOpen(p);
            }
        }

        private void listBox_pList_MouseMove(object sender, MouseEventArgs e)
        {
            if (listBox_pList.SelectedItems.Count > 1)
            {
                PListToolStrip(true);
            }
            else
            {
                PListToolStrip(false);
            }
        }

        private void listBox_cList_MouseMove(object sender, MouseEventArgs e)
        {
            CListToolStrip();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextFormSearch();
        }



        private void MainToolStripMenuOpen_Click(object sender, EventArgs e)
        {
           proc.ExcelOpen(listBox1.SelectedValue.ToString());
        }

        private void MainToolStripToMyList_Click(object sender, EventArgs e)
        {
                for( int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    PathData p = (PathData)listBox1.SelectedItems[i];
                    myList.DataInsert(proc.getPathData(p.value));
                }
                myList.Visible = true;
        }

        private void MainToolStripSplit_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                customList = new CustomList(proc.orList);
            }
            else
            {
                customList = new CustomList(proc.andList);
            }
            customList.titleLabel.Text = this.richTextBox1.Text;
            customList.parentChildLabel.Text = "本";
            customList.SearchRichTextBox = this.richTextBox1;
            customList.re = myList;
            customList.proc = proc;
            customList.Show();
        }

        private void MainToolStripMyListView_Click(object sender, EventArgs e)
        {
            myList.Visible = true;
        }

        private void ChildStripMenuOpen_Click(object sender, EventArgs e)
        {
            proc.ExcelOpen(listBox_cList.SelectedValue.ToString());
        }

        private void ChildToolStripMenuToMyList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_cList.SelectedItems.Count; i++)
            {
                PathData p = (PathData)listBox_cList.SelectedItems[i];
                myList.DataInsert(proc.getPathData(p.value));
            }
            myList.Visible = true;
        }

        private void ChildToolStripMenuSplit_Click(object sender, EventArgs e)
        {
            PathData path = proc.getPathData(listBox1.SelectedValue.ToString());
            customList = new CustomList(new List<PathData>( path.childList) );  //→新しいオブジェクトを渡さないとデータソース上から消えてしまう
            customList.titleLabel.Text = this.listBox1.SelectedValue.ToString();
            customList.parentChildLabel.Text = "子";
            customList.SearchRichTextBox = this.richTextBox1;
            customList.re = myList;
            customList.proc = this.proc;
            customList.Show();
        }

        private void ChildToolStripMenuListView_Click(object sender, EventArgs e)
        {
            myList.Visible = true;
        }

        private void ParentToolStripMenuOpen_Click(object sender, EventArgs e)
        {
            proc.ExcelOpen(listBox_pList.SelectedValue.ToString());
        }

        private void ParentToolStripMenuToMyList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_pList.SelectedItems.Count; i++)
            {
                PathData p = (PathData)listBox_pList.SelectedItems[i];
                myList.DataInsert(proc.getPathData(p.value));
            }
            myList.Visible = true;
        }

        private void ParentToolStripMenuSplit_Click(object sender, EventArgs e)
        {
            PathData path = proc.getPathData(listBox1.SelectedValue.ToString());
            customList = new CustomList(new List<PathData>( path.parentList));//→新しいオブジェクトを渡さないとデータソース上から消えてしまう

            customList.titleLabel.Text = this.listBox1.SelectedValue.ToString();
            customList.parentChildLabel.Text = "親";
            customList.SearchRichTextBox = this.richTextBox1;
            customList.re = myList;
            customList.proc = this.proc;
            customList.Show();
        }

        private void ParentToolStripMenuListView_Click(object sender, EventArgs e)
        {
            myList.Visible = true;
        }

        private void Search_Resize(object sender, EventArgs e)
        {
           
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItems.Count > 1)
            {
       
                MainToolStrip(true);
            }
            else
            {
       
                MainToolStrip(false);
            }
        }

        private void listBox_cList_KeyDown(object sender, KeyEventArgs e)
        {
            //Ctrl+Aで全選択
            if(e.KeyCode == Keys.A && e.Control)
            {
                for (int i = 0; i < listBox_cList.Items.Count; i++)
                {
                    listBox_cList.SetSelected(i, true);
                }
            }
        }

        private void listBox_pList_KeyDown(object sender, KeyEventArgs e)
        {
            //Ctrl+Aで全選択
            if (e.KeyCode == Keys.A && e.Control)
            {
                for (int i = 0; i < listBox_pList.Items.Count; i++)
                {
                    listBox_pList.SetSelected(i, true);
                }
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //Ctrl+Aで全選択
            if (e.KeyCode == Keys.A && e.Control)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SetSelected(i, true);
                }
            }
        }
    }
}
