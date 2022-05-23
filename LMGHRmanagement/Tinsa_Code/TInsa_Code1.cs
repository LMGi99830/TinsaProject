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
    public partial class TInsa_Code1 : Form
    {
        private string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        public TInsa_Code1()
        {
            InitializeComponent();
            
            #region 그룹코드테이블
            this.dataGridView1.Columns.Add("cdg_type", "상태");
            this.dataGridView1.Columns.Add("cdg_grpcd", "그룹코드");
            this.dataGridView1.Columns.Add("cdg_grpnm", "그룹코드명");
            this.dataGridView1.Columns.Add("cdg_digit", "단위코드 자리수");
            this.dataGridView1.Columns.Add("cdg_length", "단위코드명(원형) 길이");
            this.dataGridView1.Columns.Add("cdg_use", "사용여부");
            this.dataGridView1.Columns.Add("cdg_kind", "분류");

            this.dataGridView1.Columns[3].Width = 120;
            this.dataGridView1.Columns[4].Width = 160;
            #endregion

            #region 데이터그리드뷰2 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 벨리데이션 체크
            cdg_grpcd.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cdg_grpnm.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cdg_digit.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cdg_length.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cdg_use.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cdg_kind.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion

            #region 연동
            cdg_grpcd.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cdg_grpnm.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cdg_digit.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cdg_length.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cdg_use.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cdg_kind.TextChanged += new EventHandler(DataGridViewVandingEvent);
            #endregion

            #region 포커스
            cdg_grpcd.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cdg_grpnm.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cdg_digit.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cdg_length.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cdg_use.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cdg_kind.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            #endregion

        }

        private void TextBoxGotFoucsEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (!cells["cdg_type"].Value.Equals("Select")) return;
            cells["cdg_type"].Value = "Update";
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
        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            TextBoxStateChanged();
            var row = this.dataGridView1.Rows[e.RowIndex];
            this.InsertDataGridViewRowValue(row);
            this.ValidationChecking(row);
        }

        private string GetUseCaseToDat(string useCase)
        {
            if (useCase.Equals("Y")) return "Y";
            return "N";
        }
        
        private void DataLoadBtn_Click(object sender, EventArgs e)
        {
            //new Oracleparameter("parameter", $"%{parameter}%");
            this.dataGridView1.Rows.Clear();
            this.DataDeleteBtn.Enabled = true;
            this.DataSaveBtn.Enabled = true;

            TextBoxValuesClear();
            string sql = SqlCommand.Tinsa_Code1_Search;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("cdg_grpcd", $"%{search_cdg_grpnm.Text}%");
                    if (search_cdg_use.Text == "선택") { command.Parameters.Add("cdg_use", $"%{null}%"); }
                    else { command.Parameters.Add("cdg_use", $"%{search_cdg_use.Text}%");  }
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridViewSelectDataLoad(reader);
                }
            }
        }

        private void DataGridViewSelectDataLoad(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["cdg_type"].Value = "Select";
            cells["cdg_grpcd"].Value = reader["cdg_grpcd"].ToString();
            cells["cdg_grpnm"].Value = reader["cdg_grpnm"].ToString();
            cells["cdg_digit"].Value = reader["cdg_digit"].ToString();
            cells["cdg_length"].Value = reader["cdg_length"].ToString();
            if (reader["cdg_use"].ToString() == null) { cells["cdg_use"].Value = "선택"; }
            else { cells["cdg_use"].Value = reader["cdg_use"].ToString(); }
            cells["cdg_kind"].Value = reader["cdg_kind"].ToString();
        }

        private void TextBoxValuesClear()
        {
            cdg_grpcd.Text = string.Empty;
            cdg_grpnm.Text = string.Empty;
            cdg_digit.Text = string.Empty;
            cdg_length.Text = string.Empty;
            cdg_use.Text = "선택";
            cdg_kind.Text = string.Empty;               
        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            TextBoxStateChanged();
            int RowCount = dataGridView1.Rows.Count;
            var index = this.dataGridView1.Rows.Add();
            var row = this.dataGridView1.Rows[index];
            var cells = row.Cells;
            cells["cdg_type"].Value = "Insert";
            dataGridView1.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView1.Rows[index]);
            this.ValidationChecking(row);
        }

        private void TextBoxStateChanged()
        {
            cdg_grpcd.Enabled = true;
            cdg_grpnm.Enabled = true;
            cdg_digit.Enabled = true;
            cdg_length.Enabled = true;
            cdg_use.Enabled = true;
            cdg_kind.Enabled = true;
        }

        private void ValidationChecking(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(cdg_grpcd.Text.Trim())) { this.SetError(row, this.cdg_grpcd, "그룹코드를 입력해주세요.");
                return; }
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

            cdg_grpcd.Text = cells["cdg_grpcd"].Value?.ToString();
            cdg_grpnm.Text = cells["cdg_grpnm"].Value?.ToString();
            cdg_digit.Text = cells["cdg_digit"].Value?.ToString();
            cdg_length.Text = cells["cdg_length"].Value?.ToString();
            if (cells["cdg_use"].Value?.ToString() == null) { cdg_use.Text = "선택"; return; }
            cdg_use.Text = cells["cdg_use"].Value?.ToString();
            cdg_kind.Text = cells["cdg_kind"].Value?.ToString();
        }

        private void DataDeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (cells["cdg_type"].Value.Equals("Select"))
            {
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand())
                    {
                        string sql = @" DELETE lmg_tinsa_cdg WHERE cdg_grpcd = :cdg_grpcd";
                        command.Connection = connection;
                        command.Parameters.Add("cd_grpcd", cells["cd_grpcd"].Value.ToString());
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
            DialogResult dialogResult = MessageBox.Show("정말 저장하시겠습니까?", "저장", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);
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

                        if (cells["cdg_type"].Value.Equals("Insert"))
                        {
                            string sql = SqlCommand.Tinsa_Code1_Insert;
                            command.CommandText = sql;

                            command.Parameters.Add("CDG_GRPCD", cells["CDG_GRPCD"].Value?.ToString());
                            command.Parameters.Add("CDG_GRPNM", cells["CDG_GRPNM"].Value?.ToString());
                            command.Parameters.Add("CDG_DIGIT", cells["CDG_DIGIT"].Value?.ToString());
                            command.Parameters.Add("CDG_LENGTH", cells["CDG_LENGTH"].Value?.ToString());
                            if (cells["CDG_USE"].Value?.ToString() == null || cells["CDG_USE"].Value?.ToString() == "선택")
                            { command.Parameters.Add("CDG_USE", null); }
                            else { command.Parameters.Add("CDG_USE", cells["CDG_USE"].Value.ToString()); }
                            command.Parameters.Add("CDG_KIND", cells["CDG_KIND"].Value?.ToString());
                            command.ExecuteNonQuery();

                            MessageBox.Show("완료");
                        }
                        if (cells["cdg_type"].Value.Equals("Update"))
                        {
                            string sql = SqlCommand.Tinsa_Code1_Update;

                            command.CommandText = sql;
                            command.Parameters.Add("CDG_GRPNM", cells["CDG_GRPNM"].Value?.ToString());
                            command.Parameters.Add("CDG_DIGIT", cells["CDG_DIGIT"].Value?.ToString());
                            command.Parameters.Add("CDG_LENGTH", cells["CDG_LENGTH"].Value?.ToString());
                            if (cells["CDG_USE"].Value?.ToString() == null || cells["CDG_USE"].Value?.ToString() == "선택")
                            { command.Parameters.Add("CDG_USE", null); }
                            else { command.Parameters.Add("CDG_USE", cells["CDG_USE"].Value.ToString()); }
                            command.Parameters.Add("CDG_KIND", cells["CDG_KIND"].Value?.ToString());
                            command.Parameters.Add("CDG_GRPCD", cells["CDG_GRPCD"].Value?.ToString());
                            command.ExecuteNonQuery();
                            MessageBox.Show("완료");

                        }
                        cells["cdg_type"].Value = "Select";

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
