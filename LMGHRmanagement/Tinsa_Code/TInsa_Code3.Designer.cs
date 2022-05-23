namespace LMGHRmanagement
{
    partial class TInsa_Code3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TInsa_Code3));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Search_dept_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dept_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dept_names = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dept_seq = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.dept_edate = new System.Windows.Forms.DateTimePicker();
            this.dept_sdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dept_code = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DataDeleteBtn = new System.Windows.Forms.Button();
            this.DataLoadBtn = new System.Windows.Forms.Button();
            this.DataSaveBtn = new System.Windows.Forms.Button();
            this.DataInsertBtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dept_upp = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dept_seq)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Search.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "부서코드";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 37);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Search_dept_name);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(652, 37);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "검색옵션";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(341, 13);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(58, 20);
            this.button6.TabIndex = 16;
            this.button6.Text = "초기화";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "부서명칭";
            // 
            // Search_dept_name
            // 
            this.Search_dept_name.Location = new System.Drawing.Point(68, 13);
            this.Search_dept_name.Name = "Search_dept_name";
            this.Search_dept_name.Size = new System.Drawing.Size(267, 21);
            this.Search_dept_name.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "부서명칭(축약)";
            // 
            // dept_name
            // 
            this.dept_name.Enabled = false;
            this.dept_name.Location = new System.Drawing.Point(101, 36);
            this.dept_name.Multiline = true;
            this.dept_name.Name = "dept_name";
            this.dept_name.Size = new System.Drawing.Size(242, 31);
            this.dept_name.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "부서명칭(원형)";
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
            this.dataGridView1.TabIndex = 0;
            // 
            // dept_names
            // 
            this.dept_names.Enabled = false;
            this.dept_names.Location = new System.Drawing.Point(101, 69);
            this.dept_names.Multiline = true;
            this.dept_names.Name = "dept_names";
            this.dept_names.Size = new System.Drawing.Size(242, 31);
            this.dept_names.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(661, 55);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(349, 630);
            this.panel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dept_upp);
            this.groupBox1.Controls.Add(this.dept_seq);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dept_edate);
            this.groupBox1.Controls.Add(this.dept_sdate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dept_names);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dept_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dept_code);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 630);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "부서코드";
            // 
            // dept_seq
            // 
            this.dept_seq.Enabled = false;
            this.dept_seq.Location = new System.Drawing.Point(101, 102);
            this.dept_seq.Name = "dept_seq";
            this.dept_seq.Size = new System.Drawing.Size(75, 21);
            this.dept_seq.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "코드 Seq";
            // 
            // dept_edate
            // 
            this.dept_edate.CustomFormat = " ";
            this.dept_edate.Enabled = false;
            this.dept_edate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dept_edate.Location = new System.Drawing.Point(101, 171);
            this.dept_edate.Name = "dept_edate";
            this.dept_edate.Size = new System.Drawing.Size(114, 21);
            this.dept_edate.TabIndex = 36;
            // 
            // dept_sdate
            // 
            this.dept_sdate.CustomFormat = " ";
            this.dept_sdate.Enabled = false;
            this.dept_sdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dept_sdate.Location = new System.Drawing.Point(101, 148);
            this.dept_sdate.Name = "dept_sdate";
            this.dept_sdate.Size = new System.Drawing.Size(114, 21);
            this.dept_sdate.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "폐기일자";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "상위부서코드";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "생성일자";
            // 
            // dept_code
            // 
            this.dept_code.Enabled = false;
            this.dept_code.Location = new System.Drawing.Point(101, 13);
            this.dept_code.MaxLength = 3;
            this.dept_code.Name = "dept_code";
            this.dept_code.Size = new System.Drawing.Size(100, 21);
            this.dept_code.TabIndex = 10;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 593F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1013, 688);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.DataDeleteBtn);
            this.panel4.Controls.Add(this.DataLoadBtn);
            this.panel4.Controls.Add(this.DataSaveBtn);
            this.panel4.Controls.Add(this.DataInsertBtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1007, 46);
            this.panel4.TabIndex = 3;
            // 
            // DataDeleteBtn
            // 
            this.DataDeleteBtn.Enabled = false;
            this.DataDeleteBtn.Location = new System.Drawing.Point(848, 20);
            this.DataDeleteBtn.Name = "DataDeleteBtn";
            this.DataDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DataDeleteBtn.TabIndex = 14;
            this.DataDeleteBtn.Text = "삭제";
            this.DataDeleteBtn.UseVisualStyleBackColor = true;
            this.DataDeleteBtn.Click += new System.EventHandler(this.DataDeleteBtn_Click);
            // 
            // DataLoadBtn
            // 
            this.DataLoadBtn.Location = new System.Drawing.Point(686, 20);
            this.DataLoadBtn.Name = "DataLoadBtn";
            this.DataLoadBtn.Size = new System.Drawing.Size(75, 23);
            this.DataLoadBtn.TabIndex = 15;
            this.DataLoadBtn.Text = "조회";
            this.DataLoadBtn.UseVisualStyleBackColor = true;
            this.DataLoadBtn.Click += new System.EventHandler(this.DataLoadBtn_Click);
            // 
            // DataSaveBtn
            // 
            this.DataSaveBtn.Enabled = false;
            this.DataSaveBtn.Location = new System.Drawing.Point(929, 20);
            this.DataSaveBtn.Name = "DataSaveBtn";
            this.DataSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.DataSaveBtn.TabIndex = 16;
            this.DataSaveBtn.Text = "저장";
            this.DataSaveBtn.UseVisualStyleBackColor = true;
            this.DataSaveBtn.Click += new System.EventHandler(this.DataSaveBtn_Click);
            // 
            // DataInsertBtn
            // 
            this.DataInsertBtn.Location = new System.Drawing.Point(767, 20);
            this.DataInsertBtn.Name = "DataInsertBtn";
            this.DataInsertBtn.Size = new System.Drawing.Size(75, 23);
            this.DataInsertBtn.TabIndex = 13;
            this.DataInsertBtn.Text = "삽입";
            this.DataInsertBtn.UseVisualStyleBackColor = true;
            this.DataInsertBtn.Click += new System.EventHandler(this.DataInsertBtn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dept_upp
            // 
            this.dept_upp.FormattingEnabled = true;
            this.dept_upp.Location = new System.Drawing.Point(101, 125);
            this.dept_upp.Name = "dept_upp";
            this.dept_upp.Size = new System.Drawing.Size(114, 20);
            this.dept_upp.TabIndex = 39;
            // 
            // TInsa_Code3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 688);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TInsa_Code3";
            this.Text = "Tinsa_Dept_Form";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dept_seq)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dept_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox dept_names;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dept_code;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Search_dept_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button DataDeleteBtn;
        private System.Windows.Forms.Button DataLoadBtn;
        private System.Windows.Forms.Button DataSaveBtn;
        private System.Windows.Forms.Button DataInsertBtn;
        private System.Windows.Forms.DateTimePicker dept_edate;
        private System.Windows.Forms.DateTimePicker dept_sdate;
        private System.Windows.Forms.NumericUpDown dept_seq;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox dept_upp;
    }
}