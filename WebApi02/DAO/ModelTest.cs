namespace WebApi02.DAO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelTest : DbContext
    {
        public ModelTest()
            : base("name=ModelTest")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
