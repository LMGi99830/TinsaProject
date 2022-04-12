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
        private string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        private DataTable dataTable;
        private int digit_value = 0;
        public TInsa_GroupCode_Form()
        {
            InitializeComponent();
            this.dataGridView1.DataSource =  this.dataTable = new DataTable();
            #region 데이터그리드뷰 이름 
            this.dataTable.Columns.Add("cdg_type");
            this.dataTable.Columns.Add("cdg_grpcd");
            this.dataTable.Columns.Add("cdg_grpnm");
            this.dataTable.Columns.Add("cdg_digit");
            this.dataTable.Columns.Add("cdg_length");
            this.dataTable.Columns.Add("cdg_use");
            this.dataTable.Columns.Add("cdg_kind");

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
            int RowCount = dataGridView1.Rows.Count;
            if (RowCount >= 0)
            {
                this.dataTable.Rows.Add(this.dataTable.NewRow());
                dataGridView1.Rows[RowCount].Cells[0].Value = "INSERT";
                dataGridView1.ClearSelection();
                dataGridView1.Rows[RowCount].Selected = true;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[RowCount].Cells[0];
                DoubleClickMethod();
                return;
            }
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
            int rowcount = dataGridView1.Rows.Count;            

            for (int i = 0; i <= rowcount; i++)
            {
                if (!dataGridView1.SelectedRows[0].ErrorText.Equals(""))
                {
                    MessageBox.Show("오류가 발생한 행이 있습니다.");
                    return;
                }
            }

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
                        cmd.Parameters.Add(new OracleParameter("CODEUSE", GetUseCaseToDat(dataGridView1.Rows[i].Cells["cdg_use"].Value.ToString())));
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

        private string GetUseCaseToDat(string useCase)
        {
            if (useCase.Equals("Y")) return "Y";
            return "N";
        }

        public void Data_Load()
        {
            OracleConnection con = new OracleConnection(cs);
            con.Open();
            OracleDataAdapter adapt = new OracleDataAdapter("select 'SELECT' CDG_TYPE, CDG_GRPCD, CDG_GRPNM, CDG_DIGIT, CDG_LENGTH," +
                "CDG_USE, CDG_KIND from LMG_TINSA_CDG where CDG_GRPCD like '%"+ textBox6.Text +"%'" +
                "and CDG_GRPNM like '%"+ textBox7.Text + "%' and CDG_USE like '%"+ comboBox2.Text +"%' order by CDG_GRPCD", con);
            dataTable = new DataTable();
            adapt.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            con.Close();
            comboBox1.SelectedIndex = 0;
            int RowCount = dataGridView1.Rows.Count;
            if (RowCount == 0)
            {
                MessageBox.Show("데이터가 존재하지않습니다.");
                return;
            }
            DoubleClickMethod();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Data_Load();
            errorProvider1.Clear();
            int RowCount = dataGridView1.Rows.Count;
            if(RowCount <= 0)
            {
                Enabled_change_false();
                return;
            }
            Enabled_Change_True();
        }

        private void Enabled_Change_True()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            comboBox1.Enabled = true;
            textBox5.Enabled = true;
        }
        private void Enabled_change_false()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            comboBox1.Enabled = false;
            textBox5.Enabled = false;
        }

        public void DoubleClickMethod()
        {
            #region 그리드뷰에서 name의 value 가져오기

            Enabled_Change_True();
            DataGridViewRow dgvr = dataGridView1.CurrentRow;
            DataRow row = (dgvr.DataBoundItem as DataRowView).Row;
            Console.WriteLine(this.dataTable);
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

            if (row["cdg_digit"].ToString().Equals(""))
            {
                return;
            }
            digit_value = int.Parse(row["cdg_digit"].ToString());


            #endregion  그리드뷰 value값 가져오기
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DoubleClickMethod();
            textBox1_Validating(null,null);
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
            //행에 빈값이 하나라도 있으면 삭제 버튼을 눌렀을때 행을 지움
            for (int i = 1; i <= 6; i++)
            {
                if (dataGridView1.Rows[indexnum].Cells[i].Value.ToString().Equals(""))
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[indexnum]);
                    dataGridView1.Rows[indexnum - 1].Selected = true;
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[indexnum-1].Cells[0];
                    return;
                }
            }
            dataGridView1.Rows[indexnum].Cells[0].Value = "DELETE";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            if (textBox5.Text == "")
            {
                return;
            }
            dataGridView1.Rows[i].Cells[6].Value = textBox5.Text;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount == 0)
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            if (comboBox1.Text == "사용")
            {
                if(dataGridView1.Rows[i].Cells[0].Value.Equals("SELECT"))
                {
                    return;
                }
                dataGridView1.Rows[i].Cells[5].Value = "Y";
            }

            if (comboBox1.Text == "사용안함")
            {
                if(dataGridView1.Rows[i].Cells[0].Value.Equals("SELECT"))
                {
                    return;
                }
                dataGridView1.Rows[i].Cells[5].Value = "N";
            }

            if (comboBox1.Text == "선택")
            {
                if(dataGridView1.Rows[i].Cells[0].Value.Equals("SELECT"))
                {
                    return;
                }
                dataGridView1.Rows[i].Cells[5].Value = "";
            }
        }

        //KeyPress와 KeyDown의 차이
        //Press는 한영변환, 방향키, DELETE버튼에는 반응 x
        //Down은 어떤키에도 다 반응함
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char.IsDigit은 유니코드 문자가 10진수인지 확인하는코드
            //e.Keychar은 누른키에 해당하는 문자를 가져옴
            //Convert.Tochar은 지정된 값을 유니코드 문자로 변경
            //e.Hadled는 

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            //Control ctl = sender as Control;

            //if (ctl?.Text == "")
            //{
            //    errorProvider1.SetError(ctl, ctl.Tag + "를 작성해주세요."); 
            //    dataGridView1.SelectedRows[0].ErrorText = ctl.Tag + "를 작성해주세요.";
            //    return;
            //}
            //errorProvider1.SetError(textBox1, null);
            //dataGridView1.SelectedRows[0].ErrorText = "";

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "그룹코드를 작성해주세요.");
                dataGridView1.SelectedRows[0].ErrorText = "그룹코드를 작성해주세요.";
                return;
            }
            errorProvider1.SetError(textBox1, null);
            dataGridView1.SelectedRows[0].ErrorText = "";
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "그룹코드명을 작성해주세요.");
                dataGridView1.SelectedRows[0].ErrorText = "그룹코드명 작성해주세요.";
                return;
            }
            errorProvider1.SetError(textBox2, null);
            dataGridView1.SelectedRows[0].ErrorText = "";
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "단위코드 자릿수를 작성해주세요.");
                dataGridView1.SelectedRows[0].ErrorText = "단위코드 자릿수를 작성해주세요.";
                return;
            }
            errorProvider1.SetError(textBox3, null);
            dataGridView1.SelectedRows[0].ErrorText = "";
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "단위코드명 길이를 작성해주세요.");
                dataGridView1.SelectedRows[0].ErrorText = "단위코드명 길이를 작성해주세요.";
                return;
            }
            errorProvider1.SetError(textBox4, null);
            dataGridView1.SelectedRows[0].ErrorText = "";
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == "선택")
            {
                errorProvider1.SetError(comboBox1, "사용여부를 작성해주세요.");
                dataGridView1.SelectedRows[0].ErrorText = "사용여부를 작성해주세요.";
                return;
            }
            errorProvider1.SetError(comboBox1, null);
            dataGridView1.SelectedRows[0].ErrorText = "";
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                errorProvider1.SetError(textBox5, "단위코드명 길이를 작성해주세요.");
                dataGridView1.SelectedRows[0].ErrorText = "단위코드명 길이를 작성해주세요.";
                return;
            }
            errorProvider1.SetError(textBox5, null);
            dataGridView1.SelectedRows[0].ErrorText = "";
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if(this.dataGridView1.Rows.Count <= 0)
            {
                button2.Enabled = false;
                button4.Enabled = false;
                return;
            }
            button2.Enabled = true;
            button4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
