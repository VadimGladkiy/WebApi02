namespace WebApi02.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [Key]
        [ForeignKey("Customer_fk_toEmp")]
        public int Cust_PK_FK_Id { set; get; }
        
        public Employee Customer_fk_toEmp{ get; set; }

        [Required]
        [StringLength(30)]
        public string username { get; set; }

        [Required]
        [StringLength(10)]
        public string password { get; set; }

        public Employee link_Cast { set; get; }
    }
}
