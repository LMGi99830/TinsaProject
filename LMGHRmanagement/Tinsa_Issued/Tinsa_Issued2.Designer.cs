
namespace LMGHRmanagement
{
    partial class Tinsa_Issued2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tinsa_Issued2));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.papp_dept_cd = new System.Windows.Forms.ComboBox();
            this.papp_dut_cd = new System.Windows.Forms.ComboBox();
            this.papp_pos_cd = new System.Windows.Forms.ComboBox();
            this.papp_pap = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.papp_empno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.papp_dept_nm = new System.Windows.Forms.TextBox();
            this.papp_dut_nm = new System.Windows.Forms.TextBox();
            this.papp_pos_nm = new System.Windows.Forms.TextBox();
            this.papp_auth = new System.Windows.Forms.TextBox();
            this.papp_rmk = new System.Windows.Forms.TextBox();
            this.papp_basis = new System.Windows.Forms.TextBox();
            this.papp_content = new System.Windows.Forms.TextBox();
            this.papp_date = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.papp_appno = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DataSaveBtn = new System.Windows.Forms.Button();
            this.DataInsertBtn = new System.Windows.Forms.Button();
            this.DataLoadBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.search_papr_appno = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.search_papr_date = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Search.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 326);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 37);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(717, 37);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "검색옵션";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(67, 14);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "사원번호";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 369);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 316);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(717, 316);
            this.dataGridView2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(726, 58);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 4);
            this.panel3.Size = new System.Drawing.Size(284, 627);
            this.panel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.papp_dept_cd);
            this.groupBox1.Controls.Add(this.papp_dut_cd);
            this.groupBox1.Controls.Add(this.papp_pos_cd);
            this.groupBox1.Controls.Add(this.papp_pap);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.papp_empno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.papp_dept_nm);
            this.groupBox1.Controls.Add(this.papp_dut_nm);
            this.groupBox1.Controls.Add(this.papp_pos_nm);
            this.groupBox1.Controls.Add(this.papp_auth);
            this.groupBox1.Controls.Add(this.papp_rmk);
            this.groupBox1.Controls.Add(this.papp_basis);
            this.groupBox1.Controls.Add(this.papp_content);
            this.groupBox1.Controls.Add(this.papp_date);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.papp_appno);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 627);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "인사발령정보";
            // 
            // papp_dept_cd
            // 
            this.papp_dept_cd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.papp_dept_cd.FormattingEnabled = true;
            this.papp_dept_cd.Location = new System.Drawing.Point(101, 408);
            this.papp_dept_cd.Name = "papp_dept_cd";
            this.papp_dept_cd.Size = new System.Drawing.Size(118, 20);
            this.papp_dept_cd.TabIndex = 35;
            // 
            // papp_dut_cd
            // 
            this.papp_dut_cd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.papp_dut_cd.FormattingEnabled = true;
            this.papp_dut_cd.Location = new System.Drawing.Point(101, 363);
            this.papp_dut_cd.Name = "papp_dut_cd";
            this.papp_dut_cd.Size = new System.Drawing.Size(118, 20);
            this.papp_dut_cd.TabIndex = 35;
            // 
            // papp_pos_cd
            // 
            this.papp_pos_cd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.papp_pos_cd.FormattingEnabled = true;
            this.papp_pos_cd.Location = new System.Drawing.Point(101, 317);
            this.papp_pos_cd.Name = "papp_pos_cd";
            this.papp_pos_cd.Size = new System.Drawing.Size(118, 20);
            this.papp_pos_cd.TabIndex = 35;
            // 
            // papp_pap
            // 
            this.papp_pap.Enabled = false;
            this.papp_pap.FormattingEnabled = true;
            this.papp_pap.Location = new System.Drawing.Point(101, 86);
            this.papp_pap.Name = "papp_pap";
            this.papp_pap.Size = new System.Drawing.Size(118, 20);
            this.papp_pap.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(223, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 21);
            this.button1.TabIndex = 33;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // papp_empno
            // 
            this.papp_empno.Location = new System.Drawing.Point(101, 40);
            this.papp_empno.Name = "papp_empno";
            this.papp_empno.ReadOnly = true;
            this.papp_empno.Size = new System.Drawing.Size(118, 21);
            this.papp_empno.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "사원번호";
            // 
            // papp_dept_nm
            // 
            this.papp_dept_nm.Location = new System.Drawing.Point(101, 431);
            this.papp_dept_nm.Name = "papp_dept_nm";
            this.papp_dept_nm.ReadOnly = true;
            this.papp_dept_nm.Size = new System.Drawing.Size(118, 21);
            this.papp_dept_nm.TabIndex = 14;
            // 
            // papp_dut_nm
            // 
            this.papp_dut_nm.Location = new System.Drawing.Point(101, 385);
            this.papp_dut_nm.Name = "papp_dut_nm";
            this.papp_dut_nm.ReadOnly = true;
            this.papp_dut_nm.Size = new System.Drawing.Size(118, 21);
            this.papp_dut_nm.TabIndex = 14;
            // 
            // papp_pos_nm
            // 
            this.papp_pos_nm.Location = new System.Drawing.Point(101, 340);
            this.papp_pos_nm.Name = "papp_pos_nm";
            this.papp_pos_nm.ReadOnly = true;
            this.papp_pos_nm.Size = new System.Drawing.Size(118, 21);
            this.papp_pos_nm.TabIndex = 14;
            // 
            // papp_auth
            // 
            this.papp_auth.Enabled = false;
            this.papp_auth.Location = new System.Drawing.Point(101, 170);
            this.papp_auth.Name = "papp_auth";
            this.papp_auth.Size = new System.Drawing.Size(170, 21);
            this.papp_auth.TabIndex = 14;
            // 
            // papp_rmk
            // 
            this.papp_rmk.Enabled = false;
            this.papp_rmk.Location = new System.Drawing.Point(101, 255);
            this.papp_rmk.Multiline = true;
            this.papp_rmk.Name = "papp_rmk";
            this.papp_rmk.Size = new System.Drawing.Size(170, 60);
            this.papp_rmk.TabIndex = 13;
            // 
            // papp_basis
            // 
            this.papp_basis.Enabled = false;
            this.papp_basis.Location = new System.Drawing.Point(101, 193);
            this.papp_basis.Multiline = true;
            this.papp_basis.Name = "papp_basis";
            this.papp_basis.Size = new System.Drawing.Size(170, 60);
            this.papp_basis.TabIndex = 13;
            // 
            // papp_content
            // 
            this.papp_content.Enabled = false;
            this.papp_content.Location = new System.Drawing.Point(101, 108);
            this.papp_content.Multiline = true;
            this.papp_content.Name = "papp_content";
            this.papp_content.Size = new System.Drawing.Size(170, 60);
            this.papp_content.TabIndex = 13;
            // 
            // papp_date
            // 
            this.papp_date.CustomFormat = " ";
            this.papp_date.Enabled = false;
            this.papp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.papp_date.Location = new System.Drawing.Point(101, 63);
            this.papp_date.Name = "papp_date";
            this.papp_date.Size = new System.Drawing.Size(118, 21);
            this.papp_date.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "비고";
            // 
            // papp_appno
            // 
            this.papp_appno.Location = new System.Drawing.Point(101, 16);
            this.papp_appno.Name = "papp_appno";
            this.papp_appno.ReadOnly = true;
            this.papp_appno.Size = new System.Drawing.Size(118, 21);
            this.papp_appno.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 434);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "부서명(당시)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "발령근거";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 388);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "직책명(당시)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 411);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 12);
            this.label14.TabIndex = 9;
            this.label14.Text = "부서코드(당시)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "발령권자";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 366);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "직책코드(당시)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 343);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "직급명(당시)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "직급코드(당시)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "발령내용";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "발령종류";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "시행일자";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "인사발령번호";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.994186F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.70349F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.51163F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1013, 688);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.DataSaveBtn);
            this.flowLayoutPanel1.Controls.Add(this.DataInsertBtn);
            this.flowLayoutPanel1.Controls.Add(this.DataLoadBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1007, 32);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // DataSaveBtn
            // 
            this.DataSaveBtn.Location = new System.Drawing.Point(929, 3);
            this.DataSaveBtn.Name = "DataSaveBtn";
            this.DataSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.DataSaveBtn.TabIndex = 20;
            this.DataSaveBtn.Text = "저장";
            this.DataSaveBtn.UseVisualStyleBackColor = true;
            this.DataSaveBtn.Click += new System.EventHandler(this.DataSaveBtn_Click);
            // 
            // DataInsertBtn
            // 
            this.DataInsertBtn.Location = new System.Drawing.Point(848, 3);
            this.DataInsertBtn.Name = "DataInsertBtn";
            this.DataInsertBtn.Size = new System.Drawing.Size(75, 23);
            this.DataInsertBtn.TabIndex = 17;
            this.DataInsertBtn.Text = "삽입";
            this.DataInsertBtn.UseVisualStyleBackColor = true;
            this.DataInsertBtn.Click += new System.EventHandler(this.DataInsertBtn_Click);
            // 
            // DataLoadBtn
            // 
            this.DataLoadBtn.Location = new System.Drawing.Point(767, 3);
            this.DataLoadBtn.Name = "DataLoadBtn";
            this.DataLoadBtn.Size = new System.Drawing.Size(75, 23);
            this.DataLoadBtn.TabIndex = 19;
            this.DataLoadBtn.Text = "조회";
            this.DataLoadBtn.UseVisualStyleBackColor = true;
            this.DataLoadBtn.Click += new System.EventHandler(this.DataLoadBtn_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(717, 37);
            this.panel4.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.search_papr_appno);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.search_papr_date);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(717, 37);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "검색옵션";
            // 
            // search_papr_appno
            // 
            this.search_papr_appno.Location = new System.Drawing.Point(92, 16);
            this.search_papr_appno.Name = "search_papr_appno";
            this.search_papr_appno.Size = new System.Drawing.Size(118, 21);
            this.search_papr_appno.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(216, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "시행일자";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "인사발령번호";
            // 
            // search_papr_date
            // 
            this.search_papr_date.CustomFormat = " ";
            this.search_papr_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.search_papr_date.Location = new System.Drawing.Point(275, 16);
            this.search_papr_date.Name = "search_papr_date";
            this.search_papr_date.Size = new System.Drawing.Size(118, 21);
            this.search_papr_date.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 101);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(717, 219);
            this.panel5.TabIndex = 4;
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
            this.dataGridView1.Size = new System.Drawing.Size(717, 219);
            this.dataGridView1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Tinsa_Issued2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 688);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Tinsa_Issued2";
            this.Text = "Tinsa_Issued_En_Form";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox papp_auth;
        private System.Windows.Forms.TextBox papp_rmk;
        private System.Windows.Forms.TextBox papp_basis;
        private System.Windows.Forms.TextBox papp_content;
        private System.Windows.Forms.DateTimePicker papp_date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox papp_appno;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox papp_dept_nm;
        private System.Windows.Forms.TextBox papp_dut_nm;
        private System.Windows.Forms.TextBox papp_pos_nm;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox search_papr_appno;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker search_papr_date;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button DataSaveBtn;
        private System.Windows.Forms.Button DataInsertBtn;
        private System.Windows.Forms.Button DataLoadBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox papp_empno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox papp_pap;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox papp_dept_cd;
        private System.Windows.Forms.ComboBox papp_dut_cd;
        private System.Windows.Forms.ComboBox papp_pos_cd;
    }
}