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
    public partial class Tinsa_Issued1 : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public Tinsa_Issued1()
        {
            InitializeComponent();

            #region 인사발령대장조회
            this.dataGridView1.Columns.Add("papr_type", "상태");
            this.dataGridView1.Columns.Add("papr_appno", "인사발령번호");
            this.dataGridView1.Columns.Add("papr_date", "시행일자");
            this.dataGridView1.Columns.Add("papr_content", "발령내용");
            this.dataGridView1.Columns.Add("papr_num", "발령인원수");
            #endregion

            #region 텍박 벨리데이션 체크
            papr_appno.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papr_date.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papr_content.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            papr_num.LostFocus += new EventHandler(LostFocusTextBoxValidationChecking);
            #endregion            

            #region 데이터그리드뷰랑 텍스트박스 연동
            papr_appno.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papr_date.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papr_content.TextChanged += new EventHandler(DataGridViewVandingEvent);
            papr_num.TextChanged += new EventHandler(DataGridViewVandingEvent);
            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 포커스
            papr_appno.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            papr_date.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            papr_content.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            papr_num.GotFocus += new EventHandler(TextBoxGotFoucsEvent);
            #endregion


        }

        private void TextBoxGotFoucsEvent(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (!cells["papr_type"].Value.Equals("Select")) return;
            cells["papr_type"].Value = "Update";
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
            Cells["papr_date"].Value = DateValues(Cells["papr_date"].Value?.ToString());
        }

        private object DateValues(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                return v = "";
            }
            return v.Replace("-", string.Empty);
        }

        private void LostFocusTextBoxValidationChecking(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var row = this.dataGridView1.SelectedRows[0];
            ValidationChecking(row);
        }

        private void DataLoadBtn_Click(object sender, EventArgs e)
        {
            //new Oracleparameter("parameter", $"%{parameter}%");
            this.dataGridView1.Rows.Clear();
            TextBoxValuesClear();
            string sql = SqlCommand.Tinsa_Issued1_Select;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                MessageBox.Show(search_papr_date.Text.ToString());
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("papr_appno", $"%{search_papr_appno.Text}%");
                    command.Parameters.Add("papr_date", $"%{DateValues(search_papr_date.Text.ToString())}%");
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridViewSelectDataLoad(reader);
                }
            }
        }

        private void DataGridViewSelectDataLoad(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["papr_type"].Value = "Select";
            cells["papr_appno"].Value = reader["papr_appno"].ToString();
            cells["papr_date"].Value = reader["papr_date"].ToString();
            cells["papr_content"].Value = reader["papr_content"].ToString();
            cells["papr_num"].Value = reader["papr_num"].ToString();
        }

        private void TextBoxValuesClear()
        {
            papr_appno.Text = string.Empty;
            papr_date.CustomFormat = " ";
            papr_content.Text = string.Empty;
            papr_num.Text = string.Empty;

        }

        private void DataInsertBtn_Click(object sender, EventArgs e)
        {
            int RowCount = dataGridView1.Rows.Count;
            var index = this.dataGridView1.Rows.Add();
            var row = this.dataGridView1.Rows[index];
            var cells = row.Cells;

            cells["papr_type"].Value = "Insert";
            dataGridView1.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView1.Rows[index]);
            this.ValidationChecking(row);
        }

        private void ValidationChecking(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(papr_appno.Text.Trim())) { this.SetError(row, this.papr_appno, "인사발령번호가 빈칸입니다."); return; }
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
            papr_date.CustomFormat = "yyyy-MM-dd";
            this.papr_appno.Text = cells["papr_appno"].Value?.ToString();
            this.papr_content.Text = cells["papr_content"].Value?.ToString();
            this.papr_num.Text = cells["papr_num"].Value?.ToString();

            DateTime value;
            if (string.IsNullOrEmpty(cells["papr_date"].Value?.ToString()))
            {
                cells["papr_date"].Value = "";
                return;
            }
            DateTime.TryParseExact(cells["papr_date"].Value?.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out value);
            this.papr_date.Value = value;
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

                        if (cells["papr_type"].Value.Equals("Insert"))
                        {
                            string sql = SqlCommand.Tinsa_Issued1_Insert;

                            command.CommandText = sql;
                            command.Parameters.Add("papr_appno", cells["papr_appno"].Value.ToString());
                            command.Parameters.Add("papr_date", DateValues(cells["papr_date"].Value?.ToString()));
                            command.Parameters.Add("papr_content", cells["papr_content"].Value.ToString());
                            command.Parameters.Add("papr_num", cells["papr_num"].Value.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "A");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.ExecuteNonQuery();
                        }
                        if (cells["papr_type"].Value.Equals("Update"))
                        {
                            string sql = SqlCommand.Tinsa_Issued1_Update;

                            command.CommandText = sql;
                            command.Parameters.Add("papr_content", cells["papr_content"].Value.ToString());
                            command.Parameters.Add("papr_num", cells["papr_num"].Value.ToString());
                            command.Parameters.Add("DATASYS1", DateTime.Now.ToString("yyyy-MM-dd"));
                            command.Parameters.Add("DATASYS2", "U");
                            command.Parameters.Add("DATASYS3", "MinGi");
                            command.Parameters.Add("papr_appno", cells["papr_appno"].Value.ToString());
                            command.Parameters.Add("papr_date", DateValues(cells["papr_date"].Value?.ToString()));
                            command.ExecuteNonQuery();
                        }
                        cells["papr_type"].Value = "Select";

                    }
                }
                MessageBox.Show("저장 완료");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
