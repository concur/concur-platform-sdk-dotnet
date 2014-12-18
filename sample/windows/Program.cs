using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//------------------------------------
using Concur.Connect.V3;
using Concur.Connect.V3.Serializable;
using Concur.Connect.V1;
using Concur.Connect.V1.Serializable;
using Concur.Util;
using Concur.Authentication;
//------------------------------------

namespace ConcurPlatformSdkSample
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
            Application.Run(new MainForm());
        }


    }
}
