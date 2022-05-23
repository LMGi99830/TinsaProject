using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace LMGHRmanagement
{
    public partial class GroupCodeListForm : Form
    {
        private string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";
        public GroupCodeListForm()
        {
            InitializeComponent();
            GroupCode_Form_Load();
        }

        public void GroupCode_Form_Load()
        {
            OracleConnection con = new OracleConnection(cs);
            con.Open();
            OracleDataAdapter adapt = new OracleDataAdapter("Select CDG_GRPCD, CDG_GRPNM From LMG_TINSA_CDG Where CDG_GRPNM Like '%"+ textBox1.Text +"%' And CDG_USE = 'Y' Order By CDG_GRPCD", con);
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
                GroupCode_Form_Load();
                return;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string value1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            textBox1.Text = value1;

            this.Close();
        }

        public string _textBox1
        {
            get { return textBox1.Text.Trim(); }
        }
    }
}
