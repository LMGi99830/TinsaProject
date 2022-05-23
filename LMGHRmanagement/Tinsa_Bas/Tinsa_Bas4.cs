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
    public partial class Tinsa_Bas4 : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public Tinsa_Bas4()
        {
            InitializeComponent();
            #region 비활성화
            award_empno.Enabled = false;
            award_date.Enabled = false;
            award_no.Enabled = false;
            award_kind.Enabled = false;
            award_organ.Enabled = false;
            award_content.Enabled = false;
            award_inout.Enabled = false;
            award_pos.Enabled = false;
            award_dept.Enabled = false;
            #endregion

            #region 데이터그리드뷰2 초기화
            this.dataGridView2.Columns.Add("bas_empno", "사원번호");
            this.dataGridView2.Columns.Add("bas_name", "이름");

            #endregion

            #region 데이터그리드뷰1 초기화
            this.dataGridView1.Columns.Add("award_type", "상태");
            this.dataGridView1.Columns.Add("award_empno", "사원번호");
            this.dataGridView1.Columns.Add("award_date", "수여일자");
            this.dataGridView1.Columns.Add("award_no", "수여번호");
            this.dataGridView1.Columns.Add("award_kind", "수상종별");
            this.dataGridView1.Columns.Add("award_organ", "수여자(시행처)");
            this.dataGridView1.Columns.Add("award_content", "수상내용");
            this.dataGridView1.Columns.Add("award_inout", "내외구분");
            this.dataGridView1.Columns.Add("award_pos", "직급(당시)");
            this.dataGridView1.Columns.Add("award_dept", "소속(당시)");
            #endregion

            #region 데이터그리드뷰2 더블클릭
            this.dataGridView2.CellDoubleClick += new DataGridViewCellEventHandler(this.DataGridViewCellDoubleClick);
            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 벨리데이션 체크
            award_empno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            award_date.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            award_no.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            award_kind.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            award_organ.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            award_content.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            award_inout.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            award_pos.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            award_dept.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion

            #region 텍스트박스 그리드뷰 연동
            award_empno.TextChanged += new EventHandler(DataGridViewVandingEvent);
            award_date.TextChanged += new EventHandler(DataGridViewVandingEvent);
            award_no.TextChanged += new EventHandler(DataGridViewVandingEvent);
            award_kind.TextChanged += new EventHandler(DataGridViewVandingEvent);
            award_organ.TextChanged += new EventHandler(DataGridViewVandingEvent);
            award_content.TextChanged += new EventHandler(DataGridViewVandingEvent);
            award_inout.TextChanged += new EventHandler(DataGridViewVandingEvent);
            award_pos.TextChanged += new EventHandler(DataGridViewVandingEvent);
            award_dept.TextChanged += new EventHandler(DataGridViewVandingEvent);
            #endregion

            #region 포커스
            award_empno.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            award_date.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            award_no.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            award_kind.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            award_organ.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            award_content.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            award_inout.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            award_pos.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            award_dept.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            #endregion


        }

        private void TextBoxGotFoucsEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (!cells["award_type"].Value.Equals("Select")) return;
            cells["award_type"].Value = "Update";
        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = this.dataGridView1.Rows[e.RowIndex];
            this.InsertDataGridViewRowValue(row);
            this.ValidationChecking(row);
        }

        private void DataGridViewVandingEvent(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;
            var Cells = dataGridView1.SelectedRows[0].Cells;
            var TargetControl = sender as Control;
            Cells[TargetControl.Name].Value = TargetControl.Text;
            Cells["award_date"].Value = DateValues(Cells["award_date"].Value?.ToString());
        }

        private object DateValues(string date1)
        {
            if (string.IsNullOrEmpty(date1))
            {
                return date1 = "";
            }
            return date1.Replace("-", string.Empty);
        }

        private void LostFocusTextBoxValidationChecking(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var row = this.dataGridView1.SelectedRows[0];
            ValidationChecking(row);
        }

        private void DataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = dataGridView2.Rows[e.RowIndex];
            award_empno.Text = this.dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            this.DataGridView1FormLoad();
        }

        private void DataGridView1FormLoad()
        {
            this.dataGridView1.Rows.Clear();
            //ComboBoxClickEvent();
            string sql = SqlCommand.Tinsa_Bas4_Select;
            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add("bas_empno", dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView2SelectLoad(reader);
                }
            }
        }

        private void DataGridView2SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["award_type"].Value = "Select";
            cells["award_empno"].Value = reader["award_empno"].ToString();
            cells["award_date"].Value = reader["award_date"].ToString();
            cells["award_no"].Value = reader["award_no"].ToString();
            cells["award_kind"].Value = reader["award_kind"].ToString();
            cells["award_organ"].Value = reader["award_organ"].ToString();
            cells["award_content"].Value = reader["award_content"].ToString();
            cells["award_inout"].Value = reader["award_inout"].ToString();
            cells["award_pos"].Value = reader["award_pos"].ToString();
            cells["award_dept"].Value = reader["award_dept"].ToString();
        }

        private void DataLoadBtn_Click(object sender, EventArgs e)
        {
            //new Oracleparameter("parameter", $"%{parameter}%");
            this.dataGridView2.Rows.Clear();
            this.dataGridView1.Rows.Clear();
            TextBoxValuesClear();
            string sql = SqlCommand.Tinsa_Bas2_Search;
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
            var index = this.dataGridView2.Rows.Add();
            var cells = this.dataGridView2.Rows[index].Cells;

            cells["bas_empno"].Value = reader["bas_empno"].ToString();
            cells["bas_name"].Value = reader["bas_name"].ToString();
        }

        private void TextBoxValuesClear()
        {
            award_empno.Text = "";
            award_date.CustomFormat = " ";
            award_no.Text = "";
            award_kind.Text = "";
            award_organ.Text = "";
            award_content.Text = "";
            award_inout.Text = "";
            award_pos.Text = "";
            award_dept.Text = "";


        }

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (this.dataGridView2.RowCount > 0)
            {
                ValueStateChanged();
            }
        }

        private void ValueStateChanged()
        {
            award_empno.Enabled = true;
            award_date.Enabled = true;
            award_no.Enabled = true;
            award_kind.Enabled = true;
            award_organ.Enabled = true;
            award_content.Enabled = true;
            award_inout.Enabled = true;
            award_pos.Enabled = true;
            award_dept.Enabled = true;
        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            int RowCount = dataGridView1.Rows.Count;
            var index = this.dataGridView1.Rows.Add();
            var row = this.dataGridView1.Rows[index];
            var cells = row.Cells;

            cells["award_type"].Value = "Insert";
            cells["award_empno"].Value = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            dataGridView1.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView1.Rows[index]);
            this.ValidationChecking(row);
        }

        private void ValidationChecking(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(award_kind.Text.Trim())) { this.SetError(row, this.award_kind, "수상종별을 입력해주세요."); return; }
            //if (string.IsNullOrEmpty(edu_entdate.Text.Trim())) { this.SetError(row, this.edu_entdate, "입학 일자를 선택해주세요"); return; }
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

            award_date.CustomFormat = "yyyy-MM-dd";

            this.award_empno.Text = cells["award_empno"].Value?.ToString();
            this.award_no.Text = cells["award_no"].Value?.ToString();
            this.award_kind.Text = cells["award_kind"].Value?.ToString();
            this.award_organ.Text = cells["award_organ"].Value?.ToString();
            this.award_content.Text = cells["award_content"].Value?.ToString();
            this.award_inout.Text = cells["award_inout"].Value?.ToString();
            this.award_pos.Text = cells["award_pos"].Value?.ToString();
            this.award_dept.Text = cells["award_dept"].Value?.ToString();
            if (string.IsNullOrEmpty(cells["award_date"].Value?.ToString()))
            {
                cells["award_date"].Value = "";
                return;
            }
            DateTime.TryParseExact(cells["award_date"].Value.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value);
            this.award_date.Value = value;


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

                        if (cells["award_type"].Value.Equals("Insert"))
                        {
                            string sql = SqlCommand.Tinsa_Bas4_Insert;

                            command.CommandText = sql;
                            command.Parameters.Add("award_empno", cells["award_empno"].Value.ToString());
                            command.Parameters.Add("award_date", DateValues(cells["award_date"].Value?.ToString()));
                            command.Parameters.Add("award_no", cells["award_no"].Value?.ToString());
                            command.Parameters.Add("award_kind", cells["award_kind"].Value?.ToString());
                            command.Parameters.Add("award_organ", cells["award_organ"].Value?.ToString());
                            command.Parameters.Add("award_content", cells["award_content"].Value?.ToString());
                            command.Parameters.Add("award_inout", cells["award_inout"].Value?.ToString());
                            command.Parameters.Add("award_pos", cells["award_pos"].Value?.ToString());
                            command.Parameters.Add("award_dept", cells["award_dept"].Value?.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "A");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.ExecuteNonQuery();
                              
                            MessageBox.Show("완료");
                        }
                        if (cells["award_type"].Value.Equals("Update"))
                        {
                            string sql = SqlCommand.Tinsa_Bas4_Update;

                            command.CommandText = sql;
                            command.Parameters.Add("award_no", cells["award_no"].Value?.ToString());
                            command.Parameters.Add("award_kind", cells["award_kind"].Value?.ToString());
                            command.Parameters.Add("award_organ", cells["award_organ"].Value?.ToString());
                            command.Parameters.Add("award_content", cells["award_content"].Value?.ToString());
                            command.Parameters.Add("award_inout", cells["award_inout"].Value?.ToString());
                            command.Parameters.Add("award_pos", cells["award_pos"].Value?.ToString());
                            command.Parameters.Add("award_dept", cells["award_dept"].Value?.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "U");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.Parameters.Add("award_empno", cells["award_empno"].Value.ToString());
                            command.Parameters.Add("award_date", DateValues(cells["award_date"].Value?.ToString()));

                            command.ExecuteNonQuery();

                            MessageBox.Show("완료");

                        }
                        cells["award_type"].Value = "Select";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataDeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (cells["award_type"].Value.Equals("Select"))
            {
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand())
                    {
                        string sql = @" DELETE lmg_tinsa_award WHERE award_empno =:award_empno
                                        and award_date = :award_date";
                        command.Connection = connection;
                        command.Parameters.Add("award_empno", cells["award_empno"].Value.ToString());
                        command.Parameters.Add("award_date", cells["award_date"].Value.ToString());
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
    }
}
