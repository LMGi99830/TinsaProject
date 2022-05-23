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
    public partial class Tinsa_Bas5 : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public Tinsa_Bas5()
        {
            InitializeComponent();

            #region 사원테이블 초기화
            this.dataGridView1.Columns.Add("bas_empno", "사원번호");
            this.dataGridView1.Columns.Add("bas_name", "이름");

            #endregion

            #region 자격사항테이블
            this.dataGridView2.Columns.Add("CAR_TYPE", "상태");
            this.dataGridView2.Columns.Add("CAR_EMPNO", "사원번호");
            this.dataGridView2.Columns.Add("CAR_COM", "근무처명");
            this.dataGridView2.Columns.Add("CAR_REGION", "소재지");
            this.dataGridView2.Columns.Add("CAR_YYYYMM_F", "근무시작월");
            this.dataGridView2.Columns.Add("CAR_YYYYMM_T", "근무종료월");
            this.dataGridView2.Columns.Add("CAR_POS", "최종직급");
            this.dataGridView2.Columns.Add("CAR_DEPT", "담당부서");
            this.dataGridView2.Columns.Add("CAR_REASON", "퇴직/이직사유");
            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.DataGridViewCellDoubleClick);
            #endregion

            #region 데이터그리드뷰2 더블클릭
            this.dataGridView2.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 텍스트박스 그리드뷰 연동
            car_empno.TextChanged += new EventHandler(DataGridViewVandingEvent);
            car_com.TextChanged += new EventHandler(DataGridViewVandingEvent);
            car_region.TextChanged += new EventHandler(DataGridViewVandingEvent);
            car_yyyymm_f.TextChanged += new EventHandler(DataGridViewVandingEvent);
            car_yyyymm_t.TextChanged += new EventHandler(DataGridViewVandingEvent);
            car_pos.TextChanged += new EventHandler(DataGridViewVandingEvent);
            car_dept.TextChanged += new EventHandler(DataGridViewVandingEvent);
            car_reason.TextChanged += new EventHandler(DataGridViewVandingEvent);
            #endregion

            #region 벨리데이션 체크
            car_empno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            car_com.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            car_region.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            car_yyyymm_f.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            car_yyyymm_t.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            car_pos.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            car_dept.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            car_reason.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion

            #region 포커스
            car_empno.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            car_com.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            car_region.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            car_yyyymm_f.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            car_yyyymm_t.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            car_pos.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            car_dept.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            car_reason.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            #endregion


        }

        private void TextBoxGotFoucsEvent(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count <= 0) return;
            car_yyyymm_f.CustomFormat = "yyyy-MM";
            car_yyyymm_t.CustomFormat = "yyyy-MM";
            var cells = this.dataGridView2.SelectedRows[0].Cells;
            if (!cells["car_type"].Value.Equals("Select")) return;
            cells["car_type"].Value = "Update";
        }

        private void DataGridViewVandingEvent(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count <= 0) return;
            var Cells = dataGridView2.SelectedRows[0].Cells;
            var TargetControl = sender as Control;
            Cells[TargetControl.Name].Value = TargetControl.Text;
            Cells["car_yyyymm_f"].Value = DateValues(Cells["car_yyyymm_f"].Value?.ToString());
            Cells["car_yyyymm_t"].Value = DateValues(Cells["car_yyyymm_t"].Value?.ToString());
        }

        private object DateValues(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                return v = "";
            }
            return v.Replace("-", string.Empty).Substring(0, 6);

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
            car_empno.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.DataGridView1FormLoad();
        }

        private void DataGridView1FormLoad()
        {
            this.dataGridView2.Rows.Clear();
            //ComboBoxClickEvent();
            string sql = SqlCommand.Tinsa_Bas5_Select;
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

            cells["car_type"].Value = "Select";
            cells["car_empno"].Value = reader["car_empno"].ToString();
            cells["car_com"].Value = reader["car_com"].ToString();
            cells["car_region"].Value = reader["car_region"].ToString();
            cells["car_yyyymm_f"].Value = reader["car_yyyymm_f"].ToString();
            cells["car_yyyymm_t"].Value = reader["car_yyyymm_t"].ToString();
            cells["car_pos"].Value = reader["car_pos"].ToString();
            cells["car_dept"].Value = reader["car_dept"].ToString();
            cells["car_reason"].Value = reader["car_reason"].ToString();
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
            car_empno.Text = "";
            car_com.Text = "";
            car_region.Text = "";
            car_yyyymm_f.CustomFormat = " ";
            car_yyyymm_t.CustomFormat = " ";
            car_pos.Text = "";
            car_dept.Text = "";
            car_reason.Text = "";

        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            int RowCount = dataGridView2.Rows.Count;
            var index = this.dataGridView2.Rows.Add();
            var row = this.dataGridView2.Rows[index];
            var cells = row.Cells;

            cells["car_type"].Value = "Insert";
            cells["car_empno"].Value = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            dataGridView2.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView2.Rows[index]);
            this.ValidationChecking(row);
        }

        private void ValidationChecking(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(car_com.Text.Trim())) { this.SetError(row, this.car_com, "근무처명을 입력해주세요."); return; }
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


            car_empno.Text = cells["car_empno"].Value?.ToString();
            car_com.Text = cells["car_com"].Value?.ToString();
            car_region.Text = cells["car_region"].Value?.ToString();
            car_pos.Text = cells["car_pos"].Value?.ToString();
            car_dept.Text = cells["car_dept"].Value?.ToString();
            car_reason.Text = cells["car_region"].Value?.ToString();

            if (string.IsNullOrEmpty(cells["car_yyyymm_f"].Value?.ToString()))
            {
                cells["car_yyyymm_f"].Value = "";
                car_yyyymm_f.CustomFormat = " ";
                return;
            }
            if (string.IsNullOrEmpty(cells["car_yyyymm_t"].Value?.ToString()))
            {
                cells["car_yyyymm_t"].Value = "";
                car_yyyymm_t.CustomFormat = " ";
                return;
            }
            car_yyyymm_f.CustomFormat = "yyyy-MM";
            DateTime.TryParseExact(cells["car_yyyymm_f"].Value.ToString(), "yyyyMM", null, DateTimeStyles.None, out value);
            this.car_yyyymm_f.Value = value;

            car_yyyymm_t.CustomFormat = "yyyy-MM";
            DateTime.TryParseExact(cells["car_yyyymm_t"].Value.ToString(), "yyyyMM", null, DateTimeStyles.None, out value);
            this.car_yyyymm_t.Value = value;
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

                        if (cells["car_type"].Value.Equals("Insert"))
                        {
                            string sql = SqlCommand.Tinsa_Bas5_Insert;

                            command.CommandText = sql;
                            command.Parameters.Add("CAR_EMPNO", cells["CAR_EMPNO"].Value?.ToString());
                            command.Parameters.Add("CAR_COM", cells["CAR_COM"].Value?.ToString());
                            command.Parameters.Add("CAR_REGION", cells["CAR_REGION"].Value?.ToString());
                            command.Parameters.Add("CAR_YYYYMM_F", DateValues(cells["CAR_YYYYMM_F"].Value?.ToString()));
                            command.Parameters.Add("CAR_YYYYMM_T", DateValues(cells["CAR_YYYYMM_T"].Value?.ToString()));
                            command.Parameters.Add("CAR_POS", cells["CAR_POS"].Value?.ToString());
                            command.Parameters.Add("CAR_DEPT", cells["CAR_DEPT"].Value?.ToString());
                            command.Parameters.Add("CAR_REASON", cells["CAR_REASON"].Value?.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "A");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.ExecuteNonQuery();

                            MessageBox.Show("완료");
                        }
                        if (cells["car_type"].Value.Equals("Update"))
                        {
                            string sql = SqlCommand.Tinsa_Bas5_Update;

                            command.CommandText = sql;
                            command.Parameters.Add("CAR_REGION", cells["CAR_REGION"].Value?.ToString());
                            command.Parameters.Add("CAR_YYYYMM_F", DateValues(cells["CAR_YYYYMM_F"].Value?.ToString()));
                            command.Parameters.Add("CAR_YYYYMM_T", DateValues(cells["CAR_YYYYMM_T"].Value?.ToString()));
                            command.Parameters.Add("CAR_POS", cells["CAR_POS"].Value?.ToString());
                            command.Parameters.Add("CAR_DEPT", cells["CAR_DEPT"].Value?.ToString());
                            command.Parameters.Add("CAR_REASON", cells["CAR_REASON"].Value?.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "U");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.Parameters.Add("CAR_EMPNO", cells["CAR_EMPNO"].Value?.ToString());
                            command.Parameters.Add("CAR_COM", cells["CAR_COM"].Value?.ToString());

                            command.ExecuteNonQuery();

                            MessageBox.Show("완료");

                        }
                        cells["car_type"].Value = "Select";

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
            if (this.dataGridView2.SelectedRows.Count <= 0) return;
            var cells = this.dataGridView2.SelectedRows[0].Cells;
            if (cells["car_type"].Value.Equals("Select"))
            {
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand())
                    {
                        string sql = @" DELETE lmg_tinsa_car WHERE car_empno =:car_empno
                                        and car_com = :car_com";
                        command.Connection = connection;
                        command.Parameters.Add("car_empno", cells["car_empno"].Value.ToString());
                        command.Parameters.Add("car_com", cells["car_com"].Value.ToString());
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
    }
}
