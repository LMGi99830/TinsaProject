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
using System.Globalization;

namespace LMGHRmanagement
{
    public partial class Tinsa_Bas3 : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public Tinsa_Bas3()
        {
            InitializeComponent();

            #region 데이터그리드뷰2 초기화
            this.dataGridView2.Columns.Add("bas_empno", "사원번호");
            this.dataGridView2.Columns.Add("bas_name", "이름");

            #endregion

            #region 데이터그리드뷰1 초기화
            this.dataGridView1.Columns.Add("edu_type", "상태");
            this.dataGridView1.Columns.Add("edu_empno", "사원번호");
            this.dataGridView1.Columns.Add("edu_loe", "학력구분");
            this.dataGridView1.Columns.Add("edu_entdate", "입학일자");
            this.dataGridView1.Columns.Add("edu_gradate", "졸업일자");
            this.dataGridView1.Columns.Add("edu_schnm", "학교명");
            this.dataGridView1.Columns.Add("edu_dept", "학과(전공)");
            this.dataGridView1.Columns.Add("edu_degree", "학위");
            this.dataGridView1.Columns.Add("edu_grade", "성적");
            this.dataGridView1.Columns.Add("edu_gra", "졸업구분");
            this.dataGridView1.Columns.Add("edu_last", "최종여부");
            #endregion

            #region 데이터그리드뷰2 더블클릭
            this.dataGridView2.CellDoubleClick += new DataGridViewCellEventHandler(this.DataGridViewCellDoubleClick);
            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 데이터그리드뷰랑 텍스트박스 연동
            edu_empno.TextChanged += new EventHandler(DataGridViewVandingEvent);
            edu_loe.TextChanged += new EventHandler(DataGridViewVandingEvent);
            edu_entdate.TextChanged += new EventHandler(DataGridViewVandingEvent);
            edu_gradate.TextChanged += new EventHandler(DataGridViewVandingEvent);
            edu_schnm.TextChanged += new EventHandler(DataGridViewVandingEvent);
            edu_dept.TextChanged += new EventHandler(DataGridViewVandingEvent);
            edu_degree.TextChanged += new EventHandler(DataGridViewVandingEvent);
            edu_grade.TextChanged += new EventHandler(DataGridViewVandingEvent);
            edu_gra.TextChanged += new EventHandler(DataGridViewVandingEvent);
            edu_last.TextChanged += new EventHandler(DataGridViewVandingEvent);
            #endregion

            #region 텍박 벨리데이션 체크
            edu_empno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            edu_loe.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            edu_entdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            edu_gradate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            edu_schnm.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            edu_dept.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            edu_degree.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            edu_grade.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            edu_gra.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            edu_last.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion

            #region 포커스
            edu_empno.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            edu_loe.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            edu_entdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            edu_gradate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            edu_schnm.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            edu_dept.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            edu_degree.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            edu_grade.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            edu_gra.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            edu_last.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            #endregion


        }

