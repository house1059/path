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
        public string argument { get; }

        BindingSource recentSrc = new BindingSource();  //検索履歴用Listデータｾｯﾄ

        public recent()
        {
            InitializeComponent();
        }






    }
}
