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
    public partial class MilListForm : Form
    {
        private string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public MilListForm()
        {
            InitializeComponent();
            Mil_Load();
        }

        public void Mil_Load()
        {
            OracleConnection con = new OracleConnection(cs);
            con.Open();
            OracleDataAdapter adapt = new OracleDataAdapter("Select CD_CODE, CD_CODNM From LMG_TINSA_CD Where CD_GRPCD = 'MIL'" +
                "AND CD_CODNM Like '%" + textBox1.Text + "%' And CD_USE = 'Y' Order By CD_CODE", con);
            DataTable datatable = new DataTable();
            adapt.Fill(datatable);
            dataGridView1.DataSource = datatable;
            con.Close();
            int RowCount = dataGridView1.Rows.Count;
            if (RowCount == 0)
            {
                MessageBox.Show("데이터가 존재하지 않습니다.");
                return;
            }
        }

        public string _textBox11
        {   
            get { return textBox1.Text.Trim(); }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = value1;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Mil_Load();
                return;
            }
        }
    }
}
