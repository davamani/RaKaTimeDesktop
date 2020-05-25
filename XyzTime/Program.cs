using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Automation;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Word;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;

namespace XyzTime
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

             Properties.Settings.Default.StoragePath = Application.UserAppDataPath;
  
            //setup local database in user desktop machine
            SqlLiteDb SLD = new SqlLiteDb();
            SLD.SetupDatabase();

            LoginForm LF = new LoginForm();
            //Form1 LF = new Form1();

            try
            {
               // LF.Show();
                Application.Run(LF);
            }
            catch (Exception ex) {
                MessageBox.Show("Program.cs  Exception:" + ex.Message);
            }

        }

 
    }

}
