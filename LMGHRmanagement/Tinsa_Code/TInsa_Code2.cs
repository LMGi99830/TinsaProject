using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Oracle.ManagedDataAccess.Client;

namespace LMGHRmanagement
{
    public partial class TInsa_Code2 : Form
    {
        private string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        public TInsa_Code2()
        {
            InitializeComponent();

            #region 그룹코드테이블
            this.dataGridView1.Columns.Add("cdg_grpcd", "그룹코드");
            this.dataGridView1.Columns.Add("cdg_grpnm", "그룹코드명");
            #endregion

            #region 코드테이블
            this.dataGridView2.Columns.Add("cd_type", "상태");
            this.dataGridView2.Columns.Add("cd_grpcd", "그룹코드");
            this.dataGridView2.Columns.Add("cd_code", "코드");
            this.dataGridView2.Columns.Add("cd_seq", "코드 Seq");
            this.dataGridView2.Columns.Add("cd_codnms", "코드명(축약)");
            this.dataGridView2.Columns.Add("cd_codnm", "코드명(원형)");
            this.dataGridView2.Columns.Add("cd_addinfo", "추가정보");
            this.dataGridView2.Columns.Add("cd_upper", "상위분류");
            this.dataGridView2.Columns.Add("cd_use", "사용여부");
            this.dataGridView2.Columns.Add("cd_sdate", "생성일자");
            this.dataGridView2.Columns.Add("cd_edate", "폐기일자");
            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.DataGridViewCellDoubleClick);
            #endregion

            #region 데이터그리드뷰2 더블클릭
            this.dataGridView2.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 벨리데이션 체크
            cd_grpcd.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cd_code.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cd_seq.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cd_codnms.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cd_codnm.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cd_addinfo.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cd_upper.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cd_use.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cd_sdate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            cd_edate.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion

            #region 연동
            cd_grpcd.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cd_code.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cd_seq.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cd_codnms.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cd_codnm.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cd_addinfo.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cd_upper.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cd_use.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cd_sdate.TextChanged += new EventHandler(DataGridViewVandingEvent);
            cd_edate.TextChanged += new EventHandler(DataGridViewVandingEvent);
            #endregion

            #region 포커스
            cd_grpcd.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cd_code.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cd_seq.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cd_codnms.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cd_codnm.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cd_addinfo.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cd_upper.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cd_use.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cd_sdate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            cd_edate.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            #endregion


        }

