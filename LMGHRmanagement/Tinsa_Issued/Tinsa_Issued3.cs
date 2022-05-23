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
using System.Globalization;

namespace LMGHRmanagement
{
    public partial class Tinsa_Issued3 : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public Tinsa_Issued3()
        {
            InitializeComponent();

            #region 인사발령대장(Grid1) 초기화
            this.dataGridView1.Columns.Add("papr_appno", "인사발령번호");
            this.dataGridView1.Columns.Add("papr_date", "시행일자");
            this.dataGridView1.Columns.Add("papr_content", "발령내용");
            this.dataGridView1.Columns.Add("papr_num", "발령인원수");

            #endregion

            #region 인시발령등록 테이블(Grid2) 초기화
            this.dataGridView2.Columns.Add("papp_empno", "사원번호");
            this.dataGridView2.Columns.Add("papp_appno", "인사발령번호");
            this.dataGridView2.Columns.Add("papp_date", "시행일자");
            this.dataGridView2.Columns.Add("papp_pap", "발령종류");
            this.dataGridView2.Columns.Add("papp_content", "발령내용");
            this.dataGridView2.Columns.Add("papp_auth", "발령권자");
            this.dataGridView2.Columns.Add("papp_basis", "발령근거");
            this.dataGridView2.Columns.Add("papp_rmk", "비고");
            this.dataGridView2.Columns.Add("papp_pos_cd", "직급코드(당시)");
            this.dataGridView2.Columns.Add("papp_dut_cd", "직책코드(당시)");
            this.dataGridView2.Columns.Add("papp_dept_cd", "부서코드(당시)");
            this.dataGridView2.Columns.Add("papp_pos_nm", "직급명(당시)");
            this.dataGridView2.Columns.Add("papp_dut_nm", "직책명(당시)");
            this.dataGridView2.Columns.Add("papp_dept_nm", "부서명(당시)");

            this.dataGridView2.Columns[1].Width = 120;
            this.dataGridView2.Columns[8].Width = 120;
            this.dataGridView2.Columns[9].Width = 120;
            this.dataGridView2.Columns[10].Width = 120;


            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 날짜 포커스
            search_papr_date.GotFocus += new EventHandler(DateFocusEvent);
            #endregion

        }

        private void DateFocusEvent(object sender, EventArgs e)
        {
            search_papr_date.CustomFormat = "yyyy-MM-dd";
        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = dataGridView1.Rows[e.RowIndex];
            this.DataGridView1FormLoad();
        }

        private void DataGridView1FormLoad()
        {
            this.dataGridView2.Rows.Clear();
            string sql = SqlCommand.Tinsa_Issued2_Select;
            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add("papp_appno", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView2SelectLoad(reader);
                }
            }
        }

        private void DataGridView2SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView2.Rows.Add();
            var cells = this.dataGridView2.Rows[index].Cells;

            cells["papp_empno"].Value = reader["papp_empno"].ToString();
            cells["papp_appno"].Value = reader["papp_appno"].ToString();
            cells["papp_date"].Value = reader["papp_date"].ToString();
            cells["papp_pap"].Value = reader["papp_pap"].ToString();
            cells["papp_content"].Value = reader["papp_content"].ToString();
            cells["papp_auth"].Value = reader["papp_auth"].ToString();
            cells["papp_basis"].Value = reader["papp_basis"].ToString();
            cells["papp_rmk"].Value = reader["papp_rmk"].ToString();
            cells["papp_pos_cd"].Value = reader["papp_pos_cd"].ToString();
            cells["papp_dut_cd"].Value = reader["papp_dut_cd"].ToString();
            cells["papp_dept_cd"].Value = reader["papp_dept_cd"].ToString();
            cells["papp_pos_nm"].Value = reader["papp_pos_nm"].ToString();
            cells["papp_dut_nm"].Value = reader["papp_dut_nm"].ToString();
            cells["papp_dept_nm"].Value = reader["papp_dept_nm"].ToString();
        }

        private void DataLoadBtn_Click(object sender, EventArgs e)
        {
            //new Oracleparameter("parameter", $"%{parameter}%");
            this.dataGridView1.Rows.Clear();
            string sql = SqlCommand.Tinsa_Issued1_Select;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("papr_appno", $"%{search_papr_appno.Text}%");
                    if (search_papr_date.CustomFormat == " ") { command.Parameters.Add("papr_date", $"%{null}%"); }
                    else { command.Parameters.Add("papr_date", $"%{DateValues(search_papr_date.Text.ToString())}%");}
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridViewSelectDataLoad(reader);
                }
            }
        }

        private void DataGridViewSelectDataLoad(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["papr_appno"].Value = reader["papr_appno"].ToString();
            cells["papr_date"].Value = reader["papr_date"].ToString();
            cells["papr_content"].Value = reader["papr_content"].ToString();
            cells["papr_num"].Value = reader["papr_num"].ToString();
        }

        private object DateValues(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                return v = "";
            }
            return v.Replace("-", string.Empty);
        }
    }
}
