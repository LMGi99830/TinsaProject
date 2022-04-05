using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMGHRmanagement
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            menubar();
        }
        private void menubar()
        {
            this.MenuPannelStateChange(VisibleState.hidden);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.MenuPannelStateChange(VisibleState.visible);
                return;
            }
            this.MenuPannelStateChange(VisibleState.hidden);
        }
        public static class  VisibleState
        {
            public static bool hidden = false;
            public static bool visible = true;
        }
        private void MenuPannelStateChange(bool visibleState)
        {
            panel4.Visible = visibleState;
            panel5.Visible = visibleState;
            panel6.Visible = visibleState;
            panel7.Visible = visibleState;
            panel8.Visible = visibleState;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.PanelVisibleChanged(panel4);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.PanelVisibleChanged(panel5);
        }

        private void PanelVisibleChanged(Panel panel)
        {
            if (panel.Visible)
            {
                panel.Visible = false;
                return;
            }
            panel.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.PanelVisibleChanged(panel6);

        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.PanelVisibleChanged(panel7);

        }

        private void button30_Click(object sender, EventArgs e)
        {
            this.PanelVisibleChanged(panel8);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tinsa_Bas_Form tbf = new Tinsa_Bas_Form();
            this.pannelStyledChange(tbf);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Tinsa_Fam_Form tbf = new Tinsa_Fam_Form();
            this.pannelStyledChange(tbf);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tinsa_Edu_Form tbf = new Tinsa_Edu_Form();
            this.pannelStyledChange(tbf);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Tinsa_Car_Form tbf = new Tinsa_Car_Form();
            this.pannelStyledChange(tbf);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tinsa_Award_Form tbf = new Tinsa_Award_Form();
            this.pannelStyledChange(tbf);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Tinsa_Lic_Form tbf = new Tinsa_Lic_Form();
            this.pannelStyledChange(tbf);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Tinsa_Forl_Form tbf = new Tinsa_Forl_Form();
            this.pannelStyledChange(tbf);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Tinsa_Search_Form tbf = new Tinsa_Search_Form();
            this.pannelStyledChange(tbf);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            TInsa_GroupCode_Form tbf = new TInsa_GroupCode_Form();
            this.pannelStyledChange(tbf);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Tinsa_Code_Form tbf = new Tinsa_Code_Form();
            this.pannelStyledChange(tbf);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Tinsa_Issued_En_Form tbf = new Tinsa_Issued_En_Form();
            this.pannelStyledChange(tbf);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Tinsa_Issued_Form tbf = new Tinsa_Issued_Form();
            this.pannelStyledChange(tbf);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Tinsa_Issued_Search_Form tbf = new Tinsa_Issued_Search_Form();
            this.pannelStyledChange(tbf);
        }
      
        private void button20_Click(object sender, EventArgs e)
        {
            Tinsa_Dept_Total_Form tbf = new Tinsa_Dept_Total_Form();
            this.pannelStyledChange(tbf);
        }

        private void pannelStyledChange(Form tbf)
        {
            tbf.TopLevel = false;
            tbf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panel3.Controls.Clear();
            panel3.Controls.Add(tbf);
            tbf.Show();
            tbf.Dock = DockStyle.Fill;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Tinsa_Nopetc_Form tbf = new Tinsa_Nopetc_Form();
            this.pannelStyledChange(tbf);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Tinsa_Titnoe_Form tbf = new Tinsa_Titnoe_Form();
            this.pannelStyledChange(tbf);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Tinsa_Nopwr_Form tbf = new Tinsa_Nopwr_Form();
            this.pannelStyledChange(tbf);
        }
        private void button21_Click(object sender, EventArgs e)
        {
            Tinsa_Rank_Total_Form tbf = new Tinsa_Rank_Total_Form();
            this.pannelStyledChange(tbf);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Tinsa_Coe_Form tbf = new Tinsa_Coe_Form();
            this.pannelStyledChange(tbf);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Tinsa_Career_Certificate_Form tbf = new Tinsa_Career_Certificate_Form();
            this.pannelStyledChange(tbf);
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            Tinsa_Career_Total_Form tbf = new Tinsa_Career_Total_Form();
            this.pannelStyledChange(tbf);
        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            Tinsa_Dept_Form tbf = new Tinsa_Dept_Form();
            this.pannelStyledChange(tbf);
        }
    }
}
