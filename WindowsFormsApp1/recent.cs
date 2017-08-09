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
            
            //とりあえず履歴は２０個まで ⇒　リファクタ
            if (recentSrc.Count > 19)
            {
                recentSrc.RemoveAt(19);
            }

            listBox_recent.EndUpdate();


        }

        private void programBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void listBox_recent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //検索履歴の選択変更　⇒　programに通知を行いメインフォームのrichTextを書き換える
            if( seach != null)
            {
    

            }

        }
    }
}
