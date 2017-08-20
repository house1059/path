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
            System.Windows.Forms.ToolStripMenuItem MainToolStripMyListView;
            this.bt_read = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMainMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MainToolStripOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MainToolStripToMyList = new System.Windows.Forms.ToolStripMenuItem();
            this.MainToolStripSplit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextParentMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ParentToolStripMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.ParentToolStripMenuToMyList = new System.Windows.Forms.ToolStripMenuItem();
            this.ParentToolStripMenuSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.ParentToolStripMenuListView = new System.Windows.Forms.ToolStripMenuItem();
            this.contextChildMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChildToolStripMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ChildToolStripMenuToMyList = new System.Windows.Forms.ToolStripMenuItem();
            this.ChildToolStripMenuSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.ChildToolStripMenuListView = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox_cList = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            MainToolStripMyListView = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMainMenuStrip.SuspendLayout();
            this.contextParentMenuStrip.SuspendLayout();
            this.contextChildMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainToolStripMyListView
            // 
            MainToolStripMyListView.Name = "MainToolStripMyListView";
            MainToolStripMyListView.Size = new System.Drawing.Size(147, 22);
            MainToolStripMyListView.Text = "MyListの表示";
            MainToolStripMyListView.Click += new System.EventHandler(this.MainToolStripMyListView_Click);
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
            this.listBox1.ContextMenuStrip = this.contextMainMenuStrip;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(641, 208);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            this.listBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            // 
            // contextMainMenuStrip
            // 
            this.contextMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainToolStripOpen,
            this.toolStripMenuItem1,
            this.MainToolStripToMyList,
            this.MainToolStripSplit,
            this.toolStripMenuItem3,
            MainToolStripMyListView});
            this.contextMainMenuStrip.Name = "contextMenuStrip1";
            this.contextMainMenuStrip.Size = new System.Drawing.Size(148, 104);
            // 
            // MainToolStripOpen
            // 
            this.MainToolStripOpen.Enabled = false;
            this.MainToolStripOpen.Name = "MainToolStripOpen";
            this.MainToolStripOpen.Size = new System.Drawing.Size(147, 22);
            this.MainToolStripOpen.Text = "開く(&O)";
            this.MainToolStripOpen.Click += new System.EventHandler(this.MainToolStripMenuOpen_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
            // 
            // MainToolStripToMyList
            // 
            this.MainToolStripToMyList.Enabled = false;
            this.MainToolStripToMyList.Name = "MainToolStripToMyList";
            this.MainToolStripToMyList.Size = new System.Drawing.Size(147, 22);
            this.MainToolStripToMyList.Text = "MyListへ(&M)";
            this.MainToolStripToMyList.Click += new System.EventHandler(this.MainToolStripToMyList_Click);
            // 
            // MainToolStripSplit
            // 
            this.MainToolStripSplit.Enabled = false;
            this.MainToolStripSplit.Name = "MainToolStripSplit";
            this.MainToolStripSplit.Size = new System.Drawing.Size(147, 22);
            this.MainToolStripSplit.Text = "List切り離し(&C)";
            this.MainToolStripSplit.Click += new System.EventHandler(this.MainToolStripSplit_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(144, 6);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(55, 300);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(598, 19);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(55, 329);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(598, 19);
            this.textBox3.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(55, 359);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(598, 19);
            this.textBox4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "path";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ｼｰﾄ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 366);
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
            this.bt_check.Enabled = false;
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
            this.label6.Location = new System.Drawing.Point(12, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "レイヤー";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(55, 385);
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
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // listBox_pList
            // 
            this.listBox_pList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_pList.ContextMenuStrip = this.contextParentMenuStrip;
            this.listBox_pList.FormattingEnabled = true;
            this.listBox_pList.ItemHeight = 12;
            this.listBox_pList.Location = new System.Drawing.Point(12, 432);
            this.listBox_pList.Name = "listBox_pList";
            this.listBox_pList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_pList.Size = new System.Drawing.Size(335, 148);
            this.listBox_pList.TabIndex = 11;
            this.listBox_pList.SelectedIndexChanged += new System.EventHandler(this.listBox_pList_SelectedIndexChanged);
            this.listBox_pList.DoubleClick += new System.EventHandler(this.listBox_pList_DoubleClick);
            this.listBox_pList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_pList_KeyDown);
            this.listBox_pList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox_pList_MouseMove);
            // 
            // contextParentMenuStrip
            // 
            this.contextParentMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ParentToolStripMenuOpen,
            this.toolStripMenuItem5,
            this.ParentToolStripMenuToMyList,
            this.ParentToolStripMenuSplit,
            this.toolStripMenuItem6,
            this.ParentToolStripMenuListView});
            this.contextParentMenuStrip.Name = "contextParentMenuStrip";
            this.contextParentMenuStrip.Size = new System.Drawing.Size(148, 104);
            // 
            // ParentToolStripMenuOpen
            // 
            this.ParentToolStripMenuOpen.Name = "ParentToolStripMenuOpen";
            this.ParentToolStripMenuOpen.Size = new System.Drawing.Size(147, 22);
            this.ParentToolStripMenuOpen.Text = "開く(&O)";
            this.ParentToolStripMenuOpen.Click += new System.EventHandler(this.ParentToolStripMenuOpen_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(144, 6);
            // 
            // ParentToolStripMenuToMyList
            // 
            this.ParentToolStripMenuToMyList.Name = "ParentToolStripMenuToMyList";
            this.ParentToolStripMenuToMyList.Size = new System.Drawing.Size(147, 22);
            this.ParentToolStripMenuToMyList.Text = "MyListへ(&M)";
            this.ParentToolStripMenuToMyList.Click += new System.EventHandler(this.ParentToolStripMenuToMyList_Click);
            // 
            // ParentToolStripMenuSplit
            // 
            this.ParentToolStripMenuSplit.Name = "ParentToolStripMenuSplit";
            this.ParentToolStripMenuSplit.Size = new System.Drawing.Size(147, 22);
            this.ParentToolStripMenuSplit.Text = "List切り離し(&C)";
            this.ParentToolStripMenuSplit.Click += new System.EventHandler(this.ParentToolStripMenuSplit_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(144, 6);
            // 
            // ParentToolStripMenuListView
            // 
            this.ParentToolStripMenuListView.Name = "ParentToolStripMenuListView";
            this.ParentToolStripMenuListView.Size = new System.Drawing.Size(147, 22);
            this.ParentToolStripMenuListView.Text = "MyListの表示";
            this.ParentToolStripMenuListView.Click += new System.EventHandler(this.ParentToolStripMenuListView_Click);
            // 
            // contextChildMenuStrip
            // 
            this.contextChildMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChildToolStripMenuOpen,
            this.toolStripMenuItem2,
            this.ChildToolStripMenuToMyList,
            this.ChildToolStripMenuSplit,
            this.toolStripMenuItem4,
            this.ChildToolStripMenuListView});
            this.contextChildMenuStrip.Name = "contextMenuStrip2";
            this.contextChildMenuStrip.Size = new System.Drawing.Size(148, 104);
            // 
            // ChildToolStripMenuOpen
            // 
            this.ChildToolStripMenuOpen.Enabled = false;
            this.ChildToolStripMenuOpen.Name = "ChildToolStripMenuOpen";
            this.ChildToolStripMenuOpen.Size = new System.Drawing.Size(147, 22);
            this.ChildToolStripMenuOpen.Text = "開く(&O)";
            this.ChildToolStripMenuOpen.Click += new System.EventHandler(this.ChildStripMenuOpen_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(144, 6);
            // 
            // ChildToolStripMenuToMyList
            // 
            this.ChildToolStripMenuToMyList.Enabled = false;
            this.ChildToolStripMenuToMyList.Name = "ChildToolStripMenuToMyList";
            this.ChildToolStripMenuToMyList.Size = new System.Drawing.Size(147, 22);
            this.ChildToolStripMenuToMyList.Text = "MyListへ(&M)";
            this.ChildToolStripMenuToMyList.Click += new System.EventHandler(this.ChildToolStripMenuToMyList_Click);
            // 
            // ChildToolStripMenuSplit
            // 
            this.ChildToolStripMenuSplit.Enabled = false;
            this.ChildToolStripMenuSplit.Name = "ChildToolStripMenuSplit";
            this.ChildToolStripMenuSplit.Size = new System.Drawing.Size(147, 22);
            this.ChildToolStripMenuSplit.Text = "List切り離し(&C)";
            this.ChildToolStripMenuSplit.Click += new System.EventHandler(this.ChildToolStripMenuSplit_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(144, 6);
            // 
            // ChildToolStripMenuListView
            // 
            this.ChildToolStripMenuListView.Name = "ChildToolStripMenuListView";
            this.ChildToolStripMenuListView.Size = new System.Drawing.Size(147, 22);
            this.ChildToolStripMenuListView.Text = "MyListの表示";
            this.ChildToolStripMenuListView.Click += new System.EventHandler(this.ChildToolStripMenuListView_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 417);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "親リスト";
            // 
            // listBox_cList
            // 
            this.listBox_cList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_cList.ContextMenuStrip = this.contextChildMenuStrip;
            this.listBox_cList.FormattingEnabled = true;
            this.listBox_cList.ItemHeight = 12;
            this.listBox_cList.Location = new System.Drawing.Point(351, 432);
            this.listBox_cList.Name = "listBox_cList";
            this.listBox_cList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_cList.Size = new System.Drawing.Size(307, 148);
            this.listBox_cList.TabIndex = 13;
            this.listBox_cList.SelectedIndexChanged += new System.EventHandler(this.listBox_cList_SelectedIndexChanged);
            this.listBox_cList.DoubleClick += new System.EventHandler(this.listBox_cList_DoubleClick);
            this.listBox_cList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_cList_KeyDown);
            this.listBox_cList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox_cList_MouseMove);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(357, 415);
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
            this.ClientSize = new System.Drawing.Size(676, 594);
            this.ContextMenuStrip = this.contextMainMenuStrip;
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
            this.Resize += new System.EventHandler(this.Search_Resize);
            this.contextMainMenuStrip.ResumeLayout(false);
            this.contextParentMenuStrip.ResumeLayout(false);
            this.contextChildMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MainToolStripOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ListBox listBox_pList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem MainToolStripSplit;
        private System.Windows.Forms.ToolStripMenuItem MainToolStripToMyList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ChildToolStripMenuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ChildToolStripMenuToMyList;
        private System.Windows.Forms.ToolStripMenuItem ChildToolStripMenuSplit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ChildToolStripMenuListView;
        private System.Windows.Forms.ContextMenuStrip contextChildMenuStrip;
        private System.Windows.Forms.ListBox listBox_cList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextParentMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ParentToolStripMenuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem ParentToolStripMenuToMyList;
        private System.Windows.Forms.ToolStripMenuItem ParentToolStripMenuSplit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem ParentToolStripMenuListView;
    }
}

