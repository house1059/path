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
        public RichTextBox SearchRichTextBox { get; set; }
        public Label titleLabel { get; set; } = new Label();
        public Label parentChildLabel { get; set; } = new Label();
        BindingSource dataSrc = null;

        public CustomList(List<PathData> p )
        {
            InitializeComponent();
            dataSrc = new BindingSource();
            dataSrc.DataSource = p;

            listBox_parent.ValueMember = "value";
            listBox_parent.DisplayMember = "wideValue";

            listBox_parent.DataSource = dataSrc;
            label1 = titleLabel;
            label2 = parentChildLabel;

            this.Show();
        }

        private void ParentList_Load(object sender, EventArgs e)
        {

        }

        private void listBox_parent_SelectedIndexChanged(object sender, EventArgs e)
        {


            PathData path = program.getPathData(listBox_parent.SelectedValue.ToString());
            contextMenuStrip1.Items[0].Enabled = false;  //開くNG
            contextMenuStrip1.Items[2].Enabled = false;  //MyListNG
            contextMenuStrip1.Items[3].Enabled = false;  //List切り離しNG

            //何も選択していない場合は終了
            if (listBox_parent.SelectedIndex == -1)
                return;

            if (path.wbOK)
                contextMenuStrip1.Items[0].Enabled = true;  //開くOK

            contextMenuStrip1.Items[2].Enabled = true;  //MyListOK
            contextMenuStrip1.Items[3].Enabled = true;  //List切り離しOK




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
    }
}
