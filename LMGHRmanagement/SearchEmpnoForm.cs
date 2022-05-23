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
    public partial class SearchEmpnoForm : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public SearchEmpnoForm()
        {
            InitializeComponent();

            #region 인사기본사항(Grid1) 초기화
            this.dataGridView1.Columns.Add("bas_empno", "사원번호");
            this.dataGridView1.Columns.Add("bas_name", "이름");
            #endregion

            Search();

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion


        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = this.dataGridView1.Rows[e.RowIndex];
            this.InsertDataGridViewRowValue(row);
        }

        private void InsertDataGridViewRowValue(DataGridViewRow row)
        {
            var cells = row.Cells;
            this.search_bas_name.Text = cells["bas_empno"].Value?.ToString();

            this.Close();
        }

        public string _textBox1
        {
            get { return search_bas_name.Text.Trim(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {
            //new Oracleparameter("parameter", $"%{parameter}%");
            this.dataGridView1.Rows.Clear();
            string sql = SqlCommand.Tinsa_SearchEmpno1;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
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
    }
}