        private void TextBoxGotFoucsEvent(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count <= 0) return;
            cd_sdate.CustomFormat = "yyyy-MM-dd";
            var cells = this.dataGridView2.SelectedRows[0].Cells;
            if (!cells["cd_type"].Value.Equals("Select")) return;
            cells["cd_type"].Value = "Update";
        }

        private void DataGridViewVandingEvent(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count <= 0) return;
            var Cells = dataGridView2.SelectedRows[0].Cells;
            var TargetControl = sender as Control;
            Cells[TargetControl.Name].Value = TargetControl.Text;
            if (cd_use.Text.Equals("Y")) { cd_sdate.CustomFormat = "yyyy-MM-dd";  cd_sdate.Value = DateTime.Today; cd_edate.CustomFormat = " "; }
            else if (cd_use.Text.Equals("N")) { cd_sdate.CustomFormat = "yyyy-MM-dd"; cd_edate.CustomFormat = "yyyy-MM-dd"; cd_edate.Value = DateTime.Today; }
            else { cd_sdate.CustomFormat = " "; cd_edate.CustomFormat = " "; }
            if (cd_sdate.CustomFormat == " ") { Cells["cd_sdate"].Value = string.Empty; Cells["cd_edate"].Value = string.Empty; }
            else if (cd_sdate.CustomFormat == "yyyy-MM-dd") { Cells["cd_sdate"].Value = DateValues(cd_sdate.Value.ToString("yyyyMMdd")); Cells["cd_edate"].Value = string.Empty; }
            else { Cells["cd_edate"].Value = DateValues(cd_edate.Value.ToString("yyyyMMdd"));  }
            
            
            //Cells["cd_sdate"].Value = DateValues(Cells["cd_sdate"].Value?.ToString());
            //Cells["cd_edate"].Value = DateValues(Cells["cd_edate"].Value?.ToString());
        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            TextBoxStateChanged();
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
            DataDeleteBtn.Enabled = true;
            DataSaveBtn.Enabled = true;
            var row = dataGridView1.Rows[e.RowIndex];
            cd_grpcd.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.DataGridView1FormLoad();
        }

        private void DataGridView1FormLoad()
        {
            this.dataGridView2.Rows.Clear();
            //ComboBoxClickEvent();
            string sql = SqlCommand.Tinsa_Code2_Main_Search;
            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add("cdg_grpcd", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView2SelectLoad(reader);
                }
            }
        }

        private void TextBoxStateChanged()
        {
            cd_grpcd.Enabled = true;
            cd_code.Enabled = true;
            cd_seq.Enabled = true;
            cd_codnms.Enabled = true;
            cd_codnm.Enabled = true;
            cd_addinfo.Enabled = true;
            cd_upper.Enabled = true;
            cd_use.Enabled = true;
            cd_sdate.Enabled = true;
            cd_edate.Enabled = true;

        }

        private void DataGridView2SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView2.Rows.Add();
            var cells = this.dataGridView2.Rows[index].Cells;

            cells["cd_type"].Value = "Select";
            cells["cd_grpcd"].Value = reader["cd_grpcd"].ToString();
            cells["cd_code"].Value = reader["cd_code"].ToString();
            cells["cd_seq"].Value = reader["cd_seq"].ToString();
            cells["cd_codnms"].Value = reader["cd_codnms"].ToString();
            cells["cd_codnm"].Value = reader["cd_codnm"].ToString();
            cells["cd_addinfo"].Value = reader["cd_addinfo"].ToString();
            cells["cd_upper"].Value = reader["cd_upper"].ToString();
            if (reader["cd_use"].ToString() == null) { cells["cd_use"].Value = "선택"; }
            else { cells["cd_use"].Value = reader["cd_use"].ToString();  }
            cells["cd_sdate"].Value = reader["cd_sdate"].ToString();
            cells["cd_edate"].Value = reader["cd_edate"].ToString();

        }

        private void DataLoadBtn_Click(object sender, EventArgs e)
        {
            //new Oracleparameter("parameter", $"%{parameter}%");
            this.dataGridView1.Rows.Clear();
            this.dataGridView2.Rows.Clear();
            TextBoxValuesClear();
            string sql = SqlCommand.Tinsa_Code2_Search;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("cdg_grpnm", $"%{cdg_grpnm.Text}%");
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridViewSelectDataLoad(reader);
                }
            }
        }

        private void DataGridViewSelectDataLoad(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["cdg_grpcd"].Value = reader["cdg_grpcd"].ToString();
            cells["cdg_grpnm"].Value = reader["cdg_grpnm"].ToString();
        }

        private void TextBoxValuesClear()
        {
            
            cd_grpcd.Text = string.Empty;
            cd_code.Text = string.Empty;
            cd_seq.Value = 0;
            cd_seq.Text = string.Empty;
            cd_codnms.Text = string.Empty;
            cd_codnm.Text = string.Empty;
            cd_addinfo.Text = string.Empty;
            cd_upper.Text = string.Empty;
            cd_use.Text = "선택";
            cd_sdate.CustomFormat = " ";
            cd_edate.CustomFormat = " ";

        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            TextBoxStateChanged();
            cd_sdate.CustomFormat = " ";
            cd_edate.CustomFormat = " ";
            int RowCount = dataGridView2.Rows.Count;
            var index = this.dataGridView2.Rows.Add();
            var row = this.dataGridView2.Rows[index];
            var cells = row.Cells;
            cells["cd_type"].Value = "Insert";
            cells["cd_grpcd"].Value = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            dataGridView2.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView2.Rows[index]);
            this.ValidationChecking(row);

        }

        private void ValidationChecking(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(cd_code.Text.Trim())) { this.SetError(row, this.cd_code, "코드를 입력해주세요."); return; }
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
            string a = "선택";
            DateTime value;
            DateTime value1;

            cd_grpcd.Text = cells["cd_grpcd"].Value?.ToString();
            cd_code.Text = cells["cd_code"].Value?.ToString();
            cd_seq.Text = cells["cd_seq"].Value?.ToString();
            cd_codnms.Text = cells["cd_codnms"].Value?.ToString();
            cd_codnm.Text = cells["cd_codnm"].Value?.ToString();
            cd_addinfo.Text = cells["cd_addinfo"].Value?.ToString();
            cd_upper.Text = cells["cd_upper"].Value?.ToString();
            if (cells["cd_use"].Value?.ToString() == null) { cd_use.Text = a; return; }
            cd_use.Text = cells["cd_use"].Value?.ToString();

            if (string.IsNullOrEmpty(cells["cd_sdate"].Value?.ToString()))
            {
                cells["cd_sdate"].Value = "";
                return;
            }
            cd_sdate.CustomFormat = "yyyy-MM-dd";
            DateTime.TryParseExact(cells["cd_sdate"].Value.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value);
            this.cd_sdate.Value = value;

            if (string.IsNullOrEmpty(cells["cd_edate"].Value?.ToString()))
            {
                cells["cd_edate"].Value = "";
                return;
            }
            cd_edate.CustomFormat = "yyyy-MM-dd";
            DateTime.TryParseExact(cells["cd_edate"].Value.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value1);
            this.cd_edate.Value = value1;
        }

        private void DataDeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedRows.Count <= 0) return;
            var cells = this.dataGridView2.SelectedRows[0].Cells;
            if (cells["cd_type"].Value.Equals("Select"))
            {
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand())
                    {
                        string sql = @" DELETE lmg_tinsa_cd WHERE cd_grpcd =:cd_grpcd
                                        and cd_code = :cd_code";
                        command.Connection = connection;
                        command.Parameters.Add("cd_grpcd", cells["cd_grpcd"].Value.ToString());
                        command.Parameters.Add("cd_code", cells["cd_code"].Value.ToString());
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

                        if (cells["cd_type"].Value.Equals("Insert"))
                        {
                            string sql = SqlCommand.Tinsa_Code2_Insert;
                            command.CommandText = sql;
                            
                            command.Parameters.Add("CD_GRPCD", cells["CD_GRPCD"].Value?.ToString());
                            command.Parameters.Add("CD_CODE", cells["CD_CODE"].Value?.ToString());
                            command.Parameters.Add("CD_SEQ", cells["CD_SEQ"].Value?.ToString());
                            command.Parameters.Add("CD_CODNMS", cells["CD_CODNMS"].Value?.ToString());
                            command.Parameters.Add("CD_CODNM", cells["CD_CODNM"].Value?.ToString());
                            command.Parameters.Add("CD_ADDINFO", cells["CD_ADDINFO"].Value?.ToString());
                            command.Parameters.Add("CD_UPPER", cells["CD_UPPER"].Value?.ToString());
                            if (cells["CD_USE"].Value?.ToString() == null || cells["CD_USE"].Value?.ToString() == "선택")
                            { command.Parameters.Add("CD_USE", null); }
                            else {  command.Parameters.Add("CD_USE", cells["CD_USE"].Value.ToString()); }
                            command.Parameters.Add("CD_SDATE", DateValues(cells["CD_SDATE"].Value?.ToString()));
                            command.Parameters.Add("CD_EDATE", DateValues(cells["CD_EDATE"].Value?.ToString()));
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "A");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.ExecuteNonQuery();

                            MessageBox.Show("완료");
                        }
                        if (cells["cd_type"].Value.Equals("Update"))
                        {
                            string sql = SqlCommand.Tinsa_Code2_Update;

                            command.CommandText = sql;
                            command.Parameters.Add("CD_SEQ", cells["CD_SEQ"].Value?.ToString());
                            command.Parameters.Add("CD_CODNMS", cells["CD_CODNMS"].Value?.ToString());
                            command.Parameters.Add("CD_CODNM", cells["CD_CODNM"].Value?.ToString());
                            command.Parameters.Add("CD_ADDINFO", cells["CD_ADDINFO"].Value?.ToString());
                            command.Parameters.Add("CD_UPPER", cells["CD_UPPER"].Value?.ToString());
                            if (cells["CD_USE"].Value?.ToString() == null || cells["CD_USE"].Value?.ToString() == "선택")
                            { command.Parameters.Add("CD_USE", null); }
                            else { command.Parameters.Add("CD_USE", cells["CD_USE"].Value.ToString()); }
                            command.Parameters.Add("CD_SDATE", DateValues(cells["CD_SDATE"].Value?.ToString()));
                            command.Parameters.Add("CD_EDATE", DateValues(cells["CD_EDATE"].Value?.ToString()));
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "U");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.Parameters.Add("CD_GRPCD", cells["CD_GRPCD"].Value?.ToString());
                            command.Parameters.Add("CD_CODE", cells["CD_CODE"].Value?.ToString());
                            command.ExecuteNonQuery();
                            MessageBox.Show("완료");

                        }
                        cells["cd_type"].Value = "Select";

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
