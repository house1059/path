namespace PathLink
{
    partial class progress
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
            this.ProgressWhole = new System.Windows.Forms.ProgressBar();
            this.LabelWhole = new System.Windows.Forms.Label();
            this.ProgressSingle = new System.Windows.Forms.ProgressBar();
            this.LabelSingle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProgressWhole
            // 
            this.ProgressWhole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressWhole.Location = new System.Drawing.Point(2, 28);
            this.ProgressWhole.Name = "ProgressWhole";
            this.ProgressWhole.Size = new System.Drawing.Size(280, 23);
            this.ProgressWhole.TabIndex = 0;
            // 
            // LabelWhole
            // 
            this.LabelWhole.AutoSize = true;
            this.LabelWhole.Location = new System.Drawing.Point(0, 9);
            this.LabelWhole.Name = "LabelWhole";
            this.LabelWhole.Size = new System.Drawing.Size(61, 12);
            this.LabelWhole.TabIndex = 1;
            this.LabelWhole.Text = "wholeLabel";
            // 
            // ProgressSingle
            // 
            this.ProgressSingle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressSingle.Location = new System.Drawing.Point(2, 86);
            this.ProgressSingle.Name = "ProgressSingle";
            this.ProgressSingle.Size = new System.Drawing.Size(280, 23);
            this.ProgressSingle.TabIndex = 0;
            // 
            // LabelSingle
            // 
            this.LabelSingle.AutoSize = true;
            this.LabelSingle.Location = new System.Drawing.Point(0, 71);
            this.LabelSingle.Name = "LabelSingle";
            this.LabelSingle.Size = new System.Drawing.Size(62, 12);
            this.LabelSingle.TabIndex = 1;
            this.LabelSingle.Text = "singleLabel";
            // 
            // progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 115);
            this.Controls.Add(this.LabelSingle);
            this.Controls.Add(this.LabelWhole);
            this.Controls.Add(this.ProgressSingle);
            this.Controls.Add(this.ProgressWhole);
            this.Name = "progress";
            this.Text = "進捗状況";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressWhole;
        private System.Windows.Forms.Label LabelWhole;
        private System.Windows.Forms.ProgressBar ProgressSingle;
        private System.Windows.Forms.Label LabelSingle;
    }
}