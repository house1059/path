using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Recent : Form
    {
        //別のフォームから値を受け取るよう
        public RichTextBox SearchRichTextBox { get; set; }


        BindingSource recentSrc;  //検索履歴用Listデータｾｯﾄ

        public Recent()
        {
            InitializeComponent();

            recentSrc = new BindingSource();
            //recentSrc.DataMember = "value";
            listBox_recent.ValueMember = "value";
            listBox_recent.DisplayMember = "wideValue";

        }

        public void recentDataInsert( PathData p)
        {
            listBox_recent.BeginUpdate();
            recentSrc.Insert(0, p);
            listBox_recent.ValueMember = "value";
            listBox_recent.DisplayMember = "wideValue";
            listBox_recent.DataSource = recentSrc;
            listBox_recent.SelectedIndex = 0;


            listBox_recent.EndUpdate();


        }

        private void programBindingSource_CurrentChanged(object sender, EventArgs e)
        {


        }

        private void listBox_recent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_recent.SelectedIndex == -1)
                return;


            PathData path = program.getPathData(listBox_recent.SelectedValue.ToString());
            contextMyListMenuStrip.Items[0].Enabled = false;  //開くNG
      
            if (path.wbOK)
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
            program.ExcelOpen(listBox_recent.SelectedValue.ToString());
        }

        private void listBox_recent_KeyDown(object sender, KeyEventArgs e)
        {
            //Deleteで選択中の項目削除
            if(e.KeyCode == Keys.Delete)
            {
                int count = listBox_recent.SelectedItems.Count;
                for(int i = 0; i < count; i++)
                {
                    PathData p = (PathData)listBox_recent.SelectedItem;
                    recentSrc.Remove(p);
                }
            }
        }
    }
}
