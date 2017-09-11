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
            this.LabelWhole = wholeLabel;
            this.LabelSingle = singleLabel;
            this.ProgressWhole = wholeProgress;
            this.ProgressSingle = singleProgress;
        }

        public Label wholeLabel { get; }
        public Label singleLabel { get; }


        public ProgressBar wholeProgress { get; }
        public ProgressBar singleProgress { get; }


    }
}
