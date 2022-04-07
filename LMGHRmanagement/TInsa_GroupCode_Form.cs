using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace LMGHRmanagement
{
    public partial class TInsa_GroupCode_Form : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        DataTable dt;
        public TInsa_GroupCode_Form()
        {
            InitializeComponent();

            #region 데이터그리드뷰 이름 
            dataGridView1.Columns[0].Name = "cdg_type";
            dataGridView1.Columns[1].Name = "cdg_grpcd";
            dataGridView1.Columns[2].Name = "cdg_grpnm";
            dataGridView1.Columns[3].Name = "cdg_digit";
            dataGridView1.Columns[4].Name = "cdg_length";
            dataGridView1.Columns[5].Name = "cdg_use";
            dataGridView1.Columns[6].Name = "cdg_kind";
            #endregion 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int MaxRow = dataGridView1.Rows.Count;
            if (MaxRow >= 0)
            {
                DataTable dt = new DataTable();
                dt = dataGridView1.DataSource as DataTable;
                dt.Rows.Add();
                dataGridView1.DataSource = dt;
            }
            dataGridView1.Rows[MaxRow].Cells[0].Value = "INSERT";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[1].Value = textBox1.Text;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            int RowCount = dataGridView1.CurrentCell.RowIndex;
            if (textBox1.Text.Length > 0 && !dataGridView1.Rows[RowCount].Cells[0].Value.Equals("INSERT"))
            {
                dataGridView1.Rows[RowCount].Cells[0].Value = "UPDATE";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("정말 저장하시겠습니까?", "저장",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.OK)
            {
                OracleConnection con = new OracleConnection(cs);
                con.Open();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.Equals("INSERT"))
                    {
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO LMG_TINSA_CDG(CDG_GRPCD, CDG_GRPNM, CDG_DIGIT, CDG_LENGTH, CDG_USE, CDG_KIND)" +
                            "VALUES (:GROUPCODE, :CODENAME, :CODECOUNT, :CODELENGTH, :CODEUSE, :CODEKIND)";
                        cmd.Parameters.Add(new OracleParameter("GROUPCODE", dataGridView1.Rows[i].Cells["cdg_grpcd"].Value.ToString()));
                        cmd.Parameters.Add(new OracleParameter("CODENAME", dataGridView1.Rows[i].Cells["cdg_grpnm"].Value.ToString()));
                        cmd.Parameters.Add(new OracleParameter("CODECOUNT", dataGridView1.Rows[i].Cells["cdg_digit"].Value.ToString()));
                        cmd.Parameters.Add(new OracleParameter("CODELENGTH", dataGridView1.Rows[i].Cells["cdg_length"].Value.ToString()));
                        string combobox_value;

                        if (dataGridView1.Rows[i].Cells["cdg_use"].Value.ToString() == "사용")
                        {
                            combobox_value = "Y";
                        }
                        else { combobox_value = "N"; }
                        cmd.Parameters.Add(new OracleParameter("CODEUSE", combobox_value));
                        cmd.Parameters.Add(new OracleParameter("CODEKIND", dataGridView1.Rows[i].Cells["cdg_kind"].Value.ToString()));

                        cmd.ExecuteNonQuery();
                    }
                    else if (dataGridView1.Rows[i].Cells[0].Value.Equals("DELETE"))
                    {
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "DELETE FROM LMG_TINSA_CDG WHERE CDG_GRPCD = :CDG_GRPCD";
                        cmd.Parameters.Add(new OracleParameter("CDG_GRPCD", dataGridView1.Rows[i].Cells[1].Value));
                        cmd.ExecuteNonQuery();
                    }
                    else if (dataGridView1.Rows[i].Cells[0].Value.Equals("UPDATE"))
                    {
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "UPDATE LMG_TINSA_CDG SET CDG_GRPNM = :CDG_GRPNM, CDG_DIGIT = :CDG_DIGIT, CDG_LENGTH = :CDG_LENGTH, CDG_USE = :CDG_USE, CDG_KIND = :CDG_KIND WHERE CDG_GRPCD = :CDG_GRPCD";
                        cmd.Parameters.Add(new OracleParameter("CDG_GRPNM", dataGridView1.Rows[i].Cells[2].Value));
                        cmd.Parameters.Add(new OracleParameter("CDG_DIGIT", dataGridView1.Rows[i].Cells[3].Value));
                        cmd.Parameters.Add(new OracleParameter("CDG_LENGTH", dataGridView1.Rows[i].Cells[4].Value));
                        cmd.Parameters.Add(new OracleParameter("CDG_USE", dataGridView1.Rows[i].Cells[5].Value));
                        cmd.Parameters.Add(new OracleParameter("CDG_KIND", dataGridView1.Rows[i].Cells[6].Value));
                        cmd.Parameters.Add(new OracleParameter("CDG_GRPCD", dataGridView1.Rows[i].Cells[1].Value));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("저장이 완료되었습니다.");
                Data_Load();
                con.Close();
            }
        }

        public void Data_Load()
        {
            OracleConnection con = new OracleConnection(cs);
            con.Open();
            OracleDataAdapter adapt = new OracleDataAdapter("select * from lmg_tinsa_cdg order by cdg_grpcd", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            comboBox1.SelectedIndex = 0;
            int RowCount = dataGridView1.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = "SELECT";
            }
            DoubleClick();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Data_Load();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            comboBox1.Enabled = true;
            textBox5.Enabled = true;
        }

      
        public void DoubleClick()
        {
            #region 그리드뷰에서 name의 value 가져오기

            DataGridViewRow dgvr = dataGridView1.CurrentRow;
            DataRow row = (dgvr.DataBoundItem as DataRowView).Row;

            textBox1.Text = row["cdg_grpcd"].ToString();
            textBox2.Text = row["cdg_grpnm"].ToString();
            textBox3.Text = row["cdg_digit"].ToString();
            textBox4.Text = row["cdg_length"].ToString();
            if (row["cdg_use"].ToString() == "Y")
            {
                comboBox1.Text = "사용";
            }
            else if (row["cdg_use"].ToString() == "N")
            {
                comboBox1.Text = "사용안함";
            }
            else
            {
                comboBox1.Text = "선택";
            }
            textBox5.Text = row["cdg_kind"].ToString();


            #endregion  그리드뷰 value값 가져오기
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DoubleClick();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[2].Value = textBox2.Text;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[3].Value = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[4].Value = textBox4.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int indexnum = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[indexnum].Cells[0].Value = "DELETE";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[6].Value = textBox5.Text;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "사용")
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.Rows[i].Cells[5].Value.ToString() != "")
                {
                    return;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = "Y";
                }
            }
            else if (comboBox1.Text == "사용안함")
            {
                MessageBox.Show("2");
                int i = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.Rows[i].Cells[5].Value.ToString() != "")
                {
                    return;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = "N";
                }
            }
            else
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.Rows[i].Cells[5].Value.ToString() != "")
                {
                    return;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = "";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //에러 띄우는 코드
            dataGridView1.SelectedRows[0].ErrorText = "adwaf";
        }

        //KeyPress와 KeyDown의 차이
        //Press는 한영변환, 방향키, DELETE버튼에는 반응 x
        //Down은 어떤키에도 다 반응함
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char.IsDigit은 유니코드 문자가 10진수인지 확인하는코드
            //e.Keychar은 누른키에 해당하는 문자를 가져옴
            //Convert.Tochar은 지정된 값을 유니코드 문자로 변경
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
