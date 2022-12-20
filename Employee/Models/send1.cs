namespace Employee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class send1
    {
        public int id { get; set; }

        public int? EmpCode { get; set; }

        [StringLength(50)]
        public string EmpNane { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Dob { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Doj { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string Report_To { get; set; }

        public int? Contact_No { get; set; }

        [StringLength(50)]
        public string Resigned { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Resigned_Date { get; set; }
    }
}
