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
            dataGridView1.Columns[0].Name = "cdg_grpcd";
            dataGridView1.Columns[1].Name = "cdg_grpnm";
            dataGridView1.Columns[2].Name = "cdg_digit";
            dataGridView1.Columns[3].Name = "cdg_length";
            dataGridView1.Columns[4].Name = "cdg_use";
            dataGridView1.Columns[5].Name = "cdg_kind";
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
        }

        public void CleanValues()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedItem = "";
            textBox5.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {            
            if (textBox1.Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[0].Value = textBox1.Text;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("셀을 먼저 선택해주세요");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("정말 저장하시겠습니까?", "저장",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if(dialogResult == DialogResult.OK)
            {
                OracleConnection con1 = new OracleConnection(cs);
                con1.Open();
                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = con1;
                cmd1.CommandText = "select CDG_GRPCD from LMG_TINSA_CDG";
                OracleDataReader reader = cmd1.ExecuteReader();

                while(reader.Read())
                {
                    if(reader.GetString(0).Equals(dataGridView1.Rows[0].Cells[0].Value))
                    {
                        MessageBox.Show(reader.GetString(0));
                        continue;
                    }
                    else
                    {
                        OracleConnection con = new OracleConnection(cs);
                        con.Open();

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
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
                            MessageBox.Show("완료");
                            return;
                        }
                    }
                }
            }
        }

        #region 중복 데이터 비교
        public void DuplicateDataComparison()
        {
           
        }
        #endregion
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

            CleanValues();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Data_Load();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 그리드뷰에서 name의 value 가져오기

            DataGridViewRow dgvr = dataGridView1.CurrentRow;
            DataRow row = (dgvr.DataBoundItem as DataRowView).Row;

            textBox1.Text = row["cdg_grpcd"].ToString();
            textBox2.Text = row["cdg_grpnm"].ToString();
            textBox3.Text = row["cdg_digit"].ToString();
            textBox4.Text = row["cdg_length"].ToString();
            textBox5.Text = row["cdg_kind"].ToString();

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
            #endregion  그리드뷰 value값 가져오기
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[1].Value = textBox2.Text;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[2].Value = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[3].Value = textBox4.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int indexnum = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.Remove(dataGridView1.Rows[indexnum]);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[5].Value = textBox5.Text;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "사용")
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() != "")
                {
                    return;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[4].Value = "Y";
                }
            }
            else if(comboBox1.Text == "사용안함")
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() != "")
                {
                    return;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[4].Value = "N";
                }
            }
            else
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() != "")
                {
                    return;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[4].Value = "";
                }
            } 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
