
namespace LMGHRmanagement
{
    partial class Tinsa_Bas3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tinsa_Bas3));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DataDeleteBtn = new System.Windows.Forms.Button();
            this.DataLoadBtn = new System.Windows.Forms.Button();
            this.DataSaveBtn = new System.Windows.Forms.Button();
            this.DataInsertBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.search_bas_name = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.search_bas_empno = new System.Windows.Forms.TextBox();
            this.lab_bas_empno = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edu_gradate = new System.Windows.Forms.DateTimePicker();
            this.edu_entdate = new System.Windows.Forms.DateTimePicker();
            this.edu_last = new System.Windows.Forms.ComboBox();
            this.edu_gra = new System.Windows.Forms.ComboBox();
            this.edu_degree = new System.Windows.Forms.ComboBox();
            this.edu_loe = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edu_dept = new System.Windows.Forms.TextBox();
            this.edu_grade = new System.Windows.Forms.TextBox();
            this.edu_schnm = new System.Windows.Forms.TextBox();
            this.edu_empno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.70558F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.29442F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.689235F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.839026F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.47174F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1013, 688);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel5, 3);
            this.panel5.Controls.Add(this.DataDeleteBtn);
            this.panel5.Controls.Add(this.DataLoadBtn);
            this.panel5.Controls.Add(this.DataSaveBtn);
            this.panel5.Controls.Add(this.DataInsertBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1007, 46);
            this.panel5.TabIndex = 7;
            // 
            // DataDeleteBtn
            // 
            this.DataDeleteBtn.Location = new System.Drawing.Point(848, 20);
            this.DataDeleteBtn.Name = "DataDeleteBtn";
            this.DataDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DataDeleteBtn.TabIndex = 18;
            this.DataDeleteBtn.Text = "삭제";
            this.DataDeleteBtn.UseVisualStyleBackColor = true;
            this.DataDeleteBtn.Click += new System.EventHandler(this.DataDeleteBtn_Click);
            // 
            // DataLoadBtn
            // 
            this.DataLoadBtn.Location = new System.Drawing.Point(686, 20);
            this.DataLoadBtn.Name = "DataLoadBtn";
            this.DataLoadBtn.Size = new System.Drawing.Size(75, 23);
            this.DataLoadBtn.TabIndex = 19;
            this.DataLoadBtn.Text = "조회";
            this.DataLoadBtn.UseVisualStyleBackColor = true;
            this.DataLoadBtn.Click += new System.EventHandler(this.DataLoadBtn_Click);
            // 
            // DataSaveBtn
            // 
            this.DataSaveBtn.Location = new System.Drawing.Point(929, 20);
            this.DataSaveBtn.Name = "DataSaveBtn";
            this.DataSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.DataSaveBtn.TabIndex = 20;
            this.DataSaveBtn.Text = "저장";
            this.DataSaveBtn.UseVisualStyleBackColor = true;
            this.DataSaveBtn.Click += new System.EventHandler(this.DataSaveBtn_Click);
            // 
            // DataInsertBtn
            // 
            this.DataInsertBtn.Location = new System.Drawing.Point(767, 20);
            this.DataInsertBtn.Name = "DataInsertBtn";
            this.DataInsertBtn.Size = new System.Drawing.Size(75, 23);
            this.DataInsertBtn.TabIndex = 17;
            this.DataInsertBtn.Text = "삽입";
            this.DataInsertBtn.UseVisualStyleBackColor = true;
            this.DataInsertBtn.Click += new System.EventHandler(this.DataInsertBtn_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(277, 47);
            this.panel4.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.search_bas_name);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.search_bas_empno);
            this.groupBox2.Controls.Add(this.lab_bas_empno);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 47);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "검색";
            // 
            // search_bas_name
            // 
            this.search_bas_name.Location = new System.Drawing.Point(168, 22);
            this.search_bas_name.Name = "search_bas_name";
            this.search_bas_name.Size = new System.Drawing.Size(103, 21);
            this.search_bas_name.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(133, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "성명";
            // 
            // search_bas_empno
            // 
            this.search_bas_empno.Location = new System.Drawing.Point(62, 22);
            this.search_bas_empno.Name = "search_bas_empno";
            this.search_bas_empno.Size = new System.Drawing.Size(65, 21);
            this.search_bas_empno.TabIndex = 5;
            // 
            // lab_bas_empno
            // 
            this.lab_bas_empno.AutoSize = true;
            this.lab_bas_empno.Location = new System.Drawing.Point(3, 26);
            this.lab_bas_empno.Name = "lab_bas_empno";
            this.lab_bas_empno.Size = new System.Drawing.Size(53, 12);
            this.lab_bas_empno.TabIndex = 4;
            this.lab_bas_empno.Text = "사원번호";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(286, 55);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(482, 630);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(482, 630);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(774, 55);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(236, 630);
            this.panel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edu_gradate);
            this.groupBox1.Controls.Add(this.edu_entdate);
            this.groupBox1.Controls.Add(this.edu_last);
            this.groupBox1.Controls.Add(this.edu_gra);
            this.groupBox1.Controls.Add(this.edu_degree);
            this.groupBox1.Controls.Add(this.edu_loe);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.edu_dept);
            this.groupBox1.Controls.Add(this.edu_grade);
            this.groupBox1.Controls.Add(this.edu_schnm);
            this.groupBox1.Controls.Add(this.edu_empno);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 630);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "학력사항";
            // 
            // edu_gradate
            // 
            this.edu_gradate.CustomFormat = " ";
            this.edu_gradate.Enabled = false;
            this.edu_gradate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edu_gradate.Location = new System.Drawing.Point(75, 93);
            this.edu_gradate.Name = "edu_gradate";
            this.edu_gradate.Size = new System.Drawing.Size(152, 21);
            this.edu_gradate.TabIndex = 26;
            // 
            // edu_entdate
            // 
            this.edu_entdate.CustomFormat = " ";
            this.edu_entdate.Enabled = false;
            this.edu_entdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edu_entdate.Location = new System.Drawing.Point(75, 70);
            this.edu_entdate.Name = "edu_entdate";
            this.edu_entdate.Size = new System.Drawing.Size(152, 21);
            this.edu_entdate.TabIndex = 25;
            // 
            // edu_last
            // 
            this.edu_last.Enabled = false;
            this.edu_last.FormattingEnabled = true;
            this.edu_last.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.edu_last.Location = new System.Drawing.Point(75, 229);
            this.edu_last.Name = "edu_last";
            this.edu_last.Size = new System.Drawing.Size(50, 20);
            this.edu_last.TabIndex = 24;
            // 
            // edu_gra
            // 
            this.edu_gra.Enabled = false;
            this.edu_gra.FormattingEnabled = true;
            this.edu_gra.Items.AddRange(new object[] {
            "졸업",
            "수료",
            "재학"});
            this.edu_gra.Location = new System.Drawing.Point(75, 207);
            this.edu_gra.Name = "edu_gra";
            this.edu_gra.Size = new System.Drawing.Size(50, 20);
            this.edu_gra.TabIndex = 24;
            // 
            // edu_degree
            // 
            this.edu_degree.Enabled = false;
            this.edu_degree.FormattingEnabled = true;
            this.edu_degree.Items.AddRange(new object[] {
            "전문학",
            "학사",
            "석사",
            "박사"});
            this.edu_degree.Location = new System.Drawing.Point(75, 162);
            this.edu_degree.Name = "edu_degree";
            this.edu_degree.Size = new System.Drawing.Size(75, 20);
            this.edu_degree.TabIndex = 23;
            // 
            // edu_loe
            // 
            this.edu_loe.Enabled = false;
            this.edu_loe.FormattingEnabled = true;
            this.edu_loe.Items.AddRange(new object[] {
            "고등학교",
            "전문대",
            "대학교",
            "대학원"});
            this.edu_loe.Location = new System.Drawing.Point(75, 48);
            this.edu_loe.Name = "edu_loe";
            this.edu_loe.Size = new System.Drawing.Size(75, 20);
            this.edu_loe.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "졸업일자";
            // 
            // edu_dept
            // 
            this.edu_dept.Enabled = false;
            this.edu_dept.Location = new System.Drawing.Point(75, 139);
            this.edu_dept.Name = "edu_dept";
            this.edu_dept.Size = new System.Drawing.Size(152, 21);
            this.edu_dept.TabIndex = 19;
            // 
            // edu_grade
            // 
            this.edu_grade.Enabled = false;
            this.edu_grade.Location = new System.Drawing.Point(75, 184);
            this.edu_grade.Name = "edu_grade";
            this.edu_grade.Size = new System.Drawing.Size(50, 21);
            this.edu_grade.TabIndex = 20;
            // 
            // edu_schnm
            // 
            this.edu_schnm.Enabled = false;
            this.edu_schnm.Location = new System.Drawing.Point(75, 116);
            this.edu_schnm.Name = "edu_schnm";
            this.edu_schnm.Size = new System.Drawing.Size(152, 21);
            this.edu_schnm.TabIndex = 18;
            // 
            // edu_empno
            // 
            this.edu_empno.Location = new System.Drawing.Point(75, 25);
            this.edu_empno.Name = "edu_empno";
            this.edu_empno.ReadOnly = true;
            this.edu_empno.Size = new System.Drawing.Size(75, 21);
            this.edu_empno.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "학과(전공)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "최종여부";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "입학일자";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "졸업구분";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "성적";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "학위";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "학교명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "학력구분";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "사원번호";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 108);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(277, 577);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView2_RowStateChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Search.png");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Tinsa_Bas3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 688);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Tinsa_Bas3";
            this.Text = "Tinsa_Edu_Form";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker edu_gradate;
        private System.Windows.Forms.DateTimePicker edu_entdate;
        private System.Windows.Forms.ComboBox edu_gra;
        private System.Windows.Forms.ComboBox edu_degree;
        private System.Windows.Forms.ComboBox edu_loe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edu_dept;
        private System.Windows.Forms.TextBox edu_grade;
        private System.Windows.Forms.TextBox edu_schnm;
        private System.Windows.Forms.TextBox edu_empno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox search_bas_name;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox search_bas_empno;
        private System.Windows.Forms.Label lab_bas_empno;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button DataDeleteBtn;
        private System.Windows.Forms.Button DataLoadBtn;
        private System.Windows.Forms.Button DataSaveBtn;
        private System.Windows.Forms.Button DataInsertBtn;
        private System.Windows.Forms.ComboBox edu_last;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}