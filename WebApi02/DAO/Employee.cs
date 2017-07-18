namespace WebApi02.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Emp_Id { get; set; }

        [Required(ErrorMessage = "The length must be little than 20 chars")]
        [StringLength(30)]
        public string first_name { get; set; }
        
        [Required(ErrorMessage ="the length must be little than 30 chars")]
        [StringLength(40)]
        public string last_name { get; set; }

        public string gender { get; set; }

        [Required(ErrorMessage = "the type of numbers must be double")]
        public decimal salary { get; set; }
       
    }
}
