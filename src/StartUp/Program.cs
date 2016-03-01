using NIS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartUp
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
            
            // Define the parameters of your database
            NISContext.SetDataBaseOptions("localhost", "root", "", "dbSuperTest");
            
            // Run this test to see if it works! 
            var x = MyContext.db.Settings.ToList();

            // If the form opens, it works! Check your database to see if dbSuperTest has been created!
            Application.Run(new Form1());
        }
    }
}
