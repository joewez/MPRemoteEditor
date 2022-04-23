using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPRemoteEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MPRemoteRoutines mPRemoteRoutines = new MPRemoteRoutines();
            while (mPRemoteRoutines.COMM_PORT == "")
            {
                MessageBox.Show("Must select the COM port your device is on.");
                mPRemoteRoutines = new MPRemoteRoutines();
            }

            if (mPRemoteRoutines.COMM_PORT != "EXIT")
                Application.Run(new frmMain(mPRemoteRoutines));
        }
    }
}
