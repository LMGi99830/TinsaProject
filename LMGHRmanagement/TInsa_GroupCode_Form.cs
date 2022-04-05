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
        public void Textbox_Initialization()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Text_Changed();
        }
        

        public void Text_Changed()
        {
            dt.Rows[0].ItemArray[0] = textBox1.Text;
            dataGridView1.DataSource = dt;

            //, textBox2.Text, textBox3.Text, textBox4.Text,
            //    comboBox1.SelectedItem, textBox5.Text
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
            OracleConnection con = new OracleConnection(cs);
            con.Open();
 
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
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

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(cs);
            con.Open();
            OracleDataAdapter adapt = new OracleDataAdapter("select * from lmg_tinsa_cdg order by cdg_grpcd", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //#region 그리드뷰에서 name의 value 가져오기
            //int RowIndex = dataGridView1.CurrentCell.RowIndex;
            //string use_value;

            //textBox1.Text = dataGridView1.Rows[RowIndex].Cells[0].Value.ToString();
            //textBox2.Text = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
            //textBox3.Text = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString();
            //textBox4.Text = dataGridView1.Rows[RowIndex].Cells[3].Value.ToString();
            //textBox5.Text = dataGridView1.Rows[RowIndex].Cells[5].Value.ToString();
            //if (dataGridView1.Rows[RowIndex].Cells[4].Value.ToString() == "Y")
            //{
            //    use_value = "사용";                
            //}
            //else
            //{
            //    use_value = "사용안함";
            //}
            //comboBox1.Text = use_value.ToString();
            

            //#endregion  그리드뷰 value값 가져오기
        }
    }
}
