using NIS.DataAccess;
using NIS.DataAccess.Repo;
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
            
            // Provide username and password of your database, and invent a database name as wish
            MyContext.Config("localhost", "root", "password", "dbSuperTest");
            
            // Run this test to see if it works! 
            var x = MyContext.db.Settings.ToList();

            // You can create a service by simply using crud
            var repo = new CrudRepo<NIS.Domain.Models.Setting>();
            x = repo.GetAll().ToList();

            // If the form opens, it works! Check your database to see if dbSuperTest has been created!
            Application.Run(new Form1());
        }
    }
}
