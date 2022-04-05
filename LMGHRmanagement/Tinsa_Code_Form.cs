using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMGHRmanagement
{
    public partial class Tinsa_Code_Form : Form
    {
        public Tinsa_Code_Form()
        {
            InitializeComponent();
            #region 데이터그리드뷰 이름 
            dataGridView1.Columns[0].Name = "cd_grpcd";
            dataGridView1.Columns[1].Name = "cd_code";
            dataGridView1.Columns[2].Name = "cd_seq";
            dataGridView1.Columns[3].Name = "cd_codnms";
            dataGridView1.Columns[4].Name = "cd_codnm";
            dataGridView1.Columns[5].Name = "cd_addinfo";
            dataGridView1.Columns[6].Name = "cd_upper";
            dataGridView1.Columns[7].Name = "cd_use";
            #endregion 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        #region 텍스트박스 초기화
        public void Textbox_Initialization()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox2.Text = "";
        }
        #endregion

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Textbox_Initialization();

            #region 그리드뷰에서 name의 value 가져오기
            textBox1.Text = dataGridView1.CurrentRow.Cells["cd_grpcd"].Value?.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["cd_code"].Value?.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["cd_seq"].Value?.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["cd_codnms"].Value?.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["cd_codnm"].Value?.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["cd_addinfo"].Value?.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["cd_upper"].Value?.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["cd_use"].Value?.ToString();
            #endregion  그리드뷰 value값 가져오기
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Text_Changed();
        }

        public void Text_Changed()
        {
            int RowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[RowIndex].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[RowIndex].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[RowIndex].Cells[2].Value = textBox3.Text;
            dataGridView1.Rows[RowIndex].Cells[3].Value = textBox4.Text;
            dataGridView1.Rows[RowIndex].Cells[4].Value = textBox5.Text;
            dataGridView1.Rows[RowIndex].Cells[5].Value = textBox6.Text;
            dataGridView1.Rows[RowIndex].Cells[6].Value = comboBox2.Text;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("셀을 먼저 선택해주세요");
            }
        }
    }
}
