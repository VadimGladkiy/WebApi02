namespace WebApi02.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [ForeignKey("User_fk_toEmp")]
        public int User_PK_FK_Id { set; get; }
        
        public Employee User_fk_toEmp{ get; set; }

        //
        [Required]
        [StringLength(30)]
        public string username { get; set; }

        [Required]
        [StringLength(10)]
        public string password { get; set; }

    }
}
