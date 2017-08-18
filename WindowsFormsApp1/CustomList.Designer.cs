namespace WindowsFormsApp1
{
    partial class CustomList
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
            this.listBox_Custom = new System.Windows.Forms.ListBox();
            this.contextCustomMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CustomToolStripMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.CustomToolStripMenuToMyList = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextCustomMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Custom
            // 
            this.listBox_Custom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Custom.ContextMenuStrip = this.contextCustomMenuStrip;
            this.listBox_Custom.FormattingEnabled = true;
            this.listBox_Custom.ItemHeight = 12;
            this.listBox_Custom.Location = new System.Drawing.Point(-3, 29);
            this.listBox_Custom.Name = "listBox_Custom";
            this.listBox_Custom.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Custom.Size = new System.Drawing.Size(391, 268);
            this.listBox_Custom.TabIndex = 0;
            this.listBox_Custom.SelectedIndexChanged += new System.EventHandler(this.listBox_Custom_SelectedIndexChanged);
            this.listBox_Custom.DoubleClick += new System.EventHandler(this.listBox_Custom_DoubleClick);
            this.listBox_Custom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_Custom_KeyDown);
            // 
            // contextCustomMenuStrip
            // 
            this.contextCustomMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomToolStripMenuOpen,
            this.toolStripMenuItem1,
            this.CustomToolStripMenuToMyList});
            this.contextCustomMenuStrip.Name = "contextMenuStrip1";
            this.contextCustomMenuStrip.Size = new System.Drawing.Size(147, 54);
            // 
            // CustomToolStripMenuOpen
            // 
            this.CustomToolStripMenuOpen.Enabled = false;
            this.CustomToolStripMenuOpen.Name = "CustomToolStripMenuOpen";
            this.CustomToolStripMenuOpen.Size = new System.Drawing.Size(146, 22);
            this.CustomToolStripMenuOpen.Text = "開く(&O)";
            this.CustomToolStripMenuOpen.Click += new System.EventHandler(this.CustomToolStripMenuOpen_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // CustomToolStripMenuToMyList
            // 
            this.CustomToolStripMenuToMyList.Enabled = false;
            this.CustomToolStripMenuToMyList.Name = "CustomToolStripMenuToMyList";
            this.CustomToolStripMenuToMyList.Size = new System.Drawing.Size(146, 22);
            this.CustomToolStripMenuToMyList.Text = "MyListへ(&M)";
            this.CustomToolStripMenuToMyList.Click += new System.EventHandler(this.CustomToolStripMenuToMyList_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(33, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "仮";
            // 
            // CustomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 291);
            this.ContextMenuStrip = this.contextCustomMenuStrip;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Custom);
            this.Name = "CustomList";
            this.Text = "CustomList";
            this.contextCustomMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Custom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextCustomMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CustomToolStripMenuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CustomToolStripMenuToMyList;
        private System.Windows.Forms.Label label2;
    }
}