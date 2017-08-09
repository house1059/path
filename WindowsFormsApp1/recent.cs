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



            if (path.wbOK)
                contextMenuStrip1.Items[0].Enabled = true;  //開くOK

        }
        
        private void Recent_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PathData path = program.getPathData(listBox_recent.SelectedValue.ToString());


            Excel._Application ex = null; ;
            Excel._Workbook wb = null;
            Excel.Worksheet sh = null;
            Excel.Range rn = null;

            try
            {
                ex = new Excel.Application();
                wb = ex.Workbooks.Open(path.filePath, true, true);
                sh = ex.Sheets[path.sheetName];
                sh.Select();

                rn = ex.Range[path.address, path.address];
                rn.Select();

                ex.Visible = true;
                System.Threading.Thread.Sleep(1000);

                Marshal.ReleaseComObject(rn);
                Marshal.ReleaseComObject(sh);
                Marshal.ReleaseComObject(wb);
                Marshal.ReleaseComObject(ex);


            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
