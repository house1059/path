using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace WindowsFormsApp1
{
    public partial class Recent : Form
    {
        //別のフォームから値を受け取るよう
        //public string argument { get; }

        public Search seach { get; set; }


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
            PathData path = program.getPathData(listBox_recent.SelectedValue.ToString());
            contextMenuStrip1.Items[0].Enabled = false;  //開くNG
            contextMenuStrip1.Items[2].Enabled = false;  //親リストNG

            if (path.wbOK)
                contextMenuStrip1.Items[0].Enabled = true;  //開くOK

            if (path.filePath != "" && path.sheetName != "" && path.address != "")
                contextMenuStrip1.Items[2].Enabled = true;  //親リストOK

        }
        
        private void Recent_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            program.ExcelOpen(listBox_recent.SelectedValue.ToString());
        }
    }
}
