
namespace LMGHRmanagement
{
    partial class Tinsa_Issued1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tinsa_Issued1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.papr_num = new System.Windows.Forms.NumericUpDown();
            this.papr_content = new System.Windows.Forms.TextBox();
            this.papr_date = new System.Windows.Forms.DateTimePicker();
            this.papr_appno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.search_papr_appno = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.search_papr_date = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DataDeleteBtn = new System.Windows.Forms.Button();
            this.DataSaveBtn = new System.Windows.Forms.Button();
            this.DataInsertBtn = new System.Windows.Forms.Button();
            this.DataLoadBtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.papr_num)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Search.png");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(736, 50);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(274, 563);
            this.panel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.papr_num);
            this.groupBox1.Controls.Add(this.papr_content);
            this.groupBox1.Controls.Add(this.papr_date);
            this.groupBox1.Controls.Add(this.papr_appno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 563);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "인사발령정보";
            // 
            // papr_num
            // 
            this.papr_num.Location = new System.Drawing.Point(101, 122);
            this.papr_num.Name = "papr_num";
            this.papr_num.Size = new System.Drawing.Size(36, 21);
            this.papr_num.TabIndex = 14;
            // 
            // papr_content
            // 
            this.papr_content.Location = new System.Drawing.Point(101, 59);
            this.papr_content.Multiline = true;
            this.papr_content.Name = "papr_content";
            this.papr_content.Size = new System.Drawing.Size(170, 60);
            this.papr_content.TabIndex = 13;
            // 
            // papr_date
            // 
            this.papr_date.CustomFormat = " ";
            this.papr_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.papr_date.Location = new System.Drawing.Point(101, 36);
            this.papr_date.Name = "papr_date";
            this.papr_date.Size = new System.Drawing.Size(118, 21);
            this.papr_date.TabIndex = 12;
            // 
            // papr_appno
            // 
            this.papr_appno.Location = new System.Drawing.Point(101, 13);
            this.papr_appno.Name = "papr_appno";
            this.papr_appno.Size = new System.Drawing.Size(118, 21);
            this.papr_appno.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "발령 인원수";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "발령내용";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "시행일자";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "인사발령번호";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 524);
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
            this.dataGridView1.Size = new System.Drawing.Size(727, 524);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 33);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.search_papr_appno);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.search_papr_date);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(727, 33);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "검색옵션";
            // 
            // search_papr_appno
            // 
            this.search_papr_appno.Location = new System.Drawing.Point(89, 12);
            this.search_papr_appno.Name = "search_papr_appno";
            this.search_papr_appno.Size = new System.Drawing.Size(118, 21);
            this.search_papr_appno.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(213, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 13;
            this.label17.Text = "시행일자";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "인사발령번호";
            // 
            // search_papr_date
            // 
            this.search_papr_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.search_papr_date.Location = new System.Drawing.Point(273, 13);
            this.search_papr_date.Name = "search_papr_date";
            this.search_papr_date.Size = new System.Drawing.Size(118, 21);
            this.search_papr_date.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.35933F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.64067F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1013, 616);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.DataDeleteBtn);
            this.flowLayoutPanel1.Controls.Add(this.DataSaveBtn);
            this.flowLayoutPanel1.Controls.Add(this.DataInsertBtn);
            this.flowLayoutPanel1.Controls.Add(this.DataLoadBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1007, 24);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // DataDeleteBtn
            // 
            this.DataDeleteBtn.Location = new System.Drawing.Point(929, 3);
            this.DataDeleteBtn.Name = "DataDeleteBtn";
            this.DataDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DataDeleteBtn.TabIndex = 18;
            this.DataDeleteBtn.Text = "삭제";
            this.DataDeleteBtn.UseVisualStyleBackColor = true;
            // 
            // DataSaveBtn
            // 
            this.DataSaveBtn.Location = new System.Drawing.Point(848, 3);
            this.DataSaveBtn.Name = "DataSaveBtn";
            this.DataSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.DataSaveBtn.TabIndex = 20;
            this.DataSaveBtn.Text = "저장";
            this.DataSaveBtn.UseVisualStyleBackColor = true;
            this.DataSaveBtn.Click += new System.EventHandler(this.DataSaveBtn_Click);
            // 
            // DataInsertBtn
            // 
            this.DataInsertBtn.Location = new System.Drawing.Point(767, 3);
            this.DataInsertBtn.Name = "DataInsertBtn";
            this.DataInsertBtn.Size = new System.Drawing.Size(75, 23);
            this.DataInsertBtn.TabIndex = 17;
            this.DataInsertBtn.Text = "삽입";
            this.DataInsertBtn.UseVisualStyleBackColor = true;
            this.DataInsertBtn.Click += new System.EventHandler(this.DataInsertBtn_Click);
            // 
            // DataLoadBtn
            // 
            this.DataLoadBtn.Location = new System.Drawing.Point(686, 3);
            this.DataLoadBtn.Name = "DataLoadBtn";
            this.DataLoadBtn.Size = new System.Drawing.Size(75, 23);
            this.DataLoadBtn.TabIndex = 19;
            this.DataLoadBtn.Text = "조회";
            this.DataLoadBtn.UseVisualStyleBackColor = true;
            this.DataLoadBtn.Click += new System.EventHandler(this.DataLoadBtn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Tinsa_Issued1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 616);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Tinsa_Issued1";
            this.Text = "Tinsa_Issued_Form";
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.papr_num)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox papr_content;
        private System.Windows.Forms.DateTimePicker papr_date;
        private System.Windows.Forms.TextBox papr_appno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown papr_num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button DataDeleteBtn;
        private System.Windows.Forms.Button DataSaveBtn;
        private System.Windows.Forms.Button DataInsertBtn;
        private System.Windows.Forms.Button DataLoadBtn;
        private System.Windows.Forms.TextBox search_papr_appno;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker search_papr_date;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}