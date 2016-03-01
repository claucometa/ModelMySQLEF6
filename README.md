Code First + DDD + MySQL + EF6

This is what you gonna see in the main entrance Startup.Program. The code is self-explanatory.

    static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Define the parameters of your database
            NISContext.SetDataBaseOptions("localhost", "root", "", "dbSuperTest");
            
            // Run this test to see if it works! 
            var x = MyContext.db.Settings.ToList();

            // You can create a service by simply using crud
            var repo = new CrudRepo<NIS.Domain.Models.Setting>();
            x = repo.GetAll().ToList();

            // If the form opens, it works! Check your database to see if dbSuperTest has been created!
            Application.Run(new Form1());
        }
