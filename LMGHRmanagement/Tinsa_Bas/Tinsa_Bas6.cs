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
    public partial class Tinsa_Bas6 : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public Tinsa_Bas6()
        {
            InitializeComponent();

            #region 사원테이블 초기화
            this.dataGridView1.Columns.Add("bas_empno", "사원번호");
            this.dataGridView1.Columns.Add("bas_name", "이름");

            #endregion

            #region 자격사항테이블
            this.dataGridView2.Columns.Add("LIC_TYPE", "상태");
            this.dataGridView2.Columns.Add("LIC_EMPNO", "사원번호");
            this.dataGridView2.Columns.Add("LIC_NAME", "자격증명");
            this.dataGridView2.Columns.Add("LIC_GRADE", "급수");
            this.dataGridView2.Columns.Add("LIC_ACQDATE", "취득일");
            this.dataGridView2.Columns.Add("LIC_ORGAN", "발급기관");
            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.DataGridViewCellDoubleClick);
            #endregion

            #region 데이터그리드뷰2 더블클릭
            this.dataGridView2.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 벨리데이션 체크
            lic_empno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            lic_name.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            lic_grade.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            lic_acqdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            lic_organ.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion

            #region 텍스트박스 그리드뷰 연동
            lic_empno.TextChanged += new EventHandler(DataGridViewVandingEvent);
            lic_name.TextChanged += new EventHandler(DataGridViewVandingEvent);
            lic_grade.TextChanged += new EventHandler(DataGridViewVandingEvent);
            lic_acqdate.TextChanged += new EventHandler(DataGridViewVandingEvent);
            lic_organ.TextChanged += new EventHandler(DataGridViewVandingEvent);
            #endregion

            #region 포커스
            lic_empno.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            lic_name.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            lic_grade.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            lic_acqdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            lic_organ.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            #endregion

        }

        private void TextBoxGotFoucsEvent(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count <= 0) return;
            lic_acqdate.CustomFormat = "yyyy-MM-dd";
            var cells = this.dataGridView2.SelectedRows[0].Cells;
            if (!cells["lic_type"].Value.Equals("Select")) return;
            cells["lic_type"].Value = "Update";
        }

        private void DataGridViewVandingEvent(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count <= 0) return;
            var Cells = dataGridView2.SelectedRows[0].Cells;
            var TargetControl = sender as Control;
            Cells[TargetControl.Name].Value = TargetControl.Text;
            Cells["lic_acqdate"].Value = DateValues(Cells["lic_acqdate"].Value?.ToString());
        }

        private object DateValues(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                return v = "";
            }
            return v.Replace("-", string.Empty);
        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = this.dataGridView2.Rows[e.RowIndex];
            this.InsertDataGridViewRowValue(row);
            this.ValidationChecking(row);
        }

        private void LostFocusTextBoxValidationChecking(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows.Count <= 0) return;
            var row = this.dataGridView2.SelectedRows[0];
            ValidationChecking(row);
        }

        private void DataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = dataGridView1.Rows[e.RowIndex];
            lic_empno.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.DataGridView1FormLoad();
        }

        private void DataGridView1FormLoad()
        {
            this.dataGridView2.Rows.Clear();
            //ComboBoxClickEvent();
            string sql = SqlCommand.Tinsa_Bas6_Select;
            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add("bas_empno", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView2SelectLoad(reader);
                }
            }
        }

        private void DataGridView2SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView2.Rows.Add();
            var cells = this.dataGridView2.Rows[index].Cells;

            cells["lic_type"].Value = "Select";
            cells["lic_empno"].Value = reader["lic_empno"].ToString();
            cells["lic_name"].Value = reader["lic_name"].ToString();
            cells["lic_grade"].Value = reader["lic_grade"].ToString();
            cells["lic_acqdate"].Value = reader["lic_acqdate"].ToString();
            cells["lic_organ"].Value = reader["lic_organ"].ToString();
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
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["bas_empno"].Value = reader["bas_empno"].ToString();
            cells["bas_name"].Value = reader["bas_name"].ToString();
        }

        private void TextBoxValuesClear()
        {
            lic_empno.Text = "";
            lic_name.Text = "";
            lic_grade.Text = "";
            lic_acqdate.CustomFormat = " ";
            lic_organ.Text = "";

        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            int RowCount = dataGridView2.Rows.Count;
            var index = this.dataGridView2.Rows.Add();
            var row = this.dataGridView2.Rows[index];
            var cells = row.Cells;
            cells["lic_type"].Value = "Insert";
            cells["lic_empno"].Value = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            dataGridView2.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView2.Rows[index]);
            this.ValidationChecking(row);
        }

        private void ValidationChecking(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(lic_name.Text.Trim())) { this.SetError(row, this.lic_name, "자격증명을 입력해주세요."); return; }
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


            lic_empno.Text = cells["lic_empno"].Value?.ToString();
            lic_name.Text = cells["lic_name"].Value?.ToString();
            lic_grade.Text = cells["lic_grade"].Value?.ToString();
            lic_organ.Text = cells["lic_organ"].Value?.ToString();

            if (string.IsNullOrEmpty(cells["lic_acqdate"].Value?.ToString()))
            {
                cells["lic_acqdate"].Value = "";
                lic_acqdate.CustomFormat = " ";
                return;
            }
            lic_acqdate.CustomFormat = "yyyy-MM-dd";
            DateTime.TryParseExact(cells["lic_acqdate"].Value.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value);
            this.lic_acqdate.Value = value;
        }

        private void DataDeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows.Count <= 0) return;
            var cells = this.dataGridView2.SelectedRows[0].Cells;
            if (cells["lic_type"].Value.Equals("Select"))
            {
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand())
                    {
                        string sql = @" DELETE lmg_tinsa_lic WHERE lic_empno =:lic_empno
                                        and lic_name = :lic_name";
                        command.Connection = connection;
                        command.Parameters.Add("lic_empno", cells["lic_empno"].Value.ToString());
                        command.Parameters.Add("lic_name", cells["lic_name"].Value.ToString());
                        command.CommandText = sql;
                        command.BindByName = true;
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
            }
            var removeTargetRow = this.dataGridView2.SelectedRows[0];
            this.dataGridView2.Rows.Remove(removeTargetRow);
        }

        private void DataSaveBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("정말 저장하시겠습니까?", "저장", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult != DialogResult.OK) return;

            foreach (DataGridViewRow row in this.dataGridView2.Rows)
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

                        if (cells["lic_type"].Value.Equals("Insert"))
                        {
                            string sql = SqlCommand.Tinsa_Bas6_Insert;

                            command.CommandText = sql;
                            command.Parameters.Add("LIC_EMPNO", cells["LIC_EMPNO"].Value?.ToString());
                            command.Parameters.Add("LIC_NAME", cells["LIC_NAME"].Value?.ToString());
                            command.Parameters.Add("LIC_GRADE", cells["LIC_GRADE"].Value?.ToString());
                            command.Parameters.Add("LIC_ACQDATE", DateValues(cells["LIC_ACQDATE"].Value?.ToString()));
                            command.Parameters.Add("LIC_ORGAN", cells["LIC_ORGAN"].Value?.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "A");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.ExecuteNonQuery();

                            MessageBox.Show("완료");
                        }
                        if (cells["lic_type"].Value.Equals("Update"))
                        {
                            string sql = SqlCommand.Tinsa_Bas6_Update;

                            command.CommandText = sql;
                            command.Parameters.Add("LIC_GRADE", cells["LIC_GRADE"].Value?.ToString());
                            command.Parameters.Add("LIC_ACQDATE", DateValues(cells["LIC_ACQDATE"].Value?.ToString()));
                            command.Parameters.Add("LIC_ORGAN", cells["LIC_ORGAN"].Value?.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "U");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.Parameters.Add("LIC_EMPNO", cells["LIC_EMPNO"].Value?.ToString());
                            command.Parameters.Add("LIC_NAME", cells["LIC_NAME"].Value?.ToString());

                            command.ExecuteNonQuery();

                            MessageBox.Show("완료");

                        }
                        cells["lic_type"].Value = "Select";

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
