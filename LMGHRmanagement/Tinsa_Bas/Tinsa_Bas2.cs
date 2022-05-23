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
    public partial class Tinsa_Bas2 : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public Tinsa_Bas2()
        {
            InitializeComponent();

            #region 데이터그리드뷰2 초기화
            this.dataGridView2.Columns.Add("bas_empno", "사원번호");
            this.dataGridView2.Columns.Add("bas_name", "이름");

            #endregion

            #region 데이터그리드뷰1 초기화
            this.dataGridView1.Columns.Add("fam_type", "상태");
            this.dataGridView1.Columns.Add("fam_empno", "사원번호");
            this.dataGridView1.Columns.Add("fam_rel", "관계");
            this.dataGridView1.Columns.Add("fam_name", "성명");
            this.dataGridView1.Columns.Add("fam_bth", "생년월일");
            this.dataGridView1.Columns.Add("fam_ltg", "동거여부");
            #endregion

            #region 데이터그리드뷰2 더블클릭
            this.dataGridView2.CellDoubleClick += new DataGridViewCellEventHandler(this.DataGridViewCellDoubleClick);
            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 날짜 CustomFormat 변경
            this.fam_bth.GotFocus += new EventHandler(this.DateFormatChanged);
            #endregion

            #region 데이터그리드뷰랑 텍스트박스 연동
            fam_empno.TextChanged += new EventHandler(DataGridViewVandingEvent);
            fam_bth.TextChanged += new EventHandler(DataGridViewVandingEvent);
            fam_ltg.TextChanged += new EventHandler(DataGridViewVandingEvent);
            fam_name.TextChanged += new EventHandler(DataGridViewVandingEvent);
            fam_rel.TextChanged += new EventHandler(DataGridViewVandingEvent);
            #endregion

            #region 텍박 벨리데이션 체크
            fam_empno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            fam_bth.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            fam_ltg.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            fam_name.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            fam_rel.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion            

            #region 포커스
            fam_empno.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            fam_bth.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            fam_ltg.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            fam_name.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            fam_rel.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            #endregion
        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = this.dataGridView1.Rows[e.RowIndex];
            this.InsertDataGridViewRowValue(row);
            this.ValidationChecking(row);
        }

        private void TextBoxGotFoucsEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (!cells["fam_type"].Value.Equals("Select")) return;
            cells["fam_type"].Value = "Update";
        }

        public void ComboBoxClickEvent()
        {
            string sql = @"select cd_code, cd_codnms from lmg_tinsa_cd where cd_grpcd = 'FMI'";

            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    OracleDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (fam_rel.Items.Count <= 0)
                    {
                        while (rd.Read())
                        {
                            fam_rel.Items.Add(rd.GetString(0).ToString() + ":" + rd.GetString(1).ToString());
                        }
                    }
                }
            }
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
            Cells["fam_bth"].Value = DateValues(Cells["fam_bth"].Value?.ToString());
        }

        private void DateFormatChanged(object sender, EventArgs e)
        {
            fam_bth.CustomFormat = "yyyy-MM-dd";
        }

        private void DataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = dataGridView2.Rows[e.RowIndex];
            fam_empno.Text = this.dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            this.DataGridView1FormLoad();
        }

        private void DataGridView1FormLoad()
        {
            this.dataGridView1.Rows.Clear();
            ComboBoxClickEvent();
            string sql = SqlCommand.Tinsa_Bas2_Select;
            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add("fam_empno", dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView2SelectLoad(reader);
                }
            }
        }

        private void DataGridView2SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["fam_type"].Value = "Select";
            cells["fam_empno"].Value = reader["fam_empno"].ToString();
            cells["fam_rel"].Value = reader["cd_code"] + ":" + reader["cd_codnms"];
            cells["fam_name"].Value = reader["fam_name"].ToString();
            cells["fam_bth"].Value = reader["fam_bth"].ToString();
            cells["fam_ltg"].Value = reader["fam_ltg"].ToString();
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

        private void TextBoxValuesClear()
        {
            fam_empno.Text = "";
            fam_rel.Text = "";
            fam_name.Text = "";
            fam_ltg.Text = "";
            fam_bth.CustomFormat = " ";
        }

        private void DataGridViewSelectDataLoad(OracleDataReader reader)
        {
            var index = this.dataGridView2.Rows.Add();
            var cells = this.dataGridView2.Rows[index].Cells;

            cells["bas_empno"].Value = reader["bas_empno"].ToString();
            cells["bas_name"].Value = reader["bas_name"].ToString();
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
            fam_bth.Enabled = true;
            fam_empno.Enabled = true;
            fam_ltg.Enabled = true;
            fam_name.Enabled = true;
            fam_rel.Enabled = true;
        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            int RowCount = dataGridView1.Rows.Count;
            var index = this.dataGridView1.Rows.Add();
            var row = this.dataGridView1.Rows[index];
            var cells = row.Cells;

            cells["fam_type"].Value = "Insert";
            cells["fam_empno"].Value = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            dataGridView1.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView1.Rows[index]);
            this.ValidationChecking(row);
        }

        private void ValidationChecking(DataGridViewRow row)
        {
            //if (string.IsNullOrEmpty(fam_rel.Text.Trim())) { this.SetError(row, this.fam_rel, "관계를 선택해주세요"); return; }
            if (string.IsNullOrEmpty(fam_name.Text.Trim())) { this.SetError(row, this.fam_name, "이름이 빈칸입니다."); return; }
            //if (string.IsNullOrEmpty(fam_bth.Text.Trim())) { this.SetError(row, this.fam_rel, "날짜를 선택해주세요"); return; }
            if (string.IsNullOrEmpty(fam_ltg.Text.Trim())) { this.SetError(row, this.fam_ltg, "동거여부를 선택해주세요"); return; }
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
            fam_bth.CustomFormat = "yyyy-MM-dd";
            this.fam_empno.Text = cells["fam_empno"].Value?.ToString();
            this.fam_rel.Text = cells["fam_rel"].Value?.ToString();
            this.fam_name.Text = cells["fam_name"].Value?.ToString();
            this.fam_ltg.Text = cells["fam_ltg"].Value?.ToString();

            DateTime value;
            if (string.IsNullOrEmpty(cells["fam_bth"].Value?.ToString()))
            {
                cells["fam_bth"].Value = "";
                return;
            }
            DateTime.TryParseExact(cells["fam_bth"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value);
            this.fam_bth.Value = value;

            
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

                        if (cells["fam_type"].Value.Equals("Insert"))
                        {
                            string sql = SqlCommand.Tinsa_Bas2_Insert;

                            command.CommandText = sql;
                            command.Parameters.Add("fam_rel", cells["fam_rel"].Value.ToString().Substring(0, 2));
                            command.Parameters.Add("fam_name", cells["fam_name"].Value?.ToString());
                            command.Parameters.Add("fam_bth", DateValues(cells["fam_bth"].Value?.ToString()));
                            command.Parameters.Add("fam_ltg", cells["fam_ltg"].Value?.ToString());
                            command.Parameters.Add("fam_empno", cells["fam_empno"].Value.ToString());
                            command.Parameters.Add("datesys1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("datesys2", "A");
                            command.Parameters.Add("datesys3", "MinGi");
                            command.ExecuteNonQuery();
                        }
                        if (cells["fam_type"].Value.Equals("Update"))
                        {
                            string sql = SqlCommand.Tinsa_Bas2_Update;
                            command.CommandText = sql;
                            command.Parameters.Add("fam_bth", DateValues(cells["fam_bth"].Value?.ToString()));
                            command.Parameters.Add("fam_ltg", cells["fam_ltg"].Value?.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "U");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.Parameters.Add("fam_empno", cells["fam_empno"].Value.ToString());
                            command.Parameters.Add("fam_rel", cells["fam_rel"].Value.ToString().Substring(0, 2));
                            command.Parameters.Add("fam_name", cells["fam_name"].Value?.ToString());

                            command.ExecuteNonQuery();
                            MessageBox.Show("저장 완료");
                        }
                        cells["fam_type"].Value = "Select";
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
            if (cells["fam_type"].Value.Equals("Select"))
            {
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand())
                    {
                        string sql = @" DELETE lmg_tinsa_fam WHERE fam_empno =:fam_empno
                                        and fam_rel = :fam_rel and fam_name = :fam_name";
                        command.Connection = connection;
                        command.Parameters.Add("fam_empno", cells["fam_empno"].Value.ToString());
                        command.Parameters.Add("fam_rel", cells["fam_rel"].Value.ToString());
                        command.Parameters.Add("fam_name", cells["fam_name"].Value.ToString());
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

