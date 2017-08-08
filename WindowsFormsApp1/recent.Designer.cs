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
            this.listBox_recent = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_recent
            // 
            this.listBox_recent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listBox_recent.FormattingEnabled = true;
            this.listBox_recent.ItemHeight = 12;
            this.listBox_recent.Location = new System.Drawing.Point(-2, 25);
            this.listBox_recent.Name = "listBox_recent";
            this.listBox_recent.Size = new System.Drawing.Size(288, 244);
            this.listBox_recent.TabIndex = 0;
            this.listBox_recent.SelectedIndexChanged += new System.EventHandler(this.listBox_recent_SelectedIndexChanged);
            // 
            // Recent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.listBox_recent);
            this.Name = "Recent";
            this.Text = "Recent";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_recent;
    }
}