namespace WebApi02.DataModel
{
    using System;
    using System.Data.Entity;

    public class ModFromCode : DbContext
    {
        // Your context has been configured to use a 'ModFromCode' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApi02.ModFromCode' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModFromCode' 
        // connection string in the application configuration file.
        public ModFromCode()
            : base("name=ModFromCode")
        {
        }

            public virtual DbSet<Customer> Customers { get; set; }
            public virtual DbSet<Employee> Employees { get; set; }
       
    }


}