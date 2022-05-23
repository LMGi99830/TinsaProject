using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace LMGHRmanagement
{
    public partial class Tinsa_Bas1 : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        int imgvalue = 0;

        public Tinsa_Bas1()
        {
            InitializeComponent();

            #region 데이터그리드뷰 헤더 초기화
            this.dataGridView1.Columns.Add("bas_type", "상태");
            this.dataGridView1.Columns.Add("bas_empno", "사원번호");
            var index = this.dataGridView1.Columns.Add("bas_empno_cp", "*");
            this.dataGridView1.Columns[index].Visible = false;
            this.dataGridView1.Columns.Add("bas_resno", "주민등록번호");
            this.dataGridView1.Columns.Add("bas_name", "성명(한글)");
            this.dataGridView1.Columns.Add("bas_cname", "성명(한자)");
            this.dataGridView1.Columns.Add("bas_ename", "성명(영문)");
            this.dataGridView1.Columns.Add("bas_fix", "성별");
            this.dataGridView1.Columns.Add("bas_zip", "우편번호");
            this.dataGridView1.Columns.Add("bas_addr", "주소");
            this.dataGridView1.Columns.Add("bas_hdpno", "연락처(휴대폰)");
            this.dataGridView1.Columns.Add("bas_telno", "연락처(집)");
            this.dataGridView1.Columns.Add("bas_email", "이메일주소");
            this.dataGridView1.Columns.Add("bas_mil_sta", "병역(복무구분)");
            this.dataGridView1.Columns.Add("bas_mil_mil", "병역(군별)");
            this.dataGridView1.Columns.Add("bas_mil_rnk", "병역(계급)");
            this.dataGridView1.Columns.Add("bas_mar", "결혼여부");
            this.dataGridView1.Columns.Add("bas_acc_bank", "계좌사항(은행명)");
            this.dataGridView1.Columns.Add("bas_acc_name", "계좌사항(예금주)");
            this.dataGridView1.Columns.Add("bas_acc_no", "계좌사항(계좌번호)");
            this.dataGridView1.Columns.Add("bas_cont", "계약구분");
            this.dataGridView1.Columns.Add("bas_emp_sdate", "계약시작일");
            this.dataGridView1.Columns.Add("bas_emp_edate", "계약종료일");
            this.dataGridView1.Columns.Add("bas_entdate", "입사일자");
            this.dataGridView1.Columns.Add("bas_resdate", "퇴사일자");
            this.dataGridView1.Columns.Add("bas_levdate", "휴직일자");
            this.dataGridView1.Columns.Add("bas_reidate", "복직일자");
            this.dataGridView1.Columns.Add("bas_dptdate", "현부서일자");
            this.dataGridView1.Columns.Add("bas_jkpdate", "현직급일자");
            this.dataGridView1.Columns.Add("bas_posdate", "현직책일자");
            this.dataGridView1.Columns.Add("bas_wsta", "재직상태");
            this.dataGridView1.Columns.Add("bas_sts", "신분구분");
            this.dataGridView1.Columns.Add("bas_pos", "직급(현재)");
            this.dataGridView1.Columns.Add("bas_dut", "직책(현재)");
            this.dataGridView1.Columns.Add("bas_dept", "부서(현재)");
            this.dataGridView1.Columns.Add("bas_rmk", "참고사항");
            this.dataGridView1.Columns.Add("img_image", "사진");

            #endregion

            #region 데이터그리드뷰와 텍스트박스 연동 이벤트
            bas_empno.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_resno.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_name.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_cname.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_ename.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_fix.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_zip.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_addr.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_hdpno.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_telno.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_email.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_mil_sta.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_mil_mil.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_mil_rnk.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_mar.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_acc_bank.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_acc_name.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_acc_no.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_cont.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_emp_sdate.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_emp_edate.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_entdate.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_resdate.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_levdate.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_reidate.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_dptdate.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_jkpdate.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_posdate.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_wsta.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_sts.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_pos.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_dut.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_dept.TextChanged += new EventHandler(this.DataGridViewToChanged);
            bas_rmk.TextChanged += new EventHandler(this.DataGridViewToChanged);
            #endregion

            #region 데이터그리드뷰 더블클릭 이벤트
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.DataGridViewDoubleClickEvent);
            #endregion

            #region 텍스트박스 벨리데이션 체크
            bas_empno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_resno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_name.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_cname.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_ename.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_fix.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_zip.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_addr.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_hdpno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_telno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_email.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_mil_sta.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_mil_mil.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_mil_rnk.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_mar.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_acc_bank.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_acc_name.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_acc_no.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_cont.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_emp_sdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_emp_edate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_entdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_resdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_levdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_reidate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_dptdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_jkpdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_posdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_wsta.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_sts.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_pos.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_dut.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_dept.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            bas_rmk.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion

            #region 텍스트 박스 포커스 이벤트
            bas_resno.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_name.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_cname.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_ename.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_fix.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_zip.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_addr.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_hdpno.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_telno.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_email.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_mil_sta.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_mil_mil.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_mil_rnk.GotFocus += new EventHandler(RnkComboBoxClickEvent);
            bas_mar.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_acc_bank.GotFocus += new EventHandler(BankComboBoxClickEvent);
            bas_acc_name.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_acc_no.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_cont.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_emp_sdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_emp_edate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_entdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_resdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_levdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_reidate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_dptdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_jkpdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_posdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_wsta.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            bas_sts.GotFocus += new EventHandler(TextBoxGotFoucsEvent); 
            bas_pos.GotFocus += new EventHandler(TextBoxGotFoucsEvent); 
            bas_dut.GotFocus += new EventHandler(DutFocusEvent);
            bas_dept.GotFocus += new EventHandler(DeptFocusEvent);
            bas_rmk.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            #endregion
        }

        private void DeptFocusEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            bas_dept.Items.Clear();

            string sql = @"select dept_code,dept_name from lmg_tinsa_dept";

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
                        bas_dept.Items.Add(rd.GetString(0   ).ToString() + ":" + rd.GetString(1).ToString());
                    }
                }
            }
            if (!cells["bas_type"].Value.Equals("Select")) return;
            cells["bas_type"].Value = "Update";
        }

        private void DutFocusEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            bas_dut.Items.Clear();

            string sql = @"select cd_code,cd_codnms from lmg_tinsa_cd where cd_grpcd = 'DUT'";

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
                        bas_dut.Items.Add(rd.GetString(0).ToString() + ":" + rd.GetString(1).ToString());
                    }
                }
            }
            if (!cells["bas_type"].Value.Equals("Select")) return;
            cells["bas_type"].Value = "Update";
        }

        private void PosFocusEvent()
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            bas_pos.Items.Clear();
            bas_pos.Items.Add("선택");

            string sql = @"select cd_code,cd_codnms from lmg_tinsa_cd where cd_grpcd = 'POS'";

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
                        bas_pos.Items.Add(rd.GetString(0).ToString() + ":" + rd.GetString(1).ToString());
                    }
                }
            }
            if (!cells["bas_type"].Value.Equals("Select")) return;
            cells["bas_type"].Value = "Update";
        }

        private void RnkComboBoxClickEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            bas_mil_rnk.Items.Clear();

            string sql = @"select cd_codnms from lmg_tinsa_cd where cd_grpcd = 'RNK'";

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
                        bas_mil_rnk.Items.Add(rd.GetString(0).ToString());
                    }
                }
            }
            if (!cells["bas_type"].Value.Equals("Select")) return;
            cells["bas_type"].Value = "Update";
        }

        private void StsFocusEvent()
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            bas_sts.Items.Clear();
            bas_sts.Items.Add("선택");

            string sql = @"select cd_code, cd_codnms from lmg_tinsa_cd where cd_grpcd = 'STS'";

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
                        bas_sts.Items.Add(rd.GetString(0).ToString() + ":" + rd.GetString(1).ToString());
                    }
                }
            }
            if (!cells["bas_type"].Value.Equals("Select")) return;
            cells["bas_type"].Value = "Update";
        }

        private void BankComboBoxClickEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            bas_acc_bank.Items.Clear();

            string sql = @"select cd_codnms from lmg_tinsa_cd where cd_grpcd = 'BNK'";

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
                        bas_acc_bank.Items.Add(rd.GetString(0).ToString());
                    }
                }
            }
            if (!cells["bas_type"].Value.Equals("Select")) return;
            cells["bas_type"].Value = "Update";
        }

        private void TextBoxGotFoucsEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (!cells["bas_type"].Value.Equals("Select")) return;
            cells["bas_type"].Value = "Update";
        }

        private void MilComboBoxClickEvent()
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;

            bas_mil_mil.Items.Clear();
            bas_mil_mil.Items.Add("선택");
            string sql = @"select cd_codnms from lmg_tinsa_cd where cd_grpcd = 'MIL'";

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
                            bas_mil_mil.Items.Add(rd.GetString(0).ToString());
                        }
                }
            }
            if (!cells["bas_type"].Value.Equals("Select")) return;
            cells["bas_type"].Value = "Update";
        }

        private void LostFocusTextBoxValidationChecking(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var row = this.dataGridView1.SelectedRows[0];
            ValidationChecking(row);
        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = this.dataGridView1.Rows[e.RowIndex];
            this.InsertDataGridViewRowValue(row);
            this.ValidationChecking(row);

        }

        private void InsertDataGridViewRowValue(DataGridViewRow row)
        {
            img_image.Image = null;
            var cells = row.Cells;
            #region DateTime 변수 선언
            DateTime value;
            DateTime value1;
            DateTime value2;
            DateTime value3;
            DateTime value4;
            DateTime value5;
            DateTime value6;
            DateTime value7;
            DateTime value8;
            #endregion
            this.bas_empno.Text = cells["bas_empno"].Value?.ToString();
            this.bas_resno.Text = cells["bas_resno"].Value?.ToString();
            this.bas_name.Text = cells["bas_name"].Value?.ToString();
            this.bas_cname.Text = cells["bas_cname"].Value?.ToString();
            this.bas_ename.Text = cells["bas_ename"].Value?.ToString();
            this.bas_fix.Text = cells["bas_fix"].Value?.ToString();
            this.bas_zip.Text = cells["bas_zip"].Value?.ToString();
            this.bas_addr.Text = cells["bas_addr"].Value?.ToString();
            this.bas_hdpno.Text = cells["bas_hdpno"].Value?.ToString();
            this.bas_telno.Text = cells["bas_telno"].Value?.ToString();
            this.bas_email.Text = cells["bas_email"].Value?.ToString();
            if (cells["bas_mil_sta"].Value.ToString() == "") { bas_mil_sta.Text = "선택"; }
            else { this.bas_mil_sta.Text = cells["bas_mil_sta"].Value.ToString(); }
            if (cells["bas_mil_mil"].Value.ToString() == "") { bas_mil_mil.Text = "선택"; }
            else { this.bas_mil_mil.Text = cells["bas_mil_mil"].Value.ToString();  }
            this.bas_mil_rnk.Text = cells["bas_mil_rnk"].Value?.ToString();
            this.bas_mar.Text = cells["bas_mar"].Value?.ToString();
            this.bas_acc_bank.Text = cells["bas_acc_bank"].Value?.ToString();
            this.bas_acc_name.Text = cells["bas_acc_name"].Value?.ToString();
            this.bas_acc_no.Text = cells["bas_acc_no"].Value?.ToString();
            this.bas_cont.Text = cells["bas_cont"].Value?.ToString();
            #region 계약시작일
            if (string.IsNullOrEmpty(cells["bas_emp_sdate"].Value?.ToString()))
            {
                bas_emp_sdate.CustomFormat = " ";
                cells["bas_emp_sdate"].Value = "";
            }
            else
            {
                bas_emp_sdate.CustomFormat = "yyyy-MM-dd";
                DateTime.TryParseExact(cells["bas_emp_sdate"].Value.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value);
                this.bas_emp_sdate.Value = value;
            }
            #endregion
            #region 계약종료일
            if (string.IsNullOrEmpty(cells["bas_emp_edate"].Value?.ToString()))
            {
                bas_emp_edate.CustomFormat = " ";
                cells["bas_emp_edate"].Value = "";
            }
            else
            {
                bas_emp_edate.CustomFormat = "yyyy-MM-dd";
                DateTime.TryParseExact(cells["bas_emp_edate"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value1);
                this.bas_emp_edate.Value = value1;
            }
            #endregion
            #region 입사일자
            if (string.IsNullOrEmpty(cells["bas_entdate"].Value?.ToString()))
            {
                bas_entdate.CustomFormat = " ";
                cells["bas_entdate"].Value = "";
            }
            else
            {
                bas_entdate.CustomFormat = "yyyy-MM-dd";
                DateTime.TryParseExact(cells["bas_entdate"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value2);
                this.bas_entdate.Value = value2;
            }
            #endregion
            #region 퇴사일자
            if (string.IsNullOrEmpty(cells["bas_resdate"].Value?.ToString()))
            {
                bas_resdate.CustomFormat = " ";
                cells["bas_resdate"].Value = "";
            }
            else
            {
                bas_resdate.CustomFormat = "yyyy-MM-dd";
                DateTime.TryParseExact(cells["bas_resdate"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value3);
                this.bas_resdate.Value = value3;
            }
            
            #endregion
            #region 휴직일자
            if (string.IsNullOrEmpty(cells["bas_levdate"].Value?.ToString()))
            {
                bas_levdate.CustomFormat = " ";
                cells["bas_levdate"].Value = "";
            }
            else
            {
                bas_levdate.CustomFormat = "yyyy-MM-dd";
                DateTime.TryParseExact(cells["bas_levdate"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value4);
                this.bas_levdate.Value = value4;
            }
            #endregion
            #region 복직일자
            if (string.IsNullOrEmpty(cells["bas_reidate"].Value?.ToString()))
            {
                bas_reidate.CustomFormat = " ";
                cells["bas_reidate"].Value = "";
            }
            else
            {
                bas_reidate.CustomFormat = "yyyy-MM-dd";
                DateTime.TryParseExact(cells["bas_reidate"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value5);
                this.bas_reidate.Value = value5;
            }
            #endregion
            #region 현부서일자
            if (string.IsNullOrEmpty(cells["bas_dptdate"].Value?.ToString()))
            {
                bas_dptdate.CustomFormat = " ";
                cells["bas_dptdate"].Value = "";
            }
            else
            {
                bas_dptdate.CustomFormat = "yyyy-MM-dd";
                DateTime.TryParseExact(cells["bas_dptdate"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value6);
                this.bas_dptdate.Value = value6;
            }
            #endregion
            #region 현직급일자
            if (string.IsNullOrEmpty(cells["bas_jkpdate"].Value?.ToString()))
            {
                bas_jkpdate.CustomFormat = " ";
                cells["bas_jkpdate"].Value = "";
            }
            else
            {
                bas_jkpdate.CustomFormat = "yyyy-MM-dd";
                DateTime.TryParseExact(cells["bas_jkpdate"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value7);
                this.bas_jkpdate.Value = value7;
            }
            #endregion
            #region 현직책일자
            if (string.IsNullOrEmpty(cells["bas_posdate"].Value?.ToString()))
            {
                bas_posdate.CustomFormat = " ";
                cells["bas_posdate"].Value = "";
            }
            else
            {
                bas_posdate.CustomFormat = "yyyy-MM-dd";
                DateTime.TryParseExact(cells["bas_posdate"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value8);
                this.bas_posdate.Value = value8;
            }
            #endregion
            this.bas_wsta.Text = cells["bas_wsta"].Value?.ToString();
            this.bas_dut.Text = cells["bas_dut"].Value?.ToString();
            
            if (string.IsNullOrEmpty(cells["bas_sts"].Value?.ToString())) { bas_sts.Text = "선택"; }
            else { this.bas_sts.Text = cells["bas_sts"].Value.ToString(); }
            if (string.IsNullOrEmpty(cells["bas_pos"].Value?.ToString())) { bas_pos.Text = "선택"; }
            else { this.bas_pos.Text = cells["bas_pos"].Value.ToString(); }
            this.bas_dept.Text = cells["bas_dept"].Value?.ToString();
            this.bas_rmk.Text = cells["bas_rmk"].Value?.ToString();
            ImageRead();

        }

        private void ImageRead()
        {

            int rowindex = dataGridView1.CurrentCell.RowIndex;

            OracleConnection conn = new OracleConnection(cs);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select img_image from lmg_tinsa_image where img_empno = :img_empno";
            cmd.Parameters.Add("img_empno", this.bas_empno.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    byte[] imgByte = (byte[])dr["img_image"];

                    MemoryStream memoryStream = new MemoryStream(imgByte);
                    img_image.Image = new Bitmap(memoryStream);
                }
            }
            conn.Close();
        }

        private void ImageReader(OracleDataReader reader)
        {
            var index = dataGridView1.Rows.Add();
            var cells = dataGridView1.Rows[index].Cells;

            if (!reader.IsDBNull(0))
            {
                MessageBox.Show(reader.GetString(0).ToString());
                byte[] imgByte = (byte[])reader["img_image"];

                MemoryStream memoryStream = new MemoryStream(imgByte);
                img_image.Image = new Bitmap(memoryStream);
                return;
            }
            MessageBox.Show(reader.GetString(0).ToString());

        }

        private void DataGridViewToChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;
            var Cells = dataGridView1.SelectedRows[0].Cells;
            var TargetControl = sender as Control;
            Cells[TargetControl.Name].Value = TargetControl.Text;
            Cells["bas_emp_sdate"].Value = DateValues(Cells["bas_emp_sdate"].Value?.ToString());
            Cells["bas_emp_edate"].Value = DateValues(Cells["bas_emp_edate"].Value?.ToString());
            Cells["bas_entdate"].Value = DateValues(Cells["bas_entdate"].Value?.ToString());
            Cells["bas_resdate"].Value = DateValues(Cells["bas_resdate"].Value?.ToString());
            Cells["bas_levdate"].Value = DateValues(Cells["bas_levdate"].Value?.ToString());
            Cells["bas_reidate"].Value = DateValues(Cells["bas_reidate"].Value?.ToString());
            Cells["bas_dptdate"].Value = DateValues(Cells["bas_dptdate"].Value?.ToString());
            Cells["bas_jkpdate"].Value = DateValues(Cells["bas_jkpdate"].Value?.ToString());
            Cells["bas_posdate"].Value = DateValues(Cells["bas_posdate"].Value?.ToString());

        }

        #region 데이터 로드
        public void Data_Load()
        {
            this.dataGridView1.Rows.Clear();
            string sql = @" select bas.*, img.IMG_IMAGE, sts.CD_CODNM STS, pos.CD_CODNM POS
                            from LMG_TINSA_BAS bas
                            left join LMG_TINSA_IMAGE img
                            on bas.BAS_EMPNO = img.IMG_EMPNO
                            left join (select distinct cd.CD_CODE,cd.cd_codnm from LMG_TINSA_BAS bas left join LMG_TINSA_cd cd on cd.CD_CODE = bas.BAS_STS) sts
                            on bas.BAS_STS = sts.CD_CODE
                            left join (select distinct cd.CD_CODE,cd.cd_codnm from LMG_TINSA_BAS bas left join LMG_TINSA_cd cd on cd.CD_CODE = bas.BAS_POS) pos
                            on bas.BAS_POS = pos.CD_CODE
                            where bas.BAS_EMPNO like :bas_empno
                            and bas.BAS_NAME like :bas_name
                            order by BAS_EMPNO";

            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("bas_empno", $"%{search_bas_empno.Text}%");
                    command.Parameters.Add("bas_name", $"%{search_bas_name.Text}%");
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridViewSelectDataLoad(reader);
                }
            }
        }

        private void DataGridViewSelectDataLoad(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["bas_type"].Value = "Select";
            cells["bas_empno_cp"].Value = reader["bas_empno"].ToString();
            cells["bas_empno"].Value = reader["bas_empno"].ToString();
            cells["bas_resno"].Value = reader["bas_resno"].ToString();
            cells["bas_name"].Value = reader["bas_name"].ToString();
            cells["bas_cname"].Value = reader["bas_cname"].ToString();
            cells["bas_ename"].Value = reader["bas_ename"].ToString();
            cells["bas_fix"].Value = reader["bas_fix"].ToString();
            cells["bas_zip"].Value = reader["bas_zip"].ToString();
            cells["bas_addr"].Value = reader["bas_addr"].ToString();
            cells["bas_hdpno"].Value = reader["bas_hdpno"].ToString();
            cells["bas_telno"].Value = reader["bas_telno"].ToString();
            cells["bas_email"].Value = reader["bas_email"].ToString();
            cells["bas_mil_sta"].Value = reader["bas_mil_sta"].ToString();
            cells["bas_mil_mil"].Value = reader["bas_mil_mil"].ToString();
            cells["bas_mil_rnk"].Value = reader["bas_mil_rnk"].ToString();
            cells["bas_mar"].Value = reader["bas_mar"].ToString();
            cells["bas_acc_bank"].Value = reader["bas_acc_bank"].ToString();
            cells["bas_acc_name"].Value = reader["bas_acc_name"].ToString();
            cells["bas_acc_no"].Value = reader["bas_acc_no"].ToString();
            cells["bas_cont"].Value = reader["bas_cont"].ToString();
            cells["bas_emp_sdate"].Value = reader["bas_emp_sdate"].ToString();
            cells["bas_emp_edate"].Value = reader["bas_emp_edate"].ToString();
            cells["bas_entdate"].Value = reader["bas_entdate"].ToString();
            cells["bas_resdate"].Value = reader["bas_resdate"].ToString();
            cells["bas_levdate"].Value = reader["bas_levdate"].ToString();
            cells["bas_reidate"].Value = reader["bas_reidate"].ToString();
            cells["bas_dptdate"].Value = reader["bas_dptdate"].ToString();
            cells["bas_jkpdate"].Value = reader["bas_jkpdate"].ToString();
            cells["bas_posdate"].Value = reader["bas_posdate"].ToString();
            cells["bas_wsta"].Value = reader["bas_wsta"].ToString();
            if (reader["bas_sts"].ToString() == "") { cells["bas_sts"].Value = null; }
            else { cells["bas_sts"].Value = reader["bas_sts"] + ":" + reader["STS"]; }
            if (reader["bas_pos"].ToString() == "") { cells["bas_pos"].Value = null; }
            else { cells["bas_pos"].Value = reader["bas_pos"] + ":" + reader["POS"]; }
            cells["bas_dut"].Value = reader["bas_dut"].ToString();
            cells["bas_dept"].Value = reader["bas_dept"].ToString();
            cells["bas_rmk"].Value = reader["bas_rmk"].ToString();
            cells["img_image"].Value = reader["img_image"].ToString();

        }
        #endregion

        #region 행Insert
        public void Insert_Rows()
        {
            int RowCount = dataGridView1.Rows.Count;
            var index = this.dataGridView1.Rows.Add();
            var row = this.dataGridView1.Rows[index];
            var cells = row.Cells;

            cells["bas_type"].Value = "Insert";
            dataGridView1.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView1.Rows[index]);
            this.ValidationChecking(row);
        }
        #endregion

        private void ValidationChecking(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(bas_empno.Text.Trim())) { this.SetError(row, this.bas_empno, "사원번호가 빈칸입니다."); return; }
            if (string.IsNullOrEmpty(bas_resno.Text.Trim())) { this.SetError(row, this.bas_resno, "주민등록번호가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_name.Text.Trim())) { this.SetError(row, this.bas_name, "성명(한글)가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_cname.Text.Trim())) { this.SetError(row, this.bas_cname, "성명(한자)가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_ename.Text.Trim())) { this.SetError(row, this.bas_ename, "성명(영문)가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_fix.Text.Trim())) { this.SetError(row, this.bas_fix, " 가 빈칸입니다성별"); return; }
            //if (string.IsNullOrEmpty(bas_zip.Text.Trim())) { this.SetError(row, this.bas_zip, " 가 빈칸입니다우편번호"); return; }
            //if (string.IsNullOrEmpty(bas_addr.Text.Trim())) { this.SetError(row, this.bas_addr, "주소가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_hdpno.Text.Trim())) { this.SetError(row, this.bas_hdpno, "연락처(휴대폰)가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_telno.Text.Trim())) { this.SetError(row, this.bas_telno, "연락처(집)가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_email.Text.Trim())) { this.SetError(row, this.bas_email, "이메일주소가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_mil_sta.Text.Trim())) { this.SetError(row, this.bas_mil_sta, "병역(복무구분)가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_mil_mil.Text.Trim())) { this.SetError(row, this.bas_mil_mil, "병역(군별)가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_mil_rnk.Text.Trim())) { this.SetError(row, this.bas_mil_rnk, "병역(계급)가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_mar.Text.Trim())) { this.SetError(row, this.bas_mar, " 가 빈칸입니다결혼여부"); return; }
            //if (string.IsNullOrEmpty(bas_acc_bank.Text.Trim())) { this.SetError(row, this.bas_acc_bank, "계좌사항(은행명)가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_acc_name.Text.Trim())) { this.SetError(row, this.bas_acc_name, "계좌사항(예금주)가 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(bas_acc_no.Text.Trim())) { this.SetError(row, this.bas_acc_no, "계좌사항(계좌번호)가 빈칸입니다."); return; }
            this.errorProvider1.Clear();
            row.ErrorText = string.Empty;
        }

        private void SetError(DataGridViewRow row, Control control, string errorText)
        {
            this.errorProvider1.Clear();
            row.ErrorText = errorText;
            this.errorProvider1.SetError(control, errorText);
        }

        private void PIctureInsertBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string image_file = string.Empty;
            dialog.InitialDirectory = @"C:\";
            dialog.Filter = "Image File (*.jpg;*.png;)|*.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_file = dialog.FileName;
                img_image.Image = Bitmap.FromFile(image_file);

                imgvalue = 1;

            }
        }

        private void DataLoadBtn_Click(object sender, EventArgs e)
        {
            Data_Load();
            MilComboBoxClickEvent();
            StsFocusEvent();
            PosFocusEvent();
        }

        #region 저장 버튼 눌렀을때 동작
        private void DataSaveBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("정말 저장하시겠습니까?", "저장", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult != DialogResult.OK) return;

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (!string.IsNullOrEmpty(row.ErrorText))
                {
                    MessageBox.Show("오류가 발생한 행이 있습니다.");
                    dataGridView1.ClearSelection();
                    row.Selected = true;
                    this.InsertDataGridViewRowValue(row);
                    this.ValidationChecking(row);
                    return;
                }
            }

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
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
                dataGridView1.ClearSelection();
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

                        #region Parameters
                        command.Parameters.Add("bas_empno", cells["bas_empno"].Value.ToString());
                        command.Parameters.Add("bas_resno", cells["bas_resno"].Value?.ToString());
                        command.Parameters.Add("bas_name", cells["bas_name"].Value?.ToString());
                        command.Parameters.Add("bas_cname", cells["bas_cname"].Value?.ToString());
                        command.Parameters.Add("bas_ename", cells["bas_ename"].Value?.ToString());
                        command.Parameters.Add("bas_fix", cells["bas_fix"].Value?.ToString());
                        command.Parameters.Add("bas_zip", cells["bas_zip"].Value?.ToString());
                        command.Parameters.Add("bas_addr", cells["bas_addr"].Value?.ToString());
                        command.Parameters.Add("bas_hdpno", cells["bas_hdpno"].Value?.ToString());
                        command.Parameters.Add("bas_telno", cells["bas_telno"].Value?.ToString());
                        command.Parameters.Add("bas_email", cells["bas_email"].Value?.ToString());
                        if (cells["bas_mil_sta"].Value?.ToString() == null || cells["bas_mil_sta"].Value?.ToString() == "선택") command.Parameters.Add("bas_mil_sta", null);
                        else { command.Parameters.Add("bas_mil_sta", cells["bas_mil_sta"].Value.ToString()); }
                        if (cells["bas_mil_mil"].Value?.ToString() == null || cells["bas_mil_mil"].Value?.ToString() == "선택") command.Parameters.Add("bas_mil_mil", null); 
                        else { command.Parameters.Add("bas_mil_mil", cells["bas_mil_mil"].Value.ToString()); }
                        command.Parameters.Add("bas_mil_rnk", cells["bas_mil_rnk"].Value?.ToString());
                        command.Parameters.Add("bas_mar", cells["bas_mar"].Value?.ToString());
                        command.Parameters.Add("bas_acc_bank", cells["bas_acc_bank"].Value?.ToString());
                        command.Parameters.Add("bas_acc_name", cells["bas_acc_name"].Value?.ToString());
                        command.Parameters.Add("bas_acc_no", cells["bas_acc_no"].Value?.ToString());
                        command.Parameters.Add("bas_cont", cells["bas_cont"].Value?.ToString());
                        command.Parameters.Add("bas_emp_sdate", DateValues(cells["bas_emp_sdate"].Value?.ToString()));
                        command.Parameters.Add("bas_emp_edate", cells["bas_emp_edate"].Value?.ToString());
                        command.Parameters.Add("bas_entdate", DateValues(cells["bas_entdate"].Value?.ToString()));
                        command.Parameters.Add("bas_resdate", DateValues(cells["bas_resdate"].Value?.ToString()));
                        command.Parameters.Add("bas_levdate", DateValues(cells["bas_levdate"].Value?.ToString()));
                        command.Parameters.Add("bas_reidate", DateValues(cells["bas_reidate"].Value?.ToString()));
                        command.Parameters.Add("bas_dptdate", DateValues(cells["bas_dptdate"].Value?.ToString()));
                        command.Parameters.Add("bas_jkpdate", DateValues(cells["bas_jkpdate"].Value?.ToString()));
                        command.Parameters.Add("bas_posdate", DateValues(cells["bas_posdate"].Value?.ToString()));
                        command.Parameters.Add("bas_wsta", cells["bas_wsta"].Value?.ToString());
                        if (cells["bas_sts"].Value?.ToString() == null || cells["bas_sts"].Value?.ToString() == "선택") command.Parameters.Add("bas_sts", null);
                        else { command.Parameters.Add("bas_sts", cells["bas_sts"].Value.ToString()); }
                        if (cells["bas_pos"].Value?.ToString() == null || cells["bas_pos"].Value?.ToString() == "선택") command.Parameters.Add("bas_pos", null);
                        else { command.Parameters.Add("bas_pos", cells["bas_pos"].Value.ToString()); }
                        command.Parameters.Add("bas_dut", cells["bas_dut"].Value?.ToString());
                        command.Parameters.Add("bas_dept", cells["bas_dept"].Value?.ToString());
                        command.Parameters.Add("bas_rmk", cells["bas_rmk"].Value?.ToString());
                        #endregion

                        byte[] b = new byte[0];
                        if (!(img_image.Image is null))
                        {
                            Bitmap bitmap = new Bitmap((Image)img_image.Image);
                            ImageConverter converter = new ImageConverter();
                            b = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
                        }

                        if (cells["bas_type"].Value.Equals("Insert"))
                        {
                            command.CommandText = SqlCommand.Tinsa_BAS1_INSERT;

                            command.Parameters.Add("datesys1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("datesys2", "A");
                            command.Parameters.Add("datesys3", "MinGi");

                            command.ExecuteNonQuery();

                            command.CommandText = SqlCommand.TInsa_Bas1_ImageInsert;
                            command.Parameters.Add("img_empno", cells["bas_empno"].Value.ToString());
                            command.Parameters.Add("img_image", b);
                            command.ExecuteNonQuery();

                        }
                        if (cells["bas_type"].Value.Equals("Update"))
                        {
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "U");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.Parameters.Add("bas_empno_cp", cells["bas_empno_cp"].Value.ToString());
                            command.CommandText = SqlCommand.TInsa_Bas1_UPDATE;
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("저장 완료");

                        cells["bas_type"].Value = "Select";
                        cells["bas_empno_cp"].Value = cells["bas_empno"].Value;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private string DateValues(string date1)
        {
            if (string.IsNullOrEmpty(date1))
            {
                return date1 = "";
            }
            return date1.Replace("-", string.Empty);

        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            Insert_Rows();

        }

        private void DataDeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (cells["bas_type"].Value.Equals("Select"))
            {
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand())
                    {
                        string sql = @"DELETE lmg_tinsa_bas WHERE BAS_EMPNO =:BAS_EMPNO";
                        command.Connection = connection;
                        command.Parameters.Add("BAS_EMPNO", cells["BAS_EMPNO_CP"].Value.ToString());
                        command.CommandText = sql;
                        command.BindByName = true;
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
            }
            var removeTargetRow = this.dataGridView1.SelectedRows[0];
            this.dataGridView1.Rows.Remove(removeTargetRow);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
