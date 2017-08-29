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


namespace PathLink
{
    public partial class Search : Form
    {

        //他のフォームとの連携用
        Proc proc;
        MyList myList;
        CustomList customList;



        BindingSource SearchSrc { get; } = new BindingSource();             //メイン画面用のバインディングデータ
        BindingSource SearchLayerSrc { get; } = new BindingSource();        //layer用 cmdboxなので
        BindingSource ListParentSrc { get; } = new BindingSource();        //親の一時リスト
        BindingSource ListChildSrc { get; } = new BindingSource();         //子の一時リスト


        public Search()
        {
            InitializeComponent();
            proc = new Proc();
            myList = new MyList()
            {
                proc = this.proc,
                SearchRichTextBox = this.richTextBox1,    //子フォームに親のインスタンスを通知
                Visible = false
            };
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
        private void Bt_read_Click(object sender, EventArgs e)
        {
            //ダイアログボックスの表示
            OpenFileDialog fd = new OpenFileDialog()
            {
                Filter = "◎PathFile(*.txt)|*.txt;|全てのﾌｧｲﾙ(*.*)|*.*",
                Title = "PathLinkﾃﾞｰﾀﾌｧｲﾙを選択してください"
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                proc.ReadPathFile(fd.FileName);
                label4.Text = fd.SafeFileName;

                TextFormSearch();   //検索
                SearchLayerSrc.DataSource = proc.ResultLayer;
                SearchLayerSrc.Insert(0,"");
                comboBox1.DataSource = SearchLayerSrc;
                comboBox1.SelectedIndex = 0;

            }
            ViewUpdate();   //再描画
        }



        //clearボタン
        private void Bt_clear_Click(object sender, EventArgs e)
        {
            ViewClear();
        }

        private void Bt_check_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ViewUpdate();   //再描画
        }

  

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            TextFormSearch();   //検索
        }

        private void ViewUpdate()   //再描画の処理
        {
            listBox1.BeginUpdate();

            listBox_cList.DataSource = null;
            listBox_pList.DataSource = null;

            listBox1.DataSource = radioButton1.Checked ? proc.OrList : proc.AndList;
            listBox1.ValueMember = "value";
            listBox1.DisplayMember = "wideValue";

            MainToolStrip(false);    //まずここでクリア
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Text = "";
            listBox_cList.DataSource = null;
            listBox_pList.DataSource = null;


            //マルチ選択の場合はMyListへ保存のみ許可する
            if (listBox1.SelectedItems.Count > 1)
            {
                textBox2.Text = "non";
                textBox3.Text = "non";
                textBox4.Text = "non";
                textBox1.Text = "non";
                MainToolStrip(true);
            }
            else
            {
                try
                {

                    PathData p = proc.GetPathData(listBox1.SelectedValue.ToString());

                    textBox2.Text = p.FilePath;
                    textBox3.Text = p.SheetName;
                    textBox4.Text = p.Address;
                    textBox1.Text = p.Layer;


                    //親リストにバインディング
                    ListParentSrc.DataSource = p.parentList;
                    listBox_pList.DataSource = ListParentSrc;
                    listBox_pList.DisplayMember = "wideValue";
                    listBox_pList.ValueMember = "value";


                    //子リストにバインディング
                    ListChildSrc.DataSource = p.childList;
                    listBox_cList.DataSource = ListChildSrc;
                    listBox_cList.DisplayMember = "wideValue";
                    listBox_cList.ValueMember = "value";

                }
                catch (NullReferenceException)
                {
                    //getPathDataでnullが返ってきた場合
                }
                finally
                {
                    MainToolStrip(false);
                }
            }
            // Allow the ListBox to repaint and display the new items.
            listBox1.EndUpdate();


        }



