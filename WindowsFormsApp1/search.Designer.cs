namespace WindowsFormsApp1
{
    partial class Search
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem myListの表示ToolStripMenuItem;
            this.bt_read = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.開くOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.myListへMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.list切り離しCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_check = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox_pList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.開くOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.myListへMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.list切り離しCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.myListの表示ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox_cList = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            myListの表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // myListの表示ToolStripMenuItem
            // 
            myListの表示ToolStripMenuItem.Name = "myListの表示ToolStripMenuItem";
            myListの表示ToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            myListの表示ToolStripMenuItem.Text = "MyListの表示";
            myListの表示ToolStripMenuItem.Click += new System.EventHandler(this.myListの表示ToolStripMenuItem_Click_2);
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
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(641, 124);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くOToolStripMenuItem,
            this.toolStripMenuItem1,
            this.myListへMToolStripMenuItem1,
            this.list切り離しCToolStripMenuItem1,
            this.toolStripMenuItem3,
            myListの表示ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 104);
            // 
            // 開くOToolStripMenuItem
            // 
            this.開くOToolStripMenuItem.Enabled = false;
            this.開くOToolStripMenuItem.Name = "開くOToolStripMenuItem";
            this.開くOToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.開くOToolStripMenuItem.Text = "開く(&O)";
            this.開くOToolStripMenuItem.Click += new System.EventHandler(this.開くOToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // myListへMToolStripMenuItem1
            // 
            this.myListへMToolStripMenuItem1.Enabled = false;
            this.myListへMToolStripMenuItem1.Name = "myListへMToolStripMenuItem1";
            this.myListへMToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.myListへMToolStripMenuItem1.Text = "MyListへ(&M)";
            this.myListへMToolStripMenuItem1.Click += new System.EventHandler(this.myListへMToolStripMenuItem1_Click);
            // 
            // list切り離しCToolStripMenuItem1
            // 
            this.list切り離しCToolStripMenuItem1.Enabled = false;
            this.list切り離しCToolStripMenuItem1.Name = "list切り離しCToolStripMenuItem1";
            this.list切り離しCToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.list切り離しCToolStripMenuItem1.Text = "List切り離し(&C)";
            this.list切り離しCToolStripMenuItem1.Click += new System.EventHandler(this.list切り離しCToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 6);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(55, 231);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(598, 19);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(55, 260);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(598, 19);
            this.textBox3.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(55, 290);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(598, 19);
            this.textBox4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "path";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ｼｰﾄ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "ｱﾄﾞﾚｽ";
            // 
            // bt_clear
            // 
            this.bt_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_clear.Location = new System.Drawing.Point(590, 1);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(48, 28);
            this.bt_clear.TabIndex = 0;
            this.bt_clear.Text = "clear";
            this.bt_clear.UseVisualStyleBackColor = true;
            this.bt_clear.Click += new System.EventHandler(this.bt_clear_Click);
            // 
            // bt_check
            // 
            this.bt_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_check.Location = new System.Drawing.Point(536, 1);
            this.bt_check.Name = "bt_check";
            this.bt_check.Size = new System.Drawing.Size(48, 28);
            this.bt_check.TabIndex = 0;
            this.bt_check.Text = "check";
            this.bt_check.UseVisualStyleBackColor = true;
            this.bt_check.Click += new System.EventHandler(this.bt_check_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(71, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(33, 16);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "or";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(119, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(41, 16);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "and";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 47);
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(502, 19);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(520, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "layer";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "レイヤー";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(55, 316);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 19);
            this.textBox1.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DisplayMember = "selectLayer";
            this.comboBox1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(577, 44);
            this.comboBox1.MaxLength = 3;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(52, 20);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.ValueMember = "layer";
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // listBox_pList
            // 
            this.listBox_pList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_pList.ContextMenuStrip = this.contextMenuStrip2;
            this.listBox_pList.FormattingEnabled = true;
            this.listBox_pList.ItemHeight = 12;
            this.listBox_pList.Location = new System.Drawing.Point(12, 363);
            this.listBox_pList.Name = "listBox_pList";
            this.listBox_pList.Size = new System.Drawing.Size(335, 148);
            this.listBox_pList.TabIndex = 11;
            this.listBox_pList.SelectedIndexChanged += new System.EventHandler(this.listBox_pList_SelectedIndexChanged);
            this.listBox_pList.DoubleClick += new System.EventHandler(this.listBox_pList_DoubleClick);
            this.listBox_pList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox_pList_MouseMove);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くOToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.myListへMToolStripMenuItem,
            this.list切り離しCToolStripMenuItem,
            this.toolStripMenuItem4,
            this.myListの表示ToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(176, 104);
            // 
            // 開くOToolStripMenuItem1
            // 
            this.開くOToolStripMenuItem1.Enabled = false;
            this.開くOToolStripMenuItem1.Name = "開くOToolStripMenuItem1";
            this.開くOToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.開くOToolStripMenuItem1.Text = "開く(&O)";
            this.開くOToolStripMenuItem1.Click += new System.EventHandler(this.開くOToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // myListへMToolStripMenuItem
            // 
            this.myListへMToolStripMenuItem.Enabled = false;
            this.myListへMToolStripMenuItem.Name = "myListへMToolStripMenuItem";
            this.myListへMToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.myListへMToolStripMenuItem.Text = "MyListへ(&M)";
            this.myListへMToolStripMenuItem.Click += new System.EventHandler(this.myListへMToolStripMenuItem_Click);
            // 
            // list切り離しCToolStripMenuItem
            // 
            this.list切り離しCToolStripMenuItem.Enabled = false;
            this.list切り離しCToolStripMenuItem.Name = "list切り離しCToolStripMenuItem";
            this.list切り離しCToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.list切り離しCToolStripMenuItem.Text = "親List切り離し(&C)";
            this.list切り離しCToolStripMenuItem.Click += new System.EventHandler(this.list切り離しCToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(172, 6);
            // 
            // myListの表示ToolStripMenuItem1
            // 
            this.myListの表示ToolStripMenuItem1.Name = "myListの表示ToolStripMenuItem1";
            this.myListの表示ToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.myListの表示ToolStripMenuItem1.Text = "MyListの表示";
            this.myListの表示ToolStripMenuItem1.Click += new System.EventHandler(this.myListの表示ToolStripMenuItem1_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "親リスト";
            // 
            // listBox_cList
            // 
            this.listBox_cList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_cList.FormattingEnabled = true;
            this.listBox_cList.ItemHeight = 12;
            this.listBox_cList.Location = new System.Drawing.Point(351, 363);
            this.listBox_cList.Name = "listBox_cList";
            this.listBox_cList.Size = new System.Drawing.Size(307, 148);
            this.listBox_cList.TabIndex = 13;
            this.listBox_cList.SelectedIndexChanged += new System.EventHandler(this.listBox_cList_SelectedIndexChanged);
            this.listBox_cList.DoubleClick += new System.EventHandler(this.listBox_cList_DoubleClick);
            this.listBox_cList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox_cList_MouseMove);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(357, 346);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "子リスト";
            // 
            // Search
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(676, 525);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox_cList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBox_pList);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.bt_check);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.bt_read);
            this.Name = "Search";
            this.Text = "NSS　部品検索";
            this.Load += new System.EventHandler(this.search_Load);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.search_DragOver);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_read;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.Button bt_check;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 開くOToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ListBox listBox_pList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem list切り離しCToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem myListへMToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 開くOToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem myListへMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem list切り離しCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem myListの表示ToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ListBox listBox_cList;
        private System.Windows.Forms.Label label8;
    }
}

