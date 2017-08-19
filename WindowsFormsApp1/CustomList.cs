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
    public partial class CustomList : Form
    {
        //別のフォームから値を受け取るよう
        public RichTextBox SearchRichTextBox { get; set; } = new RichTextBox();
        public Label titleLabel { get; set; } = new Label();
        public Label parentChildLabel { get; set; } = new Label();
        public MyList re { get; set; }
        public Proc proc { get; set; }
        BindingSource dataSrc = null;


        public CustomList(List<PathData> p  )
        {
            InitializeComponent();
            dataSrc = new BindingSource();
            dataSrc.DataSource = p;

            listBox_Custom.ValueMember = "value";
            listBox_Custom.DisplayMember = "wideValue";

            listBox_Custom.DataSource = dataSrc;
            titleLabel = this.label1;
            parentChildLabel = this.label2;



        }

        

        private void label1_Click(object sender, EventArgs e)
        {
            if ((Label)sender != null)
            {
                //MyListのラベルをダブルクリックした場合、メイン画面のtext入力を書き換えたい
                Label label = (Label)sender;

                this.SearchRichTextBox.Text = label.Text;
            }
        }


        private void CustomToolStripMenuOpen_Click(object sender, EventArgs e)
        {
            proc.ExcelOpen(listBox_Custom.SelectedValue.ToString());
        }

        private void CustomToolStripMenuToMyList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_Custom.SelectedItems.Count; i++)
            {
                PathData p = (PathData)listBox_Custom.SelectedItems[i];
                re.DataInsert(proc.getPathData(p.value));
            }
            re.Visible = true;
        }

        private void listBox_Custom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //インスタンス作成時の自動実行は避ける
            if (proc == null)
                return;


            contextCustomMenuStrip.Items[0].Enabled = false;  //開くNG
            contextCustomMenuStrip.Items[2].Enabled = false;  //MyListNG

            //何も選択していない場合は終了
            if (listBox_Custom.SelectedIndex == -1)
                return;

            if (listBox_Custom.SelectedItems.Count == 1)
            {
                PathData path = proc.getPathData(listBox_Custom.SelectedValue.ToString());
                if (path.wbOK)
                    contextCustomMenuStrip.Items[0].Enabled = true;  //開くOK
            }
            contextCustomMenuStrip.Items[2].Enabled = true;  //MyListOK
        }

        private void listBox_Custom_DoubleClick(object sender, EventArgs e)
        {
            //ListBoxのオブジェクトが飛んできます。
            if ((ListBox)sender != null)
            {
                //MyListをダブルクリックした場合、メイン画面のtext入力を書き換えたい
                ListBox list = (ListBox)sender;
                this.SearchRichTextBox.Text = list.Text;
            }
        }

        private void listBox_Custom_KeyDown(object sender, KeyEventArgs e)
        {
            //Deleteで選択中の項目削除
            if (e.KeyCode == Keys.Delete)
            {
                int count = listBox_Custom.SelectedItems.Count;
                for (int i = 0; i < count; i++)
                {
                    PathData p = (PathData)listBox_Custom.SelectedItem;
                    dataSrc.Remove(p);
                }


                //DisposeするとpListのindexに影響がでる？
                //if (listBox_Custom.Items.Count == 0)
                //{
                //   if( MessageBox.Show("Itemが無くなりました。Formを閉じますか？", "閉じる？", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //    {
                //        me.Close();
                //    }                
                // }


            }
        }
    }
}
