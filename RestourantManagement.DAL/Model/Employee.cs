namespace RestourantManagement.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string fullName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dob { get; set; }

        public string education { get; set; }

        public string experience { get; set; }

        public string phoneNo { get; set; }

        public string addressEmp { get; set; }

        public string skills { get; set; }

        public string username { get; set; }

        public string empPassword { get; set; }

        public int? jobId { get; set; }

        public bool status { get; set; }

        public virtual Job Job { get; set; }
    }
}
