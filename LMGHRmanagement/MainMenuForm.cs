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
            Tinsa_Bas1 tbf = new Tinsa_Bas1();
            this.pannelStyledChange(tbf);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Tinsa_Bas2 tbf = new Tinsa_Bas2();
            this.pannelStyledChange(tbf);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tinsa_Bas3 tbf = new Tinsa_Bas3();
            this.pannelStyledChange(tbf);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Tinsa_Bas5 tbf = new Tinsa_Bas5();
            this.pannelStyledChange(tbf);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tinsa_Bas4 tbf = new Tinsa_Bas4();
            this.pannelStyledChange(tbf);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Tinsa_Bas6 tbf = new Tinsa_Bas6();
            this.pannelStyledChange(tbf);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Tinsa_Bas7 tbf = new Tinsa_Bas7();
            this.pannelStyledChange(tbf);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Tinsa_Bas8 tbf = new Tinsa_Bas8();
            this.pannelStyledChange(tbf);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            TInsa_Code1 tbf = new TInsa_Code1();
            this.pannelStyledChange(tbf);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            TInsa_Code2 tbf = new TInsa_Code2();
            this.pannelStyledChange(tbf);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Tinsa_Issued2 tbf = new Tinsa_Issued2();
            this.pannelStyledChange(tbf);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Tinsa_Issued1 tbf = new Tinsa_Issued1();
            this.pannelStyledChange(tbf);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Tinsa_Issued3 tbf = new Tinsa_Issued3();
            this.pannelStyledChange(tbf);
        }
      
        private void button20_Click(object sender, EventArgs e)
        {
            Tinsa_Total1 tbf = new Tinsa_Total1();
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
            Tinsa_Total4 tbf = new Tinsa_Total4();
            this.pannelStyledChange(tbf);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Tinsa_Total3 tbf = new Tinsa_Total3();
            this.pannelStyledChange(tbf);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Tinsa_Total5 tbf = new Tinsa_Total5();
            this.pannelStyledChange(tbf);
        }
        private void button21_Click(object sender, EventArgs e)
        {
            Tinsa_Total2 tbf = new Tinsa_Total2();
            this.pannelStyledChange(tbf);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Tinsa_Coe1 tbf = new Tinsa_Coe1();
            this.pannelStyledChange(tbf);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Tinsa_Coe2 tbf = new Tinsa_Coe2();
            this.pannelStyledChange(tbf);
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            Tinsa_Coe4 tbf = new Tinsa_Coe4();
            this.pannelStyledChange(tbf);
        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            TInsa_Code3 tbf = new TInsa_Code3();
            this.pannelStyledChange(tbf);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            


            //GetType().GetMethod("Data_Load");
        }
    }
}
