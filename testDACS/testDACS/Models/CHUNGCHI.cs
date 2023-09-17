namespace testDACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUNGCHI")]
    public partial class CHUNGCHI
    {
        [Key]
        [StringLength(10)]
        public string MACC { get; set; }

        [Required]
        [StringLength(64)]
        public string TENCC { get; set; }

        public int MAHV { get; set; }

        public int MAMH { get; set; }

        public virtual Du_thi Du_thi { get; set; }
    }
}
