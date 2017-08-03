namespace WindowsFormsApp1
{
    partial class search
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_read = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_check = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_read
            // 
            this.bt_read.Location = new System.Drawing.Point(1, 1);
            this.bt_read.Name = "bt_read";
            this.bt_read.Size = new System.Drawing.Size(63, 28);
            this.bt_read.TabIndex = 0;
            this.bt_read.Text = "読込み";
            this.bt_read.UseVisualStyleBackColor = true;
            this.bt_read.Click += new System.EventHandler(this.bt_read_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(425, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(425, 172);
            this.listBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(55, 262);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(382, 19);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(55, 295);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(382, 19);
            this.textBox3.TabIndex = 1;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(55, 332);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(382, 19);
            this.textBox4.TabIndex = 1;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "path";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ｼｰﾄ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "ｱﾄﾞﾚｽ";
            // 
            // bt_clear
            // 
            this.bt_clear.Location = new System.Drawing.Point(398, 1);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(48, 28);
            this.bt_clear.TabIndex = 0;
            this.bt_clear.Text = "clear";
            this.bt_clear.UseVisualStyleBackColor = true;
            // 
            // bt_check
            // 
            this.bt_check.Location = new System.Drawing.Point(344, 1);
            this.bt_check.Name = "bt_check";
            this.bt_check.Size = new System.Drawing.Size(48, 28);
            this.bt_check.TabIndex = 0;
            this.bt_check.Text = "check";
            this.bt_check.UseVisualStyleBackColor = true;
            this.bt_check.Click += new System.EventHandler(this.bt_check_Click);
            // 
            // search
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(447, 360);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bt_check);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_read);
            this.Name = "search";
            this.Text = "NSS　部品検索";
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.search_DragOver);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_read;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_check;
    }
}