        ////データを選択した時
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewUpdate();
            MainToolStrip(false);
        }


        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            TextFormSearch();   //検索
        }


        /// <summary>
        /// 検索結果をDBCした場合、ExcelOpen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
            {
                return;
            }

            //メイン画面はダブルクリックで開く仕様に変更
            PathData p = proc.GetPathData(listBox1.SelectedValue.ToString());
            if(p.WbOK)
                proc.ExcelOpen(p.Value);

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
                PathData src = proc.GetPathData(listBox1.SelectedValue.ToString());
                if (src.WbOK)
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

            if (listBox_cList.SelectedIndex == -1 || listBox_cList.SelectedValue == null)
                return;


            //open可能
            if (proc.GetPathData(listBox_cList.SelectedValue.ToString()).WbOK)
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
                if (proc.GetPathData(listBox_pList.SelectedValue.ToString()).WbOK)
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
        private void ListBox_pList_SelectedIndexChanged(object sender, EventArgs e)
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
        private void ListBox_cList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CListToolStrip();
        }


        private void ListBox_pList_DoubleClick(object sender, EventArgs e)
        {
            //親リストをダブルクリックした場合のみ、検索対象とする
            if ((ListBox)sender != null)
            {
                ListBox list = (ListBox)sender;

                //open可能か判定
                PathData p = proc.GetPathData(list.Text);
                if (p.WbOK)
                    proc.ExcelOpen(p);
            }

        }


        private void ListBox_cList_DoubleClick(object sender, EventArgs e)
        {
            //子リストをダブルクリックした場合、検索対象とする
            if ((ListBox)sender != null)
            {
                ListBox list = (ListBox)sender;

                //open可能か判定
                PathData p = proc.GetPathData(list.Text);
                if (p.WbOK)
                    proc.ExcelOpen(p);
            }
        }

        private void ListBox_pList_MouseMove(object sender, MouseEventArgs e)
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

        private void ListBox_cList_MouseMove(object sender, MouseEventArgs e)
        {
            CListToolStrip();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                    myList.DataInsert(proc.GetPathData(p.Value));
                }
                myList.Visible = true;
        }

        private void MainToolStripSplit_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                customList = new CustomList(proc.OrList);
            }
            else
            {
                customList = new CustomList(proc.AndList);
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
                myList.DataInsert(proc.GetPathData(p.Value));
            }
            myList.Visible = true;
        }

        private void ChildToolStripMenuSplit_Click(object sender, EventArgs e)
        {
            PathData path = proc.GetPathData(listBox1.SelectedValue.ToString());
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
                myList.DataInsert(proc.GetPathData(p.Value));
            }
            myList.Visible = true;
        }

        private void ParentToolStripMenuSplit_Click(object sender, EventArgs e)
        {
            PathData path = proc.GetPathData(listBox1.SelectedValue.ToString());
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
            //textBoxが二つあるためアンカー設定だと上手く行かないので手動でリサイズする

            //親側のリサイズ
            //          listBox_cList.Size = new Size(331,112);
          //  listBox_pList.Size = new Size( this.Width / 2 , listBox_pList.Size.Height);
          //  listBox_cList.Location = new Point(listBox_pList.Size.Width + 12, listBox_cList.Location.Y);
        }

        private void ListBox1_MouseMove(object sender, MouseEventArgs e)
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

        private void ListBox_cList_KeyDown(object sender, KeyEventArgs e)
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

        private void ListBox_pList_KeyDown(object sender, KeyEventArgs e)
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

        private void ListBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void RichTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = this.richTextBox1.Text.Length;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog()
            {
                Filter = "データ変換ツール(*.xlsm)|*.xlsm;|全てのﾌｧｲﾙ(*.*)|*.*",
                Title = "データ変換ツールを選択してください"
            };

            if (fd.ShowDialog() == DialogResult.OK)
            {

                XlsPath x = new XlsPath();
                //x.DataConvert(fd.FileName);    //ここで引数を渡せばいいのでは？

            }


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listBox_pList_Resize(object sender, EventArgs e)
        {
                
        }
    }
}
