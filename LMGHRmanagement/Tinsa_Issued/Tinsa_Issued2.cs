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
    public partial class Tinsa_Issued2 : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public Tinsa_Issued2()
        {
            InitializeComponent();

            #region 인시발령등록 테이블(Grid2) 초기화
            this.dataGridView2.Columns.Add("papp_type", "상태");
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

            this.dataGridView2.Columns[2].Width = 120;
            this.dataGridView2.Columns[9].Width = 120;
            this.dataGridView2.Columns[10].Width = 120;
            this.dataGridView2.Columns[11].Width = 120;


            #endregion

            #region 인사발령대장(Grid1) 초기화
            this.dataGridView1.Columns.Add("papr_appno", "인사발령번호");
            this.dataGridView1.Columns.Add("papr_date", "시행일자");
            this.dataGridView1.Columns.Add("papr_content", "발령내용");
            this.dataGridView1.Columns.Add("papr_num", "발령인원수");

            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 포커스
            search_papr_date.GotFocus += new EventHandler(DateFocusEvent);
            papp_pap.GotFocus += new EventHandler(PapFocusEvent);
            papp_date.GotFocus += new EventHandler(PappDateFocusEvent);
            papp_pos_cd.GotFocus += new EventHandler(PosCdFocusEvent);
            papp_dut_cd.GotFocus += new EventHandler(DutCdFocusEvent);
            papp_dept_cd.GotFocus += new EventHandler(DeptCdFocusEvent);
            #endregion

            #region 벨리데이션체크
            papp_empno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_appno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_date.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_pap.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_content.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_auth.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_basis.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_rmk.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_pos_cd.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_dut_cd.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_dept_cd.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_pos_nm.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_dut_nm.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papp_dept_nm.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion

            #region 그리드뷰 연동
            papp_empno.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_appno.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_date.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_pap.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_content.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_auth.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_basis.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_rmk.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_pos_cd.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_dut_cd.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_dept_cd.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_pos_nm.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_dut_nm.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papp_dept_nm.TextChanged += new EventHandler(DataGridViewVandingEvent);
            #endregion
        }

        private void DeptCdFocusEvent(object sender, EventArgs e)
        {
            papp_dept_cd.Items.Clear();
            string sql = @"select DEPT_CODE, DEPT_NAME from lmg_tinsa_dept order by DEPT_CODE";

            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    OracleDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rd.Read())
                    {
                        papp_dept_cd.Items.Add(rd.GetString(0).ToString() + ":" + rd.GetString(1).ToString());
                    }
                }
            }
        }

        private void DutCdFocusEvent(object sender, EventArgs e)
        {
            papp_dut_cd.Items.Clear();
            string sql = @"select CD_CODE, cd_codnms from lmg_tinsa_cd where cd_grpcd = 'DUT' order by CD_CODE";

            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    OracleDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rd.Read())
                    {
                        papp_dut_cd.Items.Add(rd.GetString(0).ToString() + ":" + rd.GetString(1).ToString());
                    }
                }
            }
        }

        private void PosCdFocusEvent(object sender, EventArgs e)
        {
            papp_pos_cd.Items.Clear();
            string sql = @"select CD_CODE, cd_codnms from lmg_tinsa_cd where cd_grpcd = 'POS' order by CD_CODE";

            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    OracleDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rd.Read())
                    {
                        papp_pos_cd.Items.Add(rd.GetString(0).ToString() + ":" + rd.GetString(1).ToString());
                    }
                }
            }
        }

        private void PappDateFocusEvent(object sender, EventArgs e)
        {
            papp_date.CustomFormat = "yyyy-MM-dd";
        }

        private void DataGridViewVandingEvent(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count <= 0) return;
            var Cells = dataGridView2.SelectedRows[0].Cells;
            var TargetControl = sender as Control;
            Cells[TargetControl.Name].Value = TargetControl.Text;
            Cells["papp_date"].Value = DateValues(Cells["papp_date"].Value?.ToString());
        }

        private void LostFocusTextBoxValidationChecking(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows.Count <= 0) return;
            var row = this.dataGridView2.SelectedRows[0];
            ValidationChecking(row);
        }

        private void PapFocusEvent(object sender, EventArgs e)
        {
            papp_pap.Items.Clear();
            string sql = @"select CD_CODE, cd_codnms from lmg_tinsa_cd where cd_grpcd = 'PAP' order by CD_CODE";

            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    OracleDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rd.Read())
                    {
                        papp_pap.Items.Add(rd.GetString(0).ToString() + ":" + rd.GetString(1).ToString());
                    }
                }
            }
        }

        private void DateFocusEvent(object sender, EventArgs e)
        {
            search_papr_date.CustomFormat = "yyyy-MM-dd";
        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = dataGridView1.Rows[e.RowIndex];
            papp_appno.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.DataGridView1FormLoad();
            this.TextBoxStateChange();
        }

        private void TextBoxStateChange()
        {
            papp_date.Enabled = true;
            papp_pap.Enabled = true;
            papp_content.Enabled = true;
            papp_auth.Enabled = true;
            papp_basis.Enabled = true;
            papp_rmk.Enabled = true;
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

            cells["papp_type"].Value = "Select";
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
            this.dataGridView2.Rows.Clear();
            TextBoxValuesClear();
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
                    else { command.Parameters.Add("papr_date", $"%{DateValues(search_papr_date.Text.ToString())}%"); }
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

        private void TextBoxValuesClear()
        {
            papp_empno.Text = string.Empty;
            papp_appno.Text = string.Empty;
            papp_date.CustomFormat = " ";
            papp_pap.Text = string.Empty;
            papp_content.Text = string.Empty;
            papp_auth.Text = string.Empty;
            papp_basis.Text = string.Empty;
            papp_rmk.Text = string.Empty;
            papp_pos_cd.Text = string.Empty;
            papp_dut_cd.Text = string.Empty;
            papp_dept_cd.Text = string.Empty;
            papp_pos_nm.Text = string.Empty;
            papp_dut_nm.Text = string.Empty;
            papp_dept_nm.Text = string.Empty;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchEmpnoForm Form1 = new SearchEmpnoForm();
            Form1.ShowDialog();
            papp_empno.Text = Form1._textBox1.ToString();
        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            int RowCount = dataGridView2.Rows.Count;
            var index = this.dataGridView2.Rows.Add();
            var row = this.dataGridView2.Rows[index];
            var cells = row.Cells;

            cells["papp_type"].Value = "Insert";
            dataGridView2.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView2.Rows[index]);
            this.ValidationChecking(row);
        }

        private void ValidationChecking(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(papp_pap.Text.Trim())) { this.SetError(row, this.papp_pap, "발령종류를 선택해주세요."); return; }
            this.errorProvider1.Clear();
            row.ErrorText = string.Empty;
        }

        private void SetError(DataGridViewRow row, Control control, string errorText)
        {
            this.errorProvider1.Clear();
            row.ErrorText = errorText;
            this.errorProvider1.SetError(control, errorText);
        }

        private void InsertDataGridViewRowValue(DataGridViewRow row)
        {
            var cells = row.Cells;
            this.papp_empno.Text = cells["papp_empno"].Value?.ToString();
            cells["papp_appno"].Value = this.papp_appno.Text;
            this.papp_pap.Text = cells["papp_pap"].Value?.ToString();
            this.papp_content.Text = cells["papp_content"].Value?.ToString();
            this.papp_auth.Text = cells["papp_auth"].Value?.ToString();
            this.papp_basis.Text = cells["papp_basis"].Value?.ToString();
            this.papp_rmk.Text = cells["papp_rmk"].Value?.ToString();
            this.papp_pos_cd.Text = cells["papp_pos_cd"].Value?.ToString();
            this.papp_dut_cd.Text = cells["papp_dut_cd"].Value?.ToString();
            this.papp_dept_cd.Text = cells["papp_dept_cd"].Value?.ToString();
            this.papp_pos_nm.Text = cells["papp_pos_nm"].Value?.ToString();
            this.papp_dut_nm.Text = cells["papp_dut_nm"].Value?.ToString();
            this.papp_dept_nm.Text = cells["papp_dept_nm"].Value?.ToString();

            DateTime value;
            if (string.IsNullOrEmpty(cells["papp_date"].Value?.ToString()))
            {
                cells["papp_date"].Value = "";
                return;
            }
            DateTime.TryParseExact(cells["papp_date"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value);
            this.papp_date.Value = value;
        }

        private void DataSaveBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("정말 저장하시겠습니까?", "저장", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult != DialogResult.OK) return;

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (!string.IsNullOrEmpty(row.ErrorText))
                {
                    MessageBox.Show("오류가 발생한 행이 있습니다.");
                    dataGridView2.ClearSelection();
                    row.Selected = true;
                    this.InsertDataGridViewRowValue(row);
                    this.ValidationChecking(row);
                    return;
                }
            }

            foreach (DataGridViewRow row in this.dataGridView2.Rows)
            {
                try
                {
                    var cells = row.Cells;
                    InsertAndUpadate(cells);
                    continue;
                }

                catch (OracleException oracleexception)
                {
                    if (oracleexception.Number == 1) MessageBox.Show("중복된 값 입니다.");
                }

                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());

                }
                dataGridView2.ClearSelection();
                row.Selected = true;
                return;
            }
        }

        private void InsertAndUpadate(DataGridViewCellCollection cells)
        {
            try
            {
                using (var connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (var command = new OracleCommand())
                    {

                        command.Connection = connection;
                        command.Prepare();
                        command.BindByName = true;

                        if (cells["papp_type"].Value.Equals("Insert"))
                        {
                            string sql = SqlCommand.Tinsa_Issued2_Insert;

                            command.CommandText = sql;
                            command.Parameters.Add("papp_empno", cells["papp_empno"].Value?.ToString());
                            command.Parameters.Add("papp_appno", cells["papp_appno"].Value?.ToString());
                            command.Parameters.Add("papp_date", DateValues(cells["papp_date"].Value?.ToString()));
                            command.Parameters.Add("papp_pap", cells["papp_pap"].Value.ToString().Substring(0, 2));
                            command.Parameters.Add("papp_content", cells["papp_content"].Value?.ToString());
                            command.Parameters.Add("papp_auth", cells["papp_auth"].Value?.ToString());
                            command.Parameters.Add("papp_basis", cells["papp_basis"].Value?.ToString());
                            command.Parameters.Add("papp_rmk", cells["papp_rmk"].Value?.ToString());
                            command.Parameters.Add("papp_pos_cd", cells["papp_pos_cd"].Value.ToString().Substring(0, 3));
                            command.Parameters.Add("papp_dut_cd", cells["papp_dut_cd"].Value.ToString().Substring(0, 2));
                            command.Parameters.Add("papp_dept_cd", cells["papp_dept_cd"].Value.ToString().Substring(0, 3));
                            command.Parameters.Add("papp_pos_nm", cells["papp_pos_cd"].Value.ToString().Substring(4));
                            command.Parameters.Add("papp_dut_nm", cells["papp_dut_cd"].Value.ToString().Substring(3));
                            command.Parameters.Add("papp_dept_nm", cells["papp_dept_cd"].Value.ToString().Substring(4));
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "A");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.ExecuteNonQuery();

                        }
                        cells["papp_type"].Value = "Select";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
