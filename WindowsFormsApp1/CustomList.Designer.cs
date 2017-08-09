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
            this.listBox_parent = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.開くOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.myListへMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.リスト切り離しCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_parent
            // 
            this.listBox_parent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_parent.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox_parent.FormattingEnabled = true;
            this.listBox_parent.ItemHeight = 12;
            this.listBox_parent.Location = new System.Drawing.Point(-3, 29);
            this.listBox_parent.Name = "listBox_parent";
            this.listBox_parent.Size = new System.Drawing.Size(391, 268);
            this.listBox_parent.TabIndex = 0;
            this.listBox_parent.SelectedIndexChanged += new System.EventHandler(this.listBox_parent_SelectedIndexChanged);
            this.listBox_parent.DoubleClick += new System.EventHandler(this.listBox_parent_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くOToolStripMenuItem,
            this.toolStripMenuItem1,
            this.myListへMToolStripMenuItem,
            this.リスト切り離しCToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 76);
            // 
            // 開くOToolStripMenuItem
            // 
            this.開くOToolStripMenuItem.Enabled = false;
            this.開くOToolStripMenuItem.Name = "開くOToolStripMenuItem";
            this.開くOToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.開くOToolStripMenuItem.Text = "開く(&O)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // myListへMToolStripMenuItem
            // 
            this.myListへMToolStripMenuItem.Enabled = false;
            this.myListへMToolStripMenuItem.Name = "myListへMToolStripMenuItem";
            this.myListへMToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.myListへMToolStripMenuItem.Text = "MyListへ(&M)";
            // 
            // リスト切り離しCToolStripMenuItem
            // 
            this.リスト切り離しCToolStripMenuItem.Enabled = false;
            this.リスト切り離しCToolStripMenuItem.Name = "リスト切り離しCToolStripMenuItem";
            this.リスト切り離しCToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.リスト切り離しCToolStripMenuItem.Text = "リスト切り離し(&C)";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CustomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 291);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_parent);
            this.Name = "CustomList";
            this.Text = "CustomList";
            this.Load += new System.EventHandler(this.ParentList_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_parent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 開くOToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem myListへMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem リスト切り離しCToolStripMenuItem;
    }
}