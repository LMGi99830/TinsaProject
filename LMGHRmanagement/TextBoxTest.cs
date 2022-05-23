using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMGHRmanagement
{
    public partial class TextBoxTest : Form
    {
        public TextBoxTest()
        {
            InitializeComponent();
            dataGridView1.Rows[0].Selected = true;
        }

        public void asd(int a)
        {
            if (this.Controls["textBox" + a].Text == "")
            {
                return;
            }
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[i].Cells[0].Value = this.Controls["textBox" + a].Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            asd(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(groupBox1.Controls["textBox" + 1].Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = dateTimePicker1.Value.ToString("yyyyMMdd");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime datevalue;
            string year1 = textBox3.Text.Substring(0, 4);
            string month1 = textBox3.Text.Substring(4, 2);
            string day1 = textBox3.Text.Substring(6, 2);

            string date1 = year1 + "-" + month1 + "-" + day1;
            MessageBox.Show(date1);
            MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            DateTime.TryParseExact(date1, "yyyy-MM-dd", null, DateTimeStyles.None, out datevalue);
            dateTimePicker1.Value = datevalue;


        }
    }
}
