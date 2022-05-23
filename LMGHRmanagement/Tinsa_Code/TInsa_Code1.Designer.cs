
namespace LMGHRmanagement
{
    partial class TInsa_Code1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TInsa_Code1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.search_cdg_use = new System.Windows.Forms.ComboBox();
            this.search_cdg_grpnm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cdg_use = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cdg_kind = new System.Windows.Forms.TextBox();
            this.cdg_length = new System.Windows.Forms.NumericUpDown();
            this.cdg_digit = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cdg_grpnm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cdg_grpcd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DataLoadBtn = new System.Windows.Forms.Button();
            this.DataDeleteBtn = new System.Windows.Forms.Button();
            this.DataSaveBtn = new System.Windows.Forms.Button();
            this.DataInsertBtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdg_length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdg_digit)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.386067F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.92162F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1013, 688);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 37);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.search_cdg_use);
            this.groupBox1.Controls.Add(this.search_cdg_grpnm);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 37);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색 옵션";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "그룹코드명";
            // 
            // search_cdg_use
            // 
            this.search_cdg_use.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.search_cdg_use.FormattingEnabled = true;
            this.search_cdg_use.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.search_cdg_use.Items.AddRange(new object[] {
            "선택",
            "Y",
            "N"});
            this.search_cdg_use.Location = new System.Drawing.Point(383, 14);
            this.search_cdg_use.Name = "search_cdg_use";
            this.search_cdg_use.Size = new System.Drawing.Size(75, 20);
            this.search_cdg_use.TabIndex = 5;
            // 
            // search_cdg_grpnm
            // 
            this.search_cdg_grpnm.Location = new System.Drawing.Point(80, 14);
            this.search_cdg_grpnm.Name = "search_cdg_grpnm";
            this.search_cdg_grpnm.Size = new System.Drawing.Size(238, 21);
            this.search_cdg_grpnm.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(324, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "사용여부";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 587);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(652, 587);
            this.dataGridView1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(661, 55);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(349, 630);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cdg_use);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cdg_kind);
            this.groupBox3.Controls.Add(this.cdg_length);
            this.groupBox3.Controls.Add(this.cdg_digit);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cdg_grpnm);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cdg_grpcd);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(349, 630);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "그룹코드";
            // 
            // cdg_use
            // 
            this.cdg_use.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cdg_use.Enabled = false;
            this.cdg_use.FormattingEnabled = true;
            this.cdg_use.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cdg_use.Items.AddRange(new object[] {
            "선택",
            "Y",
            "N"});
            this.cdg_use.Location = new System.Drawing.Point(139, 114);
            this.cdg_use.Name = "cdg_use";
            this.cdg_use.Size = new System.Drawing.Size(75, 20);
            this.cdg_use.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "사용여부";
            // 
            // cdg_kind
            // 
            this.cdg_kind.Enabled = false;
            this.cdg_kind.Location = new System.Drawing.Point(139, 136);
            this.cdg_kind.MaxLength = 8;
            this.cdg_kind.Name = "cdg_kind";
            this.cdg_kind.Size = new System.Drawing.Size(75, 21);
            this.cdg_kind.TabIndex = 6;
            // 
            // cdg_length
            // 
            this.cdg_length.Enabled = false;
            this.cdg_length.Location = new System.Drawing.Point(139, 91);
            this.cdg_length.Name = "cdg_length";
            this.cdg_length.Size = new System.Drawing.Size(46, 21);
            this.cdg_length.TabIndex = 4;
            // 
            // cdg_digit
            // 
            this.cdg_digit.Enabled = false;
            this.cdg_digit.Location = new System.Drawing.Point(139, 68);
            this.cdg_digit.Name = "cdg_digit";
            this.cdg_digit.Size = new System.Drawing.Size(46, 21);
            this.cdg_digit.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "분류";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "단위코드명(원형) 길이";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "단위코드 자리수";
            // 
            // cdg_grpnm
            // 
            this.cdg_grpnm.Enabled = false;
            this.cdg_grpnm.Location = new System.Drawing.Point(139, 37);
            this.cdg_grpnm.MaxLength = 30;
            this.cdg_grpnm.Multiline = true;
            this.cdg_grpnm.Name = "cdg_grpnm";
            this.cdg_grpnm.Size = new System.Drawing.Size(201, 29);
            this.cdg_grpnm.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "그룹코드명";
            // 
            // cdg_grpcd
            // 
            this.cdg_grpcd.Enabled = false;
            this.cdg_grpcd.Location = new System.Drawing.Point(139, 14);
            this.cdg_grpcd.MaxLength = 3;
            this.cdg_grpcd.Name = "cdg_grpcd";
            this.cdg_grpcd.Size = new System.Drawing.Size(46, 21);
            this.cdg_grpcd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "그룹코드";
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.DataLoadBtn);
            this.panel4.Controls.Add(this.DataDeleteBtn);
            this.panel4.Controls.Add(this.DataSaveBtn);
            this.panel4.Controls.Add(this.DataInsertBtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1007, 46);
            this.panel4.TabIndex = 3;
            // 
            // DataLoadBtn
            // 
            this.DataLoadBtn.Location = new System.Drawing.Point(686, 20);
            this.DataLoadBtn.Name = "DataLoadBtn";
            this.DataLoadBtn.Size = new System.Drawing.Size(75, 23);
            this.DataLoadBtn.TabIndex = 8;
            this.DataLoadBtn.Text = "조회";
            this.DataLoadBtn.UseVisualStyleBackColor = true;
            this.DataLoadBtn.Click += new System.EventHandler(this.DataLoadBtn_Click);
            // 
            // DataDeleteBtn
            // 
            this.DataDeleteBtn.Enabled = false;
            this.DataDeleteBtn.Location = new System.Drawing.Point(848, 20);
            this.DataDeleteBtn.Name = "DataDeleteBtn";
            this.DataDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DataDeleteBtn.TabIndex = 8;
            this.DataDeleteBtn.Text = "삭제";
            this.DataDeleteBtn.UseVisualStyleBackColor = true;
            this.DataDeleteBtn.Click += new System.EventHandler(this.DataDeleteBtn_Click);
            // 
            // DataSaveBtn
            // 
            this.DataSaveBtn.Enabled = false;
            this.DataSaveBtn.Location = new System.Drawing.Point(929, 20);
            this.DataSaveBtn.Name = "DataSaveBtn";
            this.DataSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.DataSaveBtn.TabIndex = 8;
            this.DataSaveBtn.Text = "저장";
            this.DataSaveBtn.UseVisualStyleBackColor = true;
            this.DataSaveBtn.Click += new System.EventHandler(this.DataSaveBtn_Click);
            // 
            // DataInsertBtn
            // 
            this.DataInsertBtn.Location = new System.Drawing.Point(767, 20);
            this.DataInsertBtn.Name = "DataInsertBtn";
            this.DataInsertBtn.Size = new System.Drawing.Size(75, 23);
            this.DataInsertBtn.TabIndex = 7;
            this.DataInsertBtn.Text = "삽입";
            this.DataInsertBtn.UseVisualStyleBackColor = true;
            this.DataInsertBtn.Click += new System.EventHandler(this.DataInsertBtn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Search.png");
            // 
            // TInsa_Code1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 688);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TInsa_Code1";
            this.Text = "그룹코드";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdg_length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdg_digit)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox search_cdg_grpnm;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cdg_use;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown cdg_digit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cdg_grpnm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cdg_grpcd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cdg_length;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cdg_kind;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button DataInsertBtn;
        private System.Windows.Forms.Button DataSaveBtn;
        private System.Windows.Forms.Button DataLoadBtn;
        private System.Windows.Forms.Button DataDeleteBtn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox search_cdg_use;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ImageList imageList1;
    }
}