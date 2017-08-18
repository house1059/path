namespace WindowsFormsApp1
{
    partial class Recent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox_recent = new System.Windows.Forms.ListBox();
            this.contextMyListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MyListToolStripMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMyListMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_recent
            // 
            this.listBox_recent.ContextMenuStrip = this.contextMyListMenuStrip;
            this.listBox_recent.ForeColor = System.Drawing.Color.Gray;
            this.listBox_recent.FormattingEnabled = true;
            this.listBox_recent.ItemHeight = 12;
            this.listBox_recent.Location = new System.Drawing.Point(-2, 25);
            this.listBox_recent.Name = "listBox_recent";
            this.listBox_recent.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_recent.Size = new System.Drawing.Size(288, 244);
            this.listBox_recent.TabIndex = 0;
            this.listBox_recent.SelectedIndexChanged += new System.EventHandler(this.listBox_recent_SelectedIndexChanged);
            this.listBox_recent.DoubleClick += new System.EventHandler(this.listBox_recent_DoubleClick);
            this.listBox_recent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_recent_KeyDown);
            // 
            // contextMyListMenuStrip
            // 
            this.contextMyListMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MyListToolStripMenuOpen,
            this.toolStripMenuItem1});
            this.contextMyListMenuStrip.Name = "contextMenuStrip1";
            this.contextMyListMenuStrip.Size = new System.Drawing.Size(120, 32);
            // 
            // MyListToolStripMenuOpen
            // 
            this.MyListToolStripMenuOpen.Enabled = false;
            this.MyListToolStripMenuOpen.Name = "MyListToolStripMenuOpen";
            this.MyListToolStripMenuOpen.Size = new System.Drawing.Size(119, 22);
            this.MyListToolStripMenuOpen.Text = "開く(&O)";
            this.MyListToolStripMenuOpen.Click += new System.EventHandler(this.MyListToolStripMenuOpen_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(116, 6);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ContextMenuStrip = this.contextMyListMenuStrip;
            this.label1.Location = new System.Drawing.Point(-2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "MyList（ここからでも飛べます）";
            // 
            // Recent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ContextMenuStrip = this.contextMyListMenuStrip;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_recent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Recent";
            this.Text = "MyList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Recent_FormClosing);
            this.contextMyListMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_recent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMyListMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MyListToolStripMenuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}