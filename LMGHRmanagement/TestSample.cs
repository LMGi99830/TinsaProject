using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace LMGHRmanagement
{

    public partial class TestSample : Form
    {
        private SwitchProvider switcher;
        private string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        public TestSample()
        {
            InitializeComponent();
            #region 스위치 생성
            this.switcher = new SwitchProvider();
            #endregion
            #region 데이터그리드뷰 헤더 초기화
            this.dataGridView1.Columns.Add("division", "상태");
            var index = this.dataGridView1.Columns.Add("bas_empno_cp", "*");
            this.dataGridView1.Columns[index].Visible = false;
            this.dataGridView1.Columns.Add("bas_empno", "사원번호");
            this.dataGridView1.Columns.Add("bas_resno", "주민등록번호");
            this.dataGridView1.Columns.Add("bas_name", "성명(한글)");
            this.dataGridView1.Columns.Add("bas_cname", "성명(한자)");
            this.dataGridView1.Columns.Add("bas_ename", "성명(영문)");
            #endregion
            #region 데이터그리드뷰 셀 더블 클릭 이벤트
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.DoubleClickCell);
            #endregion
            #region 데이터그리드뷰 셀렉션 체인지 이벤트
            this.dataGridView1.SelectionChanged += new EventHandler(this.DataGridViewSelectionChanged);
            #endregion
            #region 텍스트박스랑 데이트그리드뷰 연동
            bas_empno.TextChanged += new EventHandler(this.TextChangedToDataGridViewRowCell);
            bas_resno.TextChanged += new EventHandler(this.TextChangedToDataGridViewRowCell);
            bas_name.TextChanged += new EventHandler(this.TextChangedToDataGridViewRowCell);
            bas_cname.TextChanged += new EventHandler(this.TextChangedToDataGridViewRowCell);
            bas_ename.TextChanged += new EventHandler(this.TextChangedToDataGridViewRowCell);
            #endregion
            #region 텍스트박스 벨리데이션 체크
            bas_empno.LostFocus += new EventHandler(this.LeaveFocusAfterValidationControl);
            bas_resno.LostFocus += new EventHandler(this.LeaveFocusAfterValidationControl);
            bas_name.LostFocus += new EventHandler(this.LeaveFocusAfterValidationControl);
            bas_cname.LostFocus += new EventHandler(this.LeaveFocusAfterValidationControl);
            bas_ename.LostFocus += new EventHandler(this.LeaveFocusAfterValidationControl);
            #endregion
            #region 텍스트 박스 포커스 
            bas_empno.GotFocus += new EventHandler(this.GotFocusAfterChangeDivisionType);
            bas_resno.GotFocus += new EventHandler(this.GotFocusAfterChangeDivisionType);
            bas_name.GotFocus += new EventHandler(this.GotFocusAfterChangeDivisionType);
            bas_cname.GotFocus += new EventHandler(this.GotFocusAfterChangeDivisionType);
            bas_ename.GotFocus += new EventHandler(this.GotFocusAfterChangeDivisionType);
            #endregion
        }

        private void GotFocusAfterChangeDivisionType(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (!cells["division"].Value.Equals("SELECT")) return;
            cells["division"].Value = "UPDATE";
        }

        private void DataGridViewSelectionChanged(object sender, EventArgs e)
        {
            this.switcher.Off();
            this.bas_empno.Text = string.Empty;
            this.bas_resno.Text = string.Empty;
            this.bas_name.Text = string.Empty;
            this.bas_cname.Text = string.Empty;
            this.bas_ename.Text = string.Empty;
        }

        private void DoubleClickCell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            this.switcher.On();
            var row = this.dataGridView1.Rows[e.RowIndex];
            this.InsertDataGridViewRowValue(row);
            this.ValidationRules(row);
        }

        private void LeaveFocusAfterValidationControl(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var row = this.dataGridView1.SelectedRows[0];
            ValidationRules(row);
        }

        private void ValidationRules(DataGridViewRow row)
        {
            if (string.IsNullOrEmpty(bas_empno.Text.Trim())) { this.SetError(row, this.bas_empno, "사원번호 빈칸입니다."); return; }
            if (string.IsNullOrEmpty(bas_resno.Text.Trim())) { this.SetError(row, this.bas_resno, "주민등록번호 빈칸입니다."); return; }
            if (string.IsNullOrEmpty(bas_name.Text.Trim())) { this.SetError(row, this.bas_name, "성명(한글) 빈칸입니다."); return; }
            this.errorProvider1.Clear();
            row.ErrorText = string.Empty;
        }

        #region ErrorProvider 유틸리티 함수
        private void SetError(DataGridViewRow row, Control control, string errorText)
        {
            this.errorProvider1.Clear();
            row.ErrorText = errorText;
            this.errorProvider1.SetError(control, errorText);
        }

        #endregion

        #region 데이터그리드뷰 와 텍스트박스를 연동해주는 함수임
        private void TextChangedToDataGridViewRowCell(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            if (this.switcher.IsOff()) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            var targetControl = sender as Control;
            cells[targetControl.Name].Value = targetControl.Text;
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            var index = this.dataGridView1.Rows.Add();
            var row = this.dataGridView1.Rows[index];
            var cells = row.Cells;
            cells["division"].Value = "INSERT";
            this.dataGridView1.ClearSelection();
            row.Selected = true;
            this.InsertDataGridViewRowValue(this.dataGridView1.Rows[index]);
            this.ValidationRules(row);
        }

        private void InsertDataGridViewRowValue(DataGridViewRow dataGridViewRow)
        {
            var cells = dataGridViewRow.Cells;
            this.bas_empno.Text = cells["bas_empno"].Value?.ToString();
            this.bas_resno.Text = cells["bas_resno"].Value?.ToString();
            this.bas_name.Text = cells["bas_name"].Value?.ToString();
            this.bas_cname.Text = cells["bas_cname"].Value?.ToString();
            this.bas_ename.Text = cells["bas_ename"].Value?.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var cells = this.dataGridView1.SelectedRows[0].Cells;
            if (cells["division"].Value.Equals("SELECT"))
            {
                using (OracleConnection connection = new OracleConnection(cs))
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand())
                    {
                        string sql = @"DELETE P22_LMG_SAMPLE WHERE BAS_EMPNO =:BAS_EMPNO";
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

        #region 조회
        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM P22_LMG_SAMPLE";
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;

                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) InsertSelectedDataToDataGridViewRow(reader);
                }
            }

        }
        private void InsertSelectedDataToDataGridViewRow(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;
            cells["division"].Value = "SELECT";
            cells["bas_empno_cp"].Value = reader["bas_empno"].ToString();
            cells["bas_empno"].Value = reader["bas_empno"].ToString();
            cells["bas_resno"].Value = reader["bas_resno"].ToString();
            cells["bas_name"].Value = reader["bas_name"].ToString();
            cells["bas_cname"].Value = reader["bas_cname"].ToString();
            cells["bas_ename"].Value = reader["bas_ename"].ToString();
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (!string.IsNullOrEmpty(row.ErrorText))
                {
                    MessageBox.Show("멈춰!");
                    this.dataGridView1.ClearSelection();
                    row.Selected = true;
                    this.InsertDataGridViewRowValue(row);
                    this.ValidationRules(row);
                    return;
                }
            }


            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                try
                {
                    var cells = row.Cells;
                    ProcessInsertAndUpdateData(cells);
                    continue;
                }
                catch (OracleException oracleException)
                {
                    if (oracleException.Number == 1)
                    {
                        MessageBox.Show("중복띠~");
                    }
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

        private void ProcessInsertAndUpdateData(DataGridViewCellCollection cells)
        {
            using (var connection = new OracleConnection(cs))
            {
                connection.Open();
                using (var command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.Prepare();
                    command.BindByName = true;
                    command.Parameters.Add("bas_empno", cells["bas_empno"].Value.ToString());
                    command.Parameters.Add("bas_resno", cells["bas_resno"].Value.ToString());
                    command.Parameters.Add("bas_name", cells["bas_name"].Value.ToString());
                    command.Parameters.Add("bas_cname", cells["bas_cname"].Value.ToString());
                    command.Parameters.Add("bas_ename", cells["bas_ename"].Value.ToString());
                    if (cells["division"].Value.Equals("INSERT"))
                    {
                        string sql = @"
                            INSERT INTO P22_LMG_SAMPLE (bas_empno, bas_resno, bas_name, bas_cname, bas_ename) 
                            VALUES  ( :bas_empno,:bas_resno,:bas_name,:bas_cname,:bas_ename)";
                        command.CommandText = sql;
                        command.ExecuteNonQuery();

                    }
                    if (cells["division"].Value.Equals("UPDATE"))
                    {
                        string sql = @"UPDATE P22_LMG_SAMPLE
                                SET
                                BAS_EMPNO =: BAS_EMPNO, 
                                BAS_RESNO =: BAS_RESNO, 
                                BAS_NAME =: BAS_NAME, 
                                BAS_CNAME =: BAS_CNAME, 
                                BAS_ENAME =: BAS_ENAME
                                WHERE BAS_EMPNO =: BAS_EMPNO_CP";
                        command.Parameters.Add("bas_empno_cp", cells["bas_empno_cp"].Value.ToString());
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }
                    cells["division"].Value = "SELECT";
                    cells["bas_empno_cp"].Value = cells["bas_empno"].Value;
                }
            }
        }
    }
    public class SwitchProvider
    {
        private bool switched;
        public SwitchProvider()
        {
            this.switched = false;
        }
        public void Off()
        {
            this.switched = false;
        }
        public void On()
        {
            this.switched = true;
        }
        public bool IsOn()
        {
            return this.switched;
        }
        public bool IsOff()
        {
            return !this.switched;
        }
    }
}
