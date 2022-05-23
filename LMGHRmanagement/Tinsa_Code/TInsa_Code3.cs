using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace LMGHRmanagement
{
    public partial class TInsa_Code3 : Form
    {
        private string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public TInsa_Code3()
        {
            InitializeComponent();

            #region 부서코드테이블
            this.dataGridView1.Columns.Add("dept_type", "상태");
            this.dataGridView1.Columns.Add("dept_code", "부서코드");
            this.dataGridView1.Columns.Add("dept_name", "부서명칭(원형)");
            this.dataGridView1.Columns.Add("dept_names", "부서명칭(축약)");
            this.dataGridView1.Columns.Add("dept_seq", "부서SEQ");
            this.dataGridView1.Columns.Add("dept_upp", "상위부서코드");
            this.dataGridView1.Columns.Add("dept_sdate", "생성일자");
            this.dataGridView1.Columns.Add("dept_edate", "폐기일자");

            this.dataGridView1.Columns[2].Width = 120;
            this.dataGridView1.Columns[3].Width = 120;
            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 벨리데이션 체크
            dept_code.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            dept_name.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            dept_names.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            dept_seq.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            dept_upp.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            dept_sdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            dept_edate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion

            #region 연동
            dept_code.TextChanged += new EventHandler(DataGridViewVandingEvent);
            dept_name.TextChanged += new EventHandler(DataGridViewVandingEvent);
            dept_names.TextChanged += new EventHandler(DataGridViewVandingEvent);
            dept_seq.TextChanged += new EventHandler(DataGridViewVandingEvent);
            dept_upp.TextChanged += new EventHandler(DataGridViewVandingEvent);
            dept_sdate.TextChanged += new EventHandler(DataGridViewVandingEvent);
            dept_edate.TextChanged += new EventHandler(DataGridViewVandingEvent);
            #endregion

            #region 포커스
            dept_code.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            dept_name.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            dept_names.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            dept_seq.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            dept_upp.GotFocus += new EventHandler(ComboBoxBindingEvent);
            dept_sdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            dept_edate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);

            #endregion

        }

        private void ComboBoxBindingEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (!cells["dept_type"].Value.Equals("Select")) return;
            cells["dept_type"].Value = "Update";

            string sql = @"select dept_code from lmg_tinsa_dept";

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
                        dept_upp.Items.Add(rd.GetString(0).ToString());
                    }
                }
            }
        }

        private void TextBoxGotFoucsEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (!cells["dept_type"].Value.Equals("Select")) return;
            cells["dept_type"].Value = "Update";
        }

        private void DataGridViewVandingEvent(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;
            var Cells = dataGridView1.SelectedRows[0].Cells;
            var TargetControl = sender as Control;
            Cells[TargetControl.Name].Value = TargetControl.Text;
            Cells["dept_sdate"].Value = DateValues(Cells["dept_sdate"].Value?.ToString());
            Cells["dept_edate"].Value = DateValues(Cells["dept_edate"].Value?.ToString());
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
            TextBoxStateChanged();
            var row = this.dataGridView1.Rows[e.RowIndex];
            this.InsertDataGridViewRowValue(row);
            this.ValidationChecking(row);
        }

        private void ValidationChecking(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(dept_code.Text.Trim())) { this.SetError(row, this.dept_code, "부서코드를 입력해주세요."); return; }
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
            DateTime value;
            DateTime value1;

            dept_code.Text = cells["dept_code"].Value?.ToString();
            dept_name.Text = cells["dept_name"].Value?.ToString();
            dept_names.Text = cells["dept_names"].Value?.ToString();
            dept_seq.Text = cells["dept_seq"].Value?.ToString();
            dept_upp.Text = cells["dept_upp"].Value?.ToString();
            if (string.IsNullOrEmpty(cells["dept_sdate"].Value?.ToString()))
            {
                cells["dept_sdate"].Value = "";
                return;
            }
            dept_sdate.CustomFormat = "yyyy-MM-dd";
            DateTime.TryParseExact(cells["dept_sdate"].Value.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value);
            this.dept_sdate.Value = value;

            if (string.IsNullOrEmpty(cells["dept_edate"].Value?.ToString()))
            {
                cells["dept_edate"].Value = "";
                return;
            }
            dept_edate.CustomFormat = "yyyy-MM-dd";
            DateTime.TryParseExact(cells["dept_edate"].Value.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value1);
            this.dept_edate.Value = value1;
        }

        private void TextBoxStateChanged()
        {
            dept_code.Enabled = true;
            dept_name.Enabled = true;
            dept_names.Enabled = true;
            dept_seq.Enabled = true;
            dept_upp.Enabled = true;
            dept_sdate.Enabled = true;
            dept_edate.Enabled = true;
        }

        private void DataLoadBtn_Click(object sender, EventArgs e)
        {
            //new Oracleparameter("parameter", $"%{parameter}%");
            this.dataGridView1.Rows.Clear();
            this.DataDeleteBtn.Enabled = true;
            this.DataSaveBtn.Enabled = true;

            TextBoxValuesClear();
            string sql = SqlCommand.Tinsa_Code3_Search;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("dept_name", $"%{Search_dept_name.Text}%");
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridViewSelectDataLoad(reader);
                }
            }
        }

        private void DataGridViewSelectDataLoad(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["dept_type"].Value = "Select";
            cells["dept_code"].Value = reader["dept_code"].ToString();
            cells["dept_name"].Value = reader["dept_name"].ToString();
            cells["dept_names"].Value = reader["dept_names"].ToString();
            cells["dept_seq"].Value = reader["dept_seq"].ToString();
            cells["dept_upp"].Value = reader["dept_upp"].ToString();
            cells["dept_sdate"].Value = reader["dept_sdate"].ToString();
            cells["dept_edate"].Value = reader["dept_edate"].ToString();
        }

        private void TextBoxValuesClear()
        {
            dept_code.Text = string.Empty;
            dept_name.Text = string.Empty;
            dept_names.Text = string.Empty;
            dept_seq.Text = string.Empty;
            dept_upp.Text = string.Empty;
            dept_sdate.Text = string.Empty;
            dept_edate.Text = string.Empty;
        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            TextBoxStateChanged();
            int RowCount = dataGridView1.Rows.Count;
            var index = this.dataGridView1.Rows.Add();
            var row = this.dataGridView1.Rows[index];
            var cells = row.Cells;
            cells["dept_type"].Value = "Insert";
            dataGridView1.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView1.Rows[index]);
            this.ValidationChecking(row);
        }

        private void DataDeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (cells["dept_type"].Value.Equals("Select"))
            {
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand())
                    {
                        string sql = @" DELETE lmg_tinsa_dept WHERE dept_code = :dept_code";
                        command.Connection = connection;
                        command.Parameters.Add("dept_code", cells["dept_code"].Value.ToString());
                        command.CommandText = sql;
                        command.BindByName = true;
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
            }
            var removeTargetRow = this.dataGridView1.SelectedRows[0];
            this.dataGridView1.Rows.Remove(removeTargetRow);
            this.errorProvider1.Clear();
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

                        if (cells["dept_type"].Value.Equals("Insert"))
                        {
                            string sql = SqlCommand.Tinsa_Code3_Insert;
                            command.CommandText = sql;

                            command.Parameters.Add("DEPT_CODE", cells["DEPT_CODE"].Value?.ToString());
                            command.Parameters.Add("DEPT_NAME", cells["DEPT_NAME"].Value?.ToString());
                            command.Parameters.Add("DEPT_NAMES", cells["DEPT_NAMES"].Value?.ToString());
                            command.Parameters.Add("DEPT_SEQ", cells["DEPT_SEQ"].Value?.ToString());
                            command.Parameters.Add("DEPT_UPP", cells["DEPT_UPP"].Value?.ToString());
                            command.Parameters.Add("DEPT_SDATE", DateValues(cells["DEPT_SDATE"].Value?.ToString()));
                            command.Parameters.Add("DEPT_EDATE", DateValues(cells["DEPT_EDATE"].Value?.ToString()));
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "A");
                            command.Parameters.Add("DATASYS3", "MinGi");

                            command.ExecuteNonQuery();

                            MessageBox.Show("완료");
                        }
                        if (cells["dept_type"].Value.Equals("Update"))
                        {
                            string sql = SqlCommand.Tinsa_Code3_Update;

                            command.CommandText = sql;
                            command.Parameters.Add("DEPT_NAME", cells["DEPT_NAME"].Value?.ToString());
                            command.Parameters.Add("DEPT_NAMES", cells["DEPT_NAMES"].Value?.ToString());
                            command.Parameters.Add("DEPT_SEQ", cells["DEPT_SEQ"].Value?.ToString());
                            command.Parameters.Add("DEPT_UPP", cells["DEPT_UPP"].Value?.ToString());
                            command.Parameters.Add("DEPT_SDATE", DateValues(cells["DEPT_SDATE"].Value?.ToString()));
                            command.Parameters.Add("DEPT_EDATE", DateValues(cells["DEPT_EDATE"].Value?.ToString()));
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "U");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.Parameters.Add("DEPT_CODE", cells["DEPT_CODE"].Value?.ToString());

                            command.ExecuteNonQuery();
                            MessageBox.Show("완료");

                        }
                        cells["dept_type"].Value = "Select";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
