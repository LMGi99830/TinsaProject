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

namespace LMGHRmanagement.CodeMenu
{
    public partial class BnkListForm : Form
    {
        private string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        
        public BnkListForm()
        {
            InitializeComponent();
            Bnk_Load();
        }

        public void Bnk_Load()
        {
            OracleConnection con = new OracleConnection(cs);
            con.Open();
            OracleDataAdapter adapt = new OracleDataAdapter("Select CD_CODE, CD_CODNM From LMG_TINSA_CD Where CD_CODNM Like '%" + textBox1.Text + "%' And CD_USE = 'Y' Order By CD_CODE", con);
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Bnk_Load();
                return;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            textBox1.Text = value1;

            this.Close();
        }
        public string _textBox1
        {
            get { return textBox1.Text.Trim(); }
        }

    }
}
