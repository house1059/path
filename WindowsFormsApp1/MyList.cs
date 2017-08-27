using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PathLink
{
    public partial class MyList : Form
    {
        //別のフォームから値を受け取るよう
        public RichTextBox SearchRichTextBox { get; set; }
        public Proc proc { get; set; }
    
        CustomList customList;
        BindingSource myListSrc;  //検索履歴用Listデータｾｯﾄ

        public MyList()
        {
            InitializeComponent();

            myListSrc = new BindingSource();

            //ダミーデータをいったん入れて削除しておく
            PathData dummy = new PathData();
            dummy.Value = "";
            dummy.WideValue = "";
            myListSrc.DataSource = dummy;

            listBox_myList.DataSource = myListSrc;          //データソースを先に設定しないとValueMem
            listBox_myList.ValueMember = "value";
            listBox_myList.DisplayMember = "wideValue";
            myListSrc.Remove(dummy);


        }

        public void DataInsert( PathData p)
        {
            listBox_myList.BeginUpdate();
            myListSrc.Insert(0, p);
            listBox_myList.ClearSelected();
            listBox_myList.SelectedIndex = 0;
            listBox_myList.EndUpdate();
        }

    
        private void listBox_myList_SelectedIndexChanged(object sender, EventArgs e)
        {

            //インスタンス作成時の動作はリターン
            if(proc == null)
                return;


            contextMyListMenuStrip.Items[0].Enabled = false;  //開くNG
            if (listBox_myList.SelectedIndex == -1)
                return;
            
            PathData p = proc.GetPathData(listBox_myList.SelectedValue.ToString());
            if (p.WbOK)
                contextMyListMenuStrip.Items[0].Enabled = true;  //開くOK

        }
        
        private void Recent_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

 
        private void listBox_recent_DoubleClick(object sender, EventArgs e)
        {
            //ListBoxのオブジェクトが飛んできます。
            if ((ListBox)sender != null)
            {
                //MyListをダブルクリックした場合、メイン画面のtext入力を書き換えたい
                ListBox list = (ListBox)sender;
                this.SearchRichTextBox.Text = list.Text;
            }
        }

        private void MyListToolStripMenuOpen_Click(object sender, EventArgs e)
        {
            proc.ExcelOpen(listBox_myList.SelectedValue.ToString());
        }

        private void listBox_recent_KeyDown(object sender, KeyEventArgs e)
        {
            //Deleteで選択中の項目削除
            if(e.KeyCode == Keys.Delete)
            {
                int count = listBox_myList.SelectedItems.Count;
                listBox_myList.BeginUpdate();
                for(int i = 0; i < count; i++)
                {
                    PathData p = (PathData)listBox_myList.SelectedItem;
                    myListSrc.Remove(p);
                }
                listBox_myList.EndUpdate();

            }

            //Ctrl+Aで全選択
            if (e.KeyCode == Keys.A && e.Control)
            {
                for (int i = 0; i < listBox_myList.Items.Count; i++)
                {
                    listBox_myList.SetSelected(i, true);
                }
            }




        }

        private void MyListToolStripMenuSplit_Click(object sender, EventArgs e)
        {
            List<PathData> pList = new List<PathData>();
            foreach( PathData p in listBox_myList.Items)
            {
                pList.Add(p);
            }
            customList = new CustomList(pList);//→新しいオブジェクトを渡さないとデータソース上から消えてしまう

            customList.titleLabel.Text = "MyListから";
            customList.parentChildLabel.Text = "My";
            customList.SearchRichTextBox = this.SearchRichTextBox;  //メインの検索画面
            customList.re = this;
            customList.proc = this.proc;
            customList.Show();
        }
    }
}
