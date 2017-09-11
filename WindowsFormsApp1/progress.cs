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
    public partial class progress : Form
    {
        public progress()
        {
            InitializeComponent();

            wholeLabel = this.LabelWhole;
            singleLabel = this.LabelSingle;
            wholeProgress = this.ProgressWhole;
            singleProgress = this.ProgressSingle;

            wholeProgress.Value = 0;
            singleProgress.Value = 0;
            wholeProgress.Minimum = 0;
            singleProgress.Minimum = 0;

        }

        public Label wholeLabel { get; set; }
        public Label singleLabel { get; set; }


        public ProgressBar wholeProgress { get; set; }
        public ProgressBar singleProgress { get; set; }




    }
}
