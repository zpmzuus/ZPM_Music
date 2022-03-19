using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZPM_Music
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin formLogin = new FormLogin();

            if (DialogResult.OK == formLogin.ShowDialog())
            {
                Application.Run(new Form1Main() { user = formLogin.userLogin });
            }
            else
            {
                return;
            }
        }
    }
}