        private void TextBoxGotFoucsEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (!cells["edu_type"].Value.Equals("Select")) return;
            cells["edu_type"].Value = "Update";
        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = this.dataGridView1.Rows[e.RowIndex];
            this.InsertDataGridViewRowValue(row);
            this.ValidationChecking(row);
        }

        private void LostFocusTextBoxValidationChecking(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var row = this.dataGridView1.SelectedRows[0];
            ValidationChecking(row);
        }

        private void DataGridViewVandingEvent(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;
            var Cells = dataGridView1.SelectedRows[0].Cells;
            var TargetControl = sender as Control;
            Cells[TargetControl.Name].Value = TargetControl.Text;
            Cells["edu_entdate"].Value = DateValues(Cells["edu_entdate"].Value?.ToString());
            Cells["edu_gradate"].Value = DateValues(Cells["edu_gradate"].Value?.ToString());
        }

        private void DataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = dataGridView2.Rows[e.RowIndex];
            edu_empno.Text = this.dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            this.DataGridView1FormLoad();
        }

        private void DataGridView1FormLoad()
        {
            this.dataGridView1.Rows.Clear();
            string sql = SqlCommand.Tinsa_Bas3_Select;
            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add("edu_empno", dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView2SelectLoad(reader);
                }
            }
        }

        private void DataGridView2SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["edu_type"].Value = "Select";
            cells["edu_empno"].Value = reader["edu_empno"].ToString();
            cells["edu_loe"].Value = reader["edu_loe"].ToString();
            cells["edu_entdate"].Value = reader["edu_entdate"].ToString();
            cells["edu_gradate"].Value = reader["edu_gradate"].ToString();
            cells["edu_schnm"].Value = reader["edu_schnm"].ToString();
            cells["edu_dept"].Value = reader["edu_dept"].ToString();
            cells["edu_degree"].Value = reader["edu_degree"].ToString();
            cells["edu_grade"].Value = reader["edu_grade"].ToString();
            cells["edu_gra"].Value = reader["edu_gra"].ToString();
            cells["edu_last"].Value = reader["edu_last"].ToString();
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
            edu_empno.Text = "";
            edu_schnm.Text = "";
            edu_dept.Text = "";
            edu_grade.Text = "";

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
            edu_empno.Enabled = true;
            edu_loe.Enabled = true;
            edu_entdate.Enabled = true;
            edu_gradate.Enabled = true;
            edu_schnm.Enabled = true;
            edu_dept.Enabled = true;
            edu_degree.Enabled = true;
            edu_grade.Enabled = true;
            edu_gra.Enabled = true;
            edu_last.Enabled = true;
        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            int RowCount = dataGridView1.Rows.Count;
            var index = this.dataGridView1.Rows.Add();
            var row = this.dataGridView1.Rows[index];
            var cells = row.Cells;

            cells["edu_type"].Value = "Insert";
            cells["edu_empno"].Value = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            dataGridView1.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView1.Rows[index]);
            this.ValidationChecking(row);
        }

        private void ValidationChecking(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(edu_loe.Text.Trim())) { this.SetError(row, this.edu_loe, "학력을 선택해주세요."); return; }
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
            DateTime value1;
            edu_entdate.CustomFormat = "yyyy-MM-dd";
            edu_gradate.CustomFormat = "yyyy-MM-dd";
            this.edu_empno.Text = cells["edu_empno"].Value?.ToString();
            this.edu_loe.Text = cells["edu_loe"].Value?.ToString();
            this.edu_schnm.Text = cells["edu_schnm"].Value?.ToString();
            this.edu_dept.Text = cells["edu_dept"].Value?.ToString();
            this.edu_degree.Text = cells["edu_degree"].Value?.ToString();
            this.edu_grade.Text = cells["edu_grade"].Value?.ToString();
            this.edu_gra.Text = cells["edu_gra"].Value?.ToString();
            this.edu_last.Text = cells["edu_last"].Value?.ToString();
            if (string.IsNullOrEmpty(cells["edu_entdate"].Value?.ToString()))
            {
                cells["edu_entdate"].Value = "";
                return;
            }
            DateTime.TryParseExact(cells["edu_entdate"].Value.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value);
            this.edu_entdate.Value = value;

            if (string.IsNullOrEmpty(cells["edu_gradate"].Value?.ToString()))
            {
                cells["edu_gradate"].Value = "";
                return;
            }
            DateTime.TryParseExact(cells["edu_gradate"].Value.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value1);
            this.edu_gradate.Value = value1;

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

                        if (cells["edu_type"].Value.Equals("Insert"))
                        {
                            string sql = SqlCommand.Tinsa_Bas3_Insert;

                            command.CommandText = sql;
                            command.Parameters.Add("edu_empno", cells["edu_empno"].Value.ToString());
                            command.Parameters.Add("edu_loe", cells["edu_loe"].Value?.ToString());
                            command.Parameters.Add("edu_entdate", DateValues(cells["edu_entdate"].Value?.ToString()));
                            command.Parameters.Add("edu_gradate", DateValues(cells["edu_gradate"].Value?.ToString()));
                            command.Parameters.Add("edu_schnm", cells["edu_schnm"].Value?.ToString());
                            command.Parameters.Add("edu_dept", cells["edu_dept"].Value?.ToString());
                            command.Parameters.Add("edu_degree", cells["edu_degree"].Value?.ToString());
                            command.Parameters.Add("edu_grade", cells["edu_grade"].Value?.ToString());
                            command.Parameters.Add("edu_gra", cells["edu_gra"].Value?.ToString());
                            command.Parameters.Add("edu_last", cells["edu_last"].Value?.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "A");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.ExecuteNonQuery();

                            MessageBox.Show("완료");
                        }
                        if (cells["edu_type"].Value.Equals("Update"))
                        {
                            string sql = SqlCommand.Tinsa_Bas3_Update;

                            command.CommandText = sql;
                            command.Parameters.Add("edu_gradate", DateValues(cells["edu_gradate"].Value?.ToString()));
                            command.Parameters.Add("edu_schnm", cells["edu_schnm"].Value?.ToString());
                            command.Parameters.Add("edu_dept", cells["edu_dept"].Value?.ToString());
                            command.Parameters.Add("edu_degree", cells["edu_degree"].Value?.ToString());
                            command.Parameters.Add("edu_grade", cells["edu_grade"].Value?.ToString());
                            command.Parameters.Add("edu_gra", cells["edu_gra"].Value?.ToString());
                            command.Parameters.Add("edu_last", cells["edu_last"].Value?.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "U");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.Parameters.Add("edu_empno", cells["edu_empno"].Value.ToString());
                            command.Parameters.Add("edu_loe", cells["edu_loe"].Value?.ToString());
                            command.Parameters.Add("edu_entdate", DateValues(cells["edu_entdate"].Value?.ToString()));

                            command.ExecuteNonQuery();

                            MessageBox.Show("완료");

                        }
                        cells["edu_type"].Value = "Select";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private object DateValues(string date1)
        {
            if (string.IsNullOrEmpty(date1))
            {
                return date1 = "";
            }
            return date1.Replace("-", string.Empty);
        }

        private void DataDeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (cells["edu_type"].Value.Equals("Select"))
            {
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand())
                    {
                        string sql = @" DELETE lmg_tinsa_edu WHERE EDU_EMPNO =:EDU_EMPNO
                                        and EDU_LOE = :EDU_LOE and EDU_ENTDATE = :EDU_ENTDATE";
                        command.Connection = connection;
                        command.Parameters.Add("EDU_EMPNO", cells["EDU_EMPNO"].Value.ToString());
                        command.Parameters.Add("EDU_LOE", cells["EDU_LOE"].Value.ToString());
                        command.Parameters.Add("EDU_ENTDATE", cells["EDU_ENTDATE"].Value.ToString());
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
