using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMGHRmanagement
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TestSample());
            Application.Run(new MainMenuForm());
            //Application.Run(new TextBoxTest());
            //Application.Run(new Tinsa_Coe_Form());
        }
    }
}
