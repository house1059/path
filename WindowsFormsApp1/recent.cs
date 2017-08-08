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
    public partial class recent : Form
    {
        //別のフォームから値を受け取るよう
        //public string argument { get; }

        BindingSource recentSrc = new BindingSource();  //検索履歴用Listデータｾｯﾄ


        public recent()
        {
            InitializeComponent();

            listBox_recent.DataSource = recentSrc;
            
        }

        public void recentDataInsert( string b)
        {
            listBox_recent.BeginUpdate();

            recentSrc.Insert(0, b);
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


        }
    }
}
