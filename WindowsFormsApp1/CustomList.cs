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
        public Recent re { get; set; }
        BindingSource dataSrc = null;
      

        public CustomList(List<PathData> p , string s )
        {
            InitializeComponent();
            dataSrc = new BindingSource();
            dataSrc.DataSource = p;

            listBox_Custom.ValueMember = "value";
            listBox_Custom.DisplayMember = "wideValue";

            listBox_Custom.DataSource = dataSrc;
            this.label1.Text = s;

            
        }





        private void listBox_parent_SelectedIndexChanged(object sender, EventArgs e)
        {
            PathData path = program.getPathData(listBox_Custom.SelectedValue.ToString());
            contextCustomMenuStrip.Items[0].Enabled = false;  //開くNG
            contextCustomMenuStrip.Items[2].Enabled = false;  //MyListNG

            //何も選択していない場合は終了
            if (listBox_Custom.SelectedIndex == -1)
                return;

            if (path.wbOK)
                contextCustomMenuStrip.Items[0].Enabled = true;  //開くOK

            contextCustomMenuStrip.Items[2].Enabled = true;  //MyListOK
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

        private void listBox_parent_DoubleClick(object sender, EventArgs e)
        {
            //ListBoxのオブジェクトが飛んできます。
            if ((ListBox)sender != null)
            {
                //MyListをダブルクリックした場合、メイン画面のtext入力を書き換えたい
                ListBox list = (ListBox)sender;
                this.SearchRichTextBox.Text = list.Text;
            }
        }

        private void CustomToolStripMenuOpen_Click(object sender, EventArgs e)
        {
            program.ExcelOpen(listBox_Custom.SelectedValue.ToString());
        }

        private void CustomToolStripMenuToMyList_Click(object sender, EventArgs e)
        {
            re.recentDataInsert(program.getPathData(listBox_Custom.SelectedValue.ToString()));
            re.Visible = true;
        }
    }
}
